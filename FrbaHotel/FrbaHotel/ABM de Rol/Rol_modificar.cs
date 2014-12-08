using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace FrbaHotel.ABM_de_Rol
{
    public partial class Rol_modificar : Form
    {
        public int codigo;
        public bool _activo = false;
        public Rol_modificar(valoresDataGridView _valores)
        {
            InitializeComponent();
            establecerAtributosOriginales(_valores);
            cambiarTodosLosControles(false);
            string busqueda = "SELECT [Codigo], [Descripcion] FROM [TEAM_CASTY].FuncionesAsignables ()";
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;"; //ruta de la conexión
            SqlConnection conn = new SqlConnection(ConnStr);                                                             //conexión
            conn.Open();                                                                                                                                 //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_funciones.Items.Add(reader["Descripcion"].ToString());
                    _list_funciones_original.Items.Add(reader["Descripcion"].ToString());
                    if (_valores.codigos_funciones.Exists(delegate(int _obj)
                    {
                        return _obj == Convert.ToInt32(reader["Codigo"]);
                    }))
                    {
                        _list_funciones_original.SetItemChecked((list_funciones.Items.Count - 1), true);
                    }
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
            codigo = Convert.ToInt32(_valores._codigo);
            _activo = _valores._activo=="True";
            if (!_activo)
            {
                chk_activo.Enabled = true;
                chk_activo.Visible = true;
                lbl_activo.Text = "Rol INACTIVO";
                lbl_activar.Visible = true;
            }
            conn.Close();
        }
        private void establecerAtributosOriginales(valoresDataGridView _valoresDGV)
        {
            _lbl_nombre_original.Text = _valoresDGV._nombre;
        }
        private void cambiarTodosLosControles(bool _enable)
        {
            Control[] controles = {txt_nombre};
            CheckBox[] checks = {chk_funciones,chk_activo,chk_todos,chk_nombre};
            for (int i = 0; i < controles.Length; i++)
            {
                habilitar_o_deshabilitar_control(controles[i], _enable);
            }
            for (int i = 0; i < checks.Length; i++)
            {
                checks[i].Checked = _enable;
            }
            habilitar_o_deshabilitar_list(_enable);
        }
        private bool espacio(char _unCaracter)
        {
            return _unCaracter == '_';
        }
        private void habilitar_o_deshabilitar_list(bool _unBooleano)
        {
            list_funciones.Enabled = _unBooleano;

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


        private bool validado()
        {
                return _activo;
        }
      
        private void Rol_modificar_Load(object sender, EventArgs e)
        {
           
        }
        private void button_volver_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                case "chk_activo":
                    {
                        _activo=chk_activo.Enabled;
                        break;
                    }
                case "chk_funciones":
                    {
                        habilitar_o_deshabilitar_list(_checker.Checked);
                        break;
                    }
            }
            #endregion
        }
        private void check_todos_change(object sender, EventArgs e)
        {
            cambiarTodosLosControles((sender as CheckBox).Checked);
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

        private void button_modificar_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable table = new DataTable("Funciones");
                table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                if (chk_funciones.Checked)
                {
                    for (int i = 0; i < list_funciones.CheckedItems.Count; i++)
                        table.Rows.Add(list_funciones.CheckedItems[i]);
                }
                else
                {
                    for (int i = 0; i < _list_funciones_original.CheckedItems.Count; i++)
                        table.Rows.Add(_list_funciones_original.CheckedItems[i]);
                }
                using (SqlConnection conn = Home.obtenerConexion())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].Modificacion_Rol";
                        cmd.Parameters.Add(new SqlParameter("@codigo", codigo));
                        if(txt_nombre.Enabled==true && txt_nombre.Text!=string.Empty)
                        cmd.Parameters.Add(new SqlParameter("@nombre", txt_nombre.Text));
                        else
                        cmd.Parameters.Add(new SqlParameter("@nombre", _lbl_nombre_original.Text));
                        cmd.Parameters.Add(new SqlParameter("@funciones", table));
                        cmd.Parameters.Add(new SqlParameter("@Activo", validado()));
                        cmd.ExecuteNonQuery();
                        //rows number of record got updated
                        string msj = "Rol modificado con éxito \n";
                        MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    }
                }

            }
            catch (SqlException exc)
            {
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
