using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Cliente_alta : Form
    {
        public Cliente_alta()
        {
            InitializeComponent();
        }

        private void Cliente_alta_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            string busqueda = "SELECT DISTINCT [Tipo de Documento] "
                                                         + "FROM [GD2C2014].[Team_Casty].[vistaClientes]";          //búsqueda básica
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
                                                    //Busco en la sesión abierta
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();   
                            while (reader.Read())
            {
            }

                            reader.Close();
            }
            catch (SqlException exc)
            {
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message+"\n";
                MessageBox.Show(msj,"Excepcion SQL",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            }

            conn.Close();
        }
    }
}
