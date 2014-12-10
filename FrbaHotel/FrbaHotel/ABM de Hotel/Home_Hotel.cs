using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Hotel
{
    class Home_Hotel: Home
    {
        public static SqlCommand obtenerComandoRegimenes(SqlConnection conn)
        {
            string busqueda = "SELECT DISTINCT [Descripcion] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Regimen]";          //búsqueda básica de regímenes
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
        public static SqlCommand obtenerComandoCiudades(SqlConnection conn)
        {

            string busqueda = "SELECT DISTINCT [Nombre] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Ciudad]";          //búsqueda básica de ciudades
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
    }
}
