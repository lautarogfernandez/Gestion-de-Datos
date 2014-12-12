using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Reflection;

namespace FrbaHotel.ABM_de_Usuario
{
    public partial class Usuario_elegir_roles_por_hotel : Form
    {
        public string usuario;
        public DataTable tabla_auxiliar;
        public DataTable tabla_valores { get; set; } 
        public Usuario_elegir_roles_por_hotel(string _usuario)
        {
            InitializeComponent();
            usuario = _usuario;
            //TEAM_CASTY.VistaHoteles
            string busqueda = "SELECT [Codigo],[Pais],[Nombre], [Ciudad], [Calle], [Numero Calle], [Telefono], [Mail], [Fecha Creacion], " +
                               "[Cantidad de estrellas] FROM [GD2C2014].[Team_Casty].[vistaHoteles]";          //búsqueda básica
            label_progreso.Text = "Cargando Hoteles";       //Imprime en la barra de progreso
            SqlConnection conn = Home_Usuario.obtenerConexion();                           //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
            DataTable tablaHoteles = new DataTable();                                                                                 //Creo Tabla para los resultados
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                adaptador.Fill(tablaHoteles);                                                                                                    //LLeno tabla de resultados
                dgv_hoteles.DataSource = tablaHoteles;                                                                           //LLeno datagrid con tabla
                barra_progreso.Value = 100;                                                                                                    //Aviso que terminó la búsqueda
                label_progreso.Text = tablaHoteles.Rows.Count.ToString() + " Hoteles encontrados";      //Le digo la cantidad de filas encontradas
                tabla_auxiliar = new DataTable();
                tabla_auxiliar.Columns.Add(new DataColumn("Nombre", typeof(string)));
                tabla_auxiliar.Columns.Add(new DataColumn("Hotel", typeof(int)));
            }
            catch (SqlException exc)                                                                                                                             //En un error le aviso
            {
                barra_progreso.Value = 0;
                Home_Usuario.mostrarMensajeErrorSql(exc);
            }
            conn.Close();
        }

        private void list_consumible_ItemCheck(object sender, ItemCheckEventArgs e)
        {

        }

        private void Consumible_registrar_Load(object sender, EventArgs e)
        {

        }

        private void dgv_resultados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }




        private void dgv_consumible_cantidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_consumible_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_roles.CurrentCell.ColumnIndex == 2)
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
        private void dgv_consumible_cantidad_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            button_guardar.Enabled = true;
            if (dgv_roles.CurrentCell.ColumnIndex == 1)
            {
                dgv_roles.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                dgv_roles.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
        }
        private void dgv_consumible_cantidad_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_EnabledChanged(object sender, EventArgs e)
        {
            if ((sender as Control).Enabled)
            {
                (sender as Control).ForeColor = SystemColors.MenuText;
            }
            else
            {
                (sender as Control).ForeColor = SystemColors.ScrollBar;
            }
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dgv_hoteles.DataSource = null;
            dgv_roles.DataSource = null;
            button_guardar.Enabled = false;
            button_limpiar.Enabled = false;
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Form formularioPrincipal = new MenuPrincipal();
            formularioPrincipal.Show();
            this.Hide();
        }

        private void dgv_habitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_consumible_cantidad_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.KeyPress -= new KeyPressEventHandler(ColumnaCantidad_KeyPress);
            if (dgv_roles.CurrentCell.ColumnIndex == 2) //Desired Column
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress += new KeyPressEventHandler(ColumnaCantidad_KeyPress);
                }
            }
        }
        private void ColumnaCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Usuario_elegir_roles_por_hotel_Load(object sender, EventArgs e)
        {

        }

        private void dgv_hoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_guardar_Click(object sender, EventArgs e)
        {
            button_guardar.Enabled = false;
            button_guardar.ForeColor = SystemColors.ScrollBar;

            for (int i = 0; i < dgv_roles.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dgv_roles.Rows[i].Cells[0].Value) == true)
                {
                    tabla_auxiliar.Rows.Add(dgv_roles.Rows[i].Cells[1].Value.ToString(),
                        Convert.ToInt32(dgv_hoteles.SelectedRows[0].Cells[0].Value));
                }
            }
            dgv_roles.DataSource = null;
            dgv_hoteles.Rows.Remove(dgv_hoteles.SelectedRows[0]);
        }

        private void button_aceptar_Click(object sender, EventArgs e)
        {
            tabla_valores = new DataTable();
            this.tabla_valores = tabla_auxiliar;
            this.Close();
        }

        private void dgv_hoteles_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int hotel = Convert.ToInt32(dgv_hoteles.SelectedCells[0].Value);
            button_limpiar.Enabled = true;
            SqlConnection conn = Home_Usuario.obtenerConexion();
            SqlCommand cmd = Home_Usuario.obtenerComandoRoles(conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Activado", typeof(bool)));
            table.Columns.Add(new DataColumn("Nombre", typeof(string)));
            try
            {
                while (reader.Read())
                {
                    table.Rows.Add(false, reader["Nombre"].ToString());
                }

                dgv_roles.DataSource = table;
            }
            catch (SqlException exc)
            {
                Home_Usuario.mostrarMensajeErrorSql(exc);
            }
            if (usuario != "")
            {
                //FUNCTION TEAM_CASTY.RolesDeUsuarioEnHotel
                //(@usuario nvarchar(255),@hotel numeric(18))
                string busqueda1 = string.Format("SELECT * FROM [TEAM_CASTY].RolesDeUsuarioEnHotel ('{0}',{1})",
                    usuario, hotel);
                SqlCommand cmd2 = new SqlCommand(busqueda1, conn);
                reader = cmd2.ExecuteReader();                                                                              //Creo adaptador para la busqueda
                barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                DataTable table2 = new DataTable();
                table2.Columns.Add(new DataColumn("Activado", typeof(bool)));
                table2.Columns.Add(new DataColumn("Nombre", typeof(string)));
                while (reader.Read())
                {
                    table.Rows.Add(true, reader["Nombre de Rol"].ToString());
                }
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv_roles.Rows.Count; j++)
                    {
                        if (dgv_roles.Rows[j].Cells[1].Value.ToString() == table.Rows[i].ItemArray[1].ToString())
                        {
                            dgv_roles.Rows[j].Cells[0].Value = true;
                        }
                    }
                }
            }
            reader.Close();
            conn.Close();
            button_guardar.Enabled = true;
            button_guardar.ForeColor = SystemColors.MenuText;
            button_aceptar.Enabled = true;
            button_aceptar.ForeColor = SystemColors.MenuText;
        }

        private void dgv_roles_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            button_aceptar.Enabled = true;
            if (dgv_roles.CurrentCell.ColumnIndex == 1)
            {
                dgv_roles.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                dgv_roles.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
        }
    }
}
