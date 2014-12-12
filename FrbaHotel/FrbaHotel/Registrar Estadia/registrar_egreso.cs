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
        int codigoEstadia;
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
            button_registrar.Enabled = false;
            button_registrar.ForeColor = SystemColors.ScrollBar;
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
                        codigoEstadia = Convert.ToInt32(txt_codigo_estadia.Text);
                        string fecha = Home_Estadia._fechaHoySql();

                        //function  TEAM_CASTY.Estadias_Para_Check_OUT
                        //(@hotel numeric(18))
                        string busqueda2 = string.Format("SELECT * "
                 + " FROM [GD2C2014].[Team_Casty].[Estadias_Para_Check_OUT] ({0}) "
                 + " WHERE [ID_Cliente_Reservador] = {1} AND [Cod_Estadia]={2}", Home_Estadia._codigo_hotel
                 , codigoCliente, codigoEstadia);
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
                            string msj = "Se encontró al cliente y a la estadía. \n Puede realizar el check out.";
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            button_registrar.Enabled = true;
                            button_registrar.ForeColor = SystemColors.MenuText;
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

        private void button_registrar_Click(object sender, EventArgs e)
        {

            string msj = "¿Está seguro que quiere confirmar el egreso? \n Una vez confirmado, no puede volver a modificarse";
            DialogResult resultado = MessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = Home_Estadia.obtenerConexion())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            //create procedure  procedure  TEAM_CASTY.Check_OUT @cod_estadia numeric(18),
                            //@fecha datetime, @usuario nvarchar(255),@hotel numeric(18)

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].Check_OUT";
                            cmd.Parameters.Add(new SqlParameter("@cod_estadia", codigoEstadia));
                            cmd.Parameters.Add(new SqlParameter("@fecha", Home_Estadia._fechaHoySql()));
                            cmd.Parameters.Add(new SqlParameter("@usuario", Home_Estadia._nombreUsuario));
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_Estadia._codigo_hotel));
                            cmd.ExecuteNonQuery();
                            msj = "Check out exitoso. \n";
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MenuPrincipal menu_principal = new MenuPrincipal();
                            menu_principal.Show();
                            this.Hide();
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Estadia.mostrarMensajeErrorSql(exc);
                }
            }
        }
    }
}
