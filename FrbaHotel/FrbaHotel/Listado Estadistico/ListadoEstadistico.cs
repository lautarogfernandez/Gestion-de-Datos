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



namespace FrbaHotel.Listado_Estadistico
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox2.Items.Add("Hoteles con mayor cantidad de reservas canceladas.");
            comboBox2.Items.Add("Hoteles con mayor cantidad de consumibles facturados.");
            comboBox2.Items.Add("Hoteles con mayor cantidad de días fuera de servicio.");
            comboBox2.Items.Add("Habitaciones con mayor cantidad de días y veces que fueron ocupadas.");
            comboBox2.Items.Add("Cliente con mayor cantidad de puntos.");
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            button1.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fechaInicial="";
            string fechaFinal="";
            string busqueda;

            busqueda = "";
            if (comboBox1.SelectedItem.ToString() == "1")
            {
                    fechaInicial = textBox1.Text + "-01-01";          
                    fechaFinal =  textBox1.Text + "-03-31"; 
            }
            if (comboBox1.SelectedItem.ToString() == "2")
            {
                 fechaInicial = textBox1.Text + "-04-01";          
                 fechaFinal = textBox1.Text + "-06-30";
            }
            if (comboBox1.SelectedItem.ToString() == "3")
            {
                 fechaInicial =  textBox1.Text + "-07-01";         
                 fechaFinal =  textBox1.Text + "-09-30";
            }
            if (comboBox1.SelectedItem.ToString() == "4")
            {
                 fechaInicial = textBox1.Text + "-10-01";          
                 fechaFinal = textBox1.Text + "-12-31";
            }


            if (comboBox2.SelectedItem.ToString() == "Hoteles con mayor cantidad de reservas canceladas.")
            {
                 busqueda =    "SELECT * FROM   TEAM_CASTY.vistaTOP5ReservasCanceladas('"+ fechaInicial + "','"+ fechaFinal +"')";
            }



            if (comboBox2.SelectedItem.ToString() == "Hoteles con mayor cantidad de consumibles facturados.")
            {
                busqueda = "SELECT * FROM   TEAM_CASTY.vistaTOP5ConsumiblesFacturados('" + fechaInicial + "','" + fechaFinal + "')";
            }

            if (comboBox2.SelectedItem.ToString() == "Hoteles con mayor cantidad de días fuera de servicio.")
                            {
                                busqueda = "SELECT * FROM   TEAM_CASTY.vistaTOP5CantidadDeDiasFueraDeServicio('" + fechaInicial + "','" + fechaFinal + "')";
            }


            if (comboBox2.SelectedItem.ToString() == "Habitaciones con mayor cantidad de días y veces que fueron ocupadas.")
                            {
                                busqueda = "SELECT * FROM   TEAM_CASTY.vistaTOP5HabitacionesHabitadas('" + fechaInicial + "','" + fechaFinal + "')";
            }


            if (comboBox2.SelectedItem.ToString() == "Cliente con mayor cantidad de puntos.")
                         {
                             busqueda = "SELECT * FROM   TEAM_CASTY.vistaTOP5ClienteConPuntos('" + fechaInicial + "','" + fechaFinal + "')";
            }

            SqlConnection conn = Home.obtenerConexion();
        //    button_mostrar_hoteles.Enabled = false;
         //   label_progreso.Text = "Cargando Hoteles";
            SqlDataAdapter adaptador;
           // barra_progreso.Value = 0;
            DataTable tablaListado = new DataTable();
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);
                adaptador.Fill(tablaListado);
                dataGridView1.DataSource = tablaListado;
                //barra_progreso.Value = 100;
                // label_progreso.Text = "Carga de Hoteles completa";
            }
            //    catch (Exception)
            //    {

        //        barra_progreso.Value = 0;
            //      label_progreso.Text = "Error - Carga de Hoteles Inválida";
            //   }
            finally { }
            conn.Close();
         //   button_mostrar_hoteles.Enabled = true;
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
