namespace FrbaHotel.Registrar_Consumible
{
    partial class Consumible_registrar
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
            this.lbl_estadía = new System.Windows.Forms.Label();
            this.lbl_habitacion_consumible = new System.Windows.Forms.Label();
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.dgv_habitaciones = new System.Windows.Forms.DataGridView();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.dgv_consumible_cantidad = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_habitaciones)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consumible_cantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_estadía
            // 
            this.lbl_estadía.AutoSize = true;
            this.lbl_estadía.Location = new System.Drawing.Point(13, 13);
            this.lbl_estadía.Name = "lbl_estadía";
            this.lbl_estadía.Size = new System.Drawing.Size(277, 13);
            this.lbl_estadía.TabIndex = 1;
            this.lbl_estadía.Text = "Seleccione una estadía actual para registrar consumibles";
            // 
            // lbl_habitacion_consumible
            // 
            this.lbl_habitacion_consumible.AutoSize = true;
            this.lbl_habitacion_consumible.Location = new System.Drawing.Point(9, 208);
            this.lbl_habitacion_consumible.Name = "lbl_habitacion_consumible";
            this.lbl_habitacion_consumible.Size = new System.Drawing.Size(267, 13);
            this.lbl_habitacion_consumible.TabIndex = 2;
            this.lbl_habitacion_consumible.Text = "Seleccione una habitación y los consumibles a registrar";
            // 
            // dgv_resultados
            // 
            this.dgv_resultados.AllowUserToAddRows = false;
            this.dgv_resultados.AllowUserToDeleteRows = false;
            this.dgv_resultados.AllowUserToOrderColumns = true;
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_resultados.Location = new System.Drawing.Point(12, 29);
            this.dgv_resultados.MultiSelect = false;
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.ReadOnly = true;
            this.dgv_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_resultados.Size = new System.Drawing.Size(560, 176);
            this.dgv_resultados.TabIndex = 8;
            this.dgv_resultados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_resultados_CellClick);
            // 
            // dgv_habitaciones
            // 
            this.dgv_habitaciones.AllowUserToAddRows = false;
            this.dgv_habitaciones.AllowUserToDeleteRows = false;
            this.dgv_habitaciones.AllowUserToOrderColumns = true;
            this.dgv_habitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_habitaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_habitaciones.Location = new System.Drawing.Point(12, 230);
            this.dgv_habitaciones.MultiSelect = false;
            this.dgv_habitaciones.Name = "dgv_habitaciones";
            this.dgv_habitaciones.ReadOnly = true;
            this.dgv_habitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_habitaciones.Size = new System.Drawing.Size(264, 229);
            this.dgv_habitaciones.TabIndex = 9;
            this.dgv_habitaciones.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_habitaciones_CellClick);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(222, 491);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 20;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_modificar_Click);
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
            this.stat_BarraEstado.TabIndex = 22;
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
            this.button_volver.Location = new System.Drawing.Point(437, 490);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 21;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(12, 490);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 19;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            this.button_limpiar.EnabledChanged += new System.EventHandler(this.button_EnabledChanged);
            // 
            // dgv_consumible_cantidad
            // 
            this.dgv_consumible_cantidad.AllowUserToAddRows = false;
            this.dgv_consumible_cantidad.AllowUserToDeleteRows = false;
            this.dgv_consumible_cantidad.AllowUserToOrderColumns = true;
            this.dgv_consumible_cantidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_consumible_cantidad.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_consumible_cantidad.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_consumible_cantidad.Location = new System.Drawing.Point(282, 230);
            this.dgv_consumible_cantidad.MultiSelect = false;
            this.dgv_consumible_cantidad.Name = "dgv_consumible_cantidad";
            this.dgv_consumible_cantidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_consumible_cantidad.Size = new System.Drawing.Size(290, 229);
            this.dgv_consumible_cantidad.TabIndex = 23;
            this.dgv_consumible_cantidad.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consumible_cantidad_CellEnter);
            this.dgv_consumible_cantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgv_consumible_cantidad_KeyPress);
            this.dgv_consumible_cantidad.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_consumible_cantidad_CellContentClick_1);
            // 
            // Consumible_registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.dgv_consumible_cantidad);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.dgv_habitaciones);
            this.Controls.Add(this.dgv_resultados);
            this.Controls.Add(this.lbl_habitacion_consumible);
            this.Controls.Add(this.lbl_estadía);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Consumible_registrar";
            this.Text = "Consumible_registrar";
            this.Load += new System.EventHandler(this.Consumible_registrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_habitaciones)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_consumible_cantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_estadía;
        private System.Windows.Forms.Label lbl_habitacion_consumible;
        private System.Windows.Forms.DataGridView dgv_resultados;
        private System.Windows.Forms.DataGridView dgv_habitaciones;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.DataGridView dgv_consumible_cantidad;
    }
}