using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class Habitacion_alta : Form
    {
        public Habitacion_alta()
        {
            InitializeComponent();

            SqlConnection conn = Home_Habitacion.obtenerConexion();
            SqlCommand cmd = Home_Habitacion.obtenerComandoTipo_Habitacion(conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.cmb_tipo_habitacion.Items.Add(reader["Descripcion"].ToString());
                }
                reader.Close();
            }
            catch (SqlException exc)
            {
                Home_Habitacion.mostrarMensajeErrorSql(exc);
            }

            conn.Close();


        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            char frente = 'A';

            if (rb_VistaExterior.Checked) { 
                frente='S';
            }

            if (rb_VistaInterior.Checked)
            {
                frente = 'N';
            }

            if (txt_piso.Text != string.Empty && txt_numero.Text != string.Empty &&  txt_descripcion.Text != string.Empty && frente!='A'
                && cmb_tipo_habitacion.SelectedItem.ToString() != string.Empty )
            {
                try
                {
                    using (SqlConnection conn =
                    Home_Habitacion.obtenerConexion())
                    {
                        //create procedure TEAM_CASTY.CargarHabitacion
                        //(@hotel numeric(18), @numero numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255))
                        
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].Actualizar_Reservas";
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_Habitacion._codigo_hotel));
                            cmd.Parameters.Add(new SqlParameter("@numero", Convert.ToInt32(txt_numero.Text)));
                            cmd.Parameters.Add(new SqlParameter("@piso", Convert.ToInt32(txt_numero.Text)));
                            cmd.Parameters.Add(new SqlParameter("@frente", frente));
                            cmd.Parameters.Add(new SqlParameter("@tipo", cmb_tipo_habitacion.SelectedItem));
                            cmd.Parameters.Add(new SqlParameter("@descripcion", txt_descripcion.Text));
                            cmd.ExecuteNonQuery();

                            string msj = string.Format("La habitación se ha cargado correctamente.");
                            DialogResult resultado = MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Habitacion.mostrarMensajeErrorSql(exc);
                }

            }
            else
            {
                string msj = "Por favor complete los controles obligatorios faltantes \n";
                MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
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
