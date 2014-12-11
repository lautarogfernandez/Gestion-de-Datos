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

namespace FrbaHotel.Reserva
{
    public partial class Reserva_generar : Form
    {
        public Reserva_generar()
        {
            InitializeComponent();
            // TEAM_CASTY.Actualizar_Reservas 
            // TEAM_CASTY.Tipos_Habitaciones_Hotel @Hotel
            // TEAM_CASTY.RegimenesDeUnHotel @cod_hotel
            try
            {
                using (SqlConnection conn = Home_Reserva.obtenerConexion())
                {
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "[TEAM_CASTY].Actualizar_Reservas";
                        cmd.Parameters.Add(new SqlParameter("@fecha_actual", Home_Reserva._fechaHoySql()));
                        cmd.ExecuteNonQuery();
                    }
                       string busqueda1 ="SELECT * FROM TEAM_CASTY.Tipos_Habitaciones_Hotel ("
                            +Home_Reserva._codigo_hotel+")";
                       SqlCommand cmd2 = new SqlCommand(busqueda1, conn);
                        SqlDataReader reader = cmd2.ExecuteReader();                                                                              //Creo adaptador para la busqueda
                        barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                        DataTable table = new DataTable();
                        table.Columns.Add(new DataColumn("Activado", typeof(bool)));
                        table.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                        table.Columns.Add(new DataColumn("Cantidad", typeof(Int32)));
                        while (reader.Read())
                        {
                            table.Rows.Add(false, reader["Descripcion"].ToString(), 0);
                        }
                        dgv_tipos_habitaciones.DataSource = table;
                        reader.Close();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        string busqueda = "SELECT * FROM TEAM_CASTY.RegimenesDeUnHotel ("
                            + Home_Reserva._codigo_hotel + ")";
                        SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
                        barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
                        DataTable tabla = new DataTable();
                        adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                        adaptador.Fill(tabla);                                                                                                    //LLeno tabla de resultados
                        dgv_regimenes.DataSource = tabla;                                                                           //LLeno datagrid con tabla
                    }
                    dgv_regimenes.Columns[0].Width = 270;
                }
            }
            catch (SqlException exc)
            {
                Home_Reserva.mostrarMensajeErrorSql(exc);
            }
        }

        private void dgv_habitaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        
        }

        private void Reserva_generar_Load(object sender, EventArgs e)
        {


        }

        private void dgv_tipos_habitaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_tipos_habitaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            button_aceptar.Enabled = true;
            if (dgv_tipos_habitaciones.CurrentCell.ColumnIndex == 1)
            {
                dgv_tipos_habitaciones.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
            else
            {
                dgv_tipos_habitaciones.EditMode = DataGridViewEditMode.EditOnKeystroke;
            }
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            Form formularioPrincipal = new MenuPrincipal();
            formularioPrincipal.Show();
            this.Hide();
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
        
        private void button_aceptar_Click(object sender, EventArgs e)
        {
            if (dtp_desde.Value < dtp_hasta.Value && dtp_desde.Value > Home_Reserva._fechaHoy)
            {
                try
                {
                    DataTable table = new DataTable("t_reserva");
                    table.Columns.Add(new DataColumn("Tipo_habitacion", typeof(string)));
                    table.Columns.Add(new DataColumn("Cantidad", typeof(int)));
                    string regimen =dgv_regimenes.SelectedCells[0].Value.ToString();
                    for (int i = 0; i < dgv_tipos_habitaciones.Rows.Count; i++)
                    {
                        bool activado = Convert.ToBoolean(dgv_tipos_habitaciones.Rows[i].Cells[0].Value);
                        string nombre = dgv_tipos_habitaciones.Rows[i].Cells[1].Value.ToString();
                        int cantidad = Convert.ToInt32(dgv_tipos_habitaciones.Rows[i].Cells[2].Value);
                        if (activado == true && cantidad > 0)
                        {
                            table.Rows.Add(nombre, cantidad);
                        }
                    }
                    using (SqlConnection conn = Home_Reserva.obtenerConexion())
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            //function  TEAM_CASTY.Disponibilidad_Reserva
                            //(@fecha_desde datetime,@fecha_hasta datetime,@hotel numeric(18),@tabla TEAM_CASTY.t_reserva
                            cmd.CommandType = CommandType.StoredProcedure;
                            SqlParameter outputIdParam = new SqlParameter("@sePuede", SqlDbType.Bit)
                            {
                                Direction = ParameterDirection.Output
                            };
                            SqlParameter precio = new SqlParameter("@precio", SqlDbType.Money)
                            {
                                Direction = ParameterDirection.Output
                            };
                            cmd.CommandText = "[TEAM_CASTY].Disponibilidad_Reserva";
                            cmd.Parameters.Add(new SqlParameter("@fecha_desde", Home_Reserva.transformarFechaASql(dtp_desde.Value)));
                            cmd.Parameters.Add(new SqlParameter("@fecha_hasta", Home_Reserva.transformarFechaASql(dtp_hasta.Value)));
                            cmd.Parameters.Add(new SqlParameter("@hotel", Home_Reserva._codigo_hotel));
                            cmd.Parameters.Add(new SqlParameter("@tabla", table));
                            cmd.Parameters.Add(new SqlParameter("@regimen",regimen));
                            cmd.Parameters.Add(outputIdParam);
                            cmd.Parameters.Add(precio);
                            cmd.ExecuteNonQuery();
                             if (Convert.ToInt32(outputIdParam.Value)!=0)
                             {
                                 string msj =string.Format( "Reserva válida \n Precio total: USD {0} \n ¿Desea continuar y reservar?",precio.Value);
                                 DialogResult resultado=MessageBox.Show(msj, "Éxito", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                 if (resultado == DialogResult.Yes)
                                 {
                                    t_reserva _reserva = new t_reserva();
                                    _reserva.tipos_habitaciones = new List<t_reserva.habitacion_reserva>();
                                    for (int i = 0; i < dgv_tipos_habitaciones.Rows.Count; i++)
                                    {
                                     bool activado = Convert.ToBoolean(dgv_tipos_habitaciones.Rows[i].Cells[0].Value);
                                     string nombre = dgv_tipos_habitaciones.Rows[i].Cells[1].Value.ToString();
                                     int cantidad = Convert.ToInt32(dgv_tipos_habitaciones.Rows[i].Cells[2].Value);
                                        if( activado==true && cantidad>0)
                                        {
                                            t_reserva.habitacion_reserva habitacion_reserva = new t_reserva.habitacion_reserva();
                                            habitacion_reserva.cantidad=cantidad;
                                            habitacion_reserva.tipo_habitacion=nombre;
                                            _reserva.tipos_habitaciones.Add(habitacion_reserva);
                                        }
                                    }
                                    _reserva.regimen = regimen;
                                    _reserva.codigo_hotel = Home_Reserva._codigo_hotel;
                                    _reserva.fecha_desde = dtp_desde.Value;
                                    _reserva.fecha_hasta = dtp_hasta.Value;
                                    Reserva_terminar formulario_terminar_reserva = new Reserva_terminar(_reserva);
                                    formulario_terminar_reserva.Show();
                                    this.Hide();
                                 }
                             }
                             else
                             {
                                 string msj = "Reserva no disponible \n";
                                 MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                             }
                        }
                    }

                }
                catch (SqlException exc)
                {
                    Home_Reserva.mostrarMensajeErrorSql(exc);
                }
            }
            else
            {
                MessageBox.Show("Ingrese fechas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
