using System;
using System.Net;
using System.Threading;
using System.Web.Http;
using System.Collections.Generic;
using Npgsql;
using System.Data;

namespace Proyecto1.DataRequest
{
    /*
     * En esta clase se conectara con la base de datos en postgresql con todas las peticiones especificas para las tablas de la base 
     */
    public static class BDConection {

        /*
         * Esta variable contiene la configuracion para poder conectar con la base de datos 
         */
        public static NpgsqlConnection conn = new NpgsqlConnection("Server = localhost; User Id = postgres; Password = guillen1; Database = General");

        /*
         * Con esta funcion se logra conectar con la base de datos
         */
        public static void Conectar() {

            conn.Open();
        }
        /*
         * Con esta funcion se logra Desconectar de la base de datos
         */
        public static void Desconectar()
        {

            conn.Close();
        }

        //---------------------------------------Usuarios------------------------------
        /*
         * Esta funcion hace la peticion de traer todos los usuarios contenidos en la tabla Usuarios
         */
        public static DataTable Consultar_Usuario()
        {
            string query = "select * from \"Usuarios\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         * Esta funcion trae un usuario con un correo en especifico , al ser una llave primaria no se puede repetir por lo que solo traera 1 siempre y cuando exista 
         */
        public static DataTable Consultar_UsuarioPerfil(string correo)
        {
            string query = "select * from \"Usuarios\" where \"Correo\" = '"+ correo +"'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         * Esta funcion realiza un insert a la tabla usuario con todos los atributos necesarios para el manejo de la informacion
         */
        public static void Registrar_Usuario(string nombre, string apellido, string correo, string Contrasena, string direccion, string continente, string pais)
        {
            string query = "Insert into \"Usuarios\" values('"+nombre+"','"+apellido+"','"+correo+"','"+ Contrasena + "','"+direccion+"','"+continente+"','"+pais+"')";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return; 
        }
        /*
         * Esta funcion edita un usuario tomando como referencia el correo, todo lo demas lo puede editar
         */
        public static void Editar_Usuario(string nombre, string apellido, string correo, string Contrasena, string direccion, string continente, string pais)
        {
            string query = "Update \"Usuarios\" set \"Nombre\" ='" + nombre + "',\"Apellido\" = '" + apellido + "',\"Correo\" = '" + correo + "', \"Contrasena\" = '" + Contrasena + "',\"Direccion\" = '" + direccion + "',\"Continente\" = '" + continente + "',\"Pais\" = '" + pais + "'" + "where \"Correo\" = '"+correo+"'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        /*
         * Esta funcion borra un usuario de la base de datos ,tomando como referencia el correo
         */
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
        /*
         * Esta funcion trae todos los dispositivos contenidos en la tabla Dispositivo 
         */
        public static DataTable Consultar_Dispositivo()
        {
            string query = "select * from \"Dispositivo\"";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion trae todos los dispositivos que se encuentren activos , todos lo que tengan true
         */
        public static DataTable Consultar_Dispositivo_Activo()
        {
            string query = "select * from \"Dispositivo\" " + "where \"Activo\" = " + true + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion trae un dispositivo con el numeor de serie ingresado
         */
        public static DataTable Consultar_DispositivoSerie(int serie)
        {
            string query = "select * from \"Dispositivo\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         *Esta funcion trae todos los dispositivos que esten inactivos, esten en false y retorna el dispositivo con la serie indicada siempre y cuando este inactivo
         */
        public static DataTable Consultar_DispositivoSerieInactivo(int serie)
        {
            string query = "select * from \"Dispositivo\" " + "where \"Serie\" = " + serie + "and \"Activo\" = false";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         * Esta funcion une dos tablas dispositivos y distribuidores y devuelve una tabla mas grande con todos los datos de ambas tablas
         */
        public static DataTable Consultar_Dispositivo_XRegion()
        {
            string query = "SELECT \"NombreD\",\"Continente\" FROM  \"Distribuidores\" inner join \"Dispositivo\" on \"Distribuidor\" = \"NombreD\"; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         *Esta funcion trae todos los dispositivos que esten inactivos, esten en false y retorna el dispositivo con la serie indicada siempre y cuando este inactivo
         */
        public static DataTable Consultar_Dispositivo_NoActivo()
        {
            string query = "select * from \"Dispositivo\" " + "where \"Activo\" = " + false + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion realiza un insert donde agrega un dispositvio en la base de datos con los distintos atributos necesarios para ser manejado
         */
        public static void Agregar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int  t_garantia, Boolean activo, string  historialDuenos ,string distr,string Agregado,string Dueno,int precio)
        {

            string query = "Insert into \"Dispositivo\" values(" + serie + ",'" + marca + "'," + consumo + ",'" + aposento + "','" + nombre + "','" + descripcion + "'," + t_garantia + "," + activo + ", ' " + historialDuenos + "','" + distr + "','" + Agregado + "','"+ Dueno + "',"+precio+")";
            conn.Close();
            conn.Open();
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conector.ExecuteNonQuery();
            return;
        }

        /*
         * Esta funcion edita un dispositivo tomando como referencia el numero de serie el cual no se puede cambiar luego de ser ingresado
         */
        public static void Editar_Dispositivo(int serie, string marca, int consumo, string aposento, string nombre, string descripcion, int t_garantia, Boolean activo, string historialDuenos,string distr,string Agregado,string Dueno,int precio)
        {
            string query = "Update \"Dispositivo\" set \"Serie\" =" + serie + ",\"Marca\" = '" + marca + "',\"Consumo_Electrico\" = " + consumo + ", \"Aposento\" = '" + aposento + "',\"Nombre\" = '" + nombre + "',\"Descripcion\" = '" + descripcion + "',\"Tiempo_Garantia\" = " + t_garantia + ", \"Activo\"= "+activo+ ",\"Historial_Duenos\"= '" + historialDuenos+"',\"Distribuidor\"='"+distr + "',\"AgregadoPor\"='" + Agregado + "',\"Dueno\"='" + Dueno + "', \"Precio\" = "+precio+"  " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        /*
         * En esta funcion borra el dispositivo que contiene el nuemro de serie que se ha ingresado
         */
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

        /*
         * Esta funcion une dos tablas dispositivos y distribuidores y devuelve una tabla mas grande con todos los datos de ambas tablas, ordenado por el Contienete
         */
        public static DataTable Consultar_DispositivoXRegion()
        {
            string query = "SELECT * FROM \"Dispositivo\" inner join \"Distribuidores\" on \"Distribuidores\".\"NombreD\" = \"Dispositivo\".\"Distribuidor\"   Order by \"Continente\" ASC; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         *  Esta funcion tare todos los dispositivos que tienen el dueño ingresado
         */
        public static DataTable Consultar_DispositivoCorreo(string correo)
        {
            string query = "select * from \"Dispositivo\" " + "where \"Dueno\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        //------------------------------------Historial-------------------------------
        /*
         * Esta funcion agrega un historial conteniendo el numero de serie , fecha y tiempo que duro encendido 
         */
        public static void Agregar_Historial(int serie,DateTime fecha,int Tencendido) { 
            string query = "Insert into \"Historial\" values(" + serie + ",'" + String.Format("{0:M/d/yyyy HH:mm:ss}", fecha) + "'," + Tencendido + ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }
        /*
         * Esta funcion tare una lista de historial del dispositivo con la serie ingresada
         */
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
        /*
         *Esta funcion agrega una factura con todos los datos requeridos tomando como datos unicos , la serie y el nuemro de factura 
         */
        public static void Agregar_Factura(int serie, int factura, DateTime Tcompra,string dispositivo,int precio)
        {
            string query = "Insert into \"Factura\" values(" + factura + "," +serie + " , '" + String.Format("{0:M/d/yyyy HH:mm:ss}", Tcompra) + "','" + dispositivo +"'," + precio + ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }
        /*
         * En esta funcion consulta a la tabla Factura por el numero de serie del dispositivo al cual se le realiza una factura
         */

        public static DataTable Consultar_Factura(int serie)
        {
            string query = "select * from \"Factura\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Retorna toda la tabla factura
         */
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

        /*
         * Esta funcion agrega a la base de datos un certificado de garantia con todos los atributos puestos en la funcion
         */
        public static void Agregar_Certificado( DateTime Tcompra, DateTime Tfin, string marca, string nombre,int serie)
        {
            string query = "Insert into \"Certificado de Garantia\" values('" + String.Format("{0:M/d/yyyy HH:mm:ss}", Tcompra) + "','" + String.Format("{0:d/M/yyyy HH:mm:ss}", Tfin) + "','" + marca + "','" + nombre + "',"+ serie+  ")";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }

        /*
         * Esta funcion consulta y retorna un certificado de garantia que corresponde al dispositivo con el numero de serie ingresado
         */
        public static DataTable Consultar_Certificado(int serie)
        {
            string query = "select * from \"Certificado de Garantia\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion retorna todos los valores de la tabla Certificado Garantia 
         */
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
        /*
         * Esta funcion agrega a la base de datos un aposento que se relaciona con un usuario
         */
        public static void Agregar_Aposento(string correo,  string aposento)
        {
            string query = "Insert into \"Aposento\" values('" + correo + "','" + aposento + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }
        /*
         * Esta funcion consulta por aposentos que corresponden a un correo en especifico
         */
        public static DataTable Consultar_Aposento(string correo)
        {
            string query = "select * from \"Aposento\" " + "where \"Correo\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion borra todos los aposentos guardados al nombre del usuario o correo ingresado
         */
        public static void Borrar_Aposento(string correo)
        {
            string query = "Delete from \"Aposento\" " + "where \"Correo\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            conn.Close();
            return;
        }
        //---------------------------------------------------------------Pedidos-------------------------------------------------------------------

        /*
         * Esta funcion agrega un pedido  a la base de datos con los datos correspondientes 
         */
        public static void Agregar_Pedido(int pedido, DateTime  Fecha, string dispositivo,string marca,int serie, int monto,string usuario)
        {
            string query = "Insert into \"Pedidos\" values(" + pedido + " , '" + String.Format("{0:M/d/yyyy HH:mm:ss}", Fecha) + "','"+ dispositivo+"','"+ marca +"',"+serie+","+monto+ ",'" + usuario + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }
        /*
         * Esta funcion consulta un pedido correspondido al dispositivo con el numero de serie ingresado
         */
        public static DataTable Consultar_Pedido(int serie)
        {
            string query = "select * from \"Pedidos\" " + "where \"Serie\" = " + serie + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion consulta un pedido,correspondiente a un usuario ingresado y ordena la tbla con respecto al numeor de pedido de ese usuario
         */
        public static DataTable Consultar_PedidoU(string usuario)
        {
            string query = "select * from \"Pedidos\"  " + "where \"Usuario\" = '" + usuario + "'"+ "  ORDER BY \"#_Pedido\" ASC ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion borra los pedidos tomando como referencia  el correo del usuario
         */
        public static void Borrar_Pedidos(string correo)
        {
            string query = "Delete from \"Pedidos\" " + "where \"Usuario\" = '" + correo + "'";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            conn.Close();
            return;
        }

        //--------------------------------------------------------Distribuidores------------------------------------------------------------------------
        /*
         * Esta funcion agrega un distribuidor a la base de datos , con los atributos correspondiente
         */
        public static void Agregar_Distribuidor(int Cjuridica, string Nombre, string Continente, string pais)
        {
            string query = "Insert into \"Distribuidores\" values(" + Cjuridica + " , '"  + Nombre + "','" + Continente + "','" + pais + "')";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            conn.Close();
            conn.Open();
            conector.ExecuteNonQuery();
            return;
        }
        /*
         * Esta funcion realiza una consulta a la tabla Distribuidores retornando el distribuidor con ese numero de cedula juridica 
         */
        public static DataTable Consultar_Distribuidor(int Cjuridica)
        {
            string query = "select * from \"Distribuidores\" " + "where \"Cedula_Juridica\" = " + Cjuridica + "";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }

        /*
         * Esta funcion consulta un Distribuidor con respecto a su nombre
         */
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
        /*
         * Esta funcion genera un reporte, uniendo dos tablas Historial y Dispositivo , correspondiente a un usuario y una fecha en la cual lso datos deben estar entre ese valor
         */
        public static DataTable Reporte_Consumo(string correo,DateTime primer, DateTime segundo)
        {
            string query = "SELECT * FROM \"Dispositivo\" inner join \"Historial\" on \"Historial\".\"Serie\" = \"Dispositivo\".\"Serie\" where \"Dueno\" = '"+ correo +"' AND \"Fecha\"  BETWEEN '" + String.Format("{0:M/d/yyyy HH:mm:ss}", primer) + "' AND '"+ String.Format("{0:M/d/yyyy HH:mm:ss}", segundo) + "'  Order by \"Fecha\" ASC; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*
         * Esta funcion no recibe ningun parametro y retorna una lista de tipos de dispositivos ordenados por nombre y el conte de cuantas veces se repite
         */
        public static DataTable Reporte_Dispositivo()
        {
            string query = "SELECT \"Nombre\", count(*) FROM \"Dispositivo\" GROUP BY \"Nombre\" HAVING COUNT(*)> 0 Order BY \"count\" DESC; ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        /*Este reporte tampoco recibe nada y retorna la fecha de la tabla historial
         * 
         */
        public static DataTable Reporte_Periodo_del_dia()
        {
            string query = "SELECT \"Fecha\" FROM \"Historial\"  ";
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
        //--------------------------------------------------------------------Excel----------------------------------------
        /*
         * Esta funcion recibe un query el cual se va formando en otra fucnion y luego se ejecuta
         */
        public static DataTable Insertar_Excel(string query)
        {
           
            NpgsqlCommand conector = new NpgsqlCommand(query, conn);
            NpgsqlDataAdapter datos = new NpgsqlDataAdapter(conector);
            DataTable tabla = new DataTable();
            datos.Fill(tabla);
            return tabla;
        }
    }
}