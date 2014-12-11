namespace FrbaHotel.Registrar_Estadia
{
    partial class registrar_ingreso
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
            this.grp_personas = new System.Windows.Forms.GroupBox();
            this.grp_datos = new System.Windows.Forms.GroupBox();
            this.txt_codigo_reserva = new System.Windows.Forms.TextBox();
            this.lbl_reserva = new System.Windows.Forms.Label();
            this.obli_email = new System.Windows.Forms.Label();
            this.obli_num_id = new System.Windows.Forms.Label();
            this._obli_tipo_id = new System.Windows.Forms.Label();
            this.lbl_codigo_reserva = new System.Windows.Forms.Label();
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this.button_Buscar = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion = new System.Windows.Forms.ComboBox();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.lbl_Numero_id = new System.Windows.Forms.Label();
            this.lbl_Email = new System.Windows.Forms.Label();
            this.lbl_Tipo_identificacion = new System.Windows.Forms.Label();
            this.button_limpiar = new System.Windows.Forms.Button();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_volver = new System.Windows.Forms.Button();
            this.grp_datos2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Buscar2 = new System.Windows.Forms.Button();
            this.txt_numeroIdentificacion2 = new System.Windows.Forms.TextBox();
            this.cmb_tipoIdentificacion2 = new System.Windows.Forms.ComboBox();
            this.txt_Email2 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_Email2 = new System.Windows.Forms.Label();
            this.lbl = new System.Windows.Forms.Label();
            this.grp_alta = new System.Windows.Forms.GroupBox();
            this.button_agregar = new System.Windows.Forms.Button();
            this.dgv_resultados = new System.Windows.Forms.DataGridView();
            this.grp_personas.SuspendLayout();
            this.grp_datos.SuspendLayout();
            this.stat_BarraEstado.SuspendLayout();
            this.grp_datos2.SuspendLayout();
            this.grp_alta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).BeginInit();
            this.SuspendLayout();
            // 
            // grp_personas
            // 
            this.grp_personas.Controls.Add(this.dgv_resultados);
            this.grp_personas.Controls.Add(this.grp_datos2);
            this.grp_personas.Controls.Add(this.grp_alta);
            this.grp_personas.Enabled = false;
            this.grp_personas.Location = new System.Drawing.Point(13, 161);
            this.grp_personas.Name = "grp_personas";
            this.grp_personas.Size = new System.Drawing.Size(559, 307);
            this.grp_personas.TabIndex = 160;
            this.grp_personas.TabStop = false;
            this.grp_personas.Text = "Personas";
            // 
            // grp_datos
            // 
            this.grp_datos.Controls.Add(this.txt_codigo_reserva);
            this.grp_datos.Controls.Add(this.lbl_reserva);
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
            this.grp_datos.Location = new System.Drawing.Point(12, 2);
            this.grp_datos.Name = "grp_datos";
            this.grp_datos.Size = new System.Drawing.Size(560, 152);
            this.grp_datos.TabIndex = 159;
            this.grp_datos.TabStop = false;
            this.grp_datos.Text = "Ingrese los datos de la reserva";
            // 
            // txt_codigo_reserva
            // 
            this.txt_codigo_reserva.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_codigo_reserva.Location = new System.Drawing.Point(17, 117);
            this.txt_codigo_reserva.Name = "txt_codigo_reserva";
            this.txt_codigo_reserva.Size = new System.Drawing.Size(216, 20);
            this.txt_codigo_reserva.TabIndex = 153;
            this.txt_codigo_reserva.Text = "Ingrese codigo de reserva a modificar";
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
            // lbl_codigo_reserva
            // 
            this.lbl_codigo_reserva.AutoSize = true;
            this.lbl_codigo_reserva.Location = new System.Drawing.Point(17, 103);
            this.lbl_codigo_reserva.Name = "lbl_codigo_reserva";
            this.lbl_codigo_reserva.Size = new System.Drawing.Size(93, 13);
            this.lbl_codigo_reserva.TabIndex = 51;
            this.lbl_codigo_reserva.Text = "Codigo de reserva";
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
            // 
            // txt_numeroIdentificacion
            // 
            this.txt_numeroIdentificacion.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_numeroIdentificacion.Location = new System.Drawing.Point(167, 67);
            this.txt_numeroIdentificacion.Name = "txt_numeroIdentificacion";
            this.txt_numeroIdentificacion.Size = new System.Drawing.Size(216, 20);
            this.txt_numeroIdentificacion.TabIndex = 9;
            this.txt_numeroIdentificacion.Text = "Ingrese número de identificación";
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
            // 
            // txt_Email
            // 
            this.txt_Email.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Email.Location = new System.Drawing.Point(71, 19);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(312, 20);
            this.txt_Email.TabIndex = 5;
            this.txt_Email.Text = "Ingrese e-mail";
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
            // button_limpiar
            // 
            this.button_limpiar.Enabled = false;
            this.button_limpiar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_limpiar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_limpiar.Location = new System.Drawing.Point(12, 474);
            this.button_limpiar.Name = "button_limpiar";
            this.button_limpiar.Size = new System.Drawing.Size(135, 45);
            this.button_limpiar.TabIndex = 156;
            this.button_limpiar.Text = "Limpiar";
            this.button_limpiar.UseVisualStyleBackColor = true;
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
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
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 474);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 157;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // grp_datos2
            // 
            this.grp_datos2.Controls.Add(this.label2);
            this.grp_datos2.Controls.Add(this.label3);
            this.grp_datos2.Controls.Add(this.label4);
            this.grp_datos2.Controls.Add(this.label5);
            this.grp_datos2.Controls.Add(this.button_Buscar2);
            this.grp_datos2.Controls.Add(this.txt_numeroIdentificacion2);
            this.grp_datos2.Controls.Add(this.cmb_tipoIdentificacion2);
            this.grp_datos2.Controls.Add(this.txt_Email2);
            this.grp_datos2.Controls.Add(this.label6);
            this.grp_datos2.Controls.Add(this.lbl_Email2);
            this.grp_datos2.Controls.Add(this.lbl);
            this.grp_datos2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grp_datos2.Location = new System.Drawing.Point(0, 19);
            this.grp_datos2.Name = "grp_datos2";
            this.grp_datos2.Size = new System.Drawing.Size(350, 162);
            this.grp_datos2.TabIndex = 3;
            this.grp_datos2.TabStop = false;
            this.grp_datos2.Text = "Ingrese sus datos personales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(329, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 20);
            this.label2.TabIndex = 150;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(329, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 149;
            this.label3.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(144, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 20);
            this.label4.TabIndex = 148;
            this.label4.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(173, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(168, 18);
            this.label5.TabIndex = 11;
            this.label5.Text = "* Información obligatoria";
            // 
            // button_Buscar2
            // 
            this.button_Buscar2.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Buscar2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_Buscar2.Location = new System.Drawing.Point(17, 103);
            this.button_Buscar2.Name = "button_Buscar2";
            this.button_Buscar2.Size = new System.Drawing.Size(135, 45);
            this.button_Buscar2.TabIndex = 10;
            this.button_Buscar2.Text = "Buscar";
            this.button_Buscar2.UseVisualStyleBackColor = true;
            // 
            // txt_numeroIdentificacion2
            // 
            this.txt_numeroIdentificacion2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_numeroIdentificacion2.Location = new System.Drawing.Point(167, 67);
            this.txt_numeroIdentificacion2.Name = "txt_numeroIdentificacion2";
            this.txt_numeroIdentificacion2.Size = new System.Drawing.Size(162, 20);
            this.txt_numeroIdentificacion2.TabIndex = 9;
            this.txt_numeroIdentificacion2.Text = "Ingrese número de identificación";
            // 
            // cmb_tipoIdentificacion2
            // 
            this.cmb_tipoIdentificacion2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.cmb_tipoIdentificacion2.FormattingEnabled = true;
            this.cmb_tipoIdentificacion2.Location = new System.Drawing.Point(17, 67);
            this.cmb_tipoIdentificacion2.Name = "cmb_tipoIdentificacion2";
            this.cmb_tipoIdentificacion2.Size = new System.Drawing.Size(121, 21);
            this.cmb_tipoIdentificacion2.TabIndex = 7;
            this.cmb_tipoIdentificacion2.Text = "Seleccione tipo";
            // 
            // txt_Email2
            // 
            this.txt_Email2.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.txt_Email2.Location = new System.Drawing.Point(71, 19);
            this.txt_Email2.Name = "txt_Email2";
            this.txt_Email2.Size = new System.Drawing.Size(258, 20);
            this.txt_Email2.TabIndex = 5;
            this.txt_Email2.Text = "Ingrese e-mail";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(164, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(124, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Número de identificacion";
            // 
            // lbl_Email2
            // 
            this.lbl_Email2.AutoSize = true;
            this.lbl_Email2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl_Email2.Location = new System.Drawing.Point(21, 24);
            this.lbl_Email2.Name = "lbl_Email2";
            this.lbl_Email2.Size = new System.Drawing.Size(32, 13);
            this.lbl_Email2.TabIndex = 4;
            this.lbl_Email2.Text = "Email";
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lbl.Location = new System.Drawing.Point(14, 51);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(108, 13);
            this.lbl.TabIndex = 6;
            this.lbl.Text = "Tipo de identificación";
            // 
            // grp_alta
            // 
            this.grp_alta.Controls.Add(this.button_agregar);
            this.grp_alta.Location = new System.Drawing.Point(353, 19);
            this.grp_alta.Name = "grp_alta";
            this.grp_alta.Size = new System.Drawing.Size(200, 88);
            this.grp_alta.TabIndex = 2;
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
            // 
            // dgv_resultados
            // 
            this.dgv_resultados.AllowUserToAddRows = false;
            this.dgv_resultados.AllowUserToDeleteRows = false;
            this.dgv_resultados.AllowUserToOrderColumns = true;
            this.dgv_resultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_resultados.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_resultados.Location = new System.Drawing.Point(6, 187);
            this.dgv_resultados.MultiSelect = false;
            this.dgv_resultados.Name = "dgv_resultados";
            this.dgv_resultados.ReadOnly = true;
            this.dgv_resultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_resultados.Size = new System.Drawing.Size(547, 114);
            this.dgv_resultados.TabIndex = 8;
            // 
            // registrar_ingreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.grp_personas);
            this.Controls.Add(this.grp_datos);
            this.Controls.Add(this.button_limpiar);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "registrar_ingreso";
            this.Text = "registrar_ingreso";
            this.Load += new System.EventHandler(this.registrar_ingreso_Load);
            this.grp_personas.ResumeLayout(false);
            this.grp_datos.ResumeLayout(false);
            this.grp_datos.PerformLayout();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.grp_datos2.ResumeLayout(false);
            this.grp_datos2.PerformLayout();
            this.grp_alta.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_resultados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grp_personas;
        private System.Windows.Forms.GroupBox grp_datos;
        private System.Windows.Forms.TextBox txt_codigo_reserva;
        private System.Windows.Forms.Label lbl_reserva;
        private System.Windows.Forms.Label obli_email;
        private System.Windows.Forms.Label obli_num_id;
        private System.Windows.Forms.Label _obli_tipo_id;
        private System.Windows.Forms.Label lbl_codigo_reserva;
        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.Button button_Buscar;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label lbl_Numero_id;
        private System.Windows.Forms.Label lbl_Email;
        private System.Windows.Forms.Label lbl_Tipo_identificacion;
        private System.Windows.Forms.Button button_limpiar;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox grp_datos2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Buscar2;
        private System.Windows.Forms.TextBox txt_numeroIdentificacion2;
        private System.Windows.Forms.ComboBox cmb_tipoIdentificacion2;
        private System.Windows.Forms.TextBox txt_Email2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_Email2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.GroupBox grp_alta;
        private System.Windows.Forms.Button button_agregar;
        private System.Windows.Forms.DataGridView dgv_resultados;
    }
}