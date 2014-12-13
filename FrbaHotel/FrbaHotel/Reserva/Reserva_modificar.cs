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

namespace FrbaHotel.Reserva
{
    public partial class Reserva_modificar : Form
    {
         bool _buscaEmail=false;
        bool _buscaTipoDoc = false;
        bool _buscaDoc = false;
        bool _buscaCod = false;
        t_reserva _reserva = new t_reserva();
        public Reserva_modificar()
        {
            InitializeComponent();
            SqlConnection conn = Home_Reserva.obtenerConexion();
            SqlCommand cmd = Home_Reserva.obtenerComandoTipo_Documento(conn);
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
                Home_Reserva.mostrarMensajeErrorSql(exc);
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
            try
            {
                grp_cambios.Enabled = false;
                using (SqlConnection conn = Home_Reserva.obtenerConexion())
                {
                    string busqueda1 = "SELECT * FROM TEAM_CASTY.Tipos_Habitaciones_Hotel ("
                                + Home_Reserva._codigo_hotel + ")";
                    SqlCommand cmd2 = new SqlCommand(busqueda1, conn);
                    SqlDataReader reader = cmd2.ExecuteReader();                                                                              //Creo adaptador para la busqueda
                    barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                    DataTable table = new DataTable();
                    table.Columns.Add(new DataColumn("Activado", typeof(bool)));
                    table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                    table.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
                    while (reader.Read())
                    {
                        table.Rows.Add(false, reader["Descripcion"].ToString(), 0);
                    }
                    dgv_tipos_habitaciones.DataSource = table;
                    reader.Close();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string busqueda = "SELECT * FROM TEAM_CASTY.RegimenesDeUnHotel ("
                            + Home_Reserva._codigo_hotel + ")";
                        SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
                        barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                        DataTable tabla = new DataTable();
                        adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                        adaptador.Fill(tabla);                                                                                                    //LLeno tabla de resultados
                        dgv_regimenes.DataSource = tabla;                                                                           //LLeno datagrid con tabla
                    }
                    dgv_regimenes.Columns[0].Width = 270;
                }
            }
            catch (SqlException exc)
            {
                Home_Reserva.mostrarMensajeErrorSql(exc);
            }



