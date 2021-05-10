using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EASendMail;

namespace Proyecto1.DataRequest
{
    public class Correo_PDF
    {
        public static string EnviarCorreo(string correoDestino, string asunto, string mensajeCorreo)
        {
            string mensaje = "Error al enviar correo.";

            try
            {
                SmtpMail objetoCorreo = new SmtpMail("TryIt");

                objetoCorreo.From = "smarthometec2021@gmail.com";
                objetoCorreo.To = "leonardoguillen946@gmail.com";
                objetoCorreo.Subject = asunto;
                objetoCorreo.TextBody = mensajeCorreo;

                SmtpServer objetoServidor = new SmtpServer("smtp.gmail.com");

                objetoServidor.User = "smarthometec2021@gmail.com";
                objetoServidor.Password = "profesor2021";
                objetoServidor.Port = 587;
                objetoServidor.ConnectType = SmtpConnectType.ConnectSSLAuto;

                SmtpClient objetoCliente = new SmtpClient();
                objetoCliente.SendMail(objetoServidor, objetoCorreo);
                mensaje = "Correo Enviado Correctamente.";


            }
            catch (Exception ex)
            {
                mensaje = "Error al enviar correo." + ex.Message;
            }
            return mensaje;
        }
    }
}