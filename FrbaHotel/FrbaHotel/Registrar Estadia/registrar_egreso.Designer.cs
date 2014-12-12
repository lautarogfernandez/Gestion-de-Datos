namespace FrbaHotel.Registrar_Estadia
{
    partial class registrar_egreso
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
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.txt_codigo_estadia = new System.Windows.Forms.TextBox();
            this.lbl_reserva = new System.Windows.Forms.Label();
            this.obli_email = new System.Windows.Forms.Label();
            this.obli_num_id = new System.Windows.Forms.Label();
            this._obli_tipo_id = new System.Windows.Forms.Label();
            this.lbl_codigo_estadia = new System.Windows.Forms.Label();
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Numero_id = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tipo_identificacion = new System.Windows.Forms.Label();
            this.button_registrar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.grp_datos.SuspendLayout();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_datos
            // 
            this.grp_datos.Controls.Add(this.txt_codigo_estadia);
            this.grp_datos.Controls.Add(this.lbl_reserva);
            this.grp_datos.Controls.Add(this.obli_email);
            this.grp_datos.Controls.Add(this.obli_num_id);
            this.grp_datos.Controls.Add(this._obli_tipo_id);
            this.grp_datos.Controls.Add(this.lbl_codigo_estadia);
            this.grp_datos.Controls.Add(this.lbl_informacion_obligatoria);
            this.grp_datos.Controls.Add(this.button_Buscar);
            this.grp_datos.Controls.Add(this.txt_numeroIdentificacion);
            this.grp_datos.Controls.Add(this.cmb_tipoIdentificacion);
            this.grp_datos.Controls.Add(this.txt_Email);
            this.grp_datos.Controls.Add(this.lbl_Numero_id);
            this.grp_datos.Controls.Add(this.lbl_Email);
            this.grp_datos.Controls.Add(this.lbl_Tipo_identificacion);
            this.grp_datos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grp_datos.Location = new System.Drawing.Point(12, 12);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(560, 152);
            this.grp_datos.TabIndex = 160;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Ingrese los datos de la estadía";
            // 
            // txt_codigo_estadia
            // 
            this.txt_codigo_estadia.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_codigo_estadia.Location = new System.Drawing.Point(17, 117);
            this.txt_codigo_estadia.Name = "txt_codigo_estadia";
            this.txt_codigo_estadia.Size = new System.Drawing.Size(250, 20);
            this.txt_codigo_estadia.TabIndex = 153;
            this.txt_codigo_estadia.Text = "Ingrese codigo de estadía ";
            this.txt_codigo_estadia.TextChanged += new System.EventHandler(this.txt_codigo_estadia_TextChanged);
            this.txt_codigo_estadia.Click += new System.EventHandler(this.txt_codigo_estadia_Click);
            this.txt_codigo_estadia.Leave += new System.EventHandler(this.txt_codigo_estadia_Leave);
            this.txt_codigo_estadia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numeroIdentificacion_KeyPress);
            // 
            // lbl_reserva
            // 
            this.lbl_reserva.AutoSize = true;
            this.lbl_reserva.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_reserva.ForeColor = System.Drawing.Color.Red;
            this.lbl_reserva.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_reserva.Location = new System.Drawing.Point(273, 117);
            this.lbl_reserva.Name = "lbl_reserva";
            this.lbl_reserva.Size = new System.Drawing.Size(15, 20);
            this.lbl_reserva.TabIndex = 152;
            this.lbl_reserva.Text = "*";
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
            // lbl_codigo_estadia
            // 
            this.lbl_codigo_estadia.AutoSize = true;
            this.lbl_codigo_estadia.Location = new System.Drawing.Point(17, 103);
            this.lbl_codigo_estadia.Name = "lbl_codigo_estadia";
            this.lbl_codigo_estadia.Size = new System.Drawing.Size(92, 13);
            this.lbl_codigo_estadia.TabIndex = 51;
            this.lbl_codigo_estadia.Text = "Codigo de estadia";
            // 
            // lbl_informacion_obligatoria
            // 
            this.lbl_informacion_obligatoria.AutoSize = true;
            this.lbl_informacion_obligatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informacion_obligatoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_informacion_obligatoria.Location = new System.Drawing.Point(335, 116);
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
            this.txt_numeroIdentificacion.Leave += new System.EventHandler(this.txt_Email_Leave);
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
            // button_registrar
            // 
            this.button_registrar.Enabled = false;
            this.button_registrar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_registrar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_registrar.Location = new System.Drawing.Point(12, 179);
            this.button_registrar.Name = "button_registrar";
            this.button_registrar.Size = new System.Drawing.Size(135, 45);
            this.button_registrar.TabIndex = 161;
            this.button_registrar.Text = "Registrar";
            this.button_registrar.UseVisualStyleBackColor = true;
            this.button_registrar.Click += new System.EventHandler(this.button_registrar_Click);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 239);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 163;
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
            this.button_volver.Location = new System.Drawing.Point(437, 179);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 162;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // registrar_egreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.button_registrar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.grp_datos);
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "registrar_egreso";
            this.Text = "registrar_egreso";
            this.Load += new System.EventHandler(this.registrar_egreso_Load);
            this.grp_datos.ResumeLayout(false);
            this.grp_datos.PerformLayout();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.TextBox txt_codigo_estadia;
        private System.Windows.Forms.Label lbl_reserva;
        private System.Windows.Forms.Label obli_email;
        private System.Windows.Forms.Label obli_num_id;
        private System.Windows.Forms.Label _obli_tipo_id;
        private System.Windows.Forms.Label lbl_codigo_estadia;
        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Numero_id;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tipo_identificacion;
        private System.Windows.Forms.Button button_registrar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
    }
}