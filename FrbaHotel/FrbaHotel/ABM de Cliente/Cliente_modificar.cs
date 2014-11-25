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
        private string _tabla = "vistaClientes";
        public Cliente_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);
            cambiarTodosLosControles(false);
        }
        private void establecerAtributosOriginales(valoresDataGridView _valoresDGV) 
        {
            _lbl_apellido.Text = _valoresDGV._apellido;
            _lbl_calle.Text = _valoresDGV._calle;
            _lbl_departamento.Text = _valoresDGV._departamento;
            _lbl_fecha_nacimiento.Text = _valoresDGV._fecha_nacimiento;
            _lbl_localidad.Text = _valoresDGV._localidad;
            _lbl_mail.Text = _valoresDGV._mail;
            _lbl_nacionalidad.Text = _valoresDGV._nacionalidad;
            _lbl_nombre.Text = _valoresDGV._nombre;
        }
        private void cambiarTodosLosControles(bool _enable) {
            Control[] controles = {txt_apellido,txt_calle,txt_departamento,txt_localidad,txt_mail,txt_nacionalidad,
                                        txt_nombre,txt_numero_calle,txt_numero_documento,txt_pais,txt_piso,txt_telefono,
                                        cmb_tipo_documento};
            CheckBox[] checks = {chk_apellido,chk_calle,chk_departamento,chk_fecha_nacimiento,chk_localidad,
                                    chk_mail,chk_nacionalidad,chk_nombre,chk_numero_calle,chk_numero_documento,
                                    chk_pais,chk_piso,chk_telefono,chk_tipo_documento,chk_todos};
            for (int i = 0; i < controles.Length; i++)
            {
                habilitar_o_deshabilitar_control(controles[i], _enable);
            }
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = _enable;
            }
            habilitar_o_deshabilitar_fecha(dtp_fecha_nacimiento, _enable);
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
        private bool espacio(char _unCaracter)
        {
            return _unCaracter == '_';
        }
        private void habilitar_o_deshabilitar_control(Control _unControl, bool _unBooleano)
        {
                    _unControl.Enabled = _unBooleano;
                    if (_unBooleano)
                    {
                        _unControl.Text = string.Empty;
                    }
                    else
                    {
                        _unControl.Text = "Ingrese ";
                        for (int i = 3; i < _unControl.Name.Length; i++)
                            if (espacio(_unControl.Name[i])) _unControl.Text += " ";
                            else _unControl.Text += _unControl.Name[i];
                    }
        }
        private void habilitar_o_deshabilitar_fecha(DateTimePicker _unSelectorDeFecha,bool _unBooleano)
        {
            _unSelectorDeFecha.Enabled = _unBooleano;
            _unSelectorDeFecha.Value = DateTime.Today;
        }
        private void common_checkBox_check(object sender, EventArgs e)
        {
            CheckBox _checker = sender as CheckBox;
            switch (_checker.Name)
            {
                case "chk_nombre": 
                {
                    habilitar_o_deshabilitar_control(txt_nombre, _checker.Checked);
                    break;
                }
                case "chk_apellido":
                {
                    habilitar_o_deshabilitar_control(txt_apellido,_checker.Checked);
                    break;
                }
                case "chk_calle":
                {
                    habilitar_o_deshabilitar_control(txt_calle, _checker.Checked);
                    break;
                }
                case "chk_departamento":
                {
                    habilitar_o_deshabilitar_control(txt_departamento, _checker.Checked);
                    break;
                }
                case "chk_fecha_nacimiento":
                {
                    habilitar_o_deshabilitar_fecha(dtp_fecha_nacimiento, _checker.Checked);
                    break;
                }
                case "chk_localidad":
                {
                    habilitar_o_deshabilitar_control(txt_localidad, _checker.Checked);
                    break;
                }
                case "chk_mail":
                {
                    habilitar_o_deshabilitar_control(txt_mail, _checker.Checked);
                    break;
                }
                case "chk_nacionalidad":
                {
                    habilitar_o_deshabilitar_control(txt_nacionalidad, _checker.Checked);
                    break;
                }
                case "chk_numero_calle":
                {
                    habilitar_o_deshabilitar_control(txt_numero_calle, _checker.Checked);
                    break;
                }
                case "chk_numero_documento":
                {
                    habilitar_o_deshabilitar_control(txt_numero_documento, _checker.Checked);
                    break;
                }
                case "chk_pais":
                {
                    habilitar_o_deshabilitar_control(txt_pais, _checker.Checked);
                    break;
                }
                case "chk_piso":
                {
                    habilitar_o_deshabilitar_control(txt_piso, _checker.Checked);
                    break;
                }
                case "chk_telefono":
                {
                    habilitar_o_deshabilitar_control(txt_telefono, _checker.Checked);
                    break;
                }
                case "chk_tipo_documento":
                {
                    habilitar_o_deshabilitar_control(cmb_tipo_documento, _checker.Checked);
                    break;
                }
            }
        }

        private void control_enabled_change(object sender, EventArgs e)
        {
            Control _control=sender as Control;
            if (_control.Enabled)
            {
                _control.ForeColor = SystemColors.WindowText;
            }
            else
                _control.ForeColor = SystemColors.ScrollBar;
        }

        private void check_todos_change(object sender, EventArgs e)
        {
            cambiarTodosLosControles((sender as CheckBox).Checked);
        }
    }
}
