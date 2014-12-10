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
namespace FrbaHotel.Registrar_Consumible
{
    class Home_Consumible : Home
    {

        public static SqlCommand obtenerComandoConsumibles(SqlConnection conn)
        {
            string busqueda = "select [Descripcion]  from [TEAM_CASTY].Consumible";
            SqlCommand cmd = new SqlCommand(busqueda, conn);
                return cmd;
        }
    }
}
