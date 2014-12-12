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
        private string codigo;
        private int cantidad_original_estrellas;
        private int cantidad_nueva_estrellas;
        public Hotel_modificar(valoresDataGridView _valoresDGV)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valoresDGV);
            cantidad_original_estrellas =Convert.ToInt32(_valoresDGV._cantidad_estrellas);
            cambiarTodosLosControles(false);
            string busqueda = "SELECT DISTINCT [Descripcion] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Regimen]";          //búsqueda básica de regímenes
            string busqueda2 = "SELECT DISTINCT [Nombre] "
                                                         + "FROM [GD2C2014].[TEAM_CASTY].[Ciudad]";          //búsqueda básica de ciudades
            SqlConnection conn=Home_Hotel.obtenerConexion();                                                                                                                               //Abrir Conexión
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
                    _original_tipos_regimenes.Items.Add(reader["Descripcion"].ToString());
                    _original_tipos_regimenes.SetItemCheckState(_original_tipos_regimenes.Items.Count-1, CheckState.Indeterminate);
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
            _original_nombre.Text = _valoresDGV._nombre;
            _original_ciudad.Text = _valoresDGV._ciudad;

            for (int i = 0; i < _valoresDGV._regimenes.Count; i++)
            {
                for(int j=0;j<_original_tipos_regimenes.Items.Count;i++)
                {
                    if(_original_tipos_regimenes.Items[j].ToString() == _valoresDGV._regimenes[i].ToString())
                    {
                        _original_tipos_regimenes.SetItemChecked(j, true);
                    }
                }
            }

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
                                    chk_pais,chk_mail,chk_todos,chk_nombre};
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
            this.Hide();
        }
        private DataTable obtenerTablaRegimenes()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add(new DataColumn("Regimen", typeof(string)));
            if(chk_tipos_regimenes.Checked)
            {
                for (int i = 0; i < list_tipos_regimenes.CheckedItems.Count; i++)
                {
                    tabla.Rows.Add(list_tipos_regimenes.CheckedItems[i].ToString());
                }
            }
            else
                for (int i = 0; i < _original_tipos_regimenes.CheckedItems.Count; i++)
                {
                    tabla.Rows.Add(_original_tipos_regimenes.CheckedItems[i].ToString());
                }
            return tabla;
        }
        private void button_modificar_Click(object sender, EventArgs e)
        {

            string mensaje = "¿Está seguro que quiere modificar el hotel? \n ";
            DialogResult resultado = MessageBox.Show(mensaje, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                try
                {
                    DataTable table = new DataTable("Regimenes");
                    table.Columns.Add(new DataColumn("Regimen", typeof(string)));
                    for (int i = 0; i < list_tipos_regimenes.CheckedItems.Count; i++)
                    {
                        string nombre = list_tipos_regimenes.CheckedItems[i].ToString();
                        table.Rows.Add(nombre);
                    }
                    using (SqlConnection conn = Home_Hotel.obtenerConexion())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            //procedure TEAM_CASTY.modificacion_Hotel(@cod_hotel numeric (18),@nombre nvarchar(255),
                            //@mail nvarchar(255),@telefono nvarchar(50),@pais nvarchar(255),@cidudad nvarchar(255)
                            //,@cant_Estrellas numeric (18),@calle nvarchar(255),@num_calle numeric (18),
                            // @tabla t_tablaRegimenes readonly)
                            cmd.CommandText = "[TEAM_CASTY].modificacion_Hotel";
                            cmd.Parameters.Add(new SqlParameter("@cod_hotel", codigo));
                            string nombre = _original_nombre.Text;
                            if (txt_nombre.Text != string.Empty && chk_nombre.Checked)
                                nombre = txt_nombre.Text;
                            cmd.Parameters.Add(new SqlParameter("@nombre", nombre));
                            string mail = _original_mail.Text;
                            if (txt_mail.Text != string.Empty && chk_mail.Checked)
                                mail = txt_mail.Text;
                            cmd.Parameters.Add(new SqlParameter("@mail", mail));
                            string telefono = _original_telefono.Text;
                            if (txt_telefono.Text != string.Empty && chk_telefono.Checked)
                                telefono = txt_telefono.Text;
                            cmd.Parameters.Add(new SqlParameter("@telefono", telefono));
                            //    cmd.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                            string pais = _original_pais.Text;
                            if (txt_pais.Text != string.Empty && chk_pais.Checked)
                                pais = txt_pais.Text;
                            cmd.Parameters.Add(new SqlParameter("@pais", pais));
                            string ciudad = _original_ciudad.Text;
                            if (cmb_ciudad.Text != string.Empty && chk_ciudad.Checked)
                                ciudad = cmb_ciudad.Text;
                            cmd.Parameters.Add(new SqlParameter("@ciudad", cmb_ciudad.Text));
                            int cant_estrellas = cantidad_original_estrellas;
                            if (chk_estrellas.Checked)
                                cant_estrellas = cantidad_nueva_estrellas;
                            cmd.Parameters.Add(new SqlParameter("@cant_Estrellas", cant_estrellas));
                            string calle = _original_calle.Text;
                            if (txt_calle.Text != string.Empty && chk_calle.Checked)
                                calle = txt_calle.Text;
                            cmd.Parameters.Add(new SqlParameter("@calle", txt_calle));
                            string numCalle = _original_numero_calle.Text;
                            if (txt_numero_calle.Text != string.Empty && chk_numero_calle.Checked)
                                numCalle = txt_numero_calle.Text;
                            cmd.Parameters.Add(new SqlParameter("@num_calle", txt_numero_calle.Text));
                            DataTable tabla = obtenerTablaRegimenes();
                            cmd.Parameters.Add(new SqlParameter("@tabla", tabla));
                            int rows = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (SqlException exc)
                {
                    Home_Hotel.mostrarMensajeErrorSql(exc);
                }
            }
        }

        #region cantidadEstrellas
        private void rb_1estrella_Click(object sender, EventArgs e)
        {
            cantidad_nueva_estrellas = 1;
        }

        private void rb_2estrellas_Click(object sender, EventArgs e)
        {
            cantidad_nueva_estrellas = 2;
        }

        private void rb_3estrellas_Click(object sender, EventArgs e)
        {
            cantidad_nueva_estrellas = 3;
        }

        private void rb_4estrellas_Click(object sender, EventArgs e)
        {
            cantidad_nueva_estrellas = 4;
        }

        private void rb_5estrellas_Click(object sender, EventArgs e)
        {
            cantidad_nueva_estrellas = 5;
        }

        #endregion

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

        private void control_text_change(object sender, EventArgs e)
        {

        }

        private void Hotel_modificar_Load(object sender, EventArgs e)
        {

        }

        private void lbl_modificado_Click(object sender, EventArgs e)
        {

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

        private void grp_cantidad_estrellas_Enter(object sender, EventArgs e)
        {

        }


    }
}
