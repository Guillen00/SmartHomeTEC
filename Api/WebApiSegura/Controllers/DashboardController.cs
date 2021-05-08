using System;
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
    public class DashboardController : ApiController
    {
        
        //Devuelve cantidad de dispositvos gestionados
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
                disp.Dueño = tbuser5.Rows[i]["Dueño"].ToString();
                disp.Historial_Dueños = tbuser5.Rows[i]["Historial_Dueños"].ToString();
                disp.Marca = tbuser5.Rows[i]["Marca"].ToString();
                disp.Tiempo_Garantia = (int)tbuser5.Rows[i]["Tiempo_de_garantia"];
                //lista[i] = disp;
                lista.Add(disp);
                i++;
            }
            dash.Disp = lista;
            return Ok(dash);
        }

        [HttpPost]
        [Route("ReporteConsumo")]
        public IHttpActionResult ReporteConsumo(Reporte reporte)
        {
            DateTime primerDia = new DateTime(reporte.mes.Year, reporte.mes.Month, 1);
            DateTime ultimoDia = primerDia.AddMonths(1).AddDays(-1);
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Consumo(reporte.Correo,primerDia,ultimoDia);
            
            return Ok(tbuser);
        }

        [HttpGet]
        [Route("ReporteDispositivosU")]
        public IHttpActionResult Reporte_Dispositivos_mas_usados()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Reporte_Dispositivo();

            return Ok(tbuser);
        }

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
        [HttpGet]
        [Route("EnviarCorreo")]
        public IHttpActionResult Enviar_CorreoPDF()
        {
            Proyecto1.DataRequest.Correo_PDF.Enviar_Correo();
            
            return Ok("Se envio el correo");
        }
    }
}
