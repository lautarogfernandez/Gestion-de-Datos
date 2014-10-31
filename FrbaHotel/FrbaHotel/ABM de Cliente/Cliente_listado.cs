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
    public partial class Cliente_listado : Form
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
        public Cliente_listado()
        {
            InitializeComponent();
            string busqueda = "SELECT Tipo_Documento "
                                                         + "FROM [GD2C2014].[Team_Casty].[Cliente]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Clientes";       //Imprime en la barra de progreso
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlDataAdapter adaptador;
            adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
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

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            string busqueda = "SELECT * "
                                                                     + "FROM [GD2C2014].[Team_Casty].[Cliente]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Clientes";       //Imprime en la barra de progreso
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 0;                                                                                                            //0% de la barra de progreso
            DataTable tablaClientes = new DataTable();                                                                                 //Creo Tabla para los resultados
            #region Condiciones_de_busqueda
            if (_buscaApellido || _buscaDoc || _buscaEmail || _buscaNombre || _buscaTipoDoc) 
            {
                busqueda += " WHERE ";
                bool _masDeUno = false;
                if (_buscaDoc)
                {
                    _masDeUno = true;
                    busqueda += " [Nro_Documento] LIKE '%" + txt_numeroIdentificacion.Text.ToString() + "%'";
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
                    busqueda += " [Tipo_Documento] = " + cmb_tipoIdentificacion;
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

        }

        private void Cliente_listado_Load(object sender, EventArgs e)
        {

        }


    }
}
