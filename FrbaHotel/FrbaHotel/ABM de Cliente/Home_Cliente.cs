using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace FrbaHotel.ABM_de_Cliente
{
    public struct valoresDataGridView
    {
        public string _tipo_documento, _apellido, _nombre, _pais, _nacionalidad, _localidad,
            _calle, _departamento, _mail, _telefono, _codigo, _numero_documento, _numero_calle, _piso, _fecha_nacimiento;
        public bool _inhabilitado;
    }
    class Home_Cliente : Home
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
