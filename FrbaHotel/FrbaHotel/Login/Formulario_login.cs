using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.Login
{
    public partial class Formulario_login : Form
    {
        public Formulario_login()
        {
            InitializeComponent();
        }

        private void grp_usuario_y_pass_Enter(object sender, EventArgs e)
        {

        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            string password = Encriptado.Encriptador.SHA256Encripta(_txt_password.Text);
            string username = _txt_usuario.Text;
            try
            {
                string connectionString = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";
                using (SqlConnection conn =
                    new SqlConnection(connectionString))
                {
                    
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].validarUsuario";
                        cmd.Parameters.Add(new SqlParameter("@usuario", username));
                        cmd.Parameters.Add(new SqlParameter("@contraseña", password));
                        cmd.ExecuteNonQuery();
                        //rows number of record got updated
                            Home._nombreUsuario = username;
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
                //Log exception
                //Display Error message
            }
        }

        private void Formulario_login_Load(object sender, EventArgs e)
        {

        }

        private void _txt_usuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
