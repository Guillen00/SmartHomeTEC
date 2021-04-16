﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tarea1_API.Models;

namespace Tarea1_API.Controllers
{
    /// <summary>
    /// admin controller class for testing security token with role admin
    /// </summary>
    /// 

    [AllowAnonymous]
    //[Authorize(Roles = "Administrator")]
    [RoutePrefix("api/plato")]
    public class PlatoController : ApiController
    {
        //Devuelve todos los platilos
        [HttpGet]
        [Route("menu")]
        public IHttpActionResult menu()
        {
            
            return Ok("ok");
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult Agregar(Platos plato)
        {
            List<Platos> platos_base = null;


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre )
                {
                    return Ok("Platillo ya ha sido Agregado");
                }
                i++;
            }
            
            
            return Ok("Platillo Agregado");
        }

        [HttpPost]
        [Route("eliminar")]
        public IHttpActionResult Borrar(Platos plato)
        {
            List<Platos> platos_base = null;


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre)
                {
                    
                    return Ok("Platillo ya ha sido eliminado");
                }
                i++;
            }

            return Ok("Platillo no se ha encontrado");
        }


        [HttpPost]
        [Route("editar")]
        public IHttpActionResult Editar(Platos plato) 
        {
            List<Platos> platos_base = null;


            int i = 0;
            while (i < platos_base.Count)
            {
                if (plato.Nombre == platos_base[i].Nombre)
                {
                    if (plato.Descripcion != " ") {
                        platos_base[i].Descripcion = plato.Descripcion;
                    }
                    if (plato.Precio != 0)
                    {
                        platos_base[i].Precio = plato.Precio;
                    }
                    if (plato.Calorias != 0)
                    {
                        platos_base[i].Calorias = plato.Calorias;
                    }
                    if (plato.Tipo != " ")
                    {
                        platos_base[i].Tipo = plato.Tipo;
                    }
                    if (plato.Ventas != 0)
                    {
                        platos_base[i].Ventas = plato.Ventas;
                    }
                    
                    return Ok("El Platillo ha sido actualizado");
                }
                i++;
            }
            return Ok("Platillo no se ha encontrado");
        }

        //Muestra una lista con el top de platos mas vendidos
        [HttpGet]
        [Route("top_vendidos")]
        public IHttpActionResult top_vendidos()
        {
            List<Platos> platos_base = null;
            List<Platos> platos_base2 = new List<Platos> { };
            // List<Platos> platos_base3 = new List<Platos> { };
            IOrderedEnumerable<Platos> platos_base3 = platos_base.OrderByDescending(x => x.Ventas);
            

            int i = 0;
            while (platos_base2.Count < 10)
            {
                platos_base2.Add(platos_base3.ElementAt(i));

                i++;
            }


            return Ok(platos_base2);
        }

        //Muestra una lista con el top de platos con mas ganacia
        [HttpGet]
        [Route("top_ganancias")]
        public IHttpActionResult top_ganancias()
        {
            List<Platos> platos_base = null;
            List<Platos> platos_base2 = new List<Platos> { };
            // List<Platos> platos_base3 = new List<Platos> { };
            IOrderedEnumerable<Platos> platos_base3 = platos_base.OrderByDescending(x => (x.Ventas*x.Precio));


            int i = 0;
            while (platos_base2.Count < 10)
            {
                platos_base2.Add(platos_base3.ElementAt(i));

                i++;
            }


            return Ok(platos_base2);
        }

        //Muestra una lista con el top de platos con mas feedback
        [HttpGet]
        [Route("top_feedback")]
        public IHttpActionResult top_feedback()
        {
            List<Platos> platos_base = null;
            List<Platos> platos_base2 = new List<Platos> { };
            // List<Platos> platos_base3 = new List<Platos> { };
            IOrderedEnumerable<Platos> platos_base3 = platos_base.OrderByDescending(x => x.Feedback);


            int i = 0;
            while (platos_base2.Count < 10)
            {
                platos_base2.Add(platos_base3.ElementAt(i));

                i++;
            }


            return Ok(platos_base2);
        }
        //Muestra una lista con el top de usuarios con mas ordenes
        [HttpGet]
        [Route("top_ordenes")]
        public IHttpActionResult top_ordenes()
        {
            List<Usuarios> login_base =null;
            List<Usuarios> login_base2 = new List<Usuarios> { };
            // List<Platos> platos_base3 = new List<Platos> { };
            IOrderedEnumerable<Usuarios> login_base3 = login_base.OrderByDescending(x => x.Cant_Ordenes);


            int i = 0;
            while (login_base2.Count < 10)
            {
                login_base2.Add(login_base3.ElementAt(i));

                i++;
            }


            return Ok(login_base2);
        }
    }
}
