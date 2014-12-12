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
        //Codigo,Username,  Apellido, Nombre,Mail, [Tipo de Documento], [Numero de Documento],
        //Telefono, Direccion, [Fecha de Nacimiento]
        public string _codigo, _username, _apellido, _nombre, _mail, _tipo_de_documento, _numero_de_documento
            , _telefono, _direccion, _fecha_nacimiento;
        public bool _habilitado;
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
