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
    public partial class Hotel_baja : Form
    {
        #region Variables
        public bool _buscaCiudad = false; //busca ciudad
        public bool _buscaPais = false;    //busca pais
        public bool _buscaMayor = false;
        public bool _buscaMenor = false;
        public bool _buscaIgual = false;
        public bool _buscaNombre = false;
        public bool _buscaMotivo = false;
        public int cantidad_estrellas = 0;
        private enum tipoComponente
        {
            codigo,
            alfanumerico,
            numerico,
            fecha,
            seleccionAcotada,
            seleccionMultiple
        }
        //public struct ObjetoModificable
        //{
        //    public tipoComponente _restrains;
        //    public string _header;
        //    public string _tipo;
        //    public string _valor;
        //}
        //       List<ObjetoModificable> paramsModificacion = new List<ObjetoModificable>();
        #endregion

        public void habilitar_boton(Button _unBoton)
        {
            _unBoton.Enabled = true;
            _unBoton.ForeColor = SystemColors.MenuText;
        }
        public void deshabilitar_boton(Button _unBoton)
        {
            _unBoton.Enabled = false;
            _unBoton.ForeColor = SystemColors.ScrollBar;
        }
        public Hotel_baja()
        {
            InitializeComponent();
            button_Buscar.Enabled = true;
        }

        #region motivo
        private void txt_motivo_TextChanged(object sender, EventArgs e)
        {
            if (txt_motivo.TextLength > 0 && txt_motivo.Text != "Ingrese motivo de la baja")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_motivo.ForeColor = SystemColors.MenuText;
                _buscaMotivo = true;
            }
        }

        private void txt_motivo_Click(object sender, EventArgs e)
        {
            if (txt_motivo.Text == "Ingrese motivo de la baja")
            {
                txt_motivo.Text = string.Empty;
                txt_motivo.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_motivo_Leave(object sender, EventArgs e)
        {
            if (txt_motivo.Text == "Ingrese motivo de la baja" ||
                txt_motivo.Text == string.Empty)
            {
                txt_motivo.Text = "Ingrese motivo de la baja";
                txt_motivo.ForeColor = SystemColors.ScrollBar;
                _buscaMotivo = false;
            }
        }
        #endregion
        #region txt_nombre
        // EVENTOS TextBox Nombre
        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            if (txt_nombre.TextLength > 0 && txt_nombre.Text != "Ingrese nombre")
            {
                //Si escribe algo cambio el color del texto
                // esto para identificar por qué campos quiere buscar
                txt_nombre.ForeColor = SystemColors.MenuText;
                _buscaNombre = true;
            }
        }

        private void txt_nombre_Click(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "Ingrese nombre")
            {
                txt_nombre.Text = string.Empty;
                txt_nombre.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_nombre_Leave(object sender, EventArgs e)
        {
            if (txt_nombre.Text == "Ingrese nombre" ||
                txt_nombre.Text == string.Empty)
            {
                txt_nombre.Text = "Ingrese nombre";
                txt_nombre.ForeColor = SystemColors.ScrollBar;
                _buscaNombre = false;
            }
        }
        #endregion
        #region Txt_Ciudad
        private void txt_Ciudad_TextChanged(object sender, EventArgs e)
        {
            if (txt_Ciudad.TextLength > 0 && txt_Ciudad.Text != "Ingrese ciudad")
            {
                txt_Ciudad.ForeColor = SystemColors.MenuText;
                _buscaCiudad = true;
            }
        }

        private void txt_Ciudad_Click(object sender, EventArgs e)
        {
            if (txt_Ciudad.Text == "Ingrese ciudad")
            {
                txt_Ciudad.Text = string.Empty;
                txt_Ciudad.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Ciudad_Leave(object sender, EventArgs e)
        {
            if (txt_Ciudad.Text == "Ingrese ciudad" ||
                txt_Ciudad.Text == string.Empty)
            {
                txt_Ciudad.Text = "Ingrese ciudad";
                txt_Ciudad.ForeColor = SystemColors.ScrollBar;
                _buscaCiudad = false;
            }
        }
        #endregion
        #region txt_Pais
        private void txt_Pais_TextChanged(object sender, EventArgs e)
        {
            if (txt_Pais.TextLength > 0 && txt_Pais.Text != "Ingrese Pais")
            {
                txt_Pais.ForeColor = SystemColors.MenuText;
                _buscaPais = true;
            }

        }

        private void txt_Pais_Click(object sender, EventArgs e)
        {
            if (txt_Pais.Text == "Ingrese Pais")
            {
                txt_Pais.Text = string.Empty;
                txt_Pais.ForeColor = SystemColors.MenuText;
            }
        }

        private void txt_Pais_Leave(object sender, EventArgs e)
        {
            if (txt_Pais.Text == "Ingrese Pais" ||
                txt_Pais.Text == string.Empty)
            {
                txt_Pais.Text = "Ingrese Pais";
                txt_Pais.ForeColor = SystemColors.ScrollBar;
                _buscaPais = false;
            }
        }
        #endregion
        private void button_Buscar_Click(object sender, EventArgs e)
        {
            button_eliminar.Enabled = false;
            button_eliminar.ForeColor = SystemColors.ScrollBar;
            string busqueda = "SELECT [Codigo],[Pais],[Nombre], [Ciudad], [Calle], [Numero Calle], [Telefono], [Mail], [Fecha Creacion], " +
                                           "[Cantidad de estrellas] FROM [GD2C2014].[Team_Casty].[vistaHoteles]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Hoteles";       //Imprime en la barra de progreso
            SqlConnection conn = Home.obtenerConexion();                                                                                                                                    //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
            DataTable tablaHoteles = new DataTable();                                                                                 //Creo Tabla para los resultados
            #region Condiciones_de_busqueda
            if (_buscaNombre || _buscaCiudad || _buscaPais || (cantidad_estrellas > 0 && (_buscaIgual || _buscaMayor || _buscaMenor)))
            {
                busqueda += " WHERE ";
                bool _masDeUno = false;
                if (_buscaCiudad)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Ciudad] LIKE '%" + txt_Ciudad.Text.ToString().ToUpper() + "%'";
                }
                if (_buscaNombre)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Nombre] LIKE '%" + txt_nombre.Text.ToString().ToLower() + "%'";
                }
                if (_buscaPais)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Pais] LIKE '%" + txt_Pais.Text.ToString().ToLower() + "%'";
                }
                if (cantidad_estrellas > 0)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    bool mayorOMenor = false;
                    if (_buscaMayor)
                    {
                        busqueda += " [Cantidad de estrellas] >";
                        mayorOMenor = true;
                    }
                    if (_buscaMenor)
                    {
                        busqueda += " [Cantidad de estrellas] <";
                        mayorOMenor = true;
                    }
                    if (_buscaIgual)
                    {
                        if (mayorOMenor)
                        {
                            busqueda += "= ";
                        }
                        else
                            busqueda += " [Cantidad de estrellas] = ";
                    }
                    busqueda += " " + cantidad_estrellas.ToString();


                }
            }
            #endregion
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                adaptador.Fill(tablaHoteles);                                                                                                    //LLeno tabla de resultados
                dgv_resultados.DataSource = tablaHoteles;                                                                           //LLeno datagrid con tabla
                barra_progreso.Value = 100;                                                                                                    //Aviso que terminó la búsqueda
                label_progreso.Text = tablaHoteles.Rows.Count.ToString() + " Hoteles encontrados";      //Le digo la cantidad de filas encontradas
            }
            catch (SqlException exc)                                                                                                                             //En un error le aviso
            {
                barra_progreso.Value = 0;
                label_progreso.Text = "Error - Búsqueda de Hoteles Inválida";
                string msj = "Errores de sql: \n";
                for (int i = 0; i < exc.Errors.Count; i++)
                    msj += exc.Errors[i].Message + "\n";
                MessageBox.Show(msj, "Excepcion SQL", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            conn.Close();                                                                                                                                 //Cierro conexión
            button_Buscar.Enabled = true;                                                                                                     //Habilito Otra búsqueda
            habilitar_boton(button_limpiar);                                                                                                  //habilita el boton limpiar
            button_eliminar.Enabled = true;
            button_eliminar.ForeColor = SystemColors.MenuText;
        }

        private void Cliente_listado_Load(object sender, EventArgs e)
        {

        }


        private void button_volver_Click(object sender, EventArgs e)
        {
            Form formularioPrincipal = new MenuPrincipal();
            formularioPrincipal.Show();
            this.Hide();
        }

        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dgv_resultados.DataSource = null;
            button_limpiar.Enabled = false;
            label_progreso.Text = "Tabla de resultados vacía";
            button_eliminar.Enabled = false;
            button_eliminar.ForeColor = SystemColors.ScrollBar;
        }

        private void Filtros_de_busqueda_Enter(object sender, EventArgs e)
        {

        }

        private void Cliente_listado_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void Cliente_listado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (dgv_resultados.DataSource == null)
                {
                    button_Buscar_Click(this, null);
                }
                else
                {
                    button_limpiar_Click(this, null);
                }
            }
        }

        private void dgv_resultados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button_eliminar.Enabled = true;
            button_eliminar.ForeColor = SystemColors.MenuText;
        }

        private void button_eliminar_Click(object sender, EventArgs e)
        {
            if (_buscaMotivo)
            {
                if (dtp_desde.Value < dtp_hasta.Value && dtp_desde.Value > Home_Hotel._fechaHoy)
                {
                    string msj = string.Format("¿Está seguro que quiere deshabilitar el hotel desde {0} hasta {1}? \n",
                        dtp_desde.Value, dtp_hasta.Value);
                    DialogResult resultado = MessageBox.Show(msj, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            using (SqlConnection conn =
                                Home_Hotel.obtenerConexion())
                            {
                                using (SqlCommand cmd = conn.CreateCommand())
                                {
                                    //procedure TEAM_CASTY.baja_Hotel
                                    //(@cod_hotel numeric (18),@fecha_inicio datetime, @fecha_fin datetime,@motivo nvarchar(255))
                                    cmd.CommandText = "TEAM_CASTY.baja_Hotel";
                                    cmd.CommandType = CommandType.StoredProcedure;
                                    cmd.Parameters.Add(new SqlParameter("@cod_hotel", dgv_resultados.SelectedCells[0].Value));
                                    cmd.Parameters.Add(new SqlParameter("@fecha_inicio", Home_Hotel.transformarFechaASql(dtp_desde.Value)));
                                    cmd.Parameters.Add(new SqlParameter("@fecha_fin", Home_Hotel.transformarFechaASql(dtp_hasta.Value)));
                                    cmd.Parameters.Add(new SqlParameter("@motivo", txt_motivo.Text));

                                    int rows = cmd.ExecuteNonQuery();
                                    string mensaje = "Se dio de baja al hotel satisfactoriamente \n";
                                    MessageBox.Show(mensaje, "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    //rows number of record got deleted
                                }
                            }
                        }
                        catch (SqlException exc)
                        {
                            Home_Hotel.mostrarMensajeErrorSql(exc);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese fechas válidas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un motivo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Filtros_de_busqueda_Enter_1(object sender, EventArgs e)
        {

        }

        private void Cliente_modificacion_Load(object sender, EventArgs e)
        {

        }

        private void Hotel_modificacion_Load(object sender, EventArgs e)
        {

        }
        #region Estrellas
        private void click_comparador_logico(string comparador)
        {
            switch (comparador)
            {
                case "mayor":
                    {
                        if (!_buscaMayor)
                        {
                            mayor.Image = FrbaHotel.Properties.Resources.mayor_click;
                            _buscaMayor = true;
                            if (_buscaMenor == true)
                            {
                                menor.Image = FrbaHotel.Properties.Resources.menor_no_hover;
                                _buscaMenor = false;
                            }
                        }
                        else
                        {
                            mayor.Image = FrbaHotel.Properties.Resources.mayor_hover;
                            _buscaMayor = false;
                        }
                        break;
                    }
                case "igual":
                    {
                        if (!_buscaIgual)
                        {
                            igual.Image = FrbaHotel.Properties.Resources.igual_click;
                            _buscaIgual = true;
                        }
                        else
                        {
                            igual.Image = FrbaHotel.Properties.Resources.igual_hover;
                            _buscaIgual = false;
                        }
                        break;
                    }
                case "menor":
                    {
                        if (!_buscaMenor)
                        {
                            menor.Image = FrbaHotel.Properties.Resources.menor_click;
                            _buscaMenor = true;
                            if (_buscaMayor == true)
                            {
                                mayor.Image = FrbaHotel.Properties.Resources.mayor_no_hover;
                                _buscaMayor = false;
                            }
                        }
                        else
                        {
                            menor.Image = FrbaHotel.Properties.Resources.menor_hover;
                            _buscaMenor = false;
                        }
                        break;
                    }
            }
        }
        private void mayor_Click(object sender, EventArgs e)
        {
            click_comparador_logico("mayor");
        }

        private void igual_Click(object sender, EventArgs e)
        {
            click_comparador_logico("igual");
        }

        private void menor_Click(object sender, EventArgs e)
        {
            click_comparador_logico("menor");
        }

        private void menor_MouseHover(object sender, EventArgs e)
        {
            if (!_buscaMenor)
                menor.Image = FrbaHotel.Properties.Resources.menor_hover;
        }

        private void menor_MouseLeave(object sender, EventArgs e)
        {
            if (!_buscaMenor)
                menor.Image = FrbaHotel.Properties.Resources.menor_no_hover;
        }

        private void igual_MouseLeave(object sender, EventArgs e)
        {
            if (!_buscaIgual)
                igual.Image = FrbaHotel.Properties.Resources.igual_no_hover;
        }

        private void igual_MouseHover(object sender, EventArgs e)
        {
            if (!_buscaIgual)
                igual.Image = FrbaHotel.Properties.Resources.igual_hover;
        }

        private void mayor_MouseHover(object sender, EventArgs e)
        {
            if (!_buscaMayor)
                mayor.Image = FrbaHotel.Properties.Resources.mayor_hover;
        }

        private void mayor_MouseLeave(object sender, EventArgs e)
        {
            if (!_buscaMayor)
                mayor.Image = FrbaHotel.Properties.Resources.mayor_no_hover;
        }
        #region cantidadEstrellas
        private void rb_1estrella_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 1;
        }

        private void rb_2estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 2;
        }

        private void rb_3estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 3;
        }

        private void rb_4estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 4;
        }

        private void rb_5estrellas_Click(object sender, EventArgs e)
        {
            cantidad_estrellas = 5;
        }
        #endregion

        private void Hotel_baja_Load(object sender, EventArgs e)
        {

        }
        #endregion



    }
}
