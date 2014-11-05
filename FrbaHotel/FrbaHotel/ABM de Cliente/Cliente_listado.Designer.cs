namespace FrbaHotel.ABM_de_Cliente
{
    partial class Cliente_listado
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
            this.Filtros_de_busqueda = new System.Windows.Forms.GroupBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.txt_Apellido = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.lbl_Numero_id = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tipo_identificacion = new System.Windows.Forms.Label();
            this.lbl_Apellido = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.Filtros_de_busqueda.SuspendLayout();
            this.stat_BarraEstado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // Filtros_de_busqueda
            // 
            this.Filtros_de_busqueda.Controls.Add(this.button_Buscar);
            this.Filtros_de_busqueda.Controls.Add(this.txt_numeroIdentificacion);
            this.Filtros_de_busqueda.Controls.Add(this.cmb_tipoIdentificacion);
            this.Filtros_de_busqueda.Controls.Add(this.txt_Email);
            this.Filtros_de_busqueda.Controls.Add(this.txt_Apellido);
            this.Filtros_de_busqueda.Controls.Add(this.txt_Nombre);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Numero_id);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Email);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Tipo_identificacion);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Apellido);
            this.Filtros_de_busqueda.Controls.Add(this.lbl_Nombre);
            this.Filtros_de_busqueda.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.Filtros_de_busqueda.Location = new System.Drawing.Point(12, 12);
            this.Filtros_de_busqueda.Name = "Filtros_de_busqueda";
            this.Filtros_de_busqueda.Size = new System.Drawing.Size(560, 161);
            this.Filtros_de_busqueda.TabIndex = 0;
            this.Filtros_de_busqueda.TabStop = false;
            this.Filtros_de_busqueda.Text = "Filtros de búsqueda";
            this.Filtros_de_busqueda.Enter += new System.EventHandler(this.Filtros_de_busqueda_Enter);
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar.Location = new System.Drawing.Point(395, 100);
            this.button_Buscar.Name = "button_Buscar";
            this.button_Buscar.Size = new System.Drawing.Size(135, 45);
            this.button_Buscar.TabIndex = 10;
            this.button_Buscar.Text = "Buscar";
            this.button_Buscar.UseVisualStyleBackColor = true;
            this.button_Buscar.Click += new System.EventHandler(this.button_Buscar_Click);
            // 
            // txt_numeroIdentificacion
            // 
            this.txt_numeroIdentificacion.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_numeroIdentificacion.Location = new System.Drawing.Point(170, 125);
            this.txt_numeroIdentificacion.Name = "txt_numeroIdentificacion";
            this.txt_numeroIdentificacion.Size = new System.Drawing.Size(200, 20);
            this.txt_numeroIdentificacion.TabIndex = 9;
            this.txt_numeroIdentificacion.Text = "Ingrese número de identificación";
            this.txt_numeroIdentificacion.TextChanged += new System.EventHandler(this.txt_numeroIdentificacion_TextChanged);
            this.txt_numeroIdentificacion.Click += new System.EventHandler(this.txt_numeroIdentificacion_Click);
            this.txt_numeroIdentificacion.Leave += new System.EventHandler(this.txt_numeroIdentificacion_Leave);
            // 
            // cmb_tipoIdentificacion
            // 
            this.cmb_tipoIdentificacion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmb_tipoIdentificacion.FormattingEnabled = true;
            this.cmb_tipoIdentificacion.Location = new System.Drawing.Point(20, 125);
            this.cmb_tipoIdentificacion.Name = "cmb_tipoIdentificacion";
            this.cmb_tipoIdentificacion.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipoIdentificacion.TabIndex = 7;
            this.cmb_tipoIdentificacion.Text = "Seleccione tipo";
            this.cmb_tipoIdentificacion.SelectedIndexChanged += new System.EventHandler(this.cmb_tipoIdentificacion_SelectedIndexChanged);
            // 
            // txt_Email
            // 
            this.txt_Email.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Email.Location = new System.Drawing.Point(70, 60);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(460, 20);
            this.txt_Email.TabIndex = 5;
            this.txt_Email.Text = "Ingrese e-mail";
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            this.txt_Email.Click += new System.EventHandler(this.txt_Email_Click);
            this.txt_Email.Leave += new System.EventHandler(this.txt_Email_Leave);
            // 
            // txt_Apellido
            // 
            this.txt_Apellido.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Apellido.Location = new System.Drawing.Point(320, 25);
            this.txt_Apellido.Name = "txt_Apellido";
            this.txt_Apellido.Size = new System.Drawing.Size(210, 20);
            this.txt_Apellido.TabIndex = 3;
            this.txt_Apellido.Text = "Ingrese apellido";
            this.txt_Apellido.TextChanged += new System.EventHandler(this.txt_Apellido_TextChanged);
            this.txt_Apellido.Click += new System.EventHandler(this.txt_Apellido_Click);
            this.txt_Apellido.Leave += new System.EventHandler(this.txt_Apellido_Leave);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Nombre.Location = new System.Drawing.Point(70, 25);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(180, 20);
            this.txt_Nombre.TabIndex = 1;
            this.txt_Nombre.Text = "Ingrese nombre";
            this.txt_Nombre.TextChanged += new System.EventHandler(this.txt_Nombre_TextChanged);
            this.txt_Nombre.Click += new System.EventHandler(this.txt_Nombre_Click);
            this.txt_Nombre.Leave += new System.EventHandler(this.txt_Nombre_Leave);
            // 
            // lbl_Numero_id
            // 
            this.lbl_Numero_id.AutoSize = true;
            this.lbl_Numero_id.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Numero_id.Location = new System.Drawing.Point(170, 100);
            this.lbl_Numero_id.Name = "lbl_Numero_id";
            this.lbl_Numero_id.Size = new System.Drawing.Size(124, 13);
            this.lbl_Numero_id.TabIndex = 8;
            this.lbl_Numero_id.Text = "Número de identificacion";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Email.Location = new System.Drawing.Point(20, 65);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 4;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_Tipo_identificacion
            // 
            this.lbl_Tipo_identificacion.AutoSize = true;
            this.lbl_Tipo_identificacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Tipo_identificacion.Location = new System.Drawing.Point(20, 100);
            this.lbl_Tipo_identificacion.Name = "lbl_Tipo_identificacion";
            this.lbl_Tipo_identificacion.Size = new System.Drawing.Size(108, 13);
            this.lbl_Tipo_identificacion.TabIndex = 6;
            this.lbl_Tipo_identificacion.Text = "Tipo de identificación";
            // 
            // lbl_Apellido
            // 
            this.lbl_Apellido.AutoSize = true;
            this.lbl_Apellido.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Apellido.Location = new System.Drawing.Point(270, 30);
            this.lbl_Apellido.Name = "lbl_Apellido";
            this.lbl_Apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_Apellido.TabIndex = 2;
            this.lbl_Apellido.Text = "Apellido";
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Nombre.Location = new System.Drawing.Point(20, 30);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_Nombre.TabIndex = 0;
            this.lbl_Nombre.Text = "Nombre";
            // 
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(12, 485);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 11;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            this.button_limpiar.Click += new System.EventHandler(this.button_limpiar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 485);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 12;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 13;
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
            // dgv_resultados
            // 
            this.dgv_resultados.AllowUserToAddRows = false;
            this.dgv_resultados.AllowUserToDeleteRows = false;
            this.dgv_resultados.AllowUserToOrderColumns = true;
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_resultados.Location = new System.Drawing.Point(12, 179);
            this.dgv_resultados.MultiSelect = false;
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.ReadOnly = true;
            this.dgv_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_resultados.Size = new System.Drawing.Size(560, 300);
            this.dgv_resultados.TabIndex = 14;
            this.dgv_resultados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_resultados_CellContentClick);
            // 
            // Cliente_listado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.dgv_resultados);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.Filtros_de_busqueda);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Cliente_listado";
            this.Text = "Listado Clientes";
            this.Load += new System.EventHandler(this.Cliente_listado_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cliente_listado_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Cliente_listado_KeyUp);
            this.Filtros_de_busqueda.ResumeLayout(false);
            this.Filtros_de_busqueda.PerformLayout();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Filtros_de_busqueda;
        private System.Windows.Forms.Label lbl_Tipo_identificacion;
        private System.Windows.Forms.Label lbl_Apellido;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label lbl_Numero_id;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.TextBox txt_Apellido;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.DataGridView dgv_resultados;
    }
}