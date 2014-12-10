using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
namespace FrbaHotel
{
    public class Home
    {
        public static List<string> funcionalidadesHabilitadas=new List<string>();
        public static string _nombreUsuario = "guest";
        public static SqlConnection obtenerConexion()
        {
            string ConnStr = @"Data Source=localhost\SQLSERVER2008;Initial Catalog=GD2C2014;User ID=gd;Password=gd2014;Trusted_Connection=False;";
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            return conn;
        }
        public static void cargarFuncionalidadesDeRol(int _codigoRol)
        {
            string busqueda = "SELECT [Cod_Funcion], [Descripcion] FROM [TEAM_CASTY].FuncionesDeUnRol (" + _codigoRol + ")";
            SqlConnection conn = obtenerConexion();
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            SqlDataReader reader = cmd.ExecuteReader();                                                       //Busco en la sesión abierta
            int i=0;
            funcionalidadesHabilitadas.Clear();
            try
            {
                while (reader.Read())
                {
                    switch (Convert.ToInt32(reader["Cod_Funcion"]))
                    {
                        case 1:
                            {
                                funcionalidadesHabilitadas.Add("Rol");
                                break;
                            }
                        case 2:
                            {
                                funcionalidadesHabilitadas.Add("Usuario");
                                break;
                            }
                        case 3:
                            {
                                funcionalidadesHabilitadas.Add("Cliente");
                                break;
                            }
                        case 4:
                            {
                                funcionalidadesHabilitadas.Add("Hotel");
                                break;
                            }
                        case 5:
                            {
                                funcionalidadesHabilitadas.Add("Habitacion");
                                break;
                            }

                        case 6:
                            {
                                funcionalidadesHabilitadas.Add("Regimen");
                                break;
                            }
                        case 7:
                            {
                                funcionalidadesHabilitadas.Add("Reserva");
                                break;
                            }
                        case 9:
                            {
                                funcionalidadesHabilitadas.Add("Estadía");
                                break;
                            }
                        case 10:
                            {
                                funcionalidadesHabilitadas.Add("Consumible");
                                break;
                            }
                        case 11:
                            {
                                funcionalidadesHabilitadas.Add("Facturación");
                                break;
                            }
                        case 12:
                            {
                                funcionalidadesHabilitadas.Add("Listado Estadístico");
                                break;
                            }
                    }
                    i++;
                }
                MessageBox.Show("Funciones cargadas con éxito", "Excepcion SQL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo cargar las funciones", "Excepcion SQL", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            reader.Close();
            conn.Close();
        }
        public static void cerrarConexion()
        {

        }
    }
}
