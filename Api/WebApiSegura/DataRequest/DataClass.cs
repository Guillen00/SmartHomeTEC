using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/*En este archivo .cs se manejaran todas las clases a utilizar para el manejo de datos, sea en tablas o para la creacion de JSON, tambien para manejar datos que
 * son necesarios para los reportes y diferentes funcionalidades
 * 
 * 
 */
namespace Proyecto1.DataRequest
{
    /*
     * Esta clase maneja la informacion de todos los dispositivos, se puede almacenar temporalmente y transportar la informacion
     */
    public class Dispositivo
    {
        public int Serie { get; set; }
        public string Marca { get; set; }
        public int Consumo_Electrico { get; set; }
        public string Aposento { get; set; }
        public string Nombre { get; set; }
        public string Decripcion { get; set; }
        public int Tiempo_Garantia { get; set; }
        public Boolean Activo { get; set; }
        public string Historial_Duenos { get; set; }
        public string Distribuidor { get; set; }
        public string AgregadoPor { get; set; }
        public string Dueno { get; set; }
        public int Precio { get; set; }
    }
    /*
     * Esta clase maneja la informacion de todos los historiales de los dispositivos, se puede almacenar temporalmente y transportar la informacion
     */
    public class Historial
    {
        public int Serie { get; set; }
        public DateTime Fecha { get; set; }
        public int Tiempo_Encendido { get; set; }
       
    }

    /*
     * Esta clase maneja la informacion de todos los distribuidores, se puede almacenar temporalmente y transportar la informacion
     */
    public class Distribuidores
    {
        public int Cedula_Juridica { get; set; }
        public string Nombre { get; set; }
        public string Continente { get; set; }
        public string Pais { get; set; }
        
    }

    /*
     * Esta clase maneja la informacion de todos los Usuarios, se puede almacenar temporalmente y transportar la informacion
     */
    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string Direccion { get; set; }
        public string Continente { get; set; }
        public string Pais { get; set; }
        
    }

    /*
     * Esta clase maneja la informacion de todas las facturas de los dispositivos creadas por un cliente, se puede almacenar temporalmente y transportar la informacion
     */
    public class Factura
    {
        public int Num_Factura { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string dispositivo { get; set; }
        public int Precio { get; set; }
        public int serie { get; set; }

    }


    /*
     * Esta clase maneja la informacion de todos los certificados de garantia el cual contiene informacion importante del dispositivo,
     * se puede almacenar temporalmente y transportar la informacion
     */
    public class Certificado_Garantia
    {
        public DateTime Fecha_Compra { get; set; }
        public DateTime Fecha_Fin_Garantia { get; set; }
        public string Marca { get; set; }
        public string dispositivo { get; set; }
        public int Serie { get; set; }

    }

    /*
     * Esta clase maneja la informacion de todos los pedidos, cada usuario lleva una cuenta de pedidos, se puede almacenar temporalmente y transportar la informacion
     */
    public class Pedidos
    {
        public int Num_Pedido { get; set; }
        public DateTime Fecha_Hora { get; set; }
        public string dispositivo { get; set; }
        public string Marca { get; set; }
        public int Serie { get; set; }
        public int Monto_Total { get; set; }
        public string Usuario { get; set; }
    }

    /*
     * Esta clase maneja la informacion de todos los aposentos los cuales se relacionan con un usuario por medio del correo
     * , se puede almacenar temporalmente y transportar la informacion
     */
    public class Aposentos
    {
        public string Correo { get; set; }
        public string Aposento { get; set; }

    }

    /*
     * Esta clase maneja la informacion de todos los reportes,con esta clase se logra coordinar un reporte,
     * se puede almacenar temporalmente y transportar la informacion
     */
    public class Reporte
    {
        public string Correo { get; set; }
        public DateTime mes { get; set; }

    }

    /*
     * Esta clase maneja la informacion de la dashboard la cual maneja informacion importante como promedios y numeros regionales,
     * se puede almacenar temporalmente y transportar la informacion
     */
    public class Dashboard
    {
        public int DispositivosGestionados { get; set; }
        public float Promedio { get; set; }
        public int America { get; set; }
        public int Europa { get; set; }
        public int Asia { get; set; }
        public int Africa { get; set; }
        public int Oceania { get; set; }
        public List<Dispositivo> Disp { get; set; }

    }

    /*
     * Esta clase maneja la informacion para poder leer un json, proveniente de un excel y lo pasa a un lista de dispositivos 
     */
    public class Hoja
    {
        public List<Dispositivo> Hoja1 { get; set; }

    }

    /*
     * Esta clase maneja la informacion importante para poder enviar un correo y crear una factura y un certificado de garantia
     */
    public class Valor_PDF
    {
        public int serie { get; set; }
        public string Correo { get; set; }
        public DateTime fecha_compra { get; set; }
        public string dispositivo { get; set; }
        public int Precio { get; set; }
        public string Marca { get; set; }
    }
    /*
     * Esta clase maneja la informacion de la tienda ,donde se crean varias listas de dipositivos dividida por los continentes
     */
    public class Tienda
    {
        public List<Dispositivo> America { get; set; }
        public List<Dispositivo> Europa { get; set; }
        public List<Dispositivo> Asia { get; set; }
        public List<Dispositivo> Africa { get; set; }
        public List<Dispositivo> Oceania { get; set; }


    }

}