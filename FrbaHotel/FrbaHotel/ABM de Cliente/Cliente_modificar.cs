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

    public partial class Cliente_modificar : Form
    {
        private string _tabla = "vistaClientes";
        private string codigo;
        public Cliente_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);
            cambiarTodosLosControles(false);
            string busqueda = "SELECT DISTINCT [Tipo_Documento] "
                                                         + "FROM [GD2C2014].[Team_Casty].[Tipo_Documento]";          //búsqueda básica
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
            while (reader.Read())
            {
                cmb_tipo_documento.Items.Add(reader["Tipo_Documento"].ToString());
            }
            codigo = _valoresDGV._codigo;
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
            _lbl_numero_calle.Text = _valoresDGV._numero_calle;
            _lbl_numero_documento.Text = _valoresDGV._numero_documento;
            _lbl_pais.Text = _valoresDGV._pais;
            _lbl_piso.Text = _valoresDGV._piso;
            _lbl_telefono.Text = _valoresDGV._telefono;
            _lbl_tipo_documento.Text = _valoresDGV._tipo_documento;
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
            string[] _strings = {txt_apellido.Text,txt_calle.Text,txt_departamento.Text,txt_localidad.Text,txt_mail.Text,txt_nacionalidad.Text,
                                        txt_nombre.Text,txt_numero_calle.Text,txt_numero_documento.Text,txt_pais.Text,txt_piso.Text,txt_telefono.Text,
                                        cmb_tipo_documento.Text};
        }
        private void Modificar_Load(object sender, EventArgs e)
        {

        }
        
        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            string mensaje = "UPDATE [GD2C2014].[Team_Casty].[" + _tabla + "] SET ";

            bool prim = true;
            #region Atributos
            if (txt_apellido.Enabled && txt_apellido.Text!=string.Empty)
            {
                if(prim==true)
                {
                    prim = false;
                    mensaje += " [Apellido] = @Apellido";
                }
            }
            if (txt_calle.Enabled && txt_calle.Text!=string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Calle] = @Calle";
                }
                else mensaje += ", [Calle] = @Calle";
            }
            if (txt_departamento.Enabled && txt_departamento.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Departamento] = @Departamento" ;
                }
                else mensaje += ", [Departamento] = @Departamento";
            }
            if (txt_localidad.Enabled && txt_localidad.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Localidad] = @Localidad";
                }
                else mensaje += ", [Localidad] = @Localidad";
            }
            if (txt_mail.Enabled && txt_mail.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Mail] = @Mail";
                }
                else mensaje += ", [Mail] = @Mail";
            }
            if (txt_nacionalidad.Enabled && txt_nacionalidad.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Nacionalidad] = @Nacionalidad";
                }
                else mensaje += ", [Nacionalidad] = @Nacionalidad";
            }
            if (txt_nombre.Enabled && txt_nombre.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Nombre] = @Nombre";
                }
                else mensaje += ", [Nombre] = @Nombre";
            }
            if (txt_numero_calle.Enabled && txt_numero_calle.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Numero Calle] = @NumCalle";
                }
                else mensaje += ", [Numero Calle] = @NumCalle";
            }
            if (txt_numero_documento.Enabled && txt_numero_documento.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Numero Documento] = @NumDoc";
                }
                else mensaje += ", [Numero Documento] = @NumDoc";
            }
            if (txt_pais.Enabled && txt_pais.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Pais] = @Pais";
                }
                else mensaje += ", [Pais] = @Pais";
            }
            if (txt_piso.Enabled && txt_piso.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Piso] = @Piso";
                }
                else mensaje += ", [Piso] = @Piso";
            }
            if (txt_telefono.Enabled && txt_telefono.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Telefono] = @Telefono";
                }
                else mensaje += ", [Telefono] = @Telefono";
            }
            if (cmb_tipo_documento.Enabled && cmb_tipo_documento.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Tipo Documento] = @TipoDoc";
                }
                else mensaje += ", [Tipo Documento] = @TipoDoc";
            }
            if (dtp_fecha_nacimiento.Enabled && dtp_fecha_nacimiento.Value.Date < DateTime.Today)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Fecha Nacimiento] = @FechaNacimiento";
                }
                else mensaje += ", [Fecha Nacimiento] = @FechaNacimiento";
            }
            if (cmb_inhabilitado.Enabled && cmb_inhabilitado.Text != string.Empty)
            {
                if (prim == true)
                {
                    prim = false;
                    mensaje += " [Inhabilitado] = @Inhab";
                }
                else mensaje += ", [Inhabilitado] = @Inhab";
            }

            #endregion
            if (prim == false)
            {
                mensaje += " WHERE [Codigo] = " + codigo;
                try
                {
                    SqlConnection conn = Home_Cliente.obtenerConexion();
                    {
                        conn.Open();
                        using (SqlCommand cmd =
                            new SqlCommand(mensaje, conn))
                        {
                            if (dtp_fecha_nacimiento.Enabled && dtp_fecha_nacimiento.Value.Date < DateTime.Today)
                                cmd.Parameters.AddWithValue("@FechaNacimiento", dtp_fecha_nacimiento.Value);
                            if (txt_apellido.Enabled && txt_apellido.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Apellido",txt_apellido.Text);
                            if (txt_calle.Enabled && txt_calle.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Calle", txt_calle.Text);
                            if (txt_departamento.Enabled && txt_departamento.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Departamento", txt_departamento.Text);
                            if (txt_localidad.Enabled && txt_localidad.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Localidad", txt_localidad.Text);
                            if (txt_mail.Enabled && txt_mail.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Mail", txt_mail.Text);
                            if (txt_nacionalidad.Enabled && txt_nacionalidad.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Nacionalidad", txt_nacionalidad.Text);
                            if (txt_nombre.Enabled && txt_nombre.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                            if (txt_numero_calle.Enabled && txt_numero_calle.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@NumCalle", txt_numero_calle.Text);
                            if (txt_numero_documento.Enabled && txt_numero_documento.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@NumDoc", txt_numero_documento.Text);
                            if (txt_pais.Enabled && txt_pais.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Pais", txt_pais.Text);
                            if (txt_piso.Enabled && txt_piso.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Piso", txt_piso.Text);
                            if (txt_telefono.Enabled && txt_telefono.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                            if (cmb_tipo_documento.Enabled && cmb_tipo_documento.Text != string.Empty)
                                cmd.Parameters.AddWithValue("@TipoDoc", cmb_tipo_documento.Text);
                            if (cmb_inhabilitado.Enabled && cmb_inhabilitado.Text != string.Empty)
                            {
                                if(cmb_inhabilitado.Text=="INHABILITAR")
                                    cmd.Parameters.AddWithValue("@Inhab", "1");
                                else
                                    cmd.Parameters.AddWithValue("@Inhab", "0");
                            }
                            string msj = "¿Está seguro que quiere modificar el cliente? \n";
                            DialogResult resultado = MessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (resultado == DialogResult.Yes)
                            {
                                int rows = cmd.ExecuteNonQuery();
                                //rows number of record got updated

                                string info = "Cliente modificado satisfactoriamente \n";
                                MessageBox.Show(info, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (SqlException exc)
                {
                    string msj = "Errores de sql: \n";
                    for (int i = 0; i < exc.Errors.Count; i++)
                        msj += exc.Errors[i].Message + "\n";
                    MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //Log exception
                    //Display Error message
                }



            }
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
            #region Checks
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
            #endregion
        }

        private void control_enabled_change(object sender, EventArgs e)
        {
            Control _control=sender as Control;
            if (_control.Enabled)
            {
                _control.ForeColor = SystemColors.WindowText;
                button_modificar.Enabled = true;
                button_modificar.ForeColor = SystemColors.WindowText;
            }
            else
                _control.ForeColor = SystemColors.ScrollBar;
        }

        private void check_todos_change(object sender, EventArgs e)
        {
            cambiarTodosLosControles((sender as CheckBox).Checked);
        }


        private void txt_numero_documento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }

        private void txt_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }

        private void txt_numero_calle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }

        private void txt_piso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar))
                e.Handled = false;
            else if (Char.IsSeparator(e.KeyChar))
                e.Handled = true;
            else
                e.Handled = true;
        }
    }
}
