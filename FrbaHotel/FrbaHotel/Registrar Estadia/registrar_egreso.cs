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


namespace FrbaHotel.Registrar_Estadia
{
    public partial class registrar_egreso: Form
    {
        bool _buscaEmail = false;
        bool _buscaTipoDoc = false;
        bool _buscaDoc = false;
        bool _buscaCod = false;
        t_reserva _reserva = new t_reserva();
        DataTable tablaClientes = new DataTable();    //Creo Tabla para los resultados
        public registrar_egreso()
        {
            InitializeComponent();
            SqlConnection conn = Home_Estadia.obtenerConexion();
            SqlCommand cmd = Home_Estadia.obtenerComandoTipo_Documento(conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    this.cmb_tipoIdentificacion.Items.Add(reader["Tipo_Documento"].ToString());
                }
                reader.Close();
            }
            catch (SqlException exc)
            {
                Home_Estadia.mostrarMensajeErrorSql(exc);
            }

            conn.Close();

        }
        #region txt_Email
        private void txt_Email_TextChanged(object sender, EventArgs e)
        {
            if (txt_Email.TextLength > 0 && txt_Email.Text != "Ingrese e-mail")
            {
                txt_Email.ForeColor = SystemColors.MenuText;
                _buscaEmail = true;
            }

        }

