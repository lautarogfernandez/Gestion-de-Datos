using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Cliente_modificacion : Form
    {
 #region Variables
        public bool _buscaNombre = false;   //busca nombre
        public bool _buscaApellido = false; //busca apellido
        public bool _buscaEmail = false;    //busca email
        public bool _buscaTipoDoc = false;  //busca un tipo de doc
        public bool _buscaDoc = false;      //busca un numero doc
        #endregion

        public void habilitar_boton(Button _unBoton) 
        {
            _unBoton.Enabled = true;
            _unBoton.ForeColor = SystemColors.MenuText;
        }
        public void deshabilitar_boton(Button _unBoton)
        {
            _unBoton.Enabled = false;
            _unBoton.ForeColor = SystemColors.ScrollBar;
        }
        public Cliente_modificacion()
        {
            InitializeComponent();
            string busqueda = "SELECT DISTINCT [Tipo Documento] "
                                                         + "FROM [GD2C2014].[Team_Casty].[vistaClientes]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
            while (reader.Read())
            {
                cmb_tipoIdentificacion.Items.Add(reader["Tipo Documento"].ToString()); 
            }
            button_Buscar.Enabled = true;
            reader.Close();
            conn.Close();
        }
        #region Txt_Nombre
        // EVENTOS TextBox Nombre
        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {
            if (txt_Nombre.TextLength > 0 && txt_Nombre.Text != "Ingrese nombre")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_Nombre.ForeColor = SystemColors.MenuText;
                _buscaNombre = true;
            }
        }

        private void txt_Nombre_Click(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "Ingrese nombre")
            {
                txt_Nombre.Text = string.Empty;
                txt_Nombre.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Nombre_Leave(object sender, EventArgs e)
        {
            if (txt_Nombre.Text == "Ingrese nombre" ||
                txt_Nombre.Text == string.Empty)
            {
                txt_Nombre.Text = "Ingrese nombre";
                txt_Nombre.ForeColor = SystemColors.ScrollBar;
                _buscaNombre = false;
            }
        }
        #endregion
        #region Txt_Apellido
        private void txt_Apellido_TextChanged(object sender, EventArgs e)
        {
            if (txt_Apellido.TextLength > 0 && txt_Apellido.Text != "Ingrese apellido")
            {
                txt_Apellido.ForeColor = SystemColors.MenuText;
                _buscaApellido = true;
            }
        }

        private void txt_Apellido_Click(object sender, EventArgs e)
        {
            if (txt_Apellido.Text == "Ingrese apellido")
            {
                txt_Apellido.Text = string.Empty;
                txt_Apellido.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Apellido_Leave(object sender, EventArgs e)
        {
            if (txt_Apellido.Text == "Ingrese apellido" ||
                txt_Apellido.Text == string.Empty)
            {
                txt_Apellido.Text = "Ingrese apellido";
                txt_Apellido.ForeColor = SystemColors.ScrollBar;
                _buscaApellido = false;
            }
        }
        #endregion
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
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            button_modificar.Enabled = false;
            button_modificar.ForeColor = SystemColors.ScrollBar;
            string busqueda = "SELECT * "
                                                                     + "FROM [GD2C2014].[Team_Casty].[vistaClientes]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Clientes";       //Imprime en la barra de progreso
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
            DataTable tablaClientes = new DataTable();                                                                                 //Creo Tabla para los resultados
            #region Condiciones_de_busqueda
            if (_buscaApellido || _buscaDoc || _buscaEmail || _buscaNombre || _buscaTipoDoc) 
            {
                busqueda += " WHERE ";
                bool _masDeUno = false;
                if (_buscaDoc)
                {
                    _masDeUno = true;
                    busqueda += "CONVERT( VARCHAR(50),[Numero Documento]) LIKE '%" + txt_numeroIdentificacion.Text.ToString() + "%'";
                }
                if (_buscaNombre)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Nombre] LIKE '%" + txt_Nombre.Text.ToString().ToUpper() + "%'";
                }
                if (_buscaApellido)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Apellido] LIKE '%" + txt_Apellido.Text.ToString().ToUpper() + "%'";
                }
                if (_buscaEmail)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Mail] LIKE '%" + txt_Email.Text.ToString().ToLower() + "%'";
                }
                if (_buscaTipoDoc)
                {
                    if (_masDeUno) busqueda += " AND ";
                    busqueda += " [Tipo Documento] = '" + cmb_tipoIdentificacion.Text + "'";
                }
            }
            #endregion
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                adaptador.Fill(tablaClientes);                                                                                                    //LLeno tabla de resultados
                dgv_resultados.DataSource = tablaClientes;                                                                           //LLeno datagrid con tabla
                barra_progreso.Value = 100;                                                                                                    //Aviso que terminó la búsqueda
                label_progreso.Text = tablaClientes.Rows.Count.ToString()+" Clientes encontrados";      //Le digo la cantidad de filas encontradas
            }
            catch (Exception)                                                                                                                             //En un error le aviso
            {
                barra_progreso.Value = 0;
                label_progreso.Text = "Error - Búsqueda de Clientes Inválida";
            }
            conn.Close();                                                                                                                                 //Cierro conexión
            button_Buscar.Enabled = true;                                                                                                     //Habilito Otra búsqueda
            habilitar_boton(button_limpiar);                                                                                                  //habilita el boton limpiar
            button_modificar.Enabled = true;
            button_modificar.ForeColor = SystemColors.MenuText;
        }

        private void Cliente_listado_Load(object sender, EventArgs e)
        {

        }


        private void button_volver_Click(object sender, EventArgs e)
        {
            Form formularioPrincipal = new MenuPrincipal();
            formularioPrincipal.Show();
            this.Hide();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dgv_resultados.DataSource=null;
            button_limpiar.Enabled = false;
            label_progreso.Text = "Tabla de resultados vacía";
            button_modificar.Enabled = false;
            button_modificar.ForeColor = SystemColors.ScrollBar;
        }

        private void Filtros_de_busqueda_Enter(object sender, EventArgs e)
        {

        }

        private void Cliente_listado_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void Cliente_listado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13) {
                if (dgv_resultados.DataSource == null)
                {
                    button_Buscar_Click(this, null);
                }
                else
                {
                    button_limpiar_Click(this,null);
                }
            }
        }

        private void dgv_resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button_modificar.Enabled = true;
            button_modificar.ForeColor = SystemColors.MenuText;
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            Cliente_modificar fomularioModificar = new Cliente_modificar(dgv_resultados.SelectedCells,dgv_resultados.Columns);
        }

        private void Cliente_modificacion_Load(object sender, EventArgs e)
        {

        }

    }
}
