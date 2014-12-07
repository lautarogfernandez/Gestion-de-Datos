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


namespace FrbaHotel
{
    public partial class MenuPrincipal : Form
    {
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public int cantidad_hoteles;
        public string rutaFormularioElegido;
        public Form formulario_elegido;
        public ComboBox combo_objetoEstandar,combo_operacionEstandar;
        public MenuPrincipal()
        {
            InitializeComponent();
            combo_objetoEstandar = combo_objeto.ComboBox;
            combo_operacionEstandar = combo_operacion.ComboBox;
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            lbl_usuario.Text = Home._nombreUsuario;
            if ((Home._nombreUsuario).ToLower() != "guest")
            {
                button_logout.Visible = true;
                string msj = "Bienvenido: "+lbl_usuario.Text+".\n Seleccione un hotel y seleccione un rol para continuar.";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                label_progreso.Text = "Seleccione un hotel para continuar.";
            }
            else
                button_logout.Visible = false;
        }

        private void button_mostrar_hoteles_Click(object sender, EventArgs e)
        {
            button_mostrar_hoteles.Enabled = false;
            label_progreso.Text = "Cargando Hoteles";
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            SqlDataAdapter adaptador;
            barra_progreso.Value = 0;
            DataTable tablaCiudad= new DataTable();
            try
            {
                //adaptador = new SqlDataAdapter("SELECT DISTINCT [Codigo],[Nombre],[Ciudad],[Calle],[Numero Calle],"+
                //                               "[Telefono],[Cantidad de Estrellas] FROM [GD2C2014].[Team_Casty].[vistaHoteles]", conn);
            
            adaptador = new SqlDataAdapter("SELECT * FROM [TEAM_CASTY].HotelesPorUsario (1)", conn);
            adaptador.Fill(tablaCiudad);
                dgv_hoteles.DataSource = tablaCiudad;
                barra_progreso.Value = 100;
                label_progreso.Text = "Carga de Hoteles completa";
            }
            catch (Exception)
            {

                barra_progreso.Value = 0;
                label_progreso.Text = "Error - Carga de Hoteles Inválida";
            }
            conn.Close();
            button_mostrar_hoteles.Enabled = true;
            
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgv_hoteles_MouseHover(object sender, EventArgs e)
        {
            if(dgv_hoteles.DataSource!=null)
            dgv_hoteles.Width = Math.Min(dgv_hoteles.PreferredSize.Width,this.Size.Width-100);
        }

        private void dgv_hoteles_MouseLeave(object sender, EventArgs e)
        {
            dgv_hoteles.Width = this.Size.Width-imagenHotel.Width-10;
        }
        private void combo_objeto_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = combo_objeto.SelectedItem.ToString();
            string[] operaciones = { "Alta", "Baja", "Modificacion", "Listado" };
            string[] reservas = { "Generar", "Modificar", "Cancelar" };
            string[] estadías = { "Registrar Ingreso", "Registrar Egreso" };
            string consumibles = "Registrar";
            combo_operacion.Enabled = true;
            combo_operacion.Text = "Seleccione Operacion";
            combo_operacion.Items.Clear();
            switch (opcion)
            {
                case "Rol":
                    {
                        rutaFormularioElegido = "ABM_de_Rol.Rol_";
                        combo_operacion.Items.AddRange(operaciones);
                        break;
                    }
                case "Usuario":
                    {
                        rutaFormularioElegido = "ABM_de_Usuario.Usuario_";
                        combo_operacion.Items.AddRange(operaciones);
                        break;
                    }
                case "Cliente":
                    {
                        rutaFormularioElegido = "ABM_de_Cliente.Cliente_";
                        combo_operacion.Items.AddRange(operaciones);
                        break;
                    }
                case "Hotel":
                    {
                        rutaFormularioElegido = "ABM_de_Hotel.Hotel_";
                        combo_operacion.Items.AddRange(operaciones);
                        break;
                    }
                case "Habitacion":
                    {
                        rutaFormularioElegido = "ABM_de_Habitacion.Habitacion_";
                        combo_operacion.Items.AddRange(operaciones);
                        break;
                    }
                case "Reserva":
                    {
                        rutaFormularioElegido = "Reserva.Reserva_";
                        combo_operacion.Items.AddRange(reservas);
                        break;
                    }
                case "Estadía":
                    {
                        rutaFormularioElegido = "Registrar_Estadia.";
                        combo_operacion.Items.AddRange(estadías);
                        break;
                    }
                case "Consumible":
                    {
                        rutaFormularioElegido = "Registrar_Consumible.";
                        combo_operacion.Items.Add(consumibles);
                        break;
                    }
                case "Facturación":
                    {
                        rutaFormularioElegido = "Facturacion.";
                        combo_operacion.Items.Add(consumibles);
                        break;
                    }
                case "Listado Estadístico":
                    {
                        rutaFormularioElegido = "Listado_Estadistico.Listados";
                        combo_operacion.Enabled=false;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
        private void combo_operacion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_ir_Click(object sender, EventArgs e)
        {
            try
            {
                string oper = combo_operacion.SelectedItem.ToString();
                rutaFormularioElegido += oper.ToLower();
                Type t = Type.GetType("FrbaHotel." + rutaFormularioElegido);
                formulario_elegido = Activator.CreateInstance(t) as Form;
                formulario_elegido.Show();
                this.Hide();
            }
            catch (Exception)
            {
                 string msj = "No puede acceder a ese formulario \n";
                MessageBox.Show(msj,"Excepcion SQL",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Login.Formulario_login formularioLogin=new Login.Formulario_login();
            formularioLogin.Show();
            this.Hide();
        }

    }
}
