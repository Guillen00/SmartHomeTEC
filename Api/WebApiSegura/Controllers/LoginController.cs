using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Proyecto1.DataRequest;
using System.Data;

namespace Proyecto1.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        //Verifica si el usuario ingresado, correo y Contraseña coinciden con alguno guardado en la base de datos 
        [HttpPost]
        [Route("verificar")]
        public IHttpActionResult Verificar(Usuario user)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Usuario();

            int x = 0;
            while (x < tbuser.Rows.Count) {
                if (user.Correo == tbuser.Rows[x]["Correo"].ToString()) {
                    if (user.Contraseña == tbuser.Rows[x]["Contraseña"].ToString()) {
                        return Ok("Correcto");
                    }
                    else return Ok("Contraseña Incorrecta");
                } 
                x++;
            }
            return Ok("Usuario no encontrado");
        }
        // Agrega un nuevo usuario a la base de datos
        [HttpPost]
        [Route("Registrar")]
        public IHttpActionResult Registrar(Usuario user)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (user.Correo == tbuser.Rows[x]["Correo"].ToString())
                {
                    return Ok("El correo ya ha sido ingresado");
                }
                x++;
            }
            Proyecto1.DataRequest.BDConection.Registrar_Usuario(user.Nombre,user.Apellido,user.Correo,user.Contraseña,user.Direccion,user.Continente,user.Pais);
            return Ok("El usuario se ha agregado exitosamente");
        }

        //Edita el perfil, del usuario con el correo como llave
        [HttpPost]
        [Route("EditarPerfil")]
        public IHttpActionResult Editar_Perfil(Usuario user)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                if (user.Correo == tbuser.Rows[x]["Correo"].ToString())
                {
                    Proyecto1.DataRequest.BDConection.Editar_Usuario(user.Nombre, user.Apellido, user.Correo, user.Contraseña, user.Direccion, user.Continente, user.Pais);
                    return Ok("El Perfil ha sido actualizado ");
                }
                x++;
            }
            
            return Ok("El usuario no se ha agregado");
        }
        // Hace una consulta sobre todos los usuarios 
        [HttpGet]
        [Route("ListaUsuarios")]
        public IHttpActionResult Lista_Usuarios(Usuario user)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            

            return Ok(tbuser);
        }
        //Elimina un usuario por medio de su llave , correo
        [HttpPost]
        [Route("BorrarUsuario")]
        public IHttpActionResult Borrar_Usuario(Usuario user)
        {
            Proyecto1.DataRequest.BDConection.Borrar_Usuario(user.Correo);


            return Ok("El usuario ha sido eliminado exitosamente");
        }
    }

}