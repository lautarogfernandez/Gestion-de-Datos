namespace FrbaHotel.Reserva
{
    partial class Reserva_terminar
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
            this.grp_alta = new System.Windows.Forms.GroupBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Numero_id = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tipo_identificacion = new System.Windows.Forms.Label();
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this._obli_tipo_id = new System.Windows.Forms.Label();
            this.obli_num_id = new System.Windows.Forms.Label();
            this.obli_email = new System.Windows.Forms.Label();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.grp_alta.SuspendLayout();
            this.grp_datos.SuspendLayout();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp_alta
            // 
            this.grp_alta.Controls.Add(this.button_agregar);
            this.grp_alta.Location = new System.Drawing.Point(370, 13);
            this.grp_alta.Name = "grp_alta";
            this.grp_alta.Size = new System.Drawing.Size(200, 88);
            this.grp_alta.TabIndex = 0;
            this.grp_alta.TabStop = false;
            this.grp_alta.Text = "¿Cliente no registrado?";
            // 
            // button_agregar
            // 
            this.button_agregar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_agregar.Location = new System.Drawing.Point(7, 20);
            this.button_agregar.Name = "button_agregar";
            this.button_agregar.Size = new System.Drawing.Size(187, 62);
            this.button_agregar.TabIndex = 0;
            this.button_agregar.Text = "Agregar";
            this.button_agregar.UseVisualStyleBackColor = true;
            this.button_agregar.Click += new System.EventHandler(this.button_agregar_Click);
            // 
            // grp_datos
            // 
            this.grp_datos.Controls.Add(this.obli_email);
            this.grp_datos.Controls.Add(this.obli_num_id);
            this.grp_datos.Controls.Add(this._obli_tipo_id);
            this.grp_datos.Controls.Add(this.lbl_informacion_obligatoria);
            this.grp_datos.Controls.Add(this.button_Buscar);
            this.grp_datos.Controls.Add(this.txt_numeroIdentificacion);
            this.grp_datos.Controls.Add(this.cmb_tipoIdentificacion);
            this.grp_datos.Controls.Add(this.txt_Email);
            this.grp_datos.Controls.Add(this.lbl_Numero_id);
            this.grp_datos.Controls.Add(this.lbl_Email);
            this.grp_datos.Controls.Add(this.lbl_Tipo_identificacion);
            this.grp_datos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grp_datos.Location = new System.Drawing.Point(12, 13);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(350, 162);
            this.grp_datos.TabIndex = 1;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Ingrese sus datos personales";
            // 
            // button_Buscar
            // 
            this.button_Buscar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar.Location = new System.Drawing.Point(17, 103);
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
            this.txt_numeroIdentificacion.Size = new System.Drawing.Size(162, 20);
            this.txt_numeroIdentificacion.TabIndex = 9;
            this.txt_numeroIdentificacion.Text = "Ingrese número de identificación";
            this.txt_numeroIdentificacion.TextChanged += new System.EventHandler(this.txt_numeroIdentificacion_TextChanged);
            this.txt_numeroIdentificacion.Click += new System.EventHandler(this.txt_numeroIdentificacion_Click);
            this.txt_numeroIdentificacion.Leave += new System.EventHandler(this.txt_Email_Leave);
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
            this.txt_Email.Size = new System.Drawing.Size(258, 20);
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
            // lbl_informacion_obligatoria
            // 
            this.lbl_informacion_obligatoria.AutoSize = true;
            this.lbl_informacion_obligatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informacion_obligatoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_informacion_obligatoria.Location = new System.Drawing.Point(173, 119);
            this.lbl_informacion_obligatoria.Name = "lbl_informacion_obligatoria";
            this.lbl_informacion_obligatoria.Size = new System.Drawing.Size(168, 18);
            this.lbl_informacion_obligatoria.TabIndex = 11;
            this.lbl_informacion_obligatoria.Text = "* Información obligatoria";
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
            // obli_num_id
            // 
            this.obli_num_id.AutoSize = true;
            this.obli_num_id.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obli_num_id.ForeColor = System.Drawing.Color.Red;
            this.obli_num_id.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.obli_num_id.Location = new System.Drawing.Point(329, 65);
            this.obli_num_id.Name = "obli_num_id";
            this.obli_num_id.Size = new System.Drawing.Size(15, 20);
            this.obli_num_id.TabIndex = 149;
            this.obli_num_id.Text = "*";
            // 
            // obli_email
            // 
            this.obli_email.AutoSize = true;
            this.obli_email.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.obli_email.ForeColor = System.Drawing.Color.Red;
            this.obli_email.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.obli_email.Location = new System.Drawing.Point(329, 17);
            this.obli_email.Name = "obli_email";
            this.obli_email.Size = new System.Drawing.Size(15, 20);
            this.obli_email.TabIndex = 150;
            this.obli_email.Text = "*";
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 239);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 158;
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
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(15, 181);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 157;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(440, 181);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 156;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // Reserva_terminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 261);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.grp_datos);
            this.Controls.Add(this.grp_alta);
            this.MaximumSize = new System.Drawing.Size(600, 300);
            this.MinimumSize = new System.Drawing.Size(600, 300);
            this.Name = "Reserva_terminar";
            this.Text = "Reserva_terminar";
            this.Load += new System.EventHandler(this.Reserva_terminar_Load);
            this.grp_alta.ResumeLayout(false);
            this.grp_datos.ResumeLayout(false);
            this.grp_datos.PerformLayout();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_alta;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Numero_id;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tipo_identificacion;
        private System.Windows.Forms.Label _obli_tipo_id;
        private System.Windows.Forms.Label obli_email;
        private System.Windows.Forms.Label obli_num_id;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;

    }
}