using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Usuario
{
    public struct valoresDataGridView
    {
        public string _cantidad_estrellas, _ciudad, _pais, _calle, _mail, _telefono, _codigo, _numero_calle, _nombre;
        public List<string> _regimenes;
    }
    class Home_Usuario : Home
    {
        public static SqlCommand obtenerComandoTipo_Documento(SqlConnection conn)
        {
            string busqueda = "SELECT DISTINCT [Tipo_Documento] "
                                             + "FROM [GD2C2014].[Team_Casty].[Tipo_Documento]";          //búsqueda básica
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
        public static SqlCommand obtenerComandoRoles(SqlConnection conn)
        {
            string busqueda = "select [Nombre]  from [TEAM_CASTY].Rol WHERE [Activo]=1";
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            return cmd;
        }
    }
}
