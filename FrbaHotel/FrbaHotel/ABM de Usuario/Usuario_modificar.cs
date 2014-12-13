using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Usuario
{

    public partial class Usuario_modificar : Form
    {
        private string codigo;
        public DataTable tabla_roles_hoteles;
        public  bool habilitar=false;
        public Usuario_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);
            cambiarTodosLosControles(false);

            SqlConnection conn = Home_Usuario.obtenerConexion();
            SqlCommand cmd = Home_Usuario.obtenerComandoTipo_Documento(conn);
            SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
            while (reader.Read())
            {
                cmb_tipo_documento.Items.Add(reader["Tipo_Documento"].ToString());
            }
            codigo = _valoresDGV._codigo;
            habilitar = _valoresDGV._habilitado;
            if (_valoresDGV._habilitado == false)
            {
                lbl_inhabilitado.Visible = true;
                lbl_habilitar.Visible = true;
                chk_habilitar.Visible = true;
                chk_habilitar.Enabled = true;
            }
        }
        private void establecerAtributosOriginales(valoresDataGridView _valoresDGV)
        {
            _lbl_direccion.Text = _valoresDGV._direccion;
            _lbl_apellido.Text = _valoresDGV._apellido;
            _lbl_fecha_nacimiento.Text = _valoresDGV._fecha_nacimiento;
            _lbl_mail.Text = _valoresDGV._mail;
            _lbl_username.Text = _valoresDGV._username;
            _lbl_nombre.Text = _valoresDGV._nombre;
            _lbl_numero_doc.Text = _valoresDGV._numero_de_documento;
            _lbl_telefono.Text = _valoresDGV._telefono;
            _lbl_tipo_documento.Text = _valoresDGV._tipo_de_documento;
        }
        private void cambiarTodosLosControles(bool _enable)
        {
            Control[] controles = {txt_apellido,txt_mail,txt_direccion,txt_username,
                                        txt_nombre,txt_numero_documento,txt_telefono,
                                        cmb_tipo_documento};
            CheckBox[] checks = {chk_apellido,chk_direccion,chk_fecha_nacimiento,
                                    chk_mail,chk_nombre,chk_numero_documento,
                                    chk_telefono,chk_tipo_documento,chk_username,chk_todos,chk_habilitar};
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
            this.Hide();
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
        private void habilitar_o_deshabilitar_fecha(DateTimePicker _unSelectorDeFecha, bool _unBooleano)
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
                case "chk_direccion":
                    {
                        habilitar_o_deshabilitar_control(txt_direccion, _checker.Checked);
                        break;
                    }
                case "chk_username":
                    {
                        habilitar_o_deshabilitar_control(txt_username, _checker.Checked);
                        break;
                    }
                case "chk_nombre":
                    {
                        habilitar_o_deshabilitar_control(txt_nombre, _checker.Checked);
                        break;
                    }
                case "chk_apellido":
                    {
                        habilitar_o_deshabilitar_control(txt_apellido, _checker.Checked);
                        break;
                    }
                case "chk_fecha_nacimiento":
                    {
                        habilitar_o_deshabilitar_fecha(dtp_fecha_nacimiento, _checker.Checked);
                        break;
                    }
                case "chk_mail":
                    {
                        habilitar_o_deshabilitar_control(txt_mail, _checker.Checked);
                        break;
                    }
                case "chk_numero_documento":
                    {
                        habilitar_o_deshabilitar_control(txt_numero_documento, _checker.Checked);
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
                case "chk_habilitar":
                    {
                        habilitar = _checker.Checked;
                        break;
                    }
                case "chk_todos":
                    {
                        cambiarTodosLosControles(_checker.Checked);
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

        private void check_todos_change(object sender, EventArgs e)
        {
            cambiarTodosLosControles((sender as CheckBox).Checked);
        }

        private void txt_numero_documento_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Usuario_modificar_Load(object sender, EventArgs e)
        {

        }

        private void button_modificar_Click_1(object sender, EventArgs e)
        {
            string mensaje = "¿Está seguro que quiere modificar el Usuario? \n ";
            DialogResult resultado = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                if ((chk_fecha_nacimiento.Checked && dtp_fecha_nacimiento.Value < Home_Usuario._fechaHoy) 
                    || chk_fecha_nacimiento.Checked==false)
                {
                    try
                    {
                        using (SqlConnection conn = Home_Usuario.obtenerConexion())
                        {
                            using (SqlCommand cmd = conn.CreateCommand())
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                //create procedure TEAM_CASTY.modificarUsuario (@cod_usuario numeric(18),@username nvarchar(255),
                                //@nombre nvarchar(255),@apellido nvarchar(255),
                                //@tipoDocumento nvarchar(255), @numeroDocumento numeric(18),
                                //@mail nvarchar(255), @telefono nvarchar(50),
                                //@direccion nvarchar(255), @fechaNacimiento datetime, 
                                //@habilitado numeric (18),@tabla TEAM_CASTY.t_tablaHotelYRol readonly)
                                cmd.CommandText = "[TEAM_CASTY].modificarUsuario";
                                cmd.Parameters.Add(new SqlParameter("@cod_usuario", codigo));
                                string username = _lbl_username.Text;
                                if (txt_username.Text != string.Empty && chk_username.Checked)
                                    username = txt_username.Text;
                                cmd.Parameters.Add(new SqlParameter("@username", username));
                                string nombre = _lbl_nombre.Text;
                                if (txt_nombre.Text != string.Empty && chk_nombre.Checked)
                                    nombre = txt_nombre.Text;
                                cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                                string apellido = _lbl_apellido.Text;
                                if (txt_apellido.Text != string.Empty && chk_apellido.Checked)
                                    apellido = txt_apellido.Text;
                                cmd.Parameters.Add(new SqlParameter("@apellido", apellido));
                                string tipoDocumento = _lbl_tipo_documento.Text;
                                if (cmb_tipo_documento.SelectedIndex >= 0 && chk_tipo_documento.Checked)
                                    tipoDocumento = cmb_tipo_documento.Text;
                                cmd.Parameters.Add(new SqlParameter("@tipoDocumento", tipoDocumento));
                                string numerodocumento = _lbl_numero_doc.Text;
                                if (txt_numero_documento.Text != string.Empty && chk_numero_documento.Checked)
                                    numerodocumento = txt_numero_documento.Text;
                                cmd.Parameters.Add(new SqlParameter("@numeroDocumento", numerodocumento));
                                string mail = _lbl_mail.Text;
                                if (txt_mail.Text != string.Empty && chk_mail.Checked)
                                    mail = txt_mail.Text;
                                cmd.Parameters.Add(new SqlParameter("@mail", mail));
                                string telefono = _lbl_telefono.Text;
                                if (txt_telefono.Text != string.Empty && chk_telefono.Checked)
                                    telefono = txt_telefono.Text;
                                cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                                string direccion = _lbl_direccion.Text;
                                if (txt_direccion.Text != string.Empty && chk_direccion.Checked)
                                    direccion = txt_direccion.Text;
                                cmd.Parameters.Add(new SqlParameter("@direccion", direccion));
                                string fecha_nacimiento = _lbl_fecha_nacimiento.Text;
                                if (chk_fecha_nacimiento.Checked)
                                    fecha_nacimiento = Home_Usuario.transformarFechaASql(dtp_fecha_nacimiento.Value);
                                cmd.Parameters.Add(new SqlParameter("@fechaNacimiento", fecha_nacimiento));
                                cmd.Parameters.Add(new SqlParameter("@tabla", tabla_roles_hoteles));
                                cmd.Parameters.Add(new SqlParameter("@habilitado",habilitar));
                                cmd.ExecuteNonQuery();
                                string msj = "Usuario agregado con éxito";
                                MessageBox.Show(msj, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                                MenuPrincipal formularioPrincipal = new MenuPrincipal();
                                this.Hide();
                                formularioPrincipal.Show();
                            }
                        }

                    }
                    catch (SqlException exc)
                    {
                        Home_Usuario.mostrarMensajeErrorSql(exc);
                    }
                }
                else
                {
                    string msj = "Ingrese una fecha válida";
                    MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
        }

        private void button_seleccionarRoles_Click(object sender, EventArgs e)
        {
            using (var form = new Usuario_elegir_roles_por_hotel(_lbl_username.Text))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tabla_roles_hoteles = form.tabla_valores;            //values preserved after close
                    //Do something here with these values
                }
            }
        }
    }
}
