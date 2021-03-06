﻿using System;
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
    public partial class Rol_baja : Form
    {
        private bool _buscanombre = false;
        private valoresDataGridView _valores;
        public Rol_baja()
        {
            InitializeComponent();
            string busqueda = "SELECT [Cod_funcion], [Descripcion] FROM [TEAM_CASTY].Funcion";
            SqlConnection conn = Home.obtenerConexion();                                                                                                                              //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list_funciones.Items.Add(reader["Descripcion"].ToString());
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
        }

        private void Rol_baja_Load(object sender, EventArgs e)
        {

        }
        #region Txt_Nombre
        private void txt_nombre_TextChanged(object sender, EventArgs e)
        {
            if (txt_nombre.TextLength > 0 && txt_nombre.Text != "Ingrese nombre")
            {
                txt_nombre.ForeColor = SystemColors.MenuText;
                _buscanombre = true;
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

        }
        #endregion
        private void lbl_Pais_Click(object sender, EventArgs e)
        {

        }

        private void lbl_roles_Click(object sender, EventArgs e)
        {

        }

        private void button_Buscar_Click(object sender, EventArgs e)
        {
            button_desactivar.Enabled = false;
            button_desactivar.ForeColor = SystemColors.ScrollBar;
            string busqueda = "SELECT [Codigo de Rol], [Nombre], [Activo] FROM [GD2C2014].[TEAM_CASTY].[vistaRoles]";          //búsqueda básica
            button_Buscar.Enabled = false;            //Deshabilito búsqueda hasta que haya resultado
            label_progreso.Text = "Cargando Roles";       //Imprime en la barra de progreso
            SqlConnection conn = Home.obtenerConexion();                                                                                                                                 //Abrir Conexión
            SqlDataAdapter adaptador;                                                                                                          //Creo adaptador para la busqueda
            barra_progreso.Value = 5;                                                                                                            //0% de la barra de progreso
            DataTable tablaRoles = new DataTable();                                                                                 //Creo Tabla para los resultados
            #region Condiciones_de_busqueda
            if (_buscanombre || rb_activo.Checked || rb_inactivo.Checked)
            {
                busqueda += " WHERE ";
                bool _masDeUno = false;
                if (_buscanombre)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Nombre] LIKE '%" + txt_nombre.Text.ToString().ToUpper() + "%'";
                }
                if (rb_activo.Checked)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Activo] =1";
                }
                if (rb_inactivo.Checked)
                {
                    if (_masDeUno) busqueda += " AND ";
                    _masDeUno = true;
                    busqueda += " [Activo]=0";
                }
            }
            #endregion
            try
            {
                adaptador = new SqlDataAdapter(busqueda, conn);                                                              //Busco en la sesión abierta
                adaptador.Fill(tablaRoles);                                                                                                    //LLeno tabla de resultados
                dgv_roles.DataSource = tablaRoles;                                                                           //LLeno datagrid con tabla
                barra_progreso.Value = 100;                                                                                                    //Aviso que terminó la búsqueda
                label_progreso.Text = tablaRoles.Rows.Count.ToString() + " Roles encontrados";      //Le digo la cantidad de filas encontradas
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
            button_limpiar.Enabled = true;
            button_limpiar.ForeColor = SystemColors.MenuText;                            //habilita el boton limpiar

        }
        private void button_limpiar_Click(object sender, EventArgs e)
        {
            dgv_roles.DataSource = null;
            list_funciones.ClearSelected();
            button_limpiar.Enabled = false;
            button_limpiar.ForeColor = SystemColors.ScrollBar;
            label_progreso.Text = "Tabla de resultados vacía";
            button_desactivar.Enabled = false;
            button_desactivar.ForeColor = SystemColors.ScrollBar;
            for (int i = 0; i < list_funciones.Items.Count; i++)
                list_funciones.SetItemChecked(i, false);
        }

        private void button_modificar_Click(object sender, EventArgs e)
        {
            
        }

        private void dgv_roles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string busqueda = "SELECT [Cod_Funcion], [Descripcion] FROM [TEAM_CASTY].FuncionesDeUnRol (" + dgv_roles.SelectedCells[0].Value + ")";
            SqlConnection conn = Home.obtenerConexion();                                                                                                                                    //Abrir Conexión
            SqlCommand cmd = new SqlCommand(busqueda, conn);
            for (int i = 0; i < list_funciones.Items.Count; i++)
                list_funciones.SetItemChecked(i, false);
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                _valores.codigos_funciones = new List<int>();
                while (reader.Read())
                {
                    list_funciones.SetItemChecked(Convert.ToInt32(reader["Cod_Funcion"]) - 1, true);
                    _valores.codigos_funciones.Add(Convert.ToInt32(reader["Cod_Funcion"]));
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
            button_desactivar.Enabled = true;
            button_desactivar.ForeColor = SystemColors.MenuText;
            conn.Close();
        }

        private void dgv_funciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_desactivar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgv_roles.SelectedCells.Count; i++)
            {
                switch (dgv_roles.Columns[i].HeaderText)
                {
                    case "Codigo de Rol":
                        {
                            _valores._codigo = dgv_roles.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Nombre":
                        {
                            _valores._nombre = dgv_roles.SelectedCells[i].Value.ToString();
                            break;
                        }
                    case "Activo":
                        {
                            _valores._activo = dgv_roles.SelectedCells[i].Value.ToString();
                            break;
                        }
                }
            }
        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }
    }
}
