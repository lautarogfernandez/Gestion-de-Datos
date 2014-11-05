using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel
{
    public partial class Modificar : Form
    {
        List<Label> _cabecera = new List<Label>();
        List<Label> _atributos = new List<Label>();
        List<TextBox> _atributosNuevos = new List<TextBox>();
        List<CheckBox> _habilitarMod = new List<CheckBox>();

        string _tabla;
        string _formularioAnterior;
        public Modificar(DataGridViewSelectedCellCollection _camposElegidos,DataGridViewColumnCollection _columnas,string _nombreTabla)
        {
            InitializeComponent();

            for (int i = 0; i < _camposElegidos.Count; i++)
            {
                Label label = new Label();
                label.Parent = this;
                label.Text = _columnas[i].HeaderText.ToString();
                label.Left = 20;
                label.Top =( (this.Size.Height-150) * i / _camposElegidos.Count)+40;
                label.Width = this.Width * 20 / 100;
                _cabecera.Add(label);
               
                Label label2 = new Label();
                label2.Parent = this;
                label2.Text = _camposElegidos[i].Value.ToString();
                label2.Left = 20 + label.Left + label.Width;
                label2.Top = label.Top;
                label2.Width = (this.Width * 20 / 100);
                label2.MouseHover += common_hover_label;
                label2.MouseLeave += common_leave_label;
                _atributos.Add(label2);

                TextBox textBox = new TextBox();
                textBox.Parent = this;
                textBox.Text= "Ingrese "+label.Text;
                textBox.Left = 20 + label2.Left+label2.Width;
                textBox.Top = label2.Top;
                textBox.Height = label2.Height;
                textBox.Width = this.Width - textBox.Left - 50;
                textBox.Enabled = false;
                textBox.ForeColor = SystemColors.ScrollBar;
                _atributosNuevos.Add(textBox);

                CheckBox checkBox = new CheckBox();
                checkBox.Parent = this;
                checkBox.Checked = false;
                checkBox.Left = textBox.Left + textBox.Width + 10;
                checkBox.Top = textBox.Top;
                checkBox.Click += common_click_checkBox;
                _habilitarMod.Add(checkBox);
            }
            _formularioAnterior = _nombreTabla.Substring(5, _nombreTabla.Length-6)+"_modificacion";
        }
        private void Modificar_Load(object sender, EventArgs e)
        {

        }
        private void habilitar_textBox(int indice)
        {
            _atributosNuevos[indice].Enabled = true;
            _atributosNuevos[indice].ForeColor = SystemColors.MenuText;
        }
        private void deshabilitar_textBox(int indice)
        { 
             _atributosNuevos[indice].Enabled = false;
            _atributosNuevos[indice].ForeColor = SystemColors.ScrollBar;
        }
        private void common_hover_label(object sender, EventArgs e)
        {
            Label label=sender as Label;
            label.AutoSize = true;
        }
        private void common_leave_label(object sender, EventArgs e)
        {
            Label label = sender as Label;
            label.Width = this.Width * 20 / 100;
        }
        private void common_click_checkBox(object sender, EventArgs e)
        {
            CheckBox chk = sender as CheckBox;
            int num=_habilitarMod.IndexOf(chk);
            if (_habilitarMod[num].Checked == true)
            {
                habilitar_textBox(num);
            }
            else deshabilitar_textBox(num);
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
