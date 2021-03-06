﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.Reserva
{
    public partial class Reserva_terminar : Form
    {
        bool _buscaEmail=false;
        bool _buscaTipoDoc = false;
        bool _buscaDoc = false;
        t_reserva _reserva;
        public Reserva_terminar(t_reserva _unaReserva)
        {
            InitializeComponent();
            _reserva=_unaReserva;
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

        private void button_agregar_Click(object sender, EventArgs e)
        {
            ABM_de_Cliente.Cliente_alta formulario_alta = new FrbaHotel.ABM_de_Cliente.Cliente_alta(true);
            formulario_alta.Show();
        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            if (_buscaDoc && _buscaEmail && _buscaTipoDoc)
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
                        barra_progreso.Value = 100;
                        _reserva.cliente = Convert.ToInt32(tablaClientes.Rows[0].ItemArray[0].ToString());
                        string msj = "Cliente encontrado satisfactoriamente. \n Presione aceptar para confirmar la reserva.";
                        MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        button_aceptar.Enabled = true;
                        button_aceptar.ForeColor = SystemColors.MenuText;
                    }
                    //Aviso que terminó la búsqueda
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

        private void button_aceptar_Click(object sender, EventArgs e)
        {
                try
                {
                    DataTable table = new DataTable("t_reserva");
                    table.Columns.Add(new DataColumn("Tipo_habitacion", typeof(string)));
                    table.Columns.Add(new DataColumn("Cantidad", typeof(int)));
                    for (int i = 0; i < _reserva.tipos_habitaciones.Count; i++)
                    {
                        string nombre = _reserva.tipos_habitaciones[i].tipo_habitacion;
                        int cantidad = _reserva.tipos_habitaciones[i].cantidad;
                            table.Rows.Add(nombre, cantidad);
                    }
                    using (SqlConnection conn = Home_Reserva.obtenerConexion())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //procedure  TEAM_CASTY.Reservar @usuario nvarchar(255),@fecha_realizacion datetime,
                            //@fecha_reserva datetime,@cant_noches numeric(18),@id_cliente numeric(18),
                            //@regimen nvarchar(255),@hotel numeric(18),@tabla TEAM_CASTY.t_reserva readonly
                            cmd.CommandText = "[TEAM_CASTY].Reservar";
                            SqlParameter codigo_reserva = new SqlParameter("@cod_reserva", SqlDbType.Int)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.Parameters.Add(new SqlParameter("@usuario",Home_Reserva._nombreUsuario));
                            cmd.Parameters.Add(new SqlParameter("@fecha_realizacion",Home_Reserva._fechaHoySql()));
                            cmd.Parameters.Add(new SqlParameter("@fecha_reserva", Home_Reserva.transformarFechaASql(_reserva.fecha_desde)));
                            int cant_noches =Convert.ToInt32((_reserva.fecha_hasta - _reserva.fecha_desde).TotalDays);
                            cmd.Parameters.Add(new SqlParameter("@cant_noches", cant_noches));
                            cmd.Parameters.Add(new SqlParameter("@id_cliente", _reserva.cliente));
                            cmd.Parameters.Add(new SqlParameter("@regimen", _reserva.regimen));
                            cmd.Parameters.Add(new SqlParameter("@hotel", _reserva.codigo_hotel));                            
                            cmd.Parameters.Add(new SqlParameter("@tabla", table));
                            cmd.Parameters.Add(codigo_reserva);
                            cmd.ExecuteNonQuery();
                            string msj = string.Format("¡Reserva Exitosa! \n Su código de reserva es: {0} \n Usuario: {1} \n Fecha realización: {2} \n" +
                            "Fecha inicio: {3} \n Cantidad de noches: {4} \n Id cliente: {5} \n Regimen: {6} \n Codigo del Hotel: {7} \n",
                            codigo_reserva.Value.ToString(),Home_Reserva._nombreUsuario,Home_Reserva._fechaHoy.ToString(),
                            _reserva.fecha_desde.ToString(),cant_noches,_reserva.cliente,_reserva.regimen,_reserva.codigo_hotel);
                            for (int i = 0; i < table.Rows.Count; i++)
                            {
                                msj += string.Format("Tipo de habitacion: {0} - Cantidad: {1} \n", table.Rows[i].ItemArray[0], table.Rows[i].ItemArray[1]);
                            }
                            MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            this.Hide();
            menuPrincipal.Show();
        }
    }
}
