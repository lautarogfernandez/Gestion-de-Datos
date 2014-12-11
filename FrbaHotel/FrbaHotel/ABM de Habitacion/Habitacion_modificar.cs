﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaHotel.ABM_de_Habitacion
{
    public partial class Habitacion_modificar : Form
    {
        public Habitacion_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);


        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            bool error = false;
            string frente, desc,tipo_hab;
            int num, piso;
            bool baja;
            string msj_error=string.Empty;

            if(!txt_piso.Enabled)
            {piso=Convert.ToInt32(_lbl_piso.Text);}
            else if (txt_piso.Enabled && txt_piso.Text != string.Empty)
            {
                piso=Convert.ToInt32(txt_piso.Text);
            }
            else
            {
                msj_error += " No ha escrito nada en Piso";
                error = true;
            }

            if (!txt_numero.Enabled)
            { num = Convert.ToInt32(_lbl_numero.Text); }
            else if (txt_numero.Enabled && txt_numero.Text != string.Empty)
            {
                num = Convert.ToInt32(txt_numero.Text);
            }
            else
            {
                msj_error += " No ha escrito nada en Número";
                error = true;
            }

            if (!txt_descripcion.Enabled)
            {desc=_lbl_descripcion.Text; }
            else if (txt_descripcion.Enabled && txt_descripcion.Text != string.Empty)
            {
                desc = txt_descripcion.Text;
            }
            else {
                desc = string.Empty;
            }

            if (!cmb_frente.Enabled)
            { frente = _lbl_frente.Text; }
            else if (cmb_frente.Enabled && cmb_frente.SelectedItem.ToString() != string.Empty)
            {
                desc = cmb_frente.SelectedItem.ToString();
            }
            else
            {
                msj_error += " No ha seleccionado nada en Frente";
                error = true;
            }

            if (!cmb_baja.Enabled)
            { if (_lbl_frente.Text.ToString() == "SI") { baja = true; } else { baja = false; } }
            else if (cmb_baja.Enabled && cmb_baja.SelectedItem.ToString() != string.Empty)
            {
                if (cmb_baja.SelectedItem.ToString() == "SI")
                {
                    msj_error += " No se puede dar de baja a una habitación desde aquí.";
                    error = true;
                }
                else
                {
                    baja = false;
                }
            }
            else
            {
                msj_error += " No ha seleccionado nada en Frente";
                error = true;
            }

            if (error)
            {
                MessageBox.Show(msj_error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                try
                {
                    using (SqlConnection conn =
                    Home_Habitacion.obtenerConexion())
                    {
                        //create procedure TEAM_CASTY.ModificarHabitacion
                        //(@hotel numeric(18),@numeroAnterior numeric(18), @numeroActual numeric(18),@piso numeric(18),@frente char(1),@tipo nvarchar(255),@descripcion nvarchar(255), @baja numeric(18))

                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "[TEAM_CASTY].ModificarHabitacion";
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_Habitacion._codigo_hotel));

                            cmd.Parameters.Add(new SqlParameter("@numero", Convert.ToInt32(txt_numero.Text)));
                            cmd.Parameters.Add(new SqlParameter("@piso", Convert.ToInt32(txt_numero.Text)));
                            cmd.Parameters.Add(new SqlParameter("@frente", frente));
                            cmd.Parameters.Add(new SqlParameter("@tipo", cmb_tipo_habitacion.SelectedItem));
                            cmd.Parameters.Add(new SqlParameter("@descripcion", txt_descripcion.Text));
                            cmd.ExecuteNonQuery();

                            string msj = string.Format("La habitación se ha cargado correctamente.");
                            DialogResult resultado = MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Habitacion.mostrarMensajeErrorSql(exc);
                }
            }



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

        private void chk_baja_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox _checker = sender as CheckBox;
            #region Checks
            switch (_checker.Name)
            {
                case "chk_piso":
                    {
                        habilitar_o_deshabilitar_control(txt_piso, _checker.Checked);
                        break;
                    }
                case "chk_numero":
                    {
                        habilitar_o_deshabilitar_control(txt_numero, _checker.Checked);
                        break;
                    }
                case "chk_frente":
                    {
                        habilitar_o_deshabilitar_control(cmb_frente, _checker.Checked);
                        break;
                    }
                case "chk_descripcion":
                    {
                        habilitar_o_deshabilitar_control(txt_descripcion, _checker.Checked);
                        break;
                    }
                case "chk_baja":
                    {
                        habilitar_o_deshabilitar_control(cmb_baja, _checker.Checked);
                        break;
                    }
            }
            #endregion
        }

        private void control_enabled_change(object sender, EventArgs e)
        {
            Control _control = sender as Control;
            if (_control.Enabled)
            {
                _control.ForeColor = SystemColors.WindowText;
                button_modificar.Enabled = true;
                button_modificar.ForeColor = SystemColors.WindowText;
            }
            else
                _control.ForeColor = SystemColors.ScrollBar;
        }

        private void cambiarTodosLosControles(bool _enable)
        {
            Control[] controles = {txt_piso,txt_numero,txt_descripcion,cmb_baja,cmb_frente};
            CheckBox[] checks = {chk_piso,chk_numero,chk_descripcion,chk_baja,chk_frente,chk_todos};
            for (int i = 0; i < controles.Length; i++)
            {
                habilitar_o_deshabilitar_control(controles[i], _enable);
            }
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = _enable;
            }
        }

        private void check_todos_change(object sender, EventArgs e)
        {
            cambiarTodosLosControles((sender as CheckBox).Checked);
        }
        
        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void establecerAtributosOriginales(valoresDataGridView _valoresDGV)
        {
            _lbl_piso.Text = _valoresDGV._piso;
            _lbl_numero.Text = _valoresDGV._numero;
            _lbl_frente.Text = _valoresDGV._frente;
            _lbl_tipo_habitacion.Text = _valoresDGV._tipo_habitacion;
            if (_valoresDGV._descripcion.ToString() != string.Empty) 
            {_lbl_descripcion.Text = _valoresDGV._descripcion;}
            else { _lbl_descripcion.Text = " "; }            
            if (_valoresDGV._baja) 
            { _lbl_baja.Text = "SI";}
            else { _lbl_baja.Text = "NO"; }
        }
    }
}
