using System;
using System.Collections.Generic;
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
    //[Authorize(Roles = "Administrator")]
    [RoutePrefix("api/plato")]
    public class DashboardController : ApiController
    {
        
        //Devuelve todos los platilos
        [HttpGet]
        [Route("menu")]
        public IHttpActionResult menu()
        {
            

            return Ok("Conectado");
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar()
        {
            
            
            
            return Ok("Platillo Agregado");
        }

        [HttpPost]
        [Route("eliminar")]
        public IHttpActionResult Borrar()
        {
           

            return Ok("Platillo no se ha encontrado");
        }


        [HttpPost]
        [Route("editar")]
        public IHttpActionResult Editar() 
        {
           
            return Ok("Platillo no se ha encontrado");
        }

        //Muestra una lista con el top de platos mas vendidos
        [HttpGet]
        [Route("top_vendidos")]
        public IHttpActionResult top_vendidos()
        {
           

            return Ok("Desconectado");
        }

        //Muestra una lista con el top de platos con mas ganacia
        [HttpGet]
        [Route("top_ganancias")]
        public IHttpActionResult top_ganancias()
        {
            
            return Ok();
        }

        //Muestra una lista con el top de platos con mas feedback
        [HttpGet]
        [Route("top_feedback")]
        public IHttpActionResult top_feedback()
        {
     

            return Ok("ok");
        }
        //Muestra una lista con el top de usuarios con mas ordenes
        [HttpGet]
        [Route("top_ordenes")]
        public IHttpActionResult top_ordenes()
        {
            


            return Ok("ok");
        }
    }
}
