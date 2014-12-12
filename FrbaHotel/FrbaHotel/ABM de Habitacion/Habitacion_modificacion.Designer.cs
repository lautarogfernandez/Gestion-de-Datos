namespace FrbaHotel.ABM_de_Habitacion
{
    partial class Habitacion_modificacion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.Filtros_de_busqueda = new System.Windows.Forms.GroupBox();
            this.cmb_Frente = new System.Windows.Forms.ComboBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.cmb_tipo_habitacion = new System.Windows.Forms.ComboBox();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.txt_piso = new System.Windows.Forms.TextBox();
            this.lbl_frente = new System.Windows.Forms.Label();
            this.lbl_Tipo_habitacion = new System.Windows.Forms.Label();
            this.lbl_Apellido = new System.Windows.Forms.Label();
            this.lbl_piso = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            this.Filtros_de_busqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_resultados
            // 
            this.dgv_resultados.AllowUserToAddRows = false;
            this.dgv_resultados.AllowUserToDeleteRows = false;
            this.dgv_resultados.AllowUserToOrderColumns = true;
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_resultados.Location = new System.Drawing.Point(12, 170);
            this.dgv_resultados.MultiSelect = false;
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.ReadOnly = true;
            this.dgv_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_resultados.Size = new System.Drawing.Size(560, 300);
            this.dgv_resultados.TabIndex = 19;
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 540);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 24;
            this.stat_BarraEstado.Text = "Estado";
            // 
            // barra_progreso
            // 
            this.barra_progreso.Name = "barra_progreso";
            this.barra_progreso.Size = new System.Drawing.Size(100, 16);
            // 
            // label_progreso
            // 
            this.label_progreso.Name = "label_progreso";
            this.label_progreso.Size = new System.Drawing.Size(42, 17);
            this.label_progreso.Text = "Estado";
            // 
            // Filtros_de_busqueda
            // 
            this.Filtros_de_busqueda.Controls.Add(this.cmb_Frente);
            this.Filtros_de_busqueda.Controls.Add(this.button_Buscar);
            this.Filtros_de_busqueda.Controls.Add(this.cmb_tipo_habitacion);
            this.Filtros_de_busqueda.Controls.Add(this.txt_numero);
            this.Filtros_de_busqueda.Controls.Add(this.txt_piso);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_frente);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Tipo_habitacion);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Apellido);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_piso);
            this.Filtros_de_busqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Filtros_de_busqueda.Location = new System.Drawing.Point(12, 3);
            this.Filtros_de_busqueda.Name = "Filtros_de_busqueda";
            this.Filtros_de_busqueda.Size = new System.Drawing.Size(560, 161);
            this.Filtros_de_busqueda.TabIndex = 23;
            this.Filtros_de_busqueda.TabStop = false;
            this.Filtros_de_busqueda.Text = "Filtros de búsqueda";
            // 
            // cmb_Frente
            // 
            this.cmb_Frente.FormattingEnabled = true;
            this.cmb_Frente.Items.AddRange(new object[] {
            "Vista Exterior",
            "Vista Interior"});
            this.cmb_Frente.Location = new System.Drawing.Point(90, 62);
            this.cmb_Frente.Name = "cmb_Frente";
            this.cmb_Frente.Size = new System.Drawing.Size(121, 21);
            this.cmb_Frente.TabIndex = 202;
            this.cmb_Frente.SelectedIndexChanged += new System.EventHandler(this.cmb_Frente_SelectedIndexChanged);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar.Location = new System.Drawing.Point(226, 101);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(119, 45);
            this.button_Buscar.TabIndex = 6;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // cmb_tipo_habitacion
            // 
            this.cmb_tipo_habitacion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmb_tipo_habitacion.FormattingEnabled = true;
            this.cmb_tipo_habitacion.Location = new System.Drawing.Point(382, 62);
            this.cmb_tipo_habitacion.Name = "cmb_tipo_habitacion";
            this.cmb_tipo_habitacion.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipo_habitacion.TabIndex = 4;
            this.cmb_tipo_habitacion.SelectedIndexChanged += new System.EventHandler(this.cmb_tipo_habitacion_SelectedIndexChanged);
            // 
            // txt_numero
            // 
            this.txt_numero.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_numero.Location = new System.Drawing.Point(382, 25);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(121, 20);
            this.txt_numero.TabIndex = 2;
            this.txt_numero.Text = "Ingrese número";
            this.txt_numero.TextChanged += new System.EventHandler(this.txt_numero_TextChanged);
            this.txt_numero.Click += new System.EventHandler(this.txt_numero_Click);
            this.txt_numero.Leave += new System.EventHandler(this.txt_numero_Leave);
            this.txt_numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            // 
            // txt_piso
            // 
            this.txt_piso.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_piso.Location = new System.Drawing.Point(90, 25);
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(121, 20);
            this.txt_piso.TabIndex = 1;
            this.txt_piso.Text = "Ingrese piso";
            this.txt_piso.TextChanged += new System.EventHandler(this.txt_piso_TextChanged);
            this.txt_piso.Click += new System.EventHandler(this.txt_piso_Click);
            this.txt_piso.Leave += new System.EventHandler(this.txt_piso_Leave);
            this.txt_piso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            // 
            // lbl_frente
            // 
            this.lbl_frente.AutoSize = true;
            this.lbl_frente.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_frente.Location = new System.Drawing.Point(20, 65);
            this.lbl_frente.Name = "lbl_frente";
            this.lbl_frente.Size = new System.Drawing.Size(37, 13);
            this.lbl_frente.TabIndex = 4;
            this.lbl_frente.Text = "Frente";
            // 
            // lbl_Tipo_habitacion
            // 
            this.lbl_Tipo_habitacion.AutoSize = true;
            this.lbl_Tipo_habitacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Tipo_habitacion.Location = new System.Drawing.Point(270, 65);
            this.lbl_Tipo_habitacion.Name = "lbl_Tipo_habitacion";
            this.lbl_Tipo_habitacion.Size = new System.Drawing.Size(95, 13);
            this.lbl_Tipo_habitacion.TabIndex = 6;
            this.lbl_Tipo_habitacion.Text = "Tipo de habitación";
            // 
            // lbl_Apellido
            // 
            this.lbl_Apellido.AutoSize = true;
            this.lbl_Apellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Apellido.Location = new System.Drawing.Point(270, 30);
            this.lbl_Apellido.Name = "lbl_Apellido";
            this.lbl_Apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_Apellido.TabIndex = 2;
            this.lbl_Apellido.Text = "Número";
            // 
            // lbl_piso
            // 
            this.lbl_piso.AutoSize = true;
            this.lbl_piso.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_piso.Location = new System.Drawing.Point(20, 30);
            this.lbl_piso.Name = "lbl_piso";
            this.lbl_piso.Size = new System.Drawing.Size(27, 13);
            this.lbl_piso.TabIndex = 0;
            this.lbl_piso.Text = "Piso";
            // 
            // button_modificar
            // 
            this.button_modificar.Enabled = false;
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_modificar.Location = new System.Drawing.Point(222, 477);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 21;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 476);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 22;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(12, 476);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 20;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // Habitacion_modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.dgv_resultados);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.Filtros_de_busqueda);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Habitacion_modificacion";
            this.Text = "Habitacion_modificacion";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.Filtros_de_busqueda.ResumeLayout(false);
            this.Filtros_de_busqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_resultados;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.GroupBox Filtros_de_busqueda;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.ComboBox cmb_tipo_habitacion;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.TextBox txt_piso;
        private System.Windows.Forms.Label lbl_frente;
        private System.Windows.Forms.Label lbl_Tipo_habitacion;
        private System.Windows.Forms.Label lbl_Apellido;
        private System.Windows.Forms.Label lbl_piso;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.ComboBox cmb_Frente;
    }
}