        private void txt_Email_Click(object sender, EventArgs e)
        {
            if (txt_Email.Text == "Ingrese e-mail")
            {
                txt_Email.Text = string.Empty;
                txt_Email.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Email_Leave(object sender, EventArgs e)
        {
            if (txt_Email.Text == "Ingrese e-mail" ||
                txt_Email.Text == string.Empty)
            {
                txt_Email.Text = "Ingrese e-mail";
                txt_Email.ForeColor = SystemColors.ScrollBar;
                _buscaEmail = false;
            }
        }
        #endregion
        #region txt_codigo_estadia
        private void txt_codigo_estadia_TextChanged(object sender, EventArgs e)
        {
            if (txt_codigo_estadia.TextLength > 0 && txt_codigo_estadia.Text != "Ingrese codigo de estadía")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_codigo_estadia.ForeColor = SystemColors.MenuText;
                _buscaCod = true;
            }
        }

        private void txt_codigo_estadia_Click(object sender, EventArgs e)
        {
            if (txt_codigo_estadia.Text == "Ingrese codigo de estadía")
            {
                txt_codigo_estadia.Text = string.Empty;
                txt_codigo_estadia.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_codigo_estadia_Leave(object sender, EventArgs e)
        {
            if (txt_codigo_estadia.Text == "Ingrese codigo de estadía" ||
                txt_codigo_estadia.Text == string.Empty)
            {
                txt_codigo_estadia.Text = "Ingrese codigo de estadía";
                txt_codigo_estadia.ForeColor = SystemColors.ScrollBar;
                _buscaCod = false;
            }
        }
        #endregion
        #region Numero de Identificacion
        private void txt_numeroIdentificacion_TextChanged(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion.TextLength > 0 && txt_numeroIdentificacion.Text != "Ingrese nombre")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_numeroIdentificacion.ForeColor = SystemColors.MenuText;
                _buscaDoc = true;
            }
        }

        private void txt_numeroIdentificacion_Click(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion.Text == "Ingrese número de identificación")
            {
                txt_numeroIdentificacion.Text = string.Empty;
                txt_numeroIdentificacion.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_numeroIdentificacion_Leave(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion.Text == "Ingrese número de identificación" ||
                txt_numeroIdentificacion.Text == string.Empty)
            {
                txt_numeroIdentificacion.Text = "Ingrese número de identificación";
                txt_numeroIdentificacion.ForeColor = SystemColors.ScrollBar;
                _buscaDoc = false;
            }
        }
        #endregion
        private void cmb_tipoIdentificacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            _buscaTipoDoc = true;
        }
        private void Reserva_terminar_Load(object sender, EventArgs e)
        {

        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            tablaClientes.Clear();
            grp_personas.Enabled = false;
            if (_buscaDoc && _buscaEmail && _buscaTipoDoc && _buscaCod)
            {
                try
                {
                    string busqueda = string.Format("SELECT * "
                     + " FROM [GD2C2014].[Team_Casty].[vistaClientes] "
                     + " WHERE [Mail] = '{0}' AND [Tipo Documento]='{1}' AND [Numero Documento]={2}", txt_Email.Text,
                     cmb_tipoIdentificacion.SelectedItem, txt_numeroIdentificacion.Text);           //búsqueda básica
                    label_progreso.Text = "Buscando...";       //Imprime en la barra de progreso
                    SqlConnection conn = Home_Estadia.obtenerConexion();                       //Abrir Conexión
                    SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
                    barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                    adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                    adaptador.Fill(tablaClientes);                                                                                                    //LLeno tabla de resultados
                    if (tablaClientes.Rows.Count == 0)
                    {
                        string msj = "No se encontró el cliente \n";
                        MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else if (tablaClientes.Rows.Count != 1)
                    {
                        string msj = "Existe más de un cliente con esos datos. \n";
                        MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {
                        int codigoCliente = Convert.ToInt32(tablaClientes.Rows[0].ItemArray[0]);
                        int codigoReserva = Convert.ToInt32(txt_codigo_reserva.Text);
                        string fecha = Home_Estadia._fechaHoySql();

                        //function  TEAM_CASTY.Reservas_Para_Check_IN
                        //(@fecha datetime, @hotel numeric(18))
                        string busqueda2 = string.Format("SELECT * "
                 + " FROM [GD2C2014].[Team_Casty].[Reservas_Para_Check_IN] ('{0}',{1}) "
                 + " WHERE [ID_Cliente_Reservador] = {2} AND [Cod_Reserva]={3}", fecha, Home_Estadia._codigo_hotel
                 , codigoCliente, codigoReserva);
                        DataTable tablaReservas = new DataTable();                                                                                 //Creo Tabla para los resultados
                        adaptador = new SqlDataAdapter(busqueda2, conn);                                                              //Busco en la sesión abierta
                        adaptador.Fill(tablaReservas);                                                                                                    //LLeno tabla de resultados
                        if (tablaReservas.Rows.Count == 0)
                        {
                            string msj = "No existe la reserva de ese código y ese cliente. \n";
                            MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else if (tablaReservas.Rows.Count != 1)
                        {
                            string msj = "No existe la reserva de ese código y ese cliente. \n";
                            MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            string msj = "Se encontró al cliente y a la reserva. \n Puede continuar añadiendo acompañantes.";
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            grp_datos.Enabled = false;
                            grp_personas.Enabled = true;
                            grp_datos2.Enabled = true;
                            grp_alta.Enabled = true;
                            button_registrar.Enabled = true;
                            button_registrar.ForeColor = SystemColors.MenuText;
                            _buscaDoc = false;
                            _buscaEmail = false;
                            _buscaTipoDoc = false;
                            _reserva.cliente = codigoCliente;
                            _reserva.codigo_reserva = codigoReserva;
                            dgv_resultados.DataSource = tablaClientes;
                        }
                    }
                }
                catch (SqlException exc)                                                                                                                             //En un error le aviso
                {
                    barra_progreso.Value = 0;
                    Home_Estadia.mostrarMensajeErrorSql(exc);
                }
            }
            else
            {
                string msj = "Por favor, complete los campos obligatorios.";
                MessageBox.Show(msj, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void button_volver_Click(object sender, EventArgs e)
        {

            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }

        private void Reserva_modificar_Load(object sender, EventArgs e)
        {
        }
        private void button_aceptar_Click_1(object sender, EventArgs e)
        {

        }


        private void txt_numeroIdentificacion_KeyPress(object sender, KeyPressEventArgs e)
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
        private void registrar_egreso_Load(object sender, EventArgs e)
        {

        }
    }
}
