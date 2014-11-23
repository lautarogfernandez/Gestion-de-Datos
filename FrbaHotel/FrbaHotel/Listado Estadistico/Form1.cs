using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Listado_Estadistico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox2.Items.Add("Hoteles con mayor cantidad de reservas canceladas");
            comboBox2.Items.Add("Hoteles con mayor cantidad de consumibles facturados.");
            comboBox2.Items.Add("Hoteles con mayor cantidad de días fuera de servicio");
            comboBox2.Items.Add("Habitaciones con mayor cantidad de días y veces que fueron ocupadas");
            comboBox2.Items.Add("Cliente con mayor cantidad de puntos");
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
            string fechaInicial;
            string fechaFinal;
            string busqueda;

            if (comboBox1.SelectedItem =="1")
            {
                    fechaInicial = "'"+ textBox1.Text + "-01-01";          
                    fechaFinal = "'" + textBox1.Text + "-03-31"; 
            }
            if (comboBox1.SelectedItem == "2")
            {
                 fechaInicial = "'" + textBox1.Text + "-04-01";          
                 fechaFinal = "'" + textBox1.Text + "-06-30";
            }
            if (comboBox1.SelectedItem == "3")
            {
                 fechaInicial = "'" + textBox1.Text + "-07-01";         
                 fechaFinal = "'" + textBox1.Text + "-09-30";
            }
            if (comboBox1.SelectedItem == "4")
            {
                 fechaInicial = "'" + textBox1.Text + "-10-01";          
                 fechaFinal = "'" + textBox1.Text + "-12-31";
            }


            if (comboBox2.SelectedItem == "Hoteles con mayor cantidad de reservas canceladas")
            {
                 busqueda =    "SELECT * FROM   vistaTOP5ReservasCanceladas('"+ fechaInicial + "','"+ fechaFinal +"')"
            }



            if (comboBox2.SelectedItem == "Hoteles con mayor cantidad de consumibles facturados")
            {
                 busqueda =    "SELECT * FROM   vistaTOP5ConsumiblesFacturados('"+ fechaInicial + "','"+ fechaFinal +"')"
            }

            if (comboBox2.SelectedItem == "Hoteles con mayor cantidad de días fuera de servicio")
                            {
                 busqueda =    "SELECT * FROM   vistaTOP5CantidadDeDiasFueraDeServicio('"+ fechaInicial + "','"+ fechaFinal +"')"
            }


            if (comboBox2.SelectedItem == "Habitaciones con mayor cantidad de días y veces que fueron ocupadas")
                            {
                 busqueda =    "SELECT * FROM   vistaTOP5HabitacionesHabitadas('"+ fechaInicial + "','"+ fechaFinal +"')"
            }


            if (comboBox2.SelectedItem == "Cliente con mayor cantidad de puntos")
                         {
                 busqueda =    "SELECT * FROM   vistaTOP5ClienteConPuntos('"+ fechaInicial + "','"+ fechaFinal +"')"
            }   
          
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
