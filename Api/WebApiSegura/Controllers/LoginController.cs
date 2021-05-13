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
                    if (user.Contrasena == tbuser.Rows[x]["Contrasena"].ToString()) {
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
            Proyecto1.DataRequest.BDConection.Registrar_Usuario(user.Nombre,user.Apellido,user.Correo,user.Contrasena, user.Direccion,user.Continente,user.Pais);
            Proyecto1.DataRequest.BDConection.Agregar_Aposento(user.Correo, "dormitorio");
            Proyecto1.DataRequest.BDConection.Agregar_Aposento(user.Correo, "cocina");
            Proyecto1.DataRequest.BDConection.Agregar_Aposento(user.Correo, "sala");
            Proyecto1.DataRequest.BDConection.Agregar_Aposento(user.Correo, "comedor");
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
                    DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_UsuarioPerfil(user.Correo);
                    if (user.Nombre == null ) { user.Nombre = tbuser2.Rows[0]["Nombre"].ToString(); }
                    if (user.Apellido == null) { user.Apellido = tbuser2.Rows[0]["Apellido"].ToString(); }
                    if (user.Continente == null) { user.Continente = tbuser2.Rows[0]["Continente"].ToString(); }
                    if (user.Contrasena == null) { user.Contrasena = tbuser2.Rows[0]["Contrasena"].ToString(); }
                    if (user.Direccion == null) { user.Direccion = tbuser2.Rows[0]["Direccion"].ToString(); }
                    if (user.Pais == null) { user.Pais = tbuser2.Rows[0]["Pais"].ToString(); }
                    user.Correo = tbuser2.Rows[0]["Correo"].ToString();
                    Proyecto1.DataRequest.BDConection.Editar_Usuario(user.Nombre, user.Apellido, user.Correo, user.Contrasena, user.Direccion, user.Continente, user.Pais);
                    return Ok("El Perfil ha sido actualizado ");
                }
                x++;
            }
            
            return Ok("El usuario no se ha agregado");
        }
        // Hace una consulta sobre todos los usuarios 
        [HttpGet]
        [Route("ListaUsuarios")]
        public IHttpActionResult Lista_Usuarios()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            

            return Ok(tbuser);
        }
        //Elimina un usuario por medio de su llave , correo
        [HttpPost]
        [Route("BorrarUsuario")]
        public IHttpActionResult Borrar_Usuario(Usuario user)
        {
            Proyecto1.DataRequest.BDConection.Borrar_Aposento(user.Correo);
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_DispositivoCorreo(user.Correo);
            int x = 0;
            while (x < tbuser.Rows.Count)
            {
                Proyecto1.DataRequest.BDConection.Editar_Dispositivo((int)tbuser.Rows[x]["Serie"], tbuser.Rows[x]["Marca"].ToString(), (int)tbuser.Rows[x]["Consumo_Electrico"], tbuser.Rows[x]["Aposento"].ToString(), tbuser.Rows[x]["Nombre"].ToString(), tbuser.Rows[x]["Descripcion"].ToString(),  (int)tbuser.Rows[x]["Tiempo_Garantia"], false, tbuser.Rows[x]["Historial_Duenos"].ToString()+","+ tbuser.Rows[x]["Dueno"].ToString(), tbuser.Rows[x]["Distribuidor"].ToString(), tbuser.Rows[x]["AgregadoPor"].ToString(), " ", (int)tbuser.Rows[x]["Precio"]);
                x++;
            }

            Proyecto1.DataRequest.BDConection.Borrar_Pedidos(user.Correo);
             
            Proyecto1.DataRequest.BDConection.Borrar_Usuario(user.Correo);


            return Ok("El usuario ha sido eliminado exitosamente");
        }
        //Pide informacion sobre un usuario
        [HttpPost]
        [Route("PerfilUsuario")]
        public IHttpActionResult Perfil_Usuario(Usuario user)
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_UsuarioPerfil(user.Correo);


            return Ok(tbuser);
        }
    }

}