using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Facturacion
{
    
    public partial class registrar : Form
    {
        public bool pagado = true;
        public int codigo_estadia;
        
        public registrar()
        {
            InitializeComponent();
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            if (pagado)
            {
                MenuPrincipal menu = new MenuPrincipal();
                menu.Show();
                this.Hide();
            }
            else
            {
                string msj_error = "No puede salir sin registrar el pago";
                MessageBox.Show(msj_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_facturar_Click(object sender, EventArgs e)
        {
            if (txt_estadia.Text != string.Empty)
            {


                try
                {
                    using (SqlConnection conn = Home.obtenerConexion())
                    {
                        //create procedure TEAM_CASTY.Facturar
                        //@cod_Estadia numeric(18), @fecha datetime, @cod_forma_pago numeric(18)
                        SqlParameter precio = new SqlParameter("@money", SqlDbType.Money)
                        {
                            Direction = ParameterDirection.Output
                        };
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].Facturar";
                            cmd.Parameters.Add(new SqlParameter("@cod_Estadia", Convert.ToInt32(txt_estadia.Text)));
                            cmd.Parameters.Add(new SqlParameter("@fecha", Home_factura._fechaHoySql()));
                            cmd.Parameters.Add(new SqlParameter("@cod_forma_pago", 1));
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_factura._codigo_hotel));                            
                            cmd.Parameters.Add(precio);
                            
                            cmd.ExecuteNonQuery();

                            string msj = string.Format("La factura se ha realizado correctamente, el moto es: USD {0}. Ahora proceda al pago ",precio.Value);
                            DialogResult resultado = MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            button_facturar.Enabled = false;
                            pagado = false;
                            codigo_estadia = Convert.ToInt32(txt_estadia.Text);
                            rb_tarjeta.Visible = true;
                            rb_efectivo.Visible = true;
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
                string msj_error2 = "Ingrese una estadía ";
                MessageBox.Show(msj_error2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }            
        }

        private void button_pagar_Click(object sender, EventArgs e)
        {
            string msj_ok1 = "Pago registrado.";
            MenuPrincipal menu = new MenuPrincipal();
            if (rb_efectivo.Checked)
            {
                MessageBox.Show(msj_ok1, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                menu.Show();
                this.Hide();
            }
            else
            {
                if (rb_tarjeta.Checked)
                {
                    //create procedure  TEAM_CASTY.RegistrarPagoTarjeta
                    //@cod_Estadia numeric(18), @numero_tajeta numeric(18), @banco nvarchar(255)
                    try
                    {
                        using (SqlConnection conn = Home.obtenerConexion())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "[TEAM_CASTY].RegistrarPagoTarjeta";
                                cmd.Parameters.Add(new SqlParameter("@cod_Estadia", codigo_estadia));
                                cmd.Parameters.Add(new SqlParameter("@numero_tajeta", Convert.ToInt32(txt_tarjeta.Text)));
                                cmd.Parameters.Add(new SqlParameter("@banco", txt_banco.Text));
                                cmd.ExecuteNonQuery();

                                MessageBox.Show(msj_ok1, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                menu.Show();
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
                    string msj_error3 = "Seleccione un tipo de pago.";
                    MessageBox.Show(msj_error3, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void rb_tarjeta_CheckedChanged(object sender, EventArgs e)
        {
            if (rb_tarjeta.Checked)
            {
                button_pagar.Visible = true;
                l_b.Visible = true;
                l_t.Visible = true;
                txt_banco.Visible = true;
                txt_tarjeta.Visible = true;
            }
            else
            {
                button_pagar.Visible = true;
                l_b.Visible = false;
                l_t.Visible = false;
                txt_banco.Visible = false;
                txt_tarjeta.Visible = false;
            }
        }

        private void txt_estadia_KeyPress(object sender, KeyPressEventArgs e)
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

        private void registrar_Load(object sender, EventArgs e)
        {

        }


    }
}
