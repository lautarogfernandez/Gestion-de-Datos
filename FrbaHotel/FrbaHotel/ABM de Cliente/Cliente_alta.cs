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
        bool no_crear_form_principal=false;
        public Cliente_alta(bool fuiLlamado)
        {
            InitializeComponent();
            no_crear_form_principal = fuiLlamado;
            SqlConnection conn = Home_Cliente.obtenerConexion();
            SqlCommand cmd=Home_Cliente.obtenerComandoTipo_Documento(conn);
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
                Home_Cliente.mostrarMensajeErrorSql(exc);
            }

            conn.Close();
        }
        public Cliente_alta()
        {
            InitializeComponent();
            SqlConnection conn = Home_Cliente.obtenerConexion();
            SqlCommand cmd = Home_Cliente.obtenerComandoTipo_Documento(conn);
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
                Home_Cliente.mostrarMensajeErrorSql(exc);
            }

            conn.Close();
        }

        private void Cliente_alta_Load(object sender, EventArgs e)
        {
 
        }



        private void button_aceptar_Click(object sender, EventArgs e)
        {
            //barra_progreso.ForeColor = Color.Green;
            //barra_progreso.Value = 100;
            if (cmb_tipo_documento.SelectedIndex >= 0)
            {
                if (txt_apellido.Text != string.Empty && txt_nombre.Text != string.Empty && txt_mail.Text != string.Empty && txt_numero_documento.Text != string.Empty
                    && txt_nacionalidad.Text != string.Empty && dtp_fecha_nacimiento.Value < DateTime.Today)
                {
                    string mensaje = "INSERT INTO [GD2C2014].[Team_Casty].[vistaClientes] " +
                                    "([Apellido],[Calle],[Departamento],[Localidad],[Mail],[Nacionalidad],[Nombre],[Numero Calle],[Numero Documento]" +
                                    ",[Pais],[Piso],[Telefono],[Tipo Documento],[Fecha Nacimiento]) VALUES" +
                                    "(@Apellido,@Calle,@Departamento,@Localidad,@Mail,@Nacionalidad,@Nombre,@NumCalle,@NumDoc,@Pais" +
                                    ",@Piso,@Telefono,@TipoDoc,@FechaNacimiento)";
                    try
                    {
                        using (SqlConnection conn =
                        Home_Cliente.obtenerConexion())
                        {
                            using (SqlCommand cmd =
                                new SqlCommand(mensaje, conn))
                            {
                                if (dtp_fecha_nacimiento.Enabled && dtp_fecha_nacimiento.Value.Date < DateTime.Today)
                                    cmd.Parameters.AddWithValue("@FechaNacimiento", dtp_fecha_nacimiento.Value);
                                if (txt_apellido.Enabled && txt_apellido.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Apellido", txt_apellido.Text);
                                if (txt_calle.Enabled && txt_calle.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Calle", txt_calle.Text);
                                if (txt_departamento.Enabled && txt_departamento.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Departamento", txt_departamento.Text);
                                if (txt_localidad.Enabled && txt_localidad.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Localidad", txt_localidad.Text);
                                if (txt_mail.Enabled && txt_mail.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Mail", txt_mail.Text);
                                if (txt_nacionalidad.Enabled && txt_nacionalidad.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Nacionalidad", txt_nacionalidad.Text);
                                if (txt_nombre.Enabled && txt_nombre.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                                if (txt_numero_calle.Enabled && txt_numero_calle.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@NumCalle", txt_numero_calle.Text);
                                if (txt_numero_documento.Enabled && txt_numero_documento.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@NumDoc", txt_numero_documento.Text);
                                if (txt_pais.Enabled && txt_pais.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Pais", txt_pais.Text);
                                if (txt_piso.Enabled && txt_piso.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Piso", txt_piso.Text);
                                if (txt_telefono.Enabled && txt_telefono.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                                if (cmb_tipo_documento.Enabled && cmb_tipo_documento.Text != string.Empty)
                                    cmd.Parameters.AddWithValue("@TipoDoc", cmb_tipo_documento.Text);

                                int rows = cmd.ExecuteNonQuery();
                                //rows number of record got updated

                                string msj = "Cliente agregado con éxito \n";
                                MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                if (no_crear_form_principal)
                                {
                                    this.Hide();
                                }
                            }
                        }
                    }
                    catch (SqlException exc)
                    {
                        Home_Cliente.mostrarMensajeErrorSql(exc);
                    }

                }
                else
                {
                    string msj = "Por favor complete los controles obligatorios faltantes \n";
                    MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                string msj = "Por favor elija uno de documentos existentes\n";
                MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            if (no_crear_form_principal == false)
            {
                MenuPrincipal form = new MenuPrincipal();
                form.Show();
            }
            this.Hide();
        }
        private void txt_numero_documento_KeyPress_1(object sender, KeyPressEventArgs e)
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

        private void _obli_numeroDoc_Click(object sender, EventArgs e)
        {

        }




    }
}
