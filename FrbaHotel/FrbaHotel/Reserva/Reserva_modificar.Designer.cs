namespace FrbaHotel.Reserva
{
    partial class Reserva_modificar
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
            this.button_aceptar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.lbl_codigo_reserva = new System.Windows.Forms.Label();
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.txt_codigo_reserva = new System.Windows.Forms.TextBox();
            this.lbl_reserva = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.obli_email = new System.Windows.Forms.Label();
            this.obli_num_id = new System.Windows.Forms.Label();
            this._obli_tipo_id = new System.Windows.Forms.Label();
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Numero_id = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tipo_identificacion = new System.Windows.Forms.Label();
            this.grp_cambios = new System.Windows.Forms.GroupBox();
            this.dtp_hasta = new System.Windows.Forms.DateTimePicker();
            this.dtp_desde = new System.Windows.Forms.DateTimePicker();
            this.lbl_hasta = new System.Windows.Forms.Label();
            this.lbl_desde = new System.Windows.Forms.Label();
            this.dgv_regimenes = new System.Windows.Forms.DataGridView();
            this.dgv_tipos_habitaciones = new System.Windows.Forms.DataGridView();
            this.lbl_habitacion_consumible = new System.Windows.Forms.Label();
            this.lbl_estadía = new System.Windows.Forms.Label();
            this.stat_BarraEstado.SuspendLayout();
            this.grp_datos.SuspendLayout();
            this.grp_cambios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regimenes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tipos_habitaciones)).BeginInit();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(12, 480);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 43;
            this.button_aceptar.Text = "Validar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click_1);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 45;
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
            this.button_volver.Location = new System.Drawing.Point(437, 480);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 44;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // lbl_codigo_reserva
            // 
            this.lbl_codigo_reserva.AutoSize = true;
            this.lbl_codigo_reserva.Location = new System.Drawing.Point(17, 103);
            this.lbl_codigo_reserva.Name = "lbl_codigo_reserva";
            this.lbl_codigo_reserva.Size = new System.Drawing.Size(93, 13);
            this.lbl_codigo_reserva.TabIndex = 51;
            this.lbl_codigo_reserva.Text = "Codigo de reserva";
            // 
            // grp_datos
            // 
            this.grp_datos.Controls.Add(this.txt_codigo_reserva);
            this.grp_datos.Controls.Add(this.lbl_reserva);
            this.grp_datos.Controls.Add(this.button_modificar);
            this.grp_datos.Controls.Add(this.obli_email);
            this.grp_datos.Controls.Add(this.obli_num_id);
            this.grp_datos.Controls.Add(this._obli_tipo_id);
            this.grp_datos.Controls.Add(this.lbl_codigo_reserva);
            this.grp_datos.Controls.Add(this.lbl_informacion_obligatoria);
            this.grp_datos.Controls.Add(this.button_Buscar);
            this.grp_datos.Controls.Add(this.txt_numeroIdentificacion);
            this.grp_datos.Controls.Add(this.cmb_tipoIdentificacion);
            this.grp_datos.Controls.Add(this.txt_Email);
            this.grp_datos.Controls.Add(this.lbl_Numero_id);
            this.grp_datos.Controls.Add(this.lbl_Email);
            this.grp_datos.Controls.Add(this.lbl_Tipo_identificacion);
            this.grp_datos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grp_datos.Location = new System.Drawing.Point(12, 8);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(560, 152);
            this.grp_datos.TabIndex = 54;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Ingrese sus datos personales";
            this.grp_datos.Enter += new System.EventHandler(this.grp_datos_Enter);
            // 
            // txt_codigo_reserva
            // 
            this.txt_codigo_reserva.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_codigo_reserva.Location = new System.Drawing.Point(17, 117);
            this.txt_codigo_reserva.Name = "txt_codigo_reserva";
            this.txt_codigo_reserva.Size = new System.Drawing.Size(216, 20);
            this.txt_codigo_reserva.TabIndex = 153;
            this.txt_codigo_reserva.Text = "Ingrese codigo de reserva a modificar";
            this.txt_codigo_reserva.TextChanged += new System.EventHandler(this.txt_codigo_reserva_TextChanged);
            this.txt_codigo_reserva.Click += new System.EventHandler(this.txt_codigo_reserva_Click);
            this.txt_codigo_reserva.Leave += new System.EventHandler(this.txt_codigo_reserva_Leave);
            this.txt_codigo_reserva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numeroIdentificacion_KeyPress);
            // 
            // lbl_reserva
            // 
            this.lbl_reserva.AutoSize = true;
            this.lbl_reserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reserva.ForeColor = System.Drawing.Color.Red;
            this.lbl_reserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_reserva.Location = new System.Drawing.Point(239, 117);
            this.lbl_reserva.Name = "lbl_reserva";
            this.lbl_reserva.Size = new System.Drawing.Size(15, 20);
            this.lbl_reserva.TabIndex = 152;
            this.lbl_reserva.Text = "*";
            // 
            // button_modificar
            // 
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_modificar.Location = new System.Drawing.Point(419, 78);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 151;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Visible = false;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            // 
            // obli_email
            // 
            this.obli_email.AutoSize = true;
            this.obli_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obli_email.ForeColor = System.Drawing.Color.Red;
            this.obli_email.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.obli_email.Location = new System.Drawing.Point(389, 19);
            this.obli_email.Name = "obli_email";
            this.obli_email.Size = new System.Drawing.Size(15, 20);
            this.obli_email.TabIndex = 150;
            this.obli_email.Text = "*";
            // 
            // obli_num_id
            // 
            this.obli_num_id.AutoSize = true;
            this.obli_num_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obli_num_id.ForeColor = System.Drawing.Color.Red;
            this.obli_num_id.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.obli_num_id.Location = new System.Drawing.Point(389, 67);
            this.obli_num_id.Name = "obli_num_id";
            this.obli_num_id.Size = new System.Drawing.Size(15, 20);
            this.obli_num_id.TabIndex = 149;
            this.obli_num_id.Text = "*";
            // 
            // _obli_tipo_id
            // 
            this._obli_tipo_id.AutoSize = true;
            this._obli_tipo_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_tipo_id.ForeColor = System.Drawing.Color.Red;
            this._obli_tipo_id.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_tipo_id.Location = new System.Drawing.Point(144, 68);
            this._obli_tipo_id.Name = "_obli_tipo_id";
            this._obli_tipo_id.Size = new System.Drawing.Size(15, 20);
            this._obli_tipo_id.TabIndex = 148;
            this._obli_tipo_id.Text = "*";
            // 
            // lbl_informacion_obligatoria
            // 
            this.lbl_informacion_obligatoria.AutoSize = true;
            this.lbl_informacion_obligatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informacion_obligatoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_informacion_obligatoria.Location = new System.Drawing.Point(303, 126);
            this.lbl_informacion_obligatoria.Name = "lbl_informacion_obligatoria";
            this.lbl_informacion_obligatoria.Size = new System.Drawing.Size(168, 18);
            this.lbl_informacion_obligatoria.TabIndex = 11;
            this.lbl_informacion_obligatoria.Text = "* Información obligatoria";
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar.Location = new System.Drawing.Point(419, 19);
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
            this.txt_numeroIdentificacion.Location = new System.Drawing.Point(167, 67);
            this.txt_numeroIdentificacion.Name = "txt_numeroIdentificacion";
            this.txt_numeroIdentificacion.Size = new System.Drawing.Size(216, 20);
            this.txt_numeroIdentificacion.TabIndex = 9;
            this.txt_numeroIdentificacion.Text = "Ingrese número de identificación";
            this.txt_numeroIdentificacion.TextChanged += new System.EventHandler(this.txt_numeroIdentificacion_TextChanged);
            this.txt_numeroIdentificacion.Click += new System.EventHandler(this.txt_numeroIdentificacion_Click);
            this.txt_numeroIdentificacion.Leave += new System.EventHandler(this.txt_numeroIdentificacion_Leave);
            this.txt_numeroIdentificacion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numeroIdentificacion_KeyPress);
            // 
            // cmb_tipoIdentificacion
            // 
            this.cmb_tipoIdentificacion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmb_tipoIdentificacion.FormattingEnabled = true;
            this.cmb_tipoIdentificacion.Location = new System.Drawing.Point(17, 67);
            this.cmb_tipoIdentificacion.Name = "cmb_tipoIdentificacion";
            this.cmb_tipoIdentificacion.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipoIdentificacion.TabIndex = 7;
            this.cmb_tipoIdentificacion.Text = "Seleccione tipo";
            this.cmb_tipoIdentificacion.SelectedIndexChanged += new System.EventHandler(this.cmb_tipoIdentificacion_SelectedIndexChanged);
            // 
            // txt_Email
            // 
            this.txt_Email.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Email.Location = new System.Drawing.Point(71, 19);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(312, 20);
            this.txt_Email.TabIndex = 5;
            this.txt_Email.Text = "Ingrese e-mail";
            this.txt_Email.TextChanged += new System.EventHandler(this.txt_Email_TextChanged);
            this.txt_Email.Click += new System.EventHandler(this.txt_Email_Click);
            this.txt_Email.Leave += new System.EventHandler(this.txt_Email_Leave);
            // 
            // lbl_Numero_id
            // 
            this.lbl_Numero_id.AutoSize = true;
            this.lbl_Numero_id.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Numero_id.Location = new System.Drawing.Point(164, 51);
            this.lbl_Numero_id.Name = "lbl_Numero_id";
            this.lbl_Numero_id.Size = new System.Drawing.Size(124, 13);
            this.lbl_Numero_id.TabIndex = 8;
            this.lbl_Numero_id.Text = "Número de identificacion";
            // 
            // lbl_Email
            // 
            this.lbl_Email.AutoSize = true;
            this.lbl_Email.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Email.Location = new System.Drawing.Point(21, 24);
            this.lbl_Email.Name = "lbl_Email";
            this.lbl_Email.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email.TabIndex = 4;
            this.lbl_Email.Text = "Email";
            // 
            // lbl_Tipo_identificacion
            // 
            this.lbl_Tipo_identificacion.AutoSize = true;
            this.lbl_Tipo_identificacion.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Tipo_identificacion.Location = new System.Drawing.Point(14, 51);
            this.lbl_Tipo_identificacion.Name = "lbl_Tipo_identificacion";
            this.lbl_Tipo_identificacion.Size = new System.Drawing.Size(108, 13);
            this.lbl_Tipo_identificacion.TabIndex = 6;
            this.lbl_Tipo_identificacion.Text = "Tipo de identificación";
            // 
            // grp_cambios
            // 
            this.grp_cambios.Controls.Add(this.dtp_hasta);
            this.grp_cambios.Controls.Add(this.dtp_desde);
            this.grp_cambios.Controls.Add(this.lbl_hasta);
            this.grp_cambios.Controls.Add(this.lbl_desde);
            this.grp_cambios.Controls.Add(this.dgv_regimenes);
            this.grp_cambios.Controls.Add(this.dgv_tipos_habitaciones);
            this.grp_cambios.Controls.Add(this.lbl_habitacion_consumible);
            this.grp_cambios.Controls.Add(this.lbl_estadía);
            this.grp_cambios.Enabled = false;
            this.grp_cambios.Location = new System.Drawing.Point(13, 167);
            this.grp_cambios.Name = "grp_cambios";
            this.grp_cambios.Size = new System.Drawing.Size(559, 307);
            this.grp_cambios.TabIndex = 55;
            this.grp_cambios.TabStop = false;
            this.grp_cambios.Text = "Atributos";
            // 
            // dtp_hasta
            // 
            this.dtp_hasta.Location = new System.Drawing.Point(337, 38);
            this.dtp_hasta.Name = "dtp_hasta";
            this.dtp_hasta.Size = new System.Drawing.Size(216, 20);
            this.dtp_hasta.TabIndex = 58;
            // 
            // dtp_desde
            // 
            this.dtp_desde.Location = new System.Drawing.Point(16, 38);
            this.dtp_desde.Name = "dtp_desde";
            this.dtp_desde.Size = new System.Drawing.Size(216, 20);
            this.dtp_desde.TabIndex = 57;
            // 
            // lbl_hasta
            // 
            this.lbl_hasta.AutoSize = true;
            this.lbl_hasta.Location = new System.Drawing.Point(296, 38);
            this.lbl_hasta.Name = "lbl_hasta";
            this.lbl_hasta.Size = new System.Drawing.Size(35, 13);
            this.lbl_hasta.TabIndex = 56;
            this.lbl_hasta.Text = "Hasta";
            // 
            // lbl_desde
            // 
            this.lbl_desde.AutoSize = true;
            this.lbl_desde.Location = new System.Drawing.Point(238, 38);
            this.lbl_desde.Name = "lbl_desde";
            this.lbl_desde.Size = new System.Drawing.Size(38, 13);
            this.lbl_desde.TabIndex = 55;
            this.lbl_desde.Text = "Desde";
            // 
            // dgv_regimenes
            // 
            this.dgv_regimenes.AllowUserToAddRows = false;
            this.dgv_regimenes.AllowUserToDeleteRows = false;
            this.dgv_regimenes.AllowUserToOrderColumns = true;
            this.dgv_regimenes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_regimenes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_regimenes.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_regimenes.Location = new System.Drawing.Point(269, 87);
            this.dgv_regimenes.MultiSelect = false;
            this.dgv_regimenes.Name = "dgv_regimenes";
            this.dgv_regimenes.ReadOnly = true;
            this.dgv_regimenes.RowHeadersWidth = 20;
            this.dgv_regimenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_regimenes.Size = new System.Drawing.Size(284, 214);
            this.dgv_regimenes.TabIndex = 54;
            // 
            // dgv_tipos_habitaciones
            // 
            this.dgv_tipos_habitaciones.AllowUserToAddRows = false;
            this.dgv_tipos_habitaciones.AllowUserToDeleteRows = false;
            this.dgv_tipos_habitaciones.AllowUserToOrderColumns = true;
            this.dgv_tipos_habitaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_tipos_habitaciones.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_tipos_habitaciones.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_tipos_habitaciones.Location = new System.Drawing.Point(6, 87);
            this.dgv_tipos_habitaciones.MultiSelect = false;
            this.dgv_tipos_habitaciones.Name = "dgv_tipos_habitaciones";
            this.dgv_tipos_habitaciones.RowHeadersWidth = 20;
            this.dgv_tipos_habitaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_tipos_habitaciones.Size = new System.Drawing.Size(257, 214);
            this.dgv_tipos_habitaciones.TabIndex = 53;
            // 
            // lbl_habitacion_consumible
            // 
            this.lbl_habitacion_consumible.AutoSize = true;
            this.lbl_habitacion_consumible.Location = new System.Drawing.Point(9, 60);
            this.lbl_habitacion_consumible.Name = "lbl_habitacion_consumible";
            this.lbl_habitacion_consumible.Size = new System.Drawing.Size(185, 13);
            this.lbl_habitacion_consumible.TabIndex = 52;
            this.lbl_habitacion_consumible.Text = "Seleccione habitaciones y regimenes.";
            // 
            // lbl_estadía
            // 
            this.lbl_estadía.AutoSize = true;
            this.lbl_estadía.Location = new System.Drawing.Point(13, 22);
            this.lbl_estadía.Name = "lbl_estadía";
            this.lbl_estadía.Size = new System.Drawing.Size(162, 13);
            this.lbl_estadía.TabIndex = 51;
            this.lbl_estadía.Text = "Ingrese un período para reservar";
            // 
            // Reserva_modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.grp_cambios);
            this.Controls.Add(this.grp_datos);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Reserva_modificar";
            this.Text = "Reserva_modificar";
            this.Load += new System.EventHandler(this.Reserva_modificar_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.grp_datos.ResumeLayout(false);
            this.grp_datos.PerformLayout();
            this.grp_cambios.ResumeLayout(false);
            this.grp_cambios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_regimenes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_tipos_habitaciones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Label lbl_codigo_reserva;
        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.Label obli_email;
        private System.Windows.Forms.Label obli_num_id;
        private System.Windows.Forms.Label _obli_tipo_id;
        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Numero_id;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tipo_identificacion;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Label lbl_reserva;
        private System.Windows.Forms.TextBox txt_codigo_reserva;
        private System.Windows.Forms.GroupBox grp_cambios;
        private System.Windows.Forms.DateTimePicker dtp_hasta;
        private System.Windows.Forms.DateTimePicker dtp_desde;
        private System.Windows.Forms.Label lbl_hasta;
        private System.Windows.Forms.Label lbl_desde;
        private System.Windows.Forms.DataGridView dgv_regimenes;
        private System.Windows.Forms.DataGridView dgv_tipos_habitaciones;
        private System.Windows.Forms.Label lbl_habitacion_consumible;
        private System.Windows.Forms.Label lbl_estadía;
    }
}