using System.Web.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Data;
using Proyecto1.DataRequest;


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
                if (disp.Serie == (int)tbuser.Rows[x]["# Serie"])
                {
                    return Ok("El dispositivo ya ha sido ingresado");
                }
                x++;
            }
            Proyecto1.DataRequest.BDConection.Agregar_Dispositivo(disp.Serie,disp.Marca,disp.Consumo_Electrico,disp.Aposento,disp.Nombre,disp.Decripcion,disp.Tiempo_Garantia,disp.Activo,disp.Historial_Dueños);
            return Ok("El dispositivo se ha agregado exitosamente");
        }

        //Edita el perfil, del dispositivo con el numeor de serie como llave
        [HttpPost]
        [Route("EditarDispositivo")]
        public IHttpActionResult Editar_Dispositivo(Dispositivo disp)
        {
            
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_Activo();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (disp.Serie == (int) tbuser.Rows[x]["# Serie"])
                {
                    Proyecto1.DataRequest.BDConection.Editar_Dispositivo(disp.Serie, disp.Marca, disp.Consumo_Electrico, disp.Aposento, disp.Nombre, disp.Decripcion, disp.Tiempo_Garantia, disp.Activo, disp.Historial_Dueños);
                    return Ok("El dispositivo ha sido actualizado ");
                }
                x++;
            }
            
            return Ok("El Dispositivo no se ha entontrado o no esta activo");
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
        [HttpPost]
        [Route("AgregarHistorial")]
        public IHttpActionResult Agregar_Historial(Historial hist)
        {
            
            Proyecto1.DataRequest.BDConection.Agregar_Historial(hist.Serie,hist.Fecha,hist.Tiempo_Encendido);
            return Ok("El historial se ha agregado exitosamente");
        }


    }
}
