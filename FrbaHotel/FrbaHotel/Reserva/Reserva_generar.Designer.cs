namespace FrbaHotel.Reserva
{
    partial class Reserva_generar
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
            this.dgv_regimenes = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.dgv_tipos_habitaciones = new System.Windows.Forms.DataGridView();
            this.lbl_habitacion_consumible = new System.Windows.Forms.Label();
            this.lbl_estadía = new System.Windows.Forms.Label();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regimenes)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tipos_habitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_regimenes
            // 
            this.dgv_regimenes.AllowUserToAddRows = false;
            this.dgv_regimenes.AllowUserToDeleteRows = false;
            this.dgv_regimenes.AllowUserToOrderColumns = true;
            this.dgv_regimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_regimenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_regimenes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_regimenes.Location = new System.Drawing.Point(282, 223);
            this.dgv_regimenes.MultiSelect = false;
            this.dgv_regimenes.Name = "dgv_regimenes";
            this.dgv_regimenes.RowHeadersWidth = 20;
            this.dgv_regimenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_regimenes.Size = new System.Drawing.Size(290, 229);
            this.dgv_regimenes.TabIndex = 32;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(12, 483);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 29;
            this.button_aceptar.Text = "Validar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            this.button_aceptar.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 31;
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
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 483);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 30;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // dgv_tipos_habitaciones
            // 
            this.dgv_tipos_habitaciones.AllowUserToAddRows = false;
            this.dgv_tipos_habitaciones.AllowUserToDeleteRows = false;
            this.dgv_tipos_habitaciones.AllowUserToOrderColumns = true;
            this.dgv_tipos_habitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tipos_habitaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_tipos_habitaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_tipos_habitaciones.Location = new System.Drawing.Point(12, 223);
            this.dgv_tipos_habitaciones.MultiSelect = false;
            this.dgv_tipos_habitaciones.Name = "dgv_tipos_habitaciones";
            this.dgv_tipos_habitaciones.RowHeadersWidth = 20;
            this.dgv_tipos_habitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_tipos_habitaciones.Size = new System.Drawing.Size(264, 229);
            this.dgv_tipos_habitaciones.TabIndex = 27;
            this.dgv_tipos_habitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tipos_habitaciones_CellClick);
            this.dgv_tipos_habitaciones.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_tipos_habitaciones_CellEnter);
            this.dgv_tipos_habitaciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_habitaciones_CellContentClick);
            // 
            // lbl_habitacion_consumible
            // 
            this.lbl_habitacion_consumible.AutoSize = true;
            this.lbl_habitacion_consumible.Location = new System.Drawing.Point(9, 201);
            this.lbl_habitacion_consumible.Name = "lbl_habitacion_consumible";
            this.lbl_habitacion_consumible.Size = new System.Drawing.Size(185, 13);
            this.lbl_habitacion_consumible.TabIndex = 25;
            this.lbl_habitacion_consumible.Text = "Seleccione habitaciones y regimenes.";
            // 
            // lbl_estadía
            // 
            this.lbl_estadía.AutoSize = true;
            this.lbl_estadía.Location = new System.Drawing.Point(13, 6);
            this.lbl_estadía.Name = "lbl_estadía";
            this.lbl_estadía.Size = new System.Drawing.Size(162, 13);
            this.lbl_estadía.TabIndex = 24;
            this.lbl_estadía.Text = "Ingrese un período para reservar";
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(238, 35);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(38, 13);
            this.lbl_desde.TabIndex = 36;
            this.lbl_desde.Text = "Desde";
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(315, 35);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(35, 13);
            this.lbl_hasta.TabIndex = 37;
            this.lbl_hasta.Text = "Hasta";
            // 
            // dtp_desde
            // 
            this.dtp_desde.Location = new System.Drawing.Point(16, 35);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(216, 20);
            this.dtp_desde.TabIndex = 38;
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(356, 35);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(216, 20);
            this.dtp_hasta.TabIndex = 39;
            // 
            // Reserva_generar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.dtp_hasta);
            this.Controls.Add(this.dtp_desde);
            this.Controls.Add(this.lbl_hasta);
            this.Controls.Add(this.lbl_desde);
            this.Controls.Add(this.dgv_regimenes);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.dgv_tipos_habitaciones);
            this.Controls.Add(this.lbl_habitacion_consumible);
            this.Controls.Add(this.lbl_estadía);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Reserva_generar";
            this.Text = "Reserva_generar";
            this.Load += new System.EventHandler(this.Reserva_generar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regimenes)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tipos_habitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_regimenes;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.DataGridView dgv_tipos_habitaciones;
        private System.Windows.Forms.Label lbl_habitacion_consumible;
        private System.Windows.Forms.Label lbl_estadía;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
    }
}