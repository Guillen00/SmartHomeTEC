using System.Web.Http;
using Tarea1_API.Models;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// customer controller class for testing security token 
    /// </summary>

    [AllowAnonymous]
    //[Authorize]
    [RoutePrefix("api/pedidos")]
    public class PedidosController : ApiController
    {
        [HttpGet]
        [Route("listapedidos")]
        public IHttpActionResult lista() {
            
            
            return Ok("ok");
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base =null;


            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                    return Ok("Codigo del pedido ya ha sido usado");
                }
                i++;
            }
            
            return Ok("Pedido Agregado");
        }

        [HttpPost]
        [Route("eliminar")]
        public IHttpActionResult Borrar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base = null;



            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                   
                    return Ok("Pedido fue eliminado");
                }
                i++;
            }

            return Ok("Codigo de pedido no encontrado");
        }
        //Enviar solo codigo y chef
        [HttpPost]
        [Route("asignar")]
        public IHttpActionResult Asignar(Pedidos pedido)
        {
            List<Pedidos> pedidos_base = null;
            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (pedido.Codigo == pedidos_base[i].Codigo)
                {
                   
                    return Ok("Pedido fue asignado");
                }
                i++;
            }

            return Ok("Codigo de pedido no encontrado");
        }

        //Enviar pedidos asignados al chef 
        [HttpPost]
        [Route("asignado")]
        public IHttpActionResult Asignado(LoginRequest chef) 
        {
            List<Pedidos> pedidos_base = null;
            List<Pedidos> pedidos_base2 = new List<Pedidos> { };
            int i = 0;
            while (i < pedidos_base.Count)
            {
                if (chef.Username == pedidos_base[i].chef_asignado)
                {
                    pedidos_base2.Add(pedidos_base[i]);
                    
                }
                i++;
            }

            return Ok(pedidos_base2);
        }
    }
}
