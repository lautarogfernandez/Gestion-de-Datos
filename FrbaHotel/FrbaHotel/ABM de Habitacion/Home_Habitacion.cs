using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace FrbaHotel.ABM_de_Habitacion
{
    class Home_Habitacion: Home
    {
        public static SqlCommand obtenerComandoTipo_Habitacion(SqlConnection conn)
        {
            string busqueda = "SELECT DISTINCT [Descripcion] "
                                             + "FROM [GD2C2014].[Team_Casty].[Tipo_Habitacion]";          //búsqueda básica
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
    }
}
