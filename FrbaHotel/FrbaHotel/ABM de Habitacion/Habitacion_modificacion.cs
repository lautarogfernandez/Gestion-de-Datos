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
    public partial class Habitacion_modificacion : Form
    {

        public bool _buscaPiso = false;
        public bool _buscaNumero = false;
        public bool _buscaFrente = false;
        public bool _buscaTipoHab = false;

        public valoresDataGridView _valores;

        public Habitacion_modificacion()
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

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            button_modificar.Enabled = false;
            button_modificar.ForeColor = SystemColors.ScrollBar;
            string busqueda = "SELECT Codigo, Descripcion, Piso, Numero, Frente, [Descripcion de tipo], Baja " 
                               + "FROM [GD2C2014].[Team_Casty].[vistaHabitaciones]";           //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Habitaciones";       //Imprime en la barra de progreso
            SqlConnection conn = Home_Habitacion.obtenerConexion();                       //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
            DataTable tablaHabitaciones = new DataTable(); 
            //Creo Tabla para los resultados
            #region Condiciones_de_busqueda
            busqueda += " WHERE  Hotel = " + Home_Habitacion._codigo_hotel.ToString();
            if (_buscaNumero || _buscaFrente || _buscaPiso || (_buscaTipoHab && cmb_tipo_habitacion.SelectedItem.ToString()!=string.Empty) )
            {
                busqueda += " AND ";
                bool _masDeUno = false;
                if (_buscaNumero)
                {
                    if (_masDeUno)
                        busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " Numero = " + txt_numero.Text.ToString();
                }
                if (_buscaFrente)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " Frente = ";
                    if (cmb_Frente.SelectedItem.ToString()=="Vista Exterior") busqueda += "'S'";
                    else if (cmb_Frente.SelectedItem.ToString() == "Vista Interior") busqueda += "'N'";
                }
                if (_buscaPiso)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " Piso = " + txt_piso.Text.ToString();
                }
                if (_buscaTipoHab)
                {
                    if (_masDeUno) busqueda += " AND ";
                    busqueda += " [Descripcion de tipo] = '" + cmb_tipo_habitacion.Text.ToString() + "'";
                }
            }
            #endregion
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                adaptador.Fill(tablaHabitaciones);                                                                                                    //LLeno tabla de resultados
                dgv_resultados.DataSource = tablaHabitaciones;                                                                           //LLeno datagrid con tabla
                barra_progreso.Value = 100;                                                                                                    //Aviso que terminó la búsqueda
                label_progreso.Text = tablaHabitaciones.Rows.Count.ToString() + " Habitaciones encontrados"; 
            }
            catch (SqlException exc)                                                                                                                             //En un error le aviso
            {
                barra_progreso.Value = 0;
                Home_Habitacion.mostrarMensajeErrorSql(exc);
            }
            conn.Close();                                                                                                                                 //Cierro conexión
            button_Buscar.Enabled = true;                                                                                                     //Habilito Otra búsqueda
            habilitar_boton(button_limpiar);                                                                                                  //habilita el boton limpiar
            button_modificar.Enabled = true;
            button_modificar.ForeColor = SystemColors.MenuText;
        }

        public void habilitar_boton(Button _unBoton)
        {
            _unBoton.Enabled = true;
            _unBoton.ForeColor = SystemColors.MenuText;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Form formularioPrincipal = new MenuPrincipal();
            formularioPrincipal.Show();
            this.Hide();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dgv_resultados.DataSource = null;
            button_limpiar.Enabled = false;
            label_progreso.Text = "Tabla de resultados vacía";
            button_modificar.Enabled = false;
            button_modificar.ForeColor = SystemColors.ScrollBar;
        }

        private void txt_piso_TextChanged(object sender, EventArgs e)
        {
            if (txt_piso.TextLength > 0)
            {
                txt_piso.ForeColor = SystemColors.MenuText;
                _buscaPiso = true;
            }
        }

        private void txt_numero_TextChanged(object sender, EventArgs e)
        {
            if (txt_numero.TextLength > 0)
            {
                txt_numero.ForeColor = SystemColors.MenuText;
                _buscaNumero = true;
            }
        }

        private void cmb_tipo_habitacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_tipo_habitacion.SelectedItem.ToString() != string.Empty)
            {
                _buscaTipoHab = true;
            }
            else
            { _buscaTipoHab = false; }
        }

        private void cmb_Frente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_Frente.SelectedItem.ToString() != string.Empty)
            {
                cmb_Frente.ForeColor = SystemColors.MenuText;
                _buscaFrente = true;
            }
            else
            { _buscaFrente = false; }
        }

        private void txt_piso_Leave(object sender, EventArgs e)
        {
            if (txt_piso.Text == "Ingrese piso" ||
                txt_piso.Text == string.Empty)
            {
                txt_piso.Text = "Ingrese piso";
                txt_piso.ForeColor = SystemColors.ScrollBar;
                _buscaPiso = false;
            }
        }

        private void txt_numero_Leave(object sender, EventArgs e)
        {
            if (txt_numero.Text == "Ingrese número" ||
                txt_numero.Text == string.Empty)
            {
                txt_numero.Text = "Ingrese número";
                txt_numero.ForeColor = SystemColors.ScrollBar;
                _buscaNumero = false;
            }
        }


         //string busqueda = "SELECT , , , , , [], Baja " 

        private void button_modificar_Click(object sender, EventArgs e)
        {
            _valores = new valoresDataGridView();
            for (int i = 0; i < dgv_resultados.SelectedCells.Count; i++)
            {
                switch (dgv_resultados.Columns[i].HeaderText)
                {
                    case "Codigo":
                        {
                            _valores._codigo = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Descripcion":
                        {
                            _valores._descripcion = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Piso":
                        {
                            _valores._piso = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Numero":
                        {
                            _valores._numero = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Frente":
                        {
                            _valores._frente = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Descripcion de tipo":
                        {
                            _valores._tipo_habitacion = dgv_resultados.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Baja":
                        {
                            if (Convert.ToInt32(dgv_resultados.SelectedCells[i].Value) != 0)
                                _valores._baja = true;
                            else _valores._baja = false;
                            break;
                        }
                }
            }
            Habitacion_modificar formularioModificar = new Habitacion_modificar(_valores);
            formularioModificar.Show();
        }

        private void Habitacion_modificacion_Load(object sender, EventArgs e)
        {

        }

    }
}
