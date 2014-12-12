namespace FrbaHotel.ABM_de_Usuario
{
    partial class Usuario_elegir_roles_por_hotel
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
            this.dgv_roles = new System.Windows.Forms.DataGridView();
            this.dgv_hoteles = new System.Windows.Forms.DataGridView();
            this.button_guardar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.lbl_elija = new System.Windows.Forms.Label();
            this.lbl_lainfo = new System.Windows.Forms.Label();
            this.lbl_hotel = new System.Windows.Forms.Label();
            this.lbl_roles = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoteles)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_roles
            // 
            this.dgv_roles.AllowUserToAddRows = false;
            this.dgv_roles.AllowUserToDeleteRows = false;
            this.dgv_roles.AllowUserToOrderColumns = true;
            this.dgv_roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_roles.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_roles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_roles.Location = new System.Drawing.Point(10, 281);
            this.dgv_roles.MultiSelect = false;
            this.dgv_roles.Name = "dgv_roles";
            this.dgv_roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_roles.Size = new System.Drawing.Size(560, 189);
            this.dgv_roles.TabIndex = 25;
            this.dgv_roles.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_roles_CellEnter);
            // 
            // dgv_hoteles
            // 
            this.dgv_hoteles.AllowUserToAddRows = false;
            this.dgv_hoteles.AllowUserToDeleteRows = false;
            this.dgv_hoteles.AllowUserToOrderColumns = true;
            this.dgv_hoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoteles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_hoteles.Location = new System.Drawing.Point(10, 88);
            this.dgv_hoteles.MultiSelect = false;
            this.dgv_hoteles.Name = "dgv_hoteles";
            this.dgv_hoteles.ReadOnly = true;
            this.dgv_hoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_hoteles.Size = new System.Drawing.Size(560, 159);
            this.dgv_hoteles.TabIndex = 24;
            this.dgv_hoteles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hoteles_CellClick);
            this.dgv_hoteles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hoteles_CellContentClick);
            // 
            // button_guardar
            // 
            this.button_guardar.Enabled = false;
            this.button_guardar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_guardar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_guardar.Location = new System.Drawing.Point(153, 476);
            this.button_guardar.Name = "button_guardar";
            this.button_guardar.Size = new System.Drawing.Size(135, 45);
            this.button_guardar.TabIndex = 27;
            this.button_guardar.Text = "Guardar";
            this.button_guardar.UseVisualStyleBackColor = true;
            this.button_guardar.Click += new System.EventHandler(this.button_guardar_Click);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 29;
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
            this.button_volver.Location = new System.Drawing.Point(435, 476);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 28;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(294, 476);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 26;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            // 
            // lbl_elija
            // 
            this.lbl_elija.AutoSize = true;
            this.lbl_elija.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_elija.Location = new System.Drawing.Point(12, 9);
            this.lbl_elija.Name = "lbl_elija";
            this.lbl_elija.Size = new System.Drawing.Size(394, 24);
            this.lbl_elija.TabIndex = 30;
            this.lbl_elija.Text = "Elija los roles que desempeña por cada hotel:";
            // 
            // lbl_lainfo
            // 
            this.lbl_lainfo.AutoSize = true;
            this.lbl_lainfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_lainfo.Location = new System.Drawing.Point(12, 33);
            this.lbl_lainfo.Name = "lbl_lainfo";
            this.lbl_lainfo.Size = new System.Drawing.Size(503, 16);
            this.lbl_lainfo.TabIndex = 31;
            this.lbl_lainfo.Text = "(La informacion de cada hotel se almacena una vez que se hace click en \"guardar\")" +
                "";
            // 
            // lbl_hotel
            // 
            this.lbl_hotel.AutoSize = true;
            this.lbl_hotel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_hotel.Location = new System.Drawing.Point(12, 61);
            this.lbl_hotel.Name = "lbl_hotel";
            this.lbl_hotel.Size = new System.Drawing.Size(54, 24);
            this.lbl_hotel.TabIndex = 32;
            this.lbl_hotel.Text = "Hotel";
            // 
            // lbl_roles
            // 
            this.lbl_roles.AutoSize = true;
            this.lbl_roles.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_roles.Location = new System.Drawing.Point(8, 254);
            this.lbl_roles.Name = "lbl_roles";
            this.lbl_roles.Size = new System.Drawing.Size(58, 24);
            this.lbl_roles.TabIndex = 33;
            this.lbl_roles.Text = "Roles";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(12, 476);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 34;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // Usuario_elegir_roles_por_hotel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.lbl_roles);
            this.Controls.Add(this.lbl_hotel);
            this.Controls.Add(this.lbl_lainfo);
            this.Controls.Add(this.lbl_elija);
            this.Controls.Add(this.button_guardar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.dgv_roles);
            this.Controls.Add(this.dgv_hoteles);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Usuario_elegir_roles_por_hotel";
            this.Text = "Usuario_elegir_roles_por_hotel";
            this.Load += new System.EventHandler(this.Usuario_elegir_roles_por_hotel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoteles)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_roles;
        private System.Windows.Forms.DataGridView dgv_hoteles;
        private System.Windows.Forms.Button button_guardar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Label lbl_elija;
        private System.Windows.Forms.Label lbl_lainfo;
        private System.Windows.Forms.Label lbl_hotel;
        private System.Windows.Forms.Label lbl_roles;
        private System.Windows.Forms.Button button_aceptar;
    }
}