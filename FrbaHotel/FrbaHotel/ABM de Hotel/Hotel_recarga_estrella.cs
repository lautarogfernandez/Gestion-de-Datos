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
    public partial class Hotel_recarga_estrella : Form
    {
        public Hotel_recarga_estrella()
        {
            InitializeComponent();
        }

        private void lbl_modificado_Click(object sender, EventArgs e)
        {

        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu1 = new MenuPrincipal();
            this.Hide();
            menu1.Show();
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (txt_recarga.Text != string.Empty && Convert.ToInt32(txt_recarga.Text) >= 0)
            {
                try
                {
                    using (SqlConnection conn =
                    Home_Hotel.obtenerConexion())
                    {
                        //create procedure TEAM_CASTY.Inserta_Recarga
                        //(@fecha,@recarga)

                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].Insertar_Recarga";
                            cmd.Parameters.Add(new SqlParameter("@fecha", Home_Hotel._fechaHoySql()));
                            cmd.Parameters.Add(new SqlParameter("@recarga", Convert.ToInt32(txt_recarga.Text)));
                            cmd.ExecuteNonQuery();

                            string msj = string.Format("La recarga ha sido correcta.");
                            DialogResult resultado = MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MenuPrincipal menu1 = new MenuPrincipal();
                            this.Hide();
                            menu1.Show();
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
                string msj2 = string.Format("Ingrese una cantidad mayor o igual a 0.");
                MessageBox.Show(msj2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txt_recarga_KeyPress(object sender, KeyPressEventArgs e)
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
