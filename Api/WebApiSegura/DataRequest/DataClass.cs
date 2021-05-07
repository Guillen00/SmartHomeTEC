using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto1.DataRequest
{
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
        public string Historial_Dueños { get; set; }
        public string Distribuidor { get; set; }
        public string AgregadoPor { get; set; }
        public string Dueño { get; set; }
    }

    public class Historial
    {
        public int Serie { get; set; }
        public DateTime Fecha { get; set; }
        public int Tiempo_Encendido { get; set; }
       
    }

    public class Distribuidores
    {
        public int Cedula_Juridica { get; set; }
        public string Nombre { get; set; }
        public string Continente { get; set; }
        public string Pais { get; set; }
        
    }

    public class Usuario
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Direccion { get; set; }
        public string Continente { get; set; }
        public string Pais { get; set; }
        
    }

    public class Factura
    {
        public int Num_Factura { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string dispositivo { get; set; }
        public int Precio { get; set; }
        public int serie { get; set; }

    }

    public class Certificado_Garantia
    {
        public DateTime Fecha_Compra { get; set; }
        public DateTime Fecha_Fin_Garantia { get; set; }
        public string Marca { get; set; }
        public string dispositivo { get; set; }
        public int Serie { get; set; }

    }

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

    public class Aposentos
    {
        public string Correo { get; set; }
        public string Nombre { get; set; }

    }

    public class Reporte
    {
        public string Correo { get; set; }
        public DateTime mes { get; set; }

    }

    public class Dashboard
    {
        public int DispositivosGestionados { get; set; }
        public float Promedio { get; set; }
        public int America { get; set; }
        public int Europa { get; set; }
        public int Asia { get; set; }
        public int Africa { get; set; }
        public int Oceania { get; set; }
        public Dispositivo[] Disp { get; set; }

    }

}