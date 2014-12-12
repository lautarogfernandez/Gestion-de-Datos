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
    public partial class Cambiar_contraseña : Form
    {
        public Cambiar_contraseña()
        {
            InitializeComponent();
        }
        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_pass.Text == txt_repetir_pass.Text)
            {
                string password = Encriptado.Encriptador.SHA256Encripta(txt_pass.Text);
                try
                {
                    using (SqlConnection conn = Home.obtenerConexion())
                    {

                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            //TEAM_CASTY.CambiarPassword
                            //(@usuario nvarchar(255),@contraseña nvarchar(255))
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].CambiarPassword";
                            cmd.Parameters.Add(new SqlParameter("@usuario", Home._nombreUsuario));
                            cmd.Parameters.Add(new SqlParameter("@contraseña", password));
                            cmd.ExecuteNonQuery();
                            //rows number of record got updated
                            string msj = "Contraseña modificada con éxito \n";
                            MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MenuPrincipal menuPrincipal = new MenuPrincipal();
                            menuPrincipal.Show();
                            this.Hide();

                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home.mostrarMensajeErrorSql(exc);
                }
            }
            else
            {
                string msj = "Las contraseñas son diferentes \n";
                MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void Cambiar_contraseña_Load(object sender, EventArgs e)
        {

        }

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {
            if (txt_pass.Text.Length >= 4 && txt_repetir_pass.Text.Length >= 4)
            {
                button_aceptar.Enabled = true;
                button_aceptar.ForeColor = SystemColors.MenuText;
            }
            else
            {
                button_aceptar.Enabled = false;
                button_aceptar.ForeColor = SystemColors.ScrollBar;
            }
        }
    }
}
