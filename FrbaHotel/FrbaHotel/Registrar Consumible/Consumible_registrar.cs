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

namespace FrbaHotel.Registrar_Consumible
{
    public partial class Consumible_registrar : Form
    {
        public Consumible_registrar()
        {
            InitializeComponent();
            //TEAM_CASTY.Clientes_Estadia_Fecha
            SqlConnection conn = Home_Consumible.obtenerConexion();
            SqlDataAdapter adaptador;
            barra_progreso.Value = 0;
            DataTable tablaCiudad = new DataTable();
            try
            {
                adaptador = new SqlDataAdapter("SELECT * FROM [TEAM_CASTY].Clientes_Estadia_Fecha ('"+
                  Home_Consumible._fechaHoySql()  +"',"+Home_Consumible._codigo_hotel+")", conn);
                adaptador.Fill(tablaCiudad);
                dgv_resultados.DataSource = tablaCiudad;
                    barra_progreso.Value = 100;
                    label_progreso.Text = "Seleccione una habitación para continuar";
            }
            catch (SqlException exc)
            {

                barra_progreso.Value = 0;
                Home_Consumible.mostrarMensajeErrorSql(exc);
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
            //function TEAM_CASTY.HabitacionesDeEstadia (@cod_estadia numeric(18,0))
            SqlConnection conn = Home_Consumible.obtenerConexion();
            SqlDataAdapter adaptador;
            barra_progreso.Value = 0;
            DataTable tablaCiudad = new DataTable();
            try
            {
                adaptador = new SqlDataAdapter("SELECT * FROM [TEAM_CASTY].HabitacionesDeEstadia ("
                +dgv_resultados.SelectedCells[0].Value+ ")", conn);
                adaptador.Fill(tablaCiudad);
                dgv_habitaciones.DataSource = tablaCiudad;
                barra_progreso.Value = 100;
                label_progreso.Text = "Seleccione aceptar para confirmar los cambios";
            }
            catch (SqlException exc)
            {

                barra_progreso.Value = 0;
                Home_Consumible.mostrarMensajeErrorSql(exc);
            }
            conn.Close();
        }

        private void dgv_habitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            button_limpiar.Enabled = true;
            SqlConnection conn = Home_Consumible.obtenerConexion();
            SqlCommand cmd = Home_Consumible.obtenerComandoConsumibles(conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Activado", typeof(bool)));
            table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            table.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));

            try
            {
                while (reader.Read())
                {
                    table.Rows.Add(false, reader["Descripcion"].ToString(), 0);
                }

                dgv_consumible_cantidad.DataSource = table ;
            }
            catch(SqlException exc)
            {
                Home_Consumible.mostrarMensajeErrorSql(exc);
            }
            reader.Close();
            conn.Close();
        }


        private void dgv_consumible_cantidad_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_consumible_cantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgv_consumible_cantidad.CurrentCell.ColumnIndex == 2)
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
            button_aceptar.Enabled = true;
            if (dgv_consumible_cantidad.CurrentCell.ColumnIndex == 1)
            {
                dgv_consumible_cantidad.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                dgv_consumible_cantidad.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
        }
        private void dgv_consumible_cantidad_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            // TEAM_CASTY.RegistrarConsumibles @cod_Estadia numeric(18),@tabla TEAM_CASTY.t_tablaConsumibles
            button_limpiar.Enabled = true;
            try
            {
                DataTable table = new DataTable("Consumibles");
                table.Columns.Add(new DataColumn("Cod_Habitacion", typeof(int)));
                table.Columns.Add(new DataColumn("Nombre", typeof(string)));
                table.Columns.Add(new DataColumn("Cantidad", typeof(int)));
                int codigoHabitacion = Convert.ToInt32(dgv_habitaciones.SelectedCells[0].Value);
                for (int i = 0; i <dgv_consumible_cantidad.Rows.Count; i++)
                {
                    bool activado = Convert.ToBoolean(dgv_consumible_cantidad.Rows[i].Cells[0].Value);
                    string nombre = dgv_consumible_cantidad.Rows[i].Cells[1].Value.ToString();
                    int cantidad = Convert.ToInt32(dgv_consumible_cantidad.Rows[i].Cells[2].Value);
                    if (activado == true && cantidad > 0)
                    {
                        table.Rows.Add(codigoHabitacion,nombre,cantidad);
                    }
                }
                using (SqlConnection conn = Home_Consumible.obtenerConexion())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].RegistrarConsumibles";
                        cmd.Parameters.Add(new SqlParameter("@cod_Estadia", Convert.ToInt32(dgv_resultados.SelectedCells[0].Value)));
                        cmd.Parameters.Add(new SqlParameter("@tabla", table));
                        cmd.ExecuteNonQuery();
                        //rows number of record got updated
                        string msj = "Consumibles registrados con éxito \n";
                        MessageBox.Show(msj, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }

            }
            catch (SqlException exc)
            {
                Home_Consumible.mostrarMensajeErrorSql(exc);
            }
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
            dgv_habitaciones.DataSource = null;
            dgv_consumible_cantidad.DataSource = null;
            button_aceptar.Enabled = false;
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
    }
}