            if (_buscaDoc && _buscaEmail && _buscaTipoDoc && _buscaCod)
            {
                string busqueda = string.Format("SELECT [Codigo],[Mail],[Tipo Documento],[Numero Documento] "
                 + " FROM [GD2C2014].[Team_Casty].[vistaClientes] "
                 + " WHERE [Mail] = '{0}' AND [Tipo Documento]='{1}' AND [Numero Documento]={2}", txt_Email.Text,
                 cmb_tipoIdentificacion.SelectedItem, txt_numeroIdentificacion.Text);           //búsqueda básica
                label_progreso.Text = "Buscando...";       //Imprime en la barra de progreso
                SqlConnection conn = Home_Reserva.obtenerConexion();                       //Abrir Conexión
                SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
                barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                DataTable tablaClientes = new DataTable();                                                                                 //Creo Tabla para los resultados
                try
                {
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
                        int codigoReserva  = Convert.ToInt32(txt_codigo_reserva.Text);
                        string busqueda2 = string.Format("SELECT * "
                 + " FROM [GD2C2014].[Team_Casty].[vistaReservasModificables] "
                 + " WHERE [ID_Cliente_Reservador] = {0} AND [Cod_Reserva]={1}", codigoCliente,
                 codigoReserva); 
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
                            string msj = "Se encontró al cliente y a la reserva. \n Presione modificar para modificar la reserva.";
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                            _reserva.cliente = codigoCliente;
                            _reserva.codigo_reserva = codigoReserva;
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                //procedure  TEAM_CASTY.Datos_Reserva
                                //(@cod_reserva numeric(18),@fecha_reserva datetime output,@cant_noches numeric(18) output,
                                //@regimen nvarchar(255) output)
                                cmd.CommandType = CommandType.StoredProcedure;
                                SqlParameter fecha_desde = new SqlParameter("@fecha_reserva", SqlDbType.DateTime)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                SqlParameter cant_noches = new SqlParameter("@cant_noches", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                SqlParameter regimen = new SqlParameter("@regimen", SqlDbType.VarChar,255)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                cmd.CommandText = "[TEAM_CASTY].Datos_Reserva";
                                cmd.Parameters.Add(new SqlParameter("@cod_reserva", codigoReserva));
                                cmd.Parameters.Add(fecha_desde);
                                cmd.Parameters.Add(cant_noches);
                                cmd.Parameters.Add(regimen);
                                cmd.ExecuteNonQuery();
                                DateTime fecha_hasta=Convert.ToDateTime(fecha_desde.Value).AddDays(Convert.ToInt32(cant_noches.Value));

                                dtp_desde.Value = Convert.ToDateTime(fecha_desde.Value);
                                dtp_hasta.Value = fecha_hasta;
                                string _regimen = regimen.Value.ToString();
                                for(int i=0; i<dgv_regimenes.Rows.Count;i++)
                                    if (dgv_regimenes.Rows[i].Cells[0].Value.ToString() == _regimen)
                                    {
                                        dgv_regimenes.Rows[i].Selected = true;
                                    }

                            }
                            //function  TEAM_CASTY.Habitaciones_Reserva (@cod_reserva numeric(18))
                            string busqueda1 = string.Format("SELECT * FROM [TEAM_CASTY].Habitaciones_Reserva ({0})",codigoReserva);
                            SqlCommand cmd2 = new SqlCommand(busqueda1, conn);
                            SqlDataReader reader = cmd2.ExecuteReader();                                                                              //Creo adaptador para la busqueda
                            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                            DataTable table = new DataTable();
                            table.Columns.Add(new DataColumn("Activado", typeof(bool)));
                            table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                            table.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
                            while (reader.Read())
                            {
                                table.Rows.Add(true, reader["Descripcion"].ToString(), reader["Cantidad"]);
                            }
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                for (int j = 0; j < dgv_tipos_habitaciones.Rows.Count; j++)
                                {
                                    if (dgv_tipos_habitaciones.Rows[j].Cells[1].Value.ToString() == table.Rows[i].ItemArray[1].ToString())
                                    {
                                        dgv_tipos_habitaciones.Rows[j].Cells[0].Value = true;
                                        dgv_tipos_habitaciones.Rows[j].Cells[2].Value = table.Rows[i].ItemArray[2];
                                    }
                                }
                            }
                                button_modificar.Visible = true;
                        }
                        //Aviso que terminó la búsqueda
                    }
                }
                catch (SqlException exc)                                                                                                                             //En un error le aviso
                {
                    barra_progreso.Value = 0;
                    Home_Reserva.mostrarMensajeErrorSql(exc);
                }
                conn.Close();                                                                                                                                 //Cierro conexión
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
            try
            {
                using (SqlConnection conn = Home_Reserva.obtenerConexion())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].Actualizar_Reservas";
                        cmd.Parameters.Add(new SqlParameter("@fecha_actual", Home_Reserva._fechaHoySql()));
                        cmd.ExecuteNonQuery();
                    }
                    
                }
            }
            catch (SqlException exc)
            {
                Home_Reserva.mostrarMensajeErrorSql(exc);
            }
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            grp_cambios.Enabled = true;
            button_aceptar.Enabled = true;
            button_aceptar.ForeColor = SystemColors.MenuText;
        }

        private void button_aceptar_Click_1(object sender, EventArgs e)
        {
             if (dtp_desde.Value < dtp_hasta.Value && dtp_desde.Value > Home_Reserva._fechaHoy)
            {
                try
                {
                    DataTable table = new DataTable("t_reserva");
                    table.Columns.Add(new DataColumn("Tipo_habitacion", typeof(string)));
                    table.Columns.Add(new DataColumn("Cantidad", typeof(int)));
                    string regimen = dgv_regimenes.SelectedCells[0].Value.ToString();
                    for (int i = 0; i < dgv_tipos_habitaciones.Rows.Count; i++)
                    {
                        bool activado = Convert.ToBoolean(dgv_tipos_habitaciones.Rows[i].Cells[0].Value);
                        if (activado == true)
                        {
                            string nombre = dgv_tipos_habitaciones.Rows[i].Cells[1].Value.ToString();
                            int cantidad = Convert.ToInt32(dgv_tipos_habitaciones.Rows[i].Cells[2].Value);
                            table.Rows.Add(nombre, cantidad);
                        }
                    }
                    _reserva.regimen = regimen;
                    _reserva.codigo_hotel = Home_Reserva._codigo_hotel;
                    _reserva.fecha_desde = dtp_desde.Value;
                    _reserva.fecha_hasta = dtp_hasta.Value;
                    using (SqlConnection conn = Home_Reserva.obtenerConexion())
                    {
                        using (SqlCommand cmd2 = conn.CreateCommand())
                        {
                            cmd2.CommandType = CommandType.StoredProcedure;
                            //procedure  TEAM_CASTY.Modificar_Reserva(@usuario nvarchar(255),@cod_reserva numeric(18),
                            //@fecha_realizacion datetime,@fecha_reserva datetime,@cant_noches numeric(18),
                            //@id_cliente numeric(18),@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly)
                            cmd2.CommandText = "[TEAM_CASTY].Modificar_Reserva";
                            cmd2.Parameters.Add(new SqlParameter("@usuario", Home_Reserva._nombreUsuario));
                            cmd2.Parameters.Add(new SqlParameter("@cod_reserva", _reserva.codigo_reserva));
                            cmd2.Parameters.Add(new SqlParameter("@fecha_realizacion", Home_Reserva._fechaHoySql()));
                            cmd2.Parameters.Add(new SqlParameter("@fecha_reserva", Home_Reserva.transformarFechaASql(_reserva.fecha_desde)));
                            int cant_noches = Convert.ToInt32((_reserva.fecha_hasta - _reserva.fecha_desde).TotalDays);
                            cmd2.Parameters.Add(new SqlParameter("@cant_noches", cant_noches));
                            cmd2.Parameters.Add(new SqlParameter("@id_cliente", _reserva.cliente));
                            cmd2.Parameters.Add(new SqlParameter("@regimen", _reserva.regimen));
                            cmd2.Parameters.Add(new SqlParameter("@hotel", _reserva.codigo_hotel));
                            cmd2.Parameters.Add(new SqlParameter("@tabla", table));
                            cmd2.ExecuteNonQuery();
                            string mensj = string.Format("¡Reserva Exitosa! \n Su código de reserva es: {0} \n Usuario: {1} \n Fecha realización: {2} \n" +
                            "Fecha inicio: {3} \n Cantidad de noches: {4} \n Id cliente: {5} \n Regimen: {6} \n Codigo del Hotel: {7} \n",
                            txt_codigo_reserva.Text, Home_Reserva._nombreUsuario, Home_Reserva._fechaHoy.ToString(),
                            _reserva.fecha_desde.ToString(), cant_noches, _reserva.cliente, _reserva.regimen, _reserva.codigo_hotel);
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                mensj += string.Format("Tipo de habitacion: {0} - Cantidad: {1} \n", table.Rows[i].ItemArray[0], table.Rows[i].ItemArray[1]);
                            }
                            MessageBox.Show(mensj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            MenuPrincipal formularioPrincipal = new MenuPrincipal();
                            this.Hide();
                            formularioPrincipal.Show();
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Reserva.mostrarMensajeErrorSql(exc);
                }
            }
            else
            {
                MessageBox.Show("Ingrese fechas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void grp_datos_Enter(object sender, EventArgs e)
        {

        }
    }
}
