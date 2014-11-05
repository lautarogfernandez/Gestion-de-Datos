using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel
{
    public partial class Modificar : Form
    {
        List<Label> _cabecera = new List<Label>();
        List<Label> _atributos = new List<Label>();
        List<ObjetoModificable> _atributosNuevos = new List<ObjetoModificable>();
        List<CheckBox> _habilitarMod = new List<CheckBox>();
        private enum tipoComponente { 
        codigo,
        alfanumerico,
        numerico,
        fecha,
        seleccionAcotada,
        seleccionMultiple
        }
        struct ObjetoModificable {
            public tipoComponente _restrains;
            public object _valor;
            public string _tipoEstr;
        }
        string _tabla;
        string _formularioAnterior;
        public Modificar(DataGridViewSelectedCellCollection _camposElegidos,DataGridViewColumnCollection _columnas,string _nombreTabla,
                                     List<int> _seleccionesAcotadas,List<int>  _seleccionesMultiples )
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
                if (_seleccionesAcotadas.Contains(i))
                {
                    ComboBox component = new ComboBox();
                    component.Parent = this;
                    component.Text = "Ingrese " + label.Text;
                    component.Left = 20 + label2.Left + label2.Width;
                    component.Top = label2.Top;
                    component.Height = label2.Height;
                    component.Width = this.Width - component.Left - 50;
                    component.Enabled = false;
                    component.ForeColor = SystemColors.ScrollBar;
                    string busqueda = "SELECT DISTINCT [" + label.Text + "] "
                                                         + "FROM [GD2C2014].[Team_Casty].[" + _nombreTabla + "] ";          //búsqueda básica
                    string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
                    SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
                    conn.Open();                                                                                                                                 //Abrir Conexión
                    SqlCommand cmd = new SqlCommand(busqueda, conn);
                    SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
                    while (reader.Read())
                    {
                        component.Items.Add(reader[label.Text].ToString());
                    }
                    reader.Close();
                    conn.Close();

                    ObjetoModificable obj = new ObjetoModificable();
                    obj._restrains = tipoComponente.seleccionAcotada;
                    obj._valor = component;
                    obj._tipoEstr = "System.String";
                    _atributosNuevos.Add(obj);
                }
                else
                {
                    if (_seleccionesMultiples.Contains(i))
                    {
                        ListBox component = new ListBox();
                        component.Parent = this;
                        component.Text = "Ingrese " + label.Text;
                        component.Left = 20 + label2.Left + label2.Width;
                        component.Top = label2.Top;
                        component.Height = label2.Height;
                        component.Width = this.Width - component.Left - 50;
                        component.Enabled = false;
                        component.ForeColor = SystemColors.ScrollBar;
                        string busqueda = "SELECT DISTINCT [" + label.Text + "] "
                                                             + "FROM [GD2C2014].[Team_Casty].[" + _nombreTabla + "] ";          //búsqueda básica
                        string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
                        SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
                        conn.Open();                                                                                                                                 //Abrir Conexión
                        SqlCommand cmd = new SqlCommand(busqueda, conn);
                        SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
                        while (reader.Read())
                        {
                            component.Items.Add(reader[label.Text].ToString());
                        }
                        reader.Close();
                        conn.Close();

                        ObjetoModificable obj = new ObjetoModificable();
                        obj._restrains = tipoComponente.seleccionMultiple;
                        obj._valor = component;
                        obj._tipoEstr = "System.String";
                        _atributosNuevos.Add(obj);
                    }
                    else
                    {
                        switch (_camposElegidos[i].ValueType.ToString())
                        {

                            case "System.Decimal":
                                {
                                    TextBox component = new TextBox();
                                    component.Parent = this;
                                    component.Text = "Ingrese " + label.Text;
                                    component.Left = 20 + label2.Left + label2.Width;
                                    component.Top = label2.Top;
                                    component.Height = label2.Height;
                                    component.Width = this.Width - component.Left - 50;
                                    component.Enabled = false;
                                    component.ForeColor = SystemColors.ScrollBar;
                                    ObjetoModificable obj = new ObjetoModificable();
                                    obj._restrains = tipoComponente.numerico;
                                    obj._valor = component;
                                    obj._tipoEstr = "System.Decimal";
                                    _atributosNuevos.Add(obj);
                                    break;
                                }
                            case "System.DateTime":
                                {
                                    DateTimePicker component = new DateTimePicker();
                                    component.Parent = this;
                                    component.Left = 20 + label2.Left + label2.Width;
                                    component.Top = label2.Top;
                                    component.Height = label2.Height;
                                    component.Width = this.Width - component.Left - 50;
                                    component.Enabled = false;
                                    component.ForeColor = SystemColors.ScrollBar;
                                    ObjetoModificable obj = new ObjetoModificable();
                                    obj._restrains = tipoComponente.fecha;
                                    obj._valor = component;
                                    obj._tipoEstr = "System.DateTime";
                                    _atributosNuevos.Add(obj);
                                    break;
                                }
                            case "System.String":
                                {
                                    TextBox component = new TextBox();
                                    component.Parent = this;
                                    component.Text = "Ingrese " + label.Text;
                                    component.Left = 20 + label2.Left + label2.Width;
                                    component.Top = label2.Top;
                                    component.Height = label2.Height;
                                    component.Width = this.Width - component.Left - 50;
                                    component.Enabled = false;
                                    component.ForeColor = SystemColors.ScrollBar;
                                    ObjetoModificable obj = new ObjetoModificable();
                                    obj._restrains = tipoComponente.alfanumerico;
                                    obj._valor = component;
                                    obj._tipoEstr = "System.String";
                                    _atributosNuevos.Add(obj);
                                    break;
                                }
                        }
                    }
                }

                CheckBox checkBox = new CheckBox();
                checkBox.Parent = this;
                checkBox.Checked = false;
                checkBox.Left = (_atributosNuevos[i]._valor as Control).Left + (_atributosNuevos[i]._valor as Control).Width + 10;
                checkBox.Top = (_atributosNuevos[i]._valor as Control).Top;
                checkBox.Click += common_click_checkBox;
                _habilitarMod.Add(checkBox);
            }
            _formularioAnterior = _nombreTabla.Substring(5, _nombreTabla.Length-6)+"_modificacion";
            _tabla = _nombreTabla.Substring(5, _nombreTabla.Length - 6);
        }
        private void common_leave_component(object sender, EventArgs e)
        { 
        }
        private void Modificar_Load(object sender, EventArgs e)
        {

        }
        private void habilitar_component(int indice)
        {
            
            (_atributosNuevos[indice]._valor as Control).Enabled = true;
            (_atributosNuevos[indice]._valor as Control).ForeColor = SystemColors.MenuText;
            try
            {
                (_atributosNuevos[indice]._valor as Control).Text =string.Empty;
            }
            catch { }
        }
        private void deshabilitar_component(int indice)
        {
            (_atributosNuevos[indice]._valor as Control).Enabled = false;
            (_atributosNuevos[indice]._valor as Control).ForeColor = SystemColors.ScrollBar;
            try
            {
                (_atributosNuevos[indice]._valor as Control).Text = "Ingrese " + _cabecera[indice].Text;
            }
            catch{        }
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
                habilitar_component(num);
            }
            else deshabilitar_component(num);
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
           
        }

        private void stat_BarraEstado_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
