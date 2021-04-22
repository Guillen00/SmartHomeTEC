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

        public static void Registrar_Usuario(string nombre, string apellido, string correo, string contraseña, string direccion, string continente, string pais)
        {
            string query = "Insert into \"Usuarios\" values('"+nombre+"','"+apellido+"','"+correo+"','"+ contraseña+"','"+direccion+"','"+continente+"','"+pais+"')";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return; 
        }

        public static void Editar_Usuario(string nombre, string apellido, string correo, string contraseña, string direccion, string continente, string pais)
        {
            string query = "Update \"Usuarios\" set \"Nombre\" ='" + nombre + "',\"Apellido\" = '" + apellido + "',\"Correo\" = '" + correo + "', \"Contraseña\" = '" + contraseña + "',\"Direccion\" = '" + direccion + "',\"Continente\" = '" + continente + "',\"Pais\" = '" + pais + "'" + "where \"Correo\" = '"+correo+"'";
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
        public static void Agregar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int  t_garantia, Boolean activo, string  historialDuenos )
        {

            string query = "Insert into \"Dispositivo\" values(" + serie + ",'" + marca + "'," + consumo + ",'" + aposento + "','" + nombre + "','" + descripcion + "'," + t_garantia + "," + activo + ", ' " + historialDuenos + "')";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return;
        }

        public static void Editar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int t_garantia, Boolean activo, string historialDuenos)
        {
            string query = "Update \"Dispositivo\" set \"# Serie\" =" + serie + ",\"Marca\" = '" + marca + "',\"Consumo Electrico\" = " + consumo + ", \"Aposento\" = '" + aposento + "',\"Nombre\" = '" + nombre + "',\"Descripcion\" = '" + descripcion + "',\"Tiempo de garantia \" = " + t_garantia + ", \"Activo\"= "+activo+ ",\"Historial Dueños\"= '" + historialDuenos+"' "+ "where \"# Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        public static void Borrar_Dispositivo(int serie)
        {
            string query = "Delete from \"Dispositivo\" " + "where \"# Serie\" = " + serie + "";
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

    }
}