namespace FrbaHotel.ABM_de_Rol
{
    partial class Rol_modificacion
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
            this.button_modificar = new System.Windows.Forms.Button();
            this.dgv_roles = new System.Windows.Forms.DataGridView();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.Filtros_de_busqueda = new System.Windows.Forms.GroupBox();
            this.rb_inactivo = new System.Windows.Forms.RadioButton();
            this.rb_activo = new System.Windows.Forms.RadioButton();
            this.lbl_inactivo = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_activo = new System.Windows.Forms.Label();
            this.lbl_roles = new System.Windows.Forms.Label();
            this.lbl_funciones = new System.Windows.Forms.Label();
            this.list_funciones = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            this.Filtros_de_busqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_modificar
            // 
            this.button_modificar.Enabled = false;
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_modificar.Location = new System.Drawing.Point(222, 475);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 200;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // dgv_roles
            // 
            this.dgv_roles.AllowUserToAddRows = false;
            this.dgv_roles.AllowUserToDeleteRows = false;
            this.dgv_roles.AllowUserToOrderColumns = true;
            this.dgv_roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_roles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_roles.Location = new System.Drawing.Point(12, 126);
            this.dgv_roles.MultiSelect = false;
            this.dgv_roles.Name = "dgv_roles";
            this.dgv_roles.ReadOnly = true;
            this.dgv_roles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_roles.Size = new System.Drawing.Size(277, 343);
            this.dgv_roles.TabIndex = 198;
            this.dgv_roles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_roles_CellContentClick);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 203;
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
            this.button_volver.Location = new System.Drawing.Point(437, 474);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 201;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(12, 474);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 199;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // Filtros_de_busqueda
            // 
            this.Filtros_de_busqueda.Controls.Add(this.rb_inactivo);
            this.Filtros_de_busqueda.Controls.Add(this.rb_activo);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_inactivo);
            this.Filtros_de_busqueda.Controls.Add(this.button_Buscar);
            this.Filtros_de_busqueda.Controls.Add(this.txt_nombre);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_nombre);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_activo);
            this.Filtros_de_busqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Filtros_de_busqueda.Location = new System.Drawing.Point(12, 12);
            this.Filtros_de_busqueda.Name = "Filtros_de_busqueda";
            this.Filtros_de_busqueda.Size = new System.Drawing.Size(560, 71);
            this.Filtros_de_busqueda.TabIndex = 202;
            this.Filtros_de_busqueda.TabStop = false;
            this.Filtros_de_busqueda.Text = "Filtros de búsqueda";
            // 
            // rb_inactivo
            // 
            this.rb_inactivo.AutoSize = true;
            this.rb_inactivo.Location = new System.Drawing.Point(364, 43);
            this.rb_inactivo.Name = "rb_inactivo";
            this.rb_inactivo.Size = new System.Drawing.Size(14, 13);
            this.rb_inactivo.TabIndex = 9;
            this.rb_inactivo.TabStop = true;
            this.rb_inactivo.UseVisualStyleBackColor = true;
            // 
            // rb_activo
            // 
            this.rb_activo.AutoSize = true;
            this.rb_activo.Location = new System.Drawing.Point(295, 43);
            this.rb_activo.Name = "rb_activo";
            this.rb_activo.Size = new System.Drawing.Size(14, 13);
            this.rb_activo.TabIndex = 8;
            this.rb_activo.TabStop = true;
            this.rb_activo.UseVisualStyleBackColor = true;
            // 
            // lbl_inactivo
            // 
            this.lbl_inactivo.AutoSize = true;
            this.lbl_inactivo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_inactivo.Location = new System.Drawing.Point(343, 16);
            this.lbl_inactivo.Name = "lbl_inactivo";
            this.lbl_inactivo.Size = new System.Drawing.Size(57, 13);
            this.lbl_inactivo.TabIndex = 7;
            this.lbl_inactivo.Text = "INACTIVO";
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar.Location = new System.Drawing.Point(419, 16);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(135, 45);
            this.button_Buscar.TabIndex = 6;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // txt_nombre
            // 
            this.txt_nombre.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_nombre.Location = new System.Drawing.Point(78, 22);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(179, 20);
            this.txt_nombre.TabIndex = 3;
            this.txt_nombre.Text = "Ingrese Nombre";
            this.txt_nombre.TextChanged += new System.EventHandler(this.txt_nombre_TextChanged);
            this.txt_nombre.Click += new System.EventHandler(this.txt_nombre_Click);
            this.txt_nombre.Leave += new System.EventHandler(this.txt_nombre_Leave);
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_nombre.Location = new System.Drawing.Point(14, 25);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 4;
            this.lbl_nombre.Text = "Nombre";
            this.lbl_nombre.Click += new System.EventHandler(this.lbl_Pais_Click);
            // 
            // lbl_activo
            // 
            this.lbl_activo.AutoSize = true;
            this.lbl_activo.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_activo.Location = new System.Drawing.Point(280, 16);
            this.lbl_activo.Name = "lbl_activo";
            this.lbl_activo.Size = new System.Drawing.Size(46, 13);
            this.lbl_activo.TabIndex = 2;
            this.lbl_activo.Text = "ACTIVO";
            // 
            // lbl_roles
            // 
            this.lbl_roles.AutoSize = true;
            this.lbl_roles.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_roles.Location = new System.Drawing.Point(29, 90);
            this.lbl_roles.Name = "lbl_roles";
            this.lbl_roles.Size = new System.Drawing.Size(76, 29);
            this.lbl_roles.TabIndex = 205;
            this.lbl_roles.Text = "Roles";
            this.lbl_roles.Click += new System.EventHandler(this.lbl_roles_Click);
            // 
            // lbl_funciones
            // 
            this.lbl_funciones.AutoSize = true;
            this.lbl_funciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_funciones.Location = new System.Drawing.Point(312, 90);
            this.lbl_funciones.Name = "lbl_funciones";
            this.lbl_funciones.Size = new System.Drawing.Size(208, 29);
            this.lbl_funciones.TabIndex = 206;
            this.lbl_funciones.Text = "Funciones del Rol";
            // 
            // list_funciones
            // 
            this.list_funciones.Enabled = false;
            this.list_funciones.FormattingEnabled = true;
            this.list_funciones.Location = new System.Drawing.Point(295, 126);
            this.list_funciones.Name = "list_funciones";
            this.list_funciones.Size = new System.Drawing.Size(277, 334);
            this.list_funciones.TabIndex = 207;
            // 
            // Rol_modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.list_funciones);
            this.Controls.Add(this.lbl_funciones);
            this.Controls.Add(this.lbl_roles);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.dgv_roles);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.Filtros_de_busqueda);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Rol_modificacion";
            this.Text = "Rol_modificacion";
            this.Load += new System.EventHandler(this.Rol_modificacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.Filtros_de_busqueda.ResumeLayout(false);
            this.Filtros_de_busqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.DataGridView dgv_roles;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.GroupBox Filtros_de_busqueda;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_activo;
        private System.Windows.Forms.Label lbl_inactivo;
        private System.Windows.Forms.Label lbl_roles;
        private System.Windows.Forms.Label lbl_funciones;
        private System.Windows.Forms.RadioButton rb_inactivo;
        private System.Windows.Forms.RadioButton rb_activo;
        private System.Windows.Forms.CheckedListBox list_funciones;
    }
}