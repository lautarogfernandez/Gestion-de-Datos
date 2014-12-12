namespace FrbaHotel.ABM_de_Usuario
{
    partial class Usuario_alta
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
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmb_tipo_documento = new System.Windows.Forms.ComboBox();
            this._obli_fechaNacimiento = new System.Windows.Forms.Label();
            this._obli_numeroDoc = new System.Windows.Forms.Label();
            this._obli_tipoDoc = new System.Windows.Forms.Label();
            this._obli_mail = new System.Windows.Forms.Label();
            this._obli_apellido = new System.Windows.Forms.Label();
            this._obli_nombre = new System.Windows.Forms.Label();
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.lbl_fecha_nacimiento = new System.Windows.Forms.Label();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.lbl_numero_doc = new System.Windows.Forms.Label();
            this.lbl_tipo_documento = new System.Windows.Forms.Label();
            this.lbl_repetir = new System.Windows.Forms.Label();
            this.lbl_contraseña = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.dtp_fecha_nacimiento = new System.Windows.Forms.DateTimePicker();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.txt_numero_documento = new System.Windows.Forms.TextBox();
            this.txt_repetirpass = new System.Windows.Forms.TextBox();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_seleccionarRoles = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_informacion_obligatoria
            // 
            this.lbl_informacion_obligatoria.AutoSize = true;
            this.lbl_informacion_obligatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informacion_obligatoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_informacion_obligatoria.Location = new System.Drawing.Point(139, 463);
            this.lbl_informacion_obligatoria.Name = "lbl_informacion_obligatoria";
            this.lbl_informacion_obligatoria.Size = new System.Drawing.Size(168, 18);
            this.lbl_informacion_obligatoria.TabIndex = 197;
            this.lbl_informacion_obligatoria.Text = "* Información obligatoria";
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 196;
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
            // cmb_tipo_documento
            // 
            this.cmb_tipo_documento.FormattingEnabled = true;
            this.cmb_tipo_documento.Location = new System.Drawing.Point(236, 199);
            this.cmb_tipo_documento.Name = "cmb_tipo_documento";
            this.cmb_tipo_documento.Size = new System.Drawing.Size(306, 21);
            this.cmb_tipo_documento.TabIndex = 195;
            // 
            // _obli_fechaNacimiento
            // 
            this._obli_fechaNacimiento.AutoSize = true;
            this._obli_fechaNacimiento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_fechaNacimiento.ForeColor = System.Drawing.Color.Red;
            this._obli_fechaNacimiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_fechaNacimiento.Location = new System.Drawing.Point(548, 309);
            this._obli_fechaNacimiento.Name = "_obli_fechaNacimiento";
            this._obli_fechaNacimiento.Size = new System.Drawing.Size(15, 20);
            this._obli_fechaNacimiento.TabIndex = 194;
            this._obli_fechaNacimiento.Text = "*";
            // 
            // _obli_numeroDoc
            // 
            this._obli_numeroDoc.AutoSize = true;
            this._obli_numeroDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_numeroDoc.ForeColor = System.Drawing.Color.Red;
            this._obli_numeroDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_numeroDoc.Location = new System.Drawing.Point(548, 223);
            this._obli_numeroDoc.Name = "_obli_numeroDoc";
            this._obli_numeroDoc.Size = new System.Drawing.Size(15, 20);
            this._obli_numeroDoc.TabIndex = 192;
            this._obli_numeroDoc.Text = "*";
            // 
            // _obli_tipoDoc
            // 
            this._obli_tipoDoc.AutoSize = true;
            this._obli_tipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_tipoDoc.ForeColor = System.Drawing.Color.Red;
            this._obli_tipoDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_tipoDoc.Location = new System.Drawing.Point(548, 195);
            this._obli_tipoDoc.Name = "_obli_tipoDoc";
            this._obli_tipoDoc.Size = new System.Drawing.Size(15, 20);
            this._obli_tipoDoc.TabIndex = 191;
            this._obli_tipoDoc.Text = "*";
            // 
            // _obli_mail
            // 
            this._obli_mail.AutoSize = true;
            this._obli_mail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_mail.ForeColor = System.Drawing.Color.Red;
            this._obli_mail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_mail.Location = new System.Drawing.Point(548, 108);
            this._obli_mail.Name = "_obli_mail";
            this._obli_mail.Size = new System.Drawing.Size(15, 20);
            this._obli_mail.TabIndex = 190;
            this._obli_mail.Text = "*";
            // 
            // _obli_apellido
            // 
            this._obli_apellido.AutoSize = true;
            this._obli_apellido.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_apellido.ForeColor = System.Drawing.Color.Red;
            this._obli_apellido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_apellido.Location = new System.Drawing.Point(548, 80);
            this._obli_apellido.Name = "_obli_apellido";
            this._obli_apellido.Size = new System.Drawing.Size(15, 20);
            this._obli_apellido.TabIndex = 189;
            this._obli_apellido.Text = "*";
            // 
            // _obli_nombre
            // 
            this._obli_nombre.AutoSize = true;
            this._obli_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_nombre.ForeColor = System.Drawing.Color.Red;
            this._obli_nombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_nombre.Location = new System.Drawing.Point(548, 52);
            this._obli_nombre.Name = "_obli_nombre";
            this._obli_nombre.Size = new System.Drawing.Size(15, 20);
            this._obli_nombre.TabIndex = 188;
            this._obli_nombre.Text = "*";
            // 
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(39, 7);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 187;
            this.lbl_atributo.Text = "Atributo";
            // 
            // lbl_fecha_nacimiento
            // 
            this.lbl_fecha_nacimiento.AutoSize = true;
            this.lbl_fecha_nacimiento.Location = new System.Drawing.Point(39, 309);
            this.lbl_fecha_nacimiento.Name = "lbl_fecha_nacimiento";
            this.lbl_fecha_nacimiento.Size = new System.Drawing.Size(108, 13);
            this.lbl_fecha_nacimiento.TabIndex = 186;
            this.lbl_fecha_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.AutoSize = true;
            this.lbl_direccion.Location = new System.Drawing.Point(39, 286);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(52, 13);
            this.lbl_direccion.TabIndex = 179;
            this.lbl_direccion.Text = "Direccion";
            // 
            // lbl_telefono
            // 
            this.lbl_telefono.AutoSize = true;
            this.lbl_telefono.Location = new System.Drawing.Point(39, 260);
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Size = new System.Drawing.Size(49, 13);
            this.lbl_telefono.TabIndex = 178;
            this.lbl_telefono.Text = "Teléfono";
            // 
            // lbl_numero_doc
            // 
            this.lbl_numero_doc.AutoSize = true;
            this.lbl_numero_doc.Location = new System.Drawing.Point(39, 231);
            this.lbl_numero_doc.Name = "lbl_numero_doc";
            this.lbl_numero_doc.Size = new System.Drawing.Size(117, 13);
            this.lbl_numero_doc.TabIndex = 177;
            this.lbl_numero_doc.Text = "Numero de Documento";
            // 
            // lbl_tipo_documento
            // 
            this.lbl_tipo_documento.AutoSize = true;
            this.lbl_tipo_documento.Location = new System.Drawing.Point(39, 202);
            this.lbl_tipo_documento.Name = "lbl_tipo_documento";
            this.lbl_tipo_documento.Size = new System.Drawing.Size(99, 13);
            this.lbl_tipo_documento.TabIndex = 176;
            this.lbl_tipo_documento.Text = "Tipo de documento";
            // 
            // lbl_repetir
            // 
            this.lbl_repetir.AutoSize = true;
            this.lbl_repetir.Location = new System.Drawing.Point(39, 114);
            this.lbl_repetir.Name = "lbl_repetir";
            this.lbl_repetir.Size = new System.Drawing.Size(97, 13);
            this.lbl_repetir.TabIndex = 175;
            this.lbl_repetir.Text = "Repetir contraseña";
            // 
            // lbl_contraseña
            // 
            this.lbl_contraseña.AutoSize = true;
            this.lbl_contraseña.Location = new System.Drawing.Point(39, 85);
            this.lbl_contraseña.Name = "lbl_contraseña";
            this.lbl_contraseña.Size = new System.Drawing.Size(61, 13);
            this.lbl_contraseña.TabIndex = 174;
            this.lbl_contraseña.Text = "Contraseña";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(39, 56);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(96, 13);
            this.lbl_username.TabIndex = 173;
            this.lbl_username.Text = "Nombre de usuario";
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(230, 7);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(77, 31);
            this.lbl_modificado.TabIndex = 172;
            this.lbl_modificado.Text = "Valor";
            // 
            // dtp_fecha_nacimiento
            // 
            this.dtp_fecha_nacimiento.Location = new System.Drawing.Point(236, 307);
            this.dtp_fecha_nacimiento.Name = "dtp_fecha_nacimiento";
            this.dtp_fecha_nacimiento.Size = new System.Drawing.Size(306, 20);
            this.dtp_fecha_nacimiento.TabIndex = 171;
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(236, 281);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(306, 20);
            this.txt_direccion.TabIndex = 164;
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(236, 255);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(306, 20);
            this.txt_telefono.TabIndex = 163;
            // 
            // txt_numero_documento
            // 
            this.txt_numero_documento.Location = new System.Drawing.Point(236, 226);
            this.txt_numero_documento.Name = "txt_numero_documento";
            this.txt_numero_documento.Size = new System.Drawing.Size(306, 20);
            this.txt_numero_documento.TabIndex = 162;
            this.txt_numero_documento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_numero_documento_KeyPress);
            // 
            // txt_repetirpass
            // 
            this.txt_repetirpass.Location = new System.Drawing.Point(236, 112);
            this.txt_repetirpass.Name = "txt_repetirpass";
            this.txt_repetirpass.PasswordChar = '*';
            this.txt_repetirpass.Size = new System.Drawing.Size(306, 20);
            this.txt_repetirpass.TabIndex = 161;
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(236, 83);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(306, 20);
            this.txt_pass.TabIndex = 160;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(236, 54);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(306, 20);
            this.txt_username.TabIndex = 159;
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_aceptar.Location = new System.Drawing.Point(12, 491);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 158;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 491);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 157;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // button_seleccionarRoles
            // 
            this.button_seleccionarRoles.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_seleccionarRoles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_seleccionarRoles.Location = new System.Drawing.Point(42, 377);
            this.button_seleccionarRoles.Name = "button_seleccionarRoles";
            this.button_seleccionarRoles.Size = new System.Drawing.Size(197, 45);
            this.button_seleccionarRoles.TabIndex = 198;
            this.button_seleccionarRoles.Text = "Seleccionar Roles";
            this.button_seleccionarRoles.UseVisualStyleBackColor = true;
            this.button_seleccionarRoles.Click += new System.EventHandler(this.button_seleccionarRoles_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(548, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 201;
            this.label1.Text = "*";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(39, 148);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 200;
            this.lbl_nombre.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(236, 143);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(306, 20);
            this.txt_nombre.TabIndex = 199;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(548, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 20);
            this.label3.TabIndex = 204;
            this.label3.Text = "*";
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(39, 174);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_apellido.TabIndex = 203;
            this.lbl_apellido.Text = "Apellido";
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(236, 169);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(306, 20);
            this.txt_apellido.TabIndex = 202;
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Location = new System.Drawing.Point(39, 338);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(26, 13);
            this.lbl_mail.TabIndex = 206;
            this.lbl_mail.Text = "Mail";
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(236, 333);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(306, 20);
            this.txt_mail.TabIndex = 205;
            // 
            // Usuario_alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.lbl_mail);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.button_seleccionarRoles);
            this.Controls.Add(this.lbl_informacion_obligatoria);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.cmb_tipo_documento);
            this.Controls.Add(this._obli_fechaNacimiento);
            this.Controls.Add(this._obli_numeroDoc);
            this.Controls.Add(this._obli_tipoDoc);
            this.Controls.Add(this._obli_mail);
            this.Controls.Add(this._obli_apellido);
            this.Controls.Add(this._obli_nombre);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.lbl_fecha_nacimiento);
            this.Controls.Add(this.lbl_direccion);
            this.Controls.Add(this.lbl_telefono);
            this.Controls.Add(this.lbl_numero_doc);
            this.Controls.Add(this.lbl_tipo_documento);
            this.Controls.Add(this.lbl_repetir);
            this.Controls.Add(this.lbl_contraseña);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.dtp_fecha_nacimiento);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_numero_documento);
            this.Controls.Add(this.txt_repetirpass);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Usuario_alta";
            this.Text = "Usuario_alta";
            this.Load += new System.EventHandler(this.Usuario_alta_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.ComboBox cmb_tipo_documento;
        private System.Windows.Forms.Label _obli_fechaNacimiento;
        private System.Windows.Forms.Label _obli_numeroDoc;
        private System.Windows.Forms.Label _obli_tipoDoc;
        private System.Windows.Forms.Label _obli_mail;
        private System.Windows.Forms.Label _obli_apellido;
        private System.Windows.Forms.Label _obli_nombre;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.Label lbl_fecha_nacimiento;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.Label lbl_telefono;
        private System.Windows.Forms.Label lbl_numero_doc;
        private System.Windows.Forms.Label lbl_tipo_documento;
        private System.Windows.Forms.Label lbl_repetir;
        private System.Windows.Forms.Label lbl_contraseña;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.DateTimePicker dtp_fecha_nacimiento;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.TextBox txt_numero_documento;
        private System.Windows.Forms.TextBox txt_repetirpass;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_seleccionarRoles;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.TextBox txt_mail;
    }
}