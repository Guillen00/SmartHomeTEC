using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;

namespace Proyecto1.DataRequest
{
    public static class BDConection {
        public static NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = guillen1; Database = General");


        public static void Conectar() {

            conn.Open();
        }

        public static void Desconectar()
        {

            conn.Close();
        }
        //---------------------------------------Usuarios------------------------------
        public static DataTable Consultar_Usuario()
        {
            string query = "select * from \"Usuarios\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_UsuarioPerfil(string correo)
        {
            string query = "select * from \"Usuarios\" where \"Correo\" = '"+ correo +"'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public static void Registrar_Usuario(string nombre, string apellido, string correo, string Contrasena, string direccion, string continente, string pais)
        {
            string query = "Insert into \"Usuarios\" values('"+nombre+"','"+apellido+"','"+correo+"','"+ Contrasena + "','"+direccion+"','"+continente+"','"+pais+"')";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return; 
        }

        public static void Editar_Usuario(string nombre, string apellido, string correo, string Contrasena, string direccion, string continente, string pais)
        {
            string query = "Update \"Usuarios\" set \"Nombre\" ='" + nombre + "',\"Apellido\" = '" + apellido + "',\"Correo\" = '" + correo + "', \"Contrasena\" = '" + Contrasena + "',\"Direccion\" = '" + direccion + "',\"Continente\" = '" + continente + "',\"Pais\" = '" + pais + "'" + "where \"Correo\" = '"+correo+"'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static void Borrar_Usuario( string correo)
        {
            string query = "Delete from \"Usuarios\" " + "where \"Correo\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            conn.Close();
            return;
        }


        //--------------------------------Dispositivo-------------------------------------------------

        public static DataTable Consultar_Dispositivo()
        {
            string query = "select * from \"Dispositivo\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public static DataTable Consultar_Dispositivo_Activo()
        {
            string query = "select * from \"Dispositivo\" " + "where \"Activo\" = " + true + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_DispositivoSerie(int serie)
        {
            string query = "select * from \"Dispositivo\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_Dispositivo_XRegion()
        {
            string query = "SELECT \"NombreD\",\"Continente\" FROM  \"Distribuidores\" inner join \"Dispositivo\" on \"Distribuidor\" = \"NombreD\"; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_Dispositivo_NoActivo()
        {
            string query = "select * from \"Dispositivo\" " + "where \"Activo\" = " + false + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static void Agregar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int  t_garantia, Boolean activo, string  historialDuenos ,string distr,string Agregado,string Dueno)
        {

            string query = "Insert into \"Dispositivo\" values(" + serie + ",'" + marca + "'," + consumo + ",'" + aposento + "','" + nombre + "','" + descripcion + "'," + t_garantia + "," + activo + ", ' " + historialDuenos + "','" + distr + "','" + Agregado + "','"+ Dueno + "')";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return;
        }

        public static void Editar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int t_garantia, Boolean activo, string historialDuenos,string distr,string Agregado,string Dueno)
        {
            string query = "Update \"Dispositivo\" set \"Serie\" =" + serie + ",\"Marca\" = '" + marca + "',\"Consumo_Electrico\" = " + consumo + ", \"Aposento\" = '" + aposento + "',\"Nombre\" = '" + nombre + "',\"Descripcion\" = '" + descripcion + "',\"Tiempo_Garantia\" = " + t_garantia + ", \"Activo\"= "+activo+ ",\"Historial_Duenos\"= '" + historialDuenos+"',\"Distribuidor\"='"+distr + "',\"AgregadoPor\"='" + Agregado + "',\"Dueno\"='" + Dueno + "' " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static void Borrar_Dispositivo(int serie)
        {
            string query = "Delete from \"Dispositivo\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            conn.Close();
            return;
        }
        //------------------------------------Historial-------------------------------
        public static void Agregar_Historial(int serie,DateTime fecha,int Tencendido) { 
            string query = "Insert into \"Historial\" values(" + serie + ",'" + String.Format("{0:d/M/yyyy HH:mm:ss}", fecha) + "'," + Tencendido + ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Historial(int serie)
        {
            string query = "select * from \"Historial\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        //------------------------------------------------------------Factura-------------------------------------------------
        public static void Agregar_Factura(int serie, int factura, DateTime Tcompra,string dispositivo,int precio)
        {
            string query = "Insert into \"Factura\" values(" + factura + "," +serie + " , '" + String.Format("{0:d/M/yyyy HH:mm:ss}", Tcompra) + "','" + dispositivo +"'," + precio + ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Factura(int serie)
        {
            string query = "select * from \"Factura\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public static DataTable Consultar_FacturaT()
        {
            string query = "select * from \"Factura\" ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        //-----------------------------------------------------------Certificado---------------------------------------------

        public static void Agregar_Certificado( DateTime Tcompra, DateTime Tfin, string marca, string nombre,int serie)
        {
            string query = "Insert into \"Certificado de Garantia\" values('" + String.Format("{0:d/M/yyyy HH:mm:ss}", Tcompra) + "','" + String.Format("{0:d/M/yyyy HH:mm:ss}", Tfin) + "','" + marca + "','" + nombre + "',"+ serie+  ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Certificado(int serie)
        {
            string query = "select * from \"Certificado de Garantia\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_CertificadoT()
        {
            string query = "select * from \"Certificado de Garantia\" ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        //---------------------------------------------------Aposento----------------------------------------------------------------

        public static void Agregar_Aposento(string correo,  string aposento)
        {
            string query = "Insert into \"Aposento\" values('" + correo + "','" + aposento + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Aposento(string correo)
        {
            string query = "select * from \"Aposento\" " + "where \"Correo\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        //---------------------------------------------------------------Pedidos-------------------------------------------------------------------

        public static void Agregar_Pedido(int pedido, DateTime  Fecha, string dispositivo,string marca,int serie, int monto,string usuario)
        {
            string query = "Insert into \"Pedidos\" values(" + pedido + " , '" + String.Format("{0:d/M/yyyy HH:mm:ss}", Fecha) + "','"+ dispositivo+"','"+ marca +"',"+serie+","+monto+ ",'" + usuario + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Pedido(int serie)
        {
            string query = "select * from \"Pedidos\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_PedidoU(string usuario)
        {
            string query = "select * from \"Pedidos\"  " + "where \"Usuario\" = '" + usuario + "'"+ "  ORDER BY \"#_Pedido\" ASC ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        //--------------------------------------------------------Distribuidores------------------------------------------------------------------------

        public static void Agregar_Distribuidor(int Cjuridica, string Nombre, string Continente, string pais)
        {
            string query = "Insert into \"Distribuidores\" values(" + Cjuridica + " , '"  + Nombre + "','" + Continente + "','" + pais + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static DataTable Consultar_Distribuidor(int Cjuridica)
        {
            string query = "select * from \"Distribuidores\" " + "where \"Cedula_Juridica\" = " + Cjuridica + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        public static DataTable Consultar_DistribuidorN(string name)
        {
            string query = "select * from \"Distribuidores\" " + "where \"NombreD\" = '" + name + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        //----------------------------------------------------------------Reportes---------------------------------------------------
        public static DataTable Reporte_Consumo(string correo,DateTime primer, DateTime segundo)
        {
            string query = "SELECT * FROM \"Dispositivo\" inner join \"Historial\" on \"Historial\".\"Serie\" = \"Dispositivo\".\"Serie\" where \"Dueno\" = '"+ correo +"' AND \"Fecha\"  BETWEEN '" + String.Format("{0:d/M/yyyy HH:mm:ss}", primer) + "' AND '"+ String.Format("{0:d/M/yyyy HH:mm:ss}", segundo) + "'  Order by \"Fecha\" ASC; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public static DataTable Reporte_Dispositivo()
        {
            string query = "SELECT \"Nombre\", count(*) FROM \"Dispositivo\" GROUP BY \"Nombre\" HAVING COUNT(*)> 0 Order BY \"count\" DESC; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        public static DataTable Reporte_Periodo_del_dia()
        {
            string query = "SELECT \"Fecha\" FROM \"Historial\"  ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
    }
}