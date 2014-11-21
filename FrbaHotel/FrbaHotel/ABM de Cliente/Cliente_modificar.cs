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
    public struct valoresDataGridView
    {
        public string _tipo_documento, _apellido, _nombre, _pais, _nacionalidad, _localidad,
            _calle, _departamento, _mail, _telefono, _codigo, _numero_documento, _numero_calle, _piso, _fecha_nacimiento;
    }
    public partial class Cliente_modificar : Form
    {
        private valoresDataGridView _valores;
        string _tabla = "vistaClientes";
        public Cliente_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            _valores = _valoresDGV;
        }
        private void Modificar_Load(object sender, EventArgs e)
        {

        }
        
        private void button_volver_Click(object sender, EventArgs e)
        {

        }

        private void button_modificar_Click(object sender, EventArgs e)
        {

        }

        private void Cliente_modificar_Load(object sender, EventArgs e)
        {

        }

        private void lbl_nombre_Click(object sender, EventArgs e)
        {

        }

        private void lbl_mail_Click(object sender, EventArgs e)
        {

        }

        private void lbl_apellido_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void common_checkBox_check(object sender, EventArgs e)
        {

        }
    }
}
