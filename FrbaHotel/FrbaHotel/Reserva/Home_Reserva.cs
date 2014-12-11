using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;
namespace FrbaHotel.Reserva
{
    public struct t_reserva
    {
        public struct habitacion_reserva
        {
            public string tipo_habitacion;
            public int cantidad;
        }
        public int codigo_hotel;
        public string regimen;
        public DateTime fecha_desde;
        public DateTime fecha_hasta;
        public List<habitacion_reserva> tipos_habitaciones;
        public int cliente;
    }

    class Home_Reserva:Home
    {
        public static SqlCommand obtenerComandoTipo_Documento(SqlConnection conn)
        {
            string busqueda = "SELECT DISTINCT [Tipo_Documento] "
                                             + "FROM [GD2C2014].[Team_Casty].[Tipo_Documento]";          //búsqueda básica
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
    }
}
