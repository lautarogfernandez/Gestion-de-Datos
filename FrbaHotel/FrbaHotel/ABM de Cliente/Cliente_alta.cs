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
            string busqueda = "SELECT DISTINCT [Tipo_Documento] "
                                                         + "FROM [GD2C2014].[Team_Casty].[Tipo_Documento]";          //búsqueda básica
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
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
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            if (txt_apellido.Text != string.Empty && txt_nombre.Text != string.Empty && txt_mail.Text != string.Empty && txt_numero_documento.Text != string.Empty
                && txt_nacionalidad.Text != string.Empty && cmb_tipo_documento.SelectedText != string.Empty && dtp_fecha_nacimiento.Value < DateTime.Today)
            {
                string mensaje = "INSERT INTO [GD2C2014].[Team_Casty].[vistaClientes] " +
                                "([Apellido],[Calle],[Departamento],[Localidad],[Mail],[Nacionalidad],[Nombre],[Numero Calle],[Numero Documento]" +
                                ",[Pais],[Piso],[Telefono],[Tipo Documento],[Fecha Nacimiento]) VALUES" +
                                "(@Apellido,@Calle,@Departamento,@Localidad,@Mail,@Nacionalidad,@Nombre,@NumCalle,@NumDoc,@Pais" +
                                ",@Piso,@Telefono,@TipoDoc,@FechaNacimiento)";
                try
                {
                    string connectionString = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";
                    using (SqlConnection conn =
                        new SqlConnection(connectionString))
                    {
                        conn.Open();
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
            else
            {
                string msj = "Por favor complete los controles obligatorios faltantes \n";
                MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            form.Show();
            this.Hide();
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

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_numero_calle_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txt_piso_KeyPress(object sender, KeyPressEventArgs e)
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
