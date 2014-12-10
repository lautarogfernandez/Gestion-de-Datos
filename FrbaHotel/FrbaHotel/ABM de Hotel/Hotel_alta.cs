using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Hotel
{
    public partial class Hotel_alta : Form
    {
        public int cantidad_estrellas = 0;
        public Hotel_alta()
        {
            InitializeComponent();
            SqlConnection conn = Home_Hotel.obtenerConexion();
            SqlCommand cmd2 = Home_Hotel.obtenerComandoCiudades(conn);
            SqlCommand cmd = Home_Hotel.obtenerComandoRegimenes(conn);
            try
            {
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    cmb_ciudad.Items.Add(reader2["Nombre"].ToString());
                }
                reader2.Close();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_tipos_regimenes.Items.Add(reader["Descripcion"].ToString());
                }
                reader.Close();

            }
            catch (SqlException exc)
            {
                Home_Hotel.mostrarMensajeErrorSql(exc);
            }

            conn.Close();
        }

        private void Hotel_alta_Load(object sender, EventArgs e)
        {
            
        }
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            //barra_progreso.ForeColor = Color.Green;
            //barra_progreso.Value = 100;
            if (txt_nombre.Text != string.Empty && txt_mail.Text != string.Empty && txt_calle.Text != string.Empty && cmb_ciudad.Text!=string.Empty
                && list_tipos_regimenes.SelectedItems.Count != 0 && txt_numero_calle.Text!=string.Empty && txt_pais.Text!=string.Empty )
            {
                string mensaje = "INSERT INTO [GD2C2014].[Team_Casty].[vistaHoteles] " +
                                "[Ciudad],[Calle],[Numero Calle],[Telefono],[Mail],[Cantidad de estrellas]"+
                                " VALUES ()";
                try
                {
                    using (SqlConnection conn =
                        Home_Hotel.obtenerConexion())
                    {
                        using (SqlCommand cmd =
                            new SqlCommand(mensaje, conn))
                        {
                                cmd.Parameters.AddWithValue("@Calle", txt_calle.Text);
                                cmd.Parameters.AddWithValue("@Mail", txt_mail.Text);
                            //    cmd.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                                cmd.Parameters.AddWithValue("@NumCalle", txt_numero_calle.Text);
                                cmd.Parameters.AddWithValue("@Pais", txt_pais.Text);
                                cmd.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                                cmd.Parameters.AddWithValue("@Cant_estrellas", cantidad_estrellas);
                                cmd.Parameters.AddWithValue("@Ciudad",cmb_ciudad.Text);


                            int rows = cmd.ExecuteNonQuery();
                            //rows number of record got updated

                            string msj = "Hotel agregado con éxito \n";
                            MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Hotel.mostrarMensajeErrorSql(exc);
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

        private void lbl_tipo_regimenes_Click(object sender, EventArgs e)
        {

        }
        #region CheckedList_Regimenes
        private void list_tipos_regimenes_MouseHover(object sender, EventArgs e)
        {
            list_tipos_regimenes.IntegralHeight=true;
            list_tipos_regimenes.Height = list_tipos_regimenes.PreferredHeight;
            list_tipos_regimenes.BringToFront();
        }

        private void list_tipos_regimenes_MouseLeave(object sender, EventArgs e)
        {
            list_tipos_regimenes.IntegralHeight=false;
            list_tipos_regimenes.Height = 17;
        }
        #endregion
        #region cantidadEstrellas
        private void rb_1estrella_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 1;
        }

        private void rb_2estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 2;
        }

        private void rb_3estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 3;
        }

        private void rb_4estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 4;
        }

        private void rb_5estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 5;
        }

        #endregion

        private void cmb_ciudad_SelectedIndexChanged(object sender, EventArgs e)
        {

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



    }
}
