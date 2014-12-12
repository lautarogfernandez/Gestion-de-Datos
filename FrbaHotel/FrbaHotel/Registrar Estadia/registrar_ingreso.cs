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
    public partial class registrar_ingreso : Form
    {
        bool _buscaEmail = false;
        bool _buscaTipoDoc = false;
        bool _buscaDoc = false;
        bool _buscaCod = false;
        t_reserva _reserva = new t_reserva();
        DataTable tablaClientes = new DataTable();    //Creo Tabla para los resultados
        public registrar_ingreso()
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
                    this.cmb_tipoIdentificacion2.Items.Add(reader["Tipo_Documento"].ToString());
                }
                reader.Close();
            }
            catch (SqlException exc)
            {
                Home_Estadia.mostrarMensajeErrorSql(exc);
            }

            conn.Close();

        }
        #region txt_Email2
        private void txt_Email2_TextChanged(object sender, EventArgs e)
        {
            if (txt_Email2.TextLength > 0 && txt_Email2.Text != "Ingrese e-mail")
            {
                txt_Email2.ForeColor = SystemColors.MenuText;
                _buscaEmail = true;
            }

        }

        private void txt_Email2_Click(object sender, EventArgs e)
        {
            if (txt_Email2.Text == "Ingrese e-mail")
            {
                txt_Email2.Text = string.Empty;
                txt_Email2.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Email2_Leave(object sender, EventArgs e)
        {
            if (txt_Email2.Text == "Ingrese e-mail" ||
                txt_Email2.Text == string.Empty)
            {
                txt_Email2.Text = "Ingrese e-mail";
                txt_Email2.ForeColor = SystemColors.ScrollBar;
                _buscaEmail = false;
            }
        }
        #endregion
        #region Numero de Identificacion 2
        private void txt_numeroIdentificacion2_TextChanged(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion2.TextLength > 0 && txt_numeroIdentificacion2.Text != "Ingrese nombre")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_numeroIdentificacion2.ForeColor = SystemColors.MenuText;
                _buscaDoc = true;
            }
        }

        private void txt_numeroIdentificacion2_Click(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion2.Text == "Ingrese número de identificación")
            {
                txt_numeroIdentificacion2.Text = string.Empty;
                txt_numeroIdentificacion2.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_numeroIdentificacion2_Leave(object sender, EventArgs e)
        {
            if (txt_numeroIdentificacion2.Text == "Ingrese número de identificación" ||
                txt_numeroIdentificacion2.Text == string.Empty)
            {
                txt_numeroIdentificacion2.Text = "Ingrese número de identificación";
                txt_numeroIdentificacion2.ForeColor = SystemColors.ScrollBar;
                _buscaDoc = false;
            }
        }
        #endregion
        private void cmb_tipoIdentificacion2_SelectedIndexChanged(object sender, EventArgs e)
        {
            _buscaTipoDoc = true;
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

        #region codigo_de_reserva
        private void txt_codigo_reserva_TextChanged(object sender, EventArgs e)
        {
            if (txt_codigo_reserva.TextLength > 0 && txt_codigo_reserva.Text != "Ingrese codigo de reserva a modificar")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_codigo_reserva.ForeColor = SystemColors.MenuText;
                _buscaCod = true;
            }
        }

        private void txt_codigo_reserva_Click(object sender, EventArgs e)
        {
            if (txt_codigo_reserva.Text == "Ingrese codigo de reserva a modificar")
            {
                txt_codigo_reserva.Text = string.Empty;
                txt_codigo_reserva.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_codigo_reserva_Leave(object sender, EventArgs e)
        {
            if (txt_codigo_reserva.Text == "Ingrese codigo de reserva a modificar" ||
                txt_codigo_reserva.Text == string.Empty)
            {
                txt_codigo_reserva.Text = "Ingrese codigo de reserva a modificar";
                txt_codigo_reserva.ForeColor = SystemColors.ScrollBar;
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
                            button_confirmar.Enabled = true;
                            button_confirmar.ForeColor = SystemColors.MenuText;
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

        private void Reserva_cancelar_Load(object sender, EventArgs e)
        {

        }

        private void grp_datos_Enter(object sender, EventArgs e)
        {

        }

        private void registrar_ingreso_Load(object sender, EventArgs e)
        {

        }

        private void button_confirmar_Click(object sender, EventArgs e)
        {

            string msj = "¿Está seguro que quiere confirmar el checkin? \n Una vez confirmado, no puede volver a modificarse";
            DialogResult resultado = MessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {

                    using (SqlConnection conn = Home_Estadia.obtenerConexion())
                    {
                      SqlParameter codigo_estadia = new SqlParameter("@cod_estadia", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            //create procedure  TEAM_CASTY.Check_IN @Cod_Reserva numeric(18),@fecha datetime,
                            // @usuario nvarchar(255),@hotel numeric(18),@cod_estadia numeric(18) output

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].Check_IN";
                            cmd.Parameters.Add(new SqlParameter("@Cod_Reserva", _reserva.codigo_reserva));
                            cmd.Parameters.Add(new SqlParameter("@fecha", Home_Estadia._fechaHoySql()));
                            cmd.Parameters.Add(new SqlParameter("@usuario", Home_Estadia._nombreUsuario));
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_Estadia._codigo_hotel));
                            cmd.Parameters.Add(codigo_estadia);
                            cmd.ExecuteNonQuery();
                        }
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            //procedure  Agregar_Clientes_A_Estadia
                            //(@Cod_Reserva numeric(18),@tabla TEAM_CASTY.t_agregar_clientes readonly)
                            cmd.CommandType = CommandType.StoredProcedure;
                            DataTable tablaAuxiliar = new DataTable();
                            tablaAuxiliar.Columns.Add("Codigo");
                            for (int i = 1; i < tablaClientes.Rows.Count; i++)
                            {
                                tablaAuxiliar.Rows.Add(tablaClientes.Rows[i].ItemArray[0]);
                            }
                            cmd.CommandText = "[TEAM_CASTY].Agregar_Clientes_A_Estadia";
                            cmd.Parameters.Add(new SqlParameter("@Cod_Reserva", _reserva.codigo_reserva));
                            cmd.Parameters.Add(new SqlParameter("@tabla",tablaAuxiliar));
                            cmd.ExecuteNonQuery();
                            msj = string.Format("Check in exitoso. \n Su código de estadía es: {0}",codigo_estadia.Value.ToString());
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
        private bool existeEnTablaClientes(int codigo)
        {
            bool existe = false;
            for (int i = 0; i < tablaClientes.Rows.Count; i++)
            {
                if (Convert.ToInt32(tablaClientes.Rows[i].ItemArray[0]) == codigo)
                    existe = true;
            }
            return existe;
        }
        private void button_Buscar2_Click(object sender, EventArgs e)
        {
            if (_buscaDoc && _buscaEmail && _buscaTipoDoc)
            {
                    try
                    {
                        string busqueda = string.Format("SELECT * "
                         + " FROM [GD2C2014].[Team_Casty].[vistaClientes] "
                         + " WHERE [Mail] = '{0}' AND [Tipo Documento]='{1}' AND [Numero Documento]={2}", txt_Email2.Text,
                         cmb_tipoIdentificacion2.SelectedItem, txt_numeroIdentificacion2.Text);           //búsqueda básica
                        label_progreso.Text = "Buscando...";       //Imprime en la barra de progreso
                        SqlConnection conn = Home_Estadia.obtenerConexion();                       //Abrir Conexión
                        SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
                        barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                        adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                        DataTable tablaAuxiliar = new DataTable();
                        adaptador.Fill(tablaAuxiliar);                                                                                                    //LLeno tabla de resultados

                        if (tablaAuxiliar.Rows.Count == 0)
                        {
                            string msj = "No se encontró el cliente \n";
                            MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else if (tablaAuxiliar.Rows.Count != 1)
                        {
                            string msj = "Existe más de un cliente con esos datos. \n";
                            MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }
                        else
                        {
                            if (!existeEnTablaClientes(Convert.ToInt32(tablaAuxiliar.Rows[0].ItemArray[0])))
                            {

                            string msj = "Se encontró al cliente. \n Puede continuar añadiendo acompañantes.";
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            tablaClientes.Rows.Add(tablaAuxiliar.Rows[0].ItemArray);
                            }
                            else
                            {
                                string msj = "Ingrese un cliente no repetido.";
                                MessageBox.Show(msj, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button_agregar_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.Cliente_alta formulario_alta = new FrbaHotel.ABM_de_Cliente.Cliente_alta(true);
            formulario_alta.Show();
        }
    }
}
