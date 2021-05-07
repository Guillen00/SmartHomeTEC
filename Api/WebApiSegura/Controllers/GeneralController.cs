using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using Proyecto1.DataRequest;
using System;

namespace Proyecto1.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>

    [AllowAnonymous]
    //[Authorize]
    [RoutePrefix("api/general")]
    public class GeneralController : ApiController
    {
        //-------------------------------------------------Dispositivo-----------------------------------------
        // Agrega un nuevo dispositivo a la base de datos
        [HttpPost]
        [Route("AgregarDispositivo")]
        public IHttpActionResult Agregar(Dispositivo disp)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (disp.Serie == (int)tbuser.Rows[x]["#_Serie"])
                {
                    return Ok("El numero de serie del dispositivo ya ha sido ingresado");
                }
                else if (disp.Nombre == tbuser.Rows[x]["Nombre"].ToString())
                {
                    return Ok("El Nombre del dispositivo ya ha sido ingresado");
                }
                x++;
            }
            Proyecto1.DataRequest.BDConection.Agregar_Dispositivo(disp.Serie,disp.Marca,disp.Consumo_Electrico,disp.Aposento,disp.Nombre,disp.Decripcion,disp.Tiempo_Garantia,disp.Activo,disp.Historial_Dueños,disp.Distribuidor,disp.AgregadoPor,disp.Dueño);
            return Ok("El dispositivo se ha agregado exitosamente");
        }

        //Edita el perfil, del dispositivo con el numeor de serie como llave
        [HttpPost]
        [Route("EditarDispositivo")]
        public IHttpActionResult Editar_Dispositivo(Dispositivo disp)
        {
            
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_NoActivo();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (disp.Serie == (int) tbuser.Rows[x]["#_Serie"])
                {
                    DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_DispositivoSerie(disp.Serie);
                    if (disp.Nombre == null) { disp.Nombre = tbuser2.Rows[0]["Nombre"].ToString(); }
                    if (disp.Activo == null) { disp.Activo = Convert.ToBoolean(tbuser2.Rows[0]["Activo"]); }
                    if (disp.AgregadoPor == null) { disp.AgregadoPor = tbuser2.Rows[0]["AgregadoPor"].ToString(); }
                    if (disp.Aposento == null) { disp.Aposento = tbuser2.Rows[0]["Aposento"].ToString(); }
                    if (disp.Historial_Dueños == null) { disp.Historial_Dueños = tbuser2.Rows[0]["Historial_Dueños"].ToString(); }
                    disp.Serie = (int)tbuser2.Rows[0]["#_Serie"];
                    if (disp.Consumo_Electrico == null) { disp.Consumo_Electrico = (int)tbuser2.Rows[0]["Consumo_Electrico"]; }
                    if (disp.Decripcion == null) { disp.Decripcion = tbuser2.Rows[0]["Descripcion"].ToString(); }
                    if (disp.Distribuidor == null) { disp.Distribuidor = tbuser2.Rows[0]["Distribuidor"].ToString(); }
                    if (disp.Dueño == null) { disp.Dueño = tbuser2.Rows[0]["Dueño"].ToString(); }
                    if (disp.Marca == null) { disp.Marca = tbuser2.Rows[0]["Marca"].ToString(); }
                    if (disp.Tiempo_Garantia == null) { disp.Tiempo_Garantia = (int)tbuser2.Rows[0]["Tiempo_de_garantia "]; }


                    Proyecto1.DataRequest.BDConection.Editar_Dispositivo(disp.Serie, disp.Marca, disp.Consumo_Electrico, disp.Aposento, disp.Nombre, disp.Decripcion, disp.Tiempo_Garantia, disp.Activo, disp.Historial_Dueños,disp.Distribuidor,disp.AgregadoPor,disp.Dueño);
                    return Ok("El dispositivo ha sido actualizado ");
                }
                x++;
            }
            
            return Ok("El Dispositivo no se ha entontrado o esta activo");
        }
        //Edita el perfil, del dispositivo con el numeor de serie como llave
        [HttpPost]
        [Route("EditarDispositivoAdmin")]
        public IHttpActionResult Editar_Dispositivo_admin(Dispositivo disp)
        {

            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (disp.Serie == (int)tbuser.Rows[x]["#_Serie"])
                {
                    DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_DispositivoSerie(disp.Serie);
                    if (disp.Nombre == null) { disp.Nombre = tbuser2.Rows[0]["Nombre"].ToString(); }
                    if (disp.Activo == null) { disp.Activo = Convert.ToBoolean(tbuser2.Rows[0]["Activo"]); }
                    if (disp.AgregadoPor == null) { disp.AgregadoPor = tbuser2.Rows[0]["AgregadoPor"].ToString(); }
                    if (disp.Aposento == null) { disp.Aposento = tbuser2.Rows[0]["Aposento"].ToString(); }
                    if (disp.Historial_Dueños == null) { disp.Historial_Dueños = tbuser2.Rows[0]["Historial_Dueños"].ToString(); }
                    disp.Serie = (int)tbuser2.Rows[0]["#_Serie"];
                    if (disp.Consumo_Electrico == null) { disp.Consumo_Electrico = (int)tbuser2.Rows[0]["Consumo_Electrico"]; }
                    if (disp.Decripcion == null) { disp.Decripcion = tbuser2.Rows[0]["Descripcion"].ToString(); }
                    if (disp.Distribuidor == null) { disp.Distribuidor = tbuser2.Rows[0]["Distribuidor"].ToString(); }
                    if (disp.Dueño == null) { disp.Dueño = tbuser2.Rows[0]["Dueño"].ToString(); }
                    if (disp.Marca == null) { disp.Marca = tbuser2.Rows[0]["Marca"].ToString(); }
                    if (disp.Tiempo_Garantia == null) { disp.Tiempo_Garantia = (int)tbuser2.Rows[0]["Tiempo_de_garantia "]; }


                    Proyecto1.DataRequest.BDConection.Editar_Dispositivo(disp.Serie, disp.Marca, disp.Consumo_Electrico, disp.Aposento, disp.Nombre, disp.Decripcion, disp.Tiempo_Garantia, disp.Activo, disp.Historial_Dueños, disp.Distribuidor, disp.AgregadoPor, disp.Dueño);
                    return Ok("El dispositivo ha sido actualizado ");
                }
                x++;
            }

            return Ok("El Dispositivo no se ha entontrado ");
        }
        // Hace una consulta sobre todos los dispositivos 
        [HttpGet]
        [Route("ListaDispositivos")]
        public IHttpActionResult Lista_Dispositivos(Dispositivo disp)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();


            return Ok(tbuser);
        }

        //Elimina un dispositivo por medio de su llave , # serie
        [HttpPost]
        [Route("BorrarDispositivo")]
        public IHttpActionResult Borrar_Dispositivo(Dispositivo disp)
        {
            Proyecto1.DataRequest.BDConection.Borrar_Dispositivo(disp.Serie);


            return Ok("El dispositivo ha sido eliminado exitosamente");
        }


        //----------------------------------------------Historial-------------------------------
        //Agrega historial a base de datos
        [HttpPost]
        [Route("AgregarHistorial")]
        public IHttpActionResult Agregar_Historial(Historial hist)
        {
            
            Proyecto1.DataRequest.BDConection.Agregar_Historial(hist.Serie,hist.Fecha,hist.Tiempo_Encendido);
            return Ok("El historial se ha agregado exitosamente");
        }


        // Hace una consulta sobre todos los historiales  
        [HttpPost]
        [Route("ListaHistorial")]
        public IHttpActionResult Lista_Historial(Historial hist)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Historial(hist.Serie);


            return Ok(tbuser);
        }


        //------------------------------------------------------------------------------Distribuidores----------------------------------
        //Agrega distribuidor a base de datos
        [HttpPost]
        [Route("AgregarDistribuidor")]
        public IHttpActionResult Agregar_Distribuidor(Distribuidores dist)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Distribuidor(dist.Cedula_Juridica);
            DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_DistribuidorN(dist.Nombre);
            if (tbuser.Rows.Count ==0 )
            {
                if (tbuser2.Rows.Count == 0)
                {
                    Proyecto1.DataRequest.BDConection.Agregar_Distribuidor(dist.Cedula_Juridica, dist.Nombre, dist.Continente, dist.Pais);
                    return Ok("El Distribuidor se ha agregado exitosamente");
                }
                
            }
               
            
            
            return Ok("Ya se ha ingresado la Cedula Juridica o el Nombre del Distribuidor");
        }


        // Hace una consulta sobre un distribuidor  
        [HttpPost]
        [Route("Distribuidor")]
        public IHttpActionResult Distribuidor(Distribuidores dist)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Distribuidor(dist.Cedula_Juridica);


            return Ok(tbuser);
        }

        //--------------------------------------------------------------Pedido----------------------------------------------------------------------------------

        //Agrega pedido a base de datos
        [HttpPost]
        [Route("AgregarPedido")]
        public IHttpActionResult Agregar_Pedido(Pedidos pedido)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Pedido(pedido.Serie);
            DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_PedidoU(pedido.Usuario);
            if (tbuser.Rows.Count == 0)
            {
                int max = tbuser2.Rows.Count;
                int numero = max + 1;
                
                Proyecto1.DataRequest.BDConection.Agregar_Pedido(numero, pedido.Fecha_Hora, pedido.dispositivo, pedido.Marca, pedido.Serie, pedido.Monto_Total,pedido.Usuario);
                return Ok("El Pedido se ha agregado exitosamente");
                

            }
            return Ok("El numero de serie ya se ha agragado a un pedido");
        }


        // Hace una consulta sobre un pedido  
        [HttpPost]
        [Route("ConsultaPedido")]
        public IHttpActionResult Consulta_Pedido(Pedidos pedido)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Pedido(pedido.Serie);


            return Ok(tbuser);
        }

        //-------------------------------------------------------------------------------Aposento-----------------------------------------------------------------------

        //Agrega Aposento a base de datos
        [HttpPost]
        [Route("AgregarAposento")]
        public IHttpActionResult Agregar_Aposento(Aposentos apo)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Aposento(apo.Correo);
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (apo.Nombre == tbuser.Rows[x]["Nombre"].ToString())
                {
                    return Ok("El Aposento ya ha sido ingresado");
                }
                x++;
            }
            Proyecto1.DataRequest.BDConection.Agregar_Aposento(apo.Correo,apo.Nombre);
            return Ok("El Aposento se ha agregado exitosamente");
        }


        // Hace una consulta sobre todos los aposentos de un usuario 
        [HttpPost]
        [Route("ConsultaAposentos")]
        public IHttpActionResult Consulta_Aposento(Aposentos apo)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Aposento(apo.Correo);


            return Ok(tbuser);
        }


        //-----------------------------------------------------------------------Factura-----------------------------------------------
        //Agrega factura a base de datos
        [HttpPost]
        [Route("AgregarFactura")]
        public IHttpActionResult Agregar_Fatura(Factura fact)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_FacturaT();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (fact.Num_Factura == (int)tbuser.Rows[x]["#_Factura"])
                {
                    return Ok("Ya se ha ingresado ese numero de factura ");
                }
                else if (fact.serie == (int)tbuser.Rows[x]["#_Serie"])
                {
                    return Ok("Ya se ha ingresado ese  numero de serie");
                }
                x++;
            }
            Proyecto1.DataRequest.BDConection.Agregar_Factura(fact.serie,fact.Num_Factura,fact.Fecha_Compra,fact.dispositivo,fact.Precio);
            return Ok("La Factura se ha agregado exitosamente");
        }


        // Hace una consulta sobre una factura 
        [HttpPost]
        [Route("ConsultaFactura")]
        public IHttpActionResult Consulta_Factura(Factura fact)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Factura(fact.serie);


            return Ok(tbuser);
        }


        //-----------------------------------------------------------------------Certificado-----------------------------------------------
        //Agrega un certificado a base de datos
        [HttpPost]
        [Route("AgregarGarantia")]
        public IHttpActionResult Agregar_Certificado(Certificado_Garantia gara)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_CertificadoT();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (gara.Serie == (int)tbuser.Rows[x]["#_Serie"])
                {
                    return Ok("Ya se ha ingresado ese numero de serie");
                }
                
                x++;
            }
            Proyecto1.DataRequest.BDConection.Agregar_Certificado(gara.Fecha_Compra,gara.Fecha_Fin_Garantia,gara.Marca,gara.dispositivo,gara.Serie);
            return Ok("El Certificado de Garantia se ha agregado exitosamente");
        }


        // Hace una consulta sobre un certificado 
        [HttpPost]
        [Route("ConsultaGarantia")]
        public IHttpActionResult Consulta_Certificado(Certificado_Garantia gara)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Certificado(gara.Serie);


            return Ok(tbuser);
        }



    }
}
