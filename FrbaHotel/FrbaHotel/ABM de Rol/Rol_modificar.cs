using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Rol
{
    public partial class Rol_modificar : Form
    {
        public Rol_modificar()
        {
            InitializeComponent();
        }

        private void Rol_modificar_Load(object sender, EventArgs e)
        {
            string busqueda = "SELECT [Codigo], [Descripcion] FROM [TEAM_CASTY].FuncionesAsignables ()";
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_funciones.Items.Add(reader["Descripcion"].ToString());
                }
                reader.Close();

            }
            catch (SqlException exc)
            {
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            conn.Close();
        }
        private bool validado()
        {
            return rb_activo.Checked;
        }
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = new DataTable("Funciones");
                table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                for (int i = 0; i < list_funciones.CheckedItems.Count; i++)
                    table.Rows.Add(list_funciones.CheckedItems[i]);
                using (SqlConnection conn = Home.obtenerConexion())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].Alta_Rol";
                        cmd.Parameters.Add(new SqlParameter("@nombre", txt_nombre.Text));
                        cmd.Parameters.Add(new SqlParameter("@funciones", table));
                        cmd.Parameters.Add(new SqlParameter("@Activo", validado()));
                        cmd.ExecuteNonQuery();
                        //rows number of record got updated
                        string msj = "Usuario validado con éxito \n";
                        MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        MenuPrincipal menuPrincipal = new MenuPrincipal();
                        menuPrincipal.Show();
                        this.Hide();

                    }
                }

            }
            catch (SqlException exc)
            {
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
