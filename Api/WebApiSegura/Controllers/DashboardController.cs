﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Proyecto1.DataRequest;

namespace Proyecto1.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    /// 

    [AllowAnonymous]
    [RoutePrefix("api/Dashboard")]
        /*
         * En este archivo se manejaran los datos de promedios, regionales, correo y pdf
         */
    public class DashboardController : ApiController
    {
        
        //Devuelve cantidad de dispositvos gestionados, el nuemro de dispositvios promedio por usuario,el numero de dispositivos ubicados por continente y una lsita de todos los 
        //dispositivos en el sistema
        [HttpGet]
        [Route("All")]
        public IHttpActionResult DispositivosGestionados()
        {
            //Saca dispositivos gestionados
            Dashboard dash = new Dashboard();
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_Activo();
            dash.DispositivosGestionados = tbuser.Rows.Count;
            
            //  Saca un promedio de dispositivos por usuario
            DataTable tbuser3 = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            float uno = tbuser3.Rows.Count;
            float dos = tbuser2.Rows.Count;
            float Promedio = uno / dos;
            dash.Promedio = Promedio;
            
        
            DataTable tbuser4 = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_XRegion();
            int america=0, europa=0, asia=0, oceania=0, africa=0,x=0;
            
            while (x < tbuser.Rows.Count) {
                if (tbuser4.Rows[x]["Continente"].ToString() == "America") { america++; }
                if (tbuser4.Rows[x]["Continente"].ToString() == "Europa") { europa++; }
                if (tbuser4.Rows[x]["Continente"].ToString() == "Asia") { asia++; }
                if (tbuser4.Rows[x]["Continente"].ToString() == "Africa") { africa++; }
                if (tbuser4.Rows[x]["Continente"].ToString() == "Oceania") { oceania++; }
                x++;
            }

            dash.America = america;
            dash.Africa = africa;
            dash.Asia = asia;
            dash.Europa = europa;
            dash.Oceania = oceania;




            DataTable tbuser5 = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            int i = 0;
            List<Dispositivo> lista = new List<Dispositivo> { };
            while (i < tbuser5.Rows.Count) {
                Dispositivo disp = new Dispositivo();
                disp.Serie = (int)tbuser5.Rows[i]["Serie"];
                disp.Nombre = tbuser5.Rows[i]["Nombre"].ToString();
                disp.Activo = Convert.ToBoolean(tbuser5.Rows[i]["Activo"]);
                disp.AgregadoPor = tbuser5.Rows[i]["AgregadoPor"].ToString();
                disp.Aposento = tbuser5.Rows[i]["Aposento"].ToString();
                disp.Consumo_Electrico = (int)tbuser5.Rows[i]["Consumo_Electrico"];
                disp.Decripcion = tbuser5.Rows[i]["Descripcion"].ToString();
                disp.Distribuidor = tbuser5.Rows[i]["Distribuidor"].ToString();
                disp.Dueno = tbuser5.Rows[i]["Dueno"].ToString();
                disp.Historial_Duenos = tbuser5.Rows[i]["Historial_Duenos"].ToString();
                disp.Marca = tbuser5.Rows[i]["Marca"].ToString();
                disp.Tiempo_Garantia = (int)tbuser5.Rows[i]["Tiempo_Garantia"];
                disp.Precio = (int)tbuser5.Rows[i]["Precio"]; 
                lista.Add(disp);
                i++;
            }
            dash.Disp = lista;
            return Ok(dash);
        }
        //En este reporte se indican todas las veces en las cuales el dispositivo de utilizo durante el mes y año ingresado
        [HttpPost]
        [Route("ReporteConsumo")]
        public IHttpActionResult ReporteConsumo(Reporte reporte)
        {
            DateTime primerDia = new DateTime(reporte.mes.Year, reporte.mes.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Consumo(reporte.Correo,primerDia,ultimoDia);
            
            return Ok(tbuser);
        }
        //Este reporte maneja los dispositivos mas usados, en una categoria , tipo de dispositivo y numero de dispositivos con ese tipo de dispositivo
        [HttpGet]
        [Route("ReporteDispositivosU")]
        public IHttpActionResult Reporte_Dispositivos_mas_usados()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Dispositivo();

            return Ok(tbuser);
        }
        //Este reporte de consumo indica en cual periodo del dia de utilizan mas los dispositivos
        [HttpGet]
        [Route("ReportePeriodo")]
        public IHttpActionResult Reporte_Periodo_mas_usado()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Periodo_del_dia();
            int x = 0, dia = 0, tarde = 0, noche = 0;
            while (x < tbuser.Rows.Count) {
                DateTime temp = (DateTime)tbuser.Rows[x]["Fecha"];
                if (6 <= temp.Hour & temp.Hour <= 12) { dia++; }
                else if (13 <= temp.Hour & temp.Hour <= 18) { tarde++; }
                else if (19 <= temp.Hour & temp.Hour <= 24) { noche++; }
                else if (0 <= temp.Hour & temp.Hour <= 5) { noche++; }
                   x++;
            }
            int[] resultado = { dia, tarde, noche };
            return Ok(resultado);
        }
        //----------------------------------------------------------Correo----------------------------------------
        //En esta funcion se envia un correo desde la empresa a un correo del cliente, conteniendo una factura y el certificado de garantia contenidos en pdf distintos
        [HttpPost]
        [Route("EnviarCorreo")]
        public IHttpActionResult Enviar_CorreoPDF(Valor_PDF pdf)
        {
            //Crea una factura
            DataTable tbuser0 = Proyecto1.DataRequest.BDConection.Consultar_FacturaT();
            int x = 0;
            while (x < tbuser0.Rows.Count)
            {
                
                 if (pdf.serie == (int)tbuser0.Rows[x]["Serie"])
                {
                    return Ok("Ya se ha ingresado ese  numero de serie anteriormente");
                }
                x++;
            }
            int index = (int)(tbuser0.Rows[tbuser0.Rows.Count-1]["Factura"]);
            Proyecto1.DataRequest.BDConection.Agregar_Factura(pdf.serie, index+1, pdf.fecha_compra, pdf.dispositivo, pdf.Precio);
            //--------------------------------------------------------------------------------------------------------------------------------------------
            //Crear un certificado de garantia
            DataTable tbuser3 = Proyecto1.DataRequest.BDConection.Consultar_CertificadoT();
            x = 0;
            while (x < tbuser3.Rows.Count)
            {
                if (pdf.serie == (int)tbuser3.Rows[x]["Serie"])
                {
                    return Ok("Ya se ha ingresado ese numero de serie");
                }

                x++;
            }
            DataTable tbuser4 = Proyecto1.DataRequest.BDConection.Consultar_DispositivoSerie(pdf.serie);

            Proyecto1.DataRequest.BDConection.Agregar_Certificado(pdf.fecha_compra, pdf.fecha_compra.AddMonths((int)tbuser4.Rows[0]["Tiempo_Garantia"]), pdf.Marca, pdf.dispositivo, pdf.serie);
            //---------------------------------------------------------------------------------------------------------------------------------------------
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (pdf.serie == (int)tbuser.Rows[x]["Serie"])
                {
                    DataTable tbuser1 = Proyecto1.DataRequest.BDConection.Consultar_Factura(pdf.serie);
                    DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_Certificado(pdf.serie);
                    Proyecto1.DataRequest.Correo_PDF.Crear_PDF(tbuser1, @"C:\Users\leona\Desktop\Factura.pdf", "Factura del Dispositivo #"+pdf.serie);
                    Proyecto1.DataRequest.Correo_PDF.Crear_PDF(tbuser2, @"C:\Users\leona\Desktop\Garantia.pdf", "Garantia del Dispositivo #" + pdf.serie);
                    Proyecto1.DataRequest.Correo_PDF.EnviarCorreo(pdf.Correo, "SmartHome", "Compra de Producto con serie: "+pdf.serie);
                    return Ok("Se ha enviado exitosamente el correo");
                    
                }
                
                x++;
            }

            return Ok("El numero de serie no existe");
        }
        [HttpGet]
        [Route("PDF")]
        //Esta funcion crea un pdf de prueba
        public IHttpActionResult PDF()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Dispositivo();
            //Proyecto1.DataRequest.Correo_PDF.EnviarCorreo("leonardoguillen946@gmail.com", "le", "li");
            Proyecto1.DataRequest.Correo_PDF.Crear_PDF(tbuser, @"C:\Users\leona\Desktop\Prueba.pdf", "Primer Reporte");
            return Ok("Listo");
        }
        //-----------------------------------------------------------------------------Tienda en linea-------------------------------------------
        [HttpGet]
        [Route("TiendaLinea")]
        //En este campo de relaciona con la tienda en linea , creando varias listas de dispositivos , dividida por contienentes o region
        public IHttpActionResult Tienda_Linea()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_DispositivoXRegion();
            Tienda tienda = new Tienda();
            tienda.America = new List<Dispositivo> { };
            tienda.Africa = new List<Dispositivo> { };
            tienda.Asia = new List<Dispositivo> { };
            tienda.Europa = new List<Dispositivo> { };
            tienda.Oceania = new List<Dispositivo> { };

            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (tbuser.Rows[x]["Continente"].ToString() == "America") { 
                    Dispositivo nuevo = new Dispositivo();
                    nuevo.Serie = (int)tbuser.Rows[x]["Serie"];
                    nuevo.Nombre = tbuser.Rows[x]["Nombre"].ToString();
                    nuevo.Marca = tbuser.Rows[x]["Marca"].ToString();
                    nuevo.Tiempo_Garantia = (int)tbuser.Rows[x]["Tiempo_Garantia"];
                    nuevo.Distribuidor = tbuser.Rows[x]["Distribuidor"].ToString();
                    nuevo.Decripcion = tbuser.Rows[x]["Descripcion"].ToString();
                    nuevo.Consumo_Electrico = (int)tbuser.Rows[x]["Consumo_Electrico"];
                    nuevo.AgregadoPor = tbuser.Rows[x]["AgregadoPor"].ToString();
                    nuevo.Precio = (int)tbuser.Rows[x]["Precio"]; 
                    tienda.America.Add(nuevo);
                }
                if (tbuser.Rows[x]["Continente"].ToString() == "Europa") {
                    Dispositivo nuevo = new Dispositivo();
                    nuevo.Serie = (int)tbuser.Rows[x]["Serie"];
                    nuevo.Nombre = tbuser.Rows[x]["Nombre"].ToString();
                    nuevo.Marca = tbuser.Rows[x]["Marca"].ToString();
                    nuevo.Tiempo_Garantia = (int)tbuser.Rows[x]["Tiempo_Garantia"];
                    nuevo.Distribuidor = tbuser.Rows[x]["Distribuidor"].ToString();
                    nuevo.Decripcion = tbuser.Rows[x]["Descripcion"].ToString();
                    nuevo.Consumo_Electrico = (int)tbuser.Rows[x]["Consumo_Electrico"];
                    nuevo.AgregadoPor = tbuser.Rows[x]["AgregadoPor"].ToString();
                    nuevo.Precio = (int)tbuser.Rows[x]["Precio"];
                    tienda.Europa.Add(nuevo);
                }
                if (tbuser.Rows[x]["Continente"].ToString() == "Asia") {
                    Dispositivo nuevo = new Dispositivo();
                    nuevo.Serie = (int)tbuser.Rows[x]["Serie"];
                    nuevo.Nombre = tbuser.Rows[x]["Nombre"].ToString();
                    nuevo.Marca = tbuser.Rows[x]["Marca"].ToString();
                    nuevo.Tiempo_Garantia = (int)tbuser.Rows[x]["Tiempo_Garantia"];
                    nuevo.Distribuidor = tbuser.Rows[x]["Distribuidor"].ToString();
                    nuevo.Decripcion = tbuser.Rows[x]["Descripcion"].ToString();
                    nuevo.Consumo_Electrico = (int)tbuser.Rows[x]["Consumo_Electrico"];
                    nuevo.AgregadoPor = tbuser.Rows[x]["AgregadoPor"].ToString();
                    nuevo.Precio = (int)tbuser.Rows[x]["Precio"];
                    tienda.Asia.Add(nuevo);
                }
                if (tbuser.Rows[x]["Continente"].ToString() == "Africa") {
                    Dispositivo nuevo = new Dispositivo();
                    nuevo.Serie = (int)tbuser.Rows[x]["Serie"];
                    nuevo.Nombre = tbuser.Rows[x]["Nombre"].ToString();
                    nuevo.Marca = tbuser.Rows[x]["Marca"].ToString();
                    nuevo.Tiempo_Garantia = (int)tbuser.Rows[x]["Tiempo_Garantia"];
                    nuevo.Distribuidor = tbuser.Rows[x]["Distribuidor"].ToString();
                    nuevo.Decripcion = tbuser.Rows[x]["Descripcion"].ToString();
                    nuevo.Consumo_Electrico = (int)tbuser.Rows[x]["Consumo_Electrico"];
                    nuevo.AgregadoPor = tbuser.Rows[x]["AgregadoPor"].ToString();
                    nuevo.Precio = (int)tbuser.Rows[x]["Precio"];
                    tienda.Africa.Add(nuevo);
                }
                if (tbuser.Rows[x]["Continente"].ToString() == "Oceania") {
                    Dispositivo nuevo = new Dispositivo();
                    nuevo.Serie = (int)tbuser.Rows[x]["Serie"];
                    nuevo.Nombre = tbuser.Rows[x]["Nombre"].ToString();
                    nuevo.Marca = tbuser.Rows[x]["Marca"].ToString();
                    nuevo.Tiempo_Garantia = (int)tbuser.Rows[x]["Tiempo_Garantia"];
                    nuevo.Distribuidor = tbuser.Rows[x]["Distribuidor"].ToString();
                    nuevo.Decripcion = tbuser.Rows[x]["Descripcion"].ToString();
                    nuevo.Consumo_Electrico = (int)tbuser.Rows[x]["Consumo_Electrico"];
                    nuevo.AgregadoPor = tbuser.Rows[x]["AgregadoPor"].ToString();
                    nuevo.Precio = (int)tbuser.Rows[x]["Precio"];
                    tienda.Oceania.Add(nuevo);
                }
                x++;
            }
            return Ok(tienda);
        }

    }
}
