using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.ABM_de_Cliente
{
    public partial class Cliente_modificar : Form
    {
        public Cliente_modificar(DataGridViewSelectedCellCollection _camposElegidos,DataGridViewColumnCollection _columnas)
        {
            InitializeComponent();
            Modificar formulario = new Modificar(_camposElegidos,_columnas,"vistaClientes");
            this.Hide();
            formulario.Show();
        }

        private void Cliente_modificar_Load(object sender, EventArgs e)
        {

        }
    }
}
