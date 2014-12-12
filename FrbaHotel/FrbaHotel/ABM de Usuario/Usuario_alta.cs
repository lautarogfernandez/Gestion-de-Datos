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

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class Usuario_alta : Form
    {
        public DataTable tabla_roles_hoteles;
        public Usuario_alta()
        {
            InitializeComponent();
            SqlConnection conn = Home_Usuario.obtenerConexion();
            SqlCommand cmd=Home_Usuario.obtenerComandoTipo_Documento(conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.cmb_tipo_documento.Items.Add(reader["Tipo_Documento"].ToString());
                }
                reader.Close();
            }
            catch (SqlException exc)
            {
                Home_Usuario.mostrarMensajeErrorSql(exc);
            }

            conn.Close();
        }

        private void button_seleccionarRoles_Click(object sender, EventArgs e)
        {
            using (var form = new Usuario_elegir_roles_por_hotel(""))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tabla_roles_hoteles = form.tabla_valores;            //values preserved after close
                    //Do something here with these values
                }
            }
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (cmb_tipo_documento.SelectedIndex >= 0)
            {
                if (dtp_fecha_nacimiento.Value < Home_Usuario._fechaHoy)
                {
                    if (txt_apellido.Text != string.Empty && txt_direccion.Text != string.Empty && txt_mail.Text != string.Empty
                        && txt_numero_documento.Text != string.Empty && txt_pass.Text != string.Empty && txt_repetirpass.Text != string.Empty &&
                        txt_telefono.Text != string.Empty && txt_username.Text != string.Empty)
                    {
                        if (txt_pass.Text == txt_repetirpass.Text)
                        {
                            try
                            {
                                using (SqlConnection conn = Home_Usuario.obtenerConexion())
                                {
                                    using (SqlCommand cmd = conn.CreateCommand())
                                    {
                                        cmd.CommandType = CommandType.StoredProcedure;
                                        //procedure TEAM_CASTY.crearUsuario
                                        //(@username nvarchar(255),@password nvarchar(255),@nombre nvarchar(255),@apellido nvarchar(255),
                                        //@tipoDocumento nvarchar(255), @numeroDocumento numeric(18), @mail nvarchar(255), @telefono nvarchar(50),
                                        //@direccion nvarchar(255), @fechaNacimiento datetime, @tabla TEAM_CASTY.t_tablaHotelYRol readonly)
                                        cmd.CommandText = "[TEAM_CASTY].crearUsuario";
                                        cmd.Parameters.Add(new SqlParameter("@username", txt_username.Text));
                                        string password = Encriptado.Encriptador.SHA256Encripta(txt_pass.Text);
                                        cmd.Parameters.Add(new SqlParameter("@password", password));
                                        cmd.Parameters.Add(new SqlParameter("@nombre", txt_nombre.Text));
                                        cmd.Parameters.Add(new SqlParameter("@apellido", txt_apellido.Text));
                                        cmd.Parameters.Add(new SqlParameter("@tipoDocumento", cmb_tipo_documento.Text));
                                        cmd.Parameters.Add(new SqlParameter("@numeroDocumento", txt_numero_documento.Text));
                                        cmd.Parameters.Add(new SqlParameter("@mail", txt_mail.Text));
                                        cmd.Parameters.Add(new SqlParameter("@telefono", txt_telefono.Text));
                                        cmd.Parameters.Add(new SqlParameter("@direccion", txt_direccion.Text));
                                        cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", dtp_fecha_nacimiento.Text));
                                        cmd.Parameters.Add(new SqlParameter("@tabla", tabla_roles_hoteles));
                                        cmd.ExecuteNonQuery();
                                        string msj = "Usuario agregado con éxito";
                                        MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                        MenuPrincipal formularioPrincipal = new MenuPrincipal();
                                        this.Hide();
                                        formularioPrincipal.Show();
                                    }
                                }

                            }
                            catch (SqlException exc)
                            {
                                Home_Usuario.mostrarMensajeErrorSql(exc);
                            }
                        }
                        else
                        {
                            string msj = "Las contraseñas no son iguales";
                            MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                    }
                    else
                    {
                        string msj = "Complete todos los controles obligatorios";
                        MessageBox.Show(msj, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    string msj = "Seleccione una fecha válida";
                    MessageBox.Show(msj, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
            else
            {
                string msj = "Seleccione un documento valido";
                MessageBox.Show(msj, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Usuario_alta_Load(object sender, EventArgs e)
        {

        }

        private void txt_numero_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }

    }
}
