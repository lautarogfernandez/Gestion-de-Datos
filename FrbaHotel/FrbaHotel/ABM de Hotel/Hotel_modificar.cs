using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Hotel
{

    public partial class Hotel_modificar : Form
    {
        private string _tabla = "vistaClientes";
        private string codigo;
        public Hotel_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);
            cambiarTodosLosControles(false);
            string busqueda = "SELECT DISTINCT [Descripcion] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Regimen]";          //búsqueda básica de regímenes
            string busqueda2 = "SELECT DISTINCT [Nombre] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Ciudad]";          //búsqueda básica de ciudades
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            SqlCommand cmd2 = new SqlCommand(busqueda2, conn);
            try
            {
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    cmb_ciudad.Items.Add(reader2["Nombre"].ToString());
                }
                reader2.Close();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_tipos_regimenes.Items.Add(reader["Descripcion"].ToString());
                }
                reader.Close();

            }
            catch (SqlException exc)
            {
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            conn.Close();
            codigo = _valoresDGV._codigo;
        }
        private void establecerAtributosOriginales(valoresDataGridView _valoresDGV)
        {
            _original_calle.Text = _valoresDGV._calle;
            _original_mail.Text = _valoresDGV._mail;
            _original_numero_calle.Text = _valoresDGV._numero_calle;
            _original_pais.Text = _valoresDGV._pais;
            _original_telefono.Text = _valoresDGV._telefono;
            switch(_valoresDGV._cantidad_estrellas)
            {
                case "1":
                    {
                        rb_1estrella.Checked = true;
                        break;
                    }
                case "2":
                    {
                        rb_2estrellas.Checked = true;
                        break;
                    }
                case "3":
                    {
                        rb_3estrellas.Checked = true;
                        break;
                    }
                case "4":
                    {
                        rb_4estrellas.Checked = true;
                        break;
                    }
                case "5":
                    {
                        rb_5estrellas.Checked = true;
                        break;
                    }
            }
        }
        private void cambiarTodosLosControles(bool _enable)
        {
            Control[] controles = {txt_calle,txt_mail,txt_nombre,txt_numero_calle,txt_pais,txt_telefono,cmb_ciudad,list_tipos_regimenes,grp_cantidad_estrellas};
            CheckBox[] checks = {chk_telefono,chk_calle,chk_estrellas,chk_ciudad,chk_tipos_regimenes,chk_numero_calle,chk_calle,
                                    chk_pais,chk_mail,chk_todos};
            for (int i = 0; i < controles.Length; i++)
            {
                habilitar_o_deshabilitar_control(controles[i], _enable);
            }
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = _enable;
            }
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
                case "chk_nombre":
                    {
                        habilitar_o_deshabilitar_control(txt_nombre, _checker.Checked);
                        break;
                    }
                case "chk_calle":
                    {
                        habilitar_o_deshabilitar_control(txt_calle, _checker.Checked);
                        break;
                    }
                case "chk_mail":
                    {
                        habilitar_o_deshabilitar_control(txt_mail, _checker.Checked);
                        break;
                    }
                case "chk_numero_calle":
                    {
                        habilitar_o_deshabilitar_control(txt_numero_calle, _checker.Checked);
                        break;
                    }
                case "chk_pais":
                    {
                        habilitar_o_deshabilitar_control(txt_pais, _checker.Checked);
                        break;
                    }
                case "chk_telefono":
                    {
                        habilitar_o_deshabilitar_control(txt_telefono, _checker.Checked);
                        break;
                    }
                case "chk_ciudad":
                    {
                        habilitar_o_deshabilitar_control(cmb_ciudad, _checker.Checked);
                        break;
                    }
                case "chk_estrellas":
                    {
                        habilitar_o_deshabilitar_control(grp_cantidad_estrellas, _checker.Checked);
                        break;
                    }
                case "chk_tipos_regimenes":
                    {
                        habilitar_o_deshabilitar_control(list_tipos_regimenes, _checker.Checked);
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

        private void control_text_change(object sender, EventArgs e)
        {

        }

        private void Hotel_modificar_Load(object sender, EventArgs e)
        {

        }

        private void lbl_modificado_Click(object sender, EventArgs e)
        {

        }
    }
}
