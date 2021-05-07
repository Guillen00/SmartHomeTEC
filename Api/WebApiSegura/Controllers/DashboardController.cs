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
        [Route("dispositivosGestionados")]
        public IHttpActionResult DispositivosGestionados()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_Activo();

            return Ok(tbuser.Rows.Count);
        }
        //Devuelve cantidad de dispositivos por usuario en promedio
        [HttpGet]
        [Route("promedioDXU")]
        public IHttpActionResult PromedioDispositivoPorUsuario()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();
            DataTable tbuser2 = Proyecto1.DataRequest.BDConection.Consultar_Usuario();
            float uno = tbuser.Rows.Count;
            float dos = tbuser2.Rows.Count;
            float Promedio = uno / dos;

            return Ok(Promedio);
        }


        //Devuelve cantidad de dispositivos por region
        [HttpGet]
        [Route("DipositivosXRegion")]
        public IHttpActionResult DipositivosXRegion()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo_XRegion();
            int america=0, europa=0, asia=0, oceania=0, africa=0,x=0;
            
            while (x < tbuser.Rows.Count) {
                if (tbuser.Rows[x]["Continente"].ToString() == "America") { america++; }
                if (tbuser.Rows[x]["Continente"].ToString() == "Europa") { europa++; }
                if (tbuser.Rows[x]["Continente"].ToString() == "Asia") { asia++; }
                if (tbuser.Rows[x]["Continente"].ToString() == "Africa") { africa++; }
                if (tbuser.Rows[x]["Continente"].ToString() == "Oceania") { oceania++; }
                x++;
            }
        // America, Europa, Asia, Africa, Oceania
            DataTable tabla = new DataTable();

            // Variables para las columnas y las filas
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "America";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Europa";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Asia";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Africa";
            tabla.Columns.Add(column);

            column = new DataColumn();
            column.DataType = Type.GetType("System.Int32");
            column.ColumnName = "Oceania";
            tabla.Columns.Add(column);

            row = tabla.NewRow();
            row["America"] = america;
            row["Europa"] = europa;
            row["Asia"] = asia;
            row["Africa"] = africa;
            row["Oceania"] = oceania;
            tabla.Rows.Add(row);

            return Ok(tabla);

        }


        //Devuelve cantidad de dispositivos agregados y su estado activo
        [HttpGet]
        [Route("Dispositivos")]
        public IHttpActionResult Dipositivos()
        {
            DataTable tbuser = Proyecto1.DataRequest.BDConection.Consultar_Dispositivo();

            return Ok(tbuser);
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
