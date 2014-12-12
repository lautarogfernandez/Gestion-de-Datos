namespace FrbaHotel.ABM_de_Usuario
{
    partial class Usuario_modificar
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
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.lbl_original = new System.Windows.Forms.Label();
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.chk_telefono = new System.Windows.Forms.CheckBox();
            this.chk_numero_documento = new System.Windows.Forms.CheckBox();
            this.chk_direccion = new System.Windows.Forms.CheckBox();
            this.chk_mail = new System.Windows.Forms.CheckBox();
            this.chk_fecha_nacimiento = new System.Windows.Forms.CheckBox();
            this.chk_tipo_documento = new System.Windows.Forms.CheckBox();
            this.chk_username = new System.Windows.Forms.CheckBox();
            this.chk_apellido = new System.Windows.Forms.CheckBox();
            this.chk_nombre = new System.Windows.Forms.CheckBox();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.lbl_mail = new System.Windows.Forms.Label();
            this.txt_mail = new System.Windows.Forms.TextBox();
            this.lbl_apellido = new System.Windows.Forms.Label();
            this.txt_apellido = new System.Windows.Forms.TextBox();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.cmb_tipo_documento = new System.Windows.Forms.ComboBox();
            this.lbl_fecha_nacimiento = new System.Windows.Forms.Label();
            this.lbl_direccion = new System.Windows.Forms.Label();
            this.lbl_telefono = new System.Windows.Forms.Label();
            this.lbl_numero_doc = new System.Windows.Forms.Label();
            this.lbl_tipo_documento = new System.Windows.Forms.Label();
            this.lbl_username = new System.Windows.Forms.Label();
            this.dtp_fecha_nacimiento = new System.Windows.Forms.DateTimePicker();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.txt_telefono = new System.Windows.Forms.TextBox();
            this.txt_numero_documento = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.button_seleccionarRoles = new System.Windows.Forms.Button();
            this._lbl_mail = new System.Windows.Forms.Label();
            this._lbl_apellido = new System.Windows.Forms.Label();
            this._lbl_nombre = new System.Windows.Forms.Label();
            this._lbl_fecha_nacimiento = new System.Windows.Forms.Label();
            this._lbl_direccion = new System.Windows.Forms.Label();
            this._lbl_telefono = new System.Windows.Forms.Label();
            this._lbl_numero_doc = new System.Windows.Forms.Label();
            this._lbl_tipo_documento = new System.Windows.Forms.Label();
            this._lbl_username = new System.Windows.Forms.Label();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(317, 38);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(145, 31);
            this.lbl_modificado.TabIndex = 157;
            this.lbl_modificado.Text = "Modificado";
            // 
            // lbl_original
            // 
            this.lbl_original.AutoSize = true;
            this.lbl_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_original.Location = new System.Drawing.Point(167, 36);
            this.lbl_original.Name = "lbl_original";
            this.lbl_original.Size = new System.Drawing.Size(107, 31);
            this.lbl_original.TabIndex = 156;
            this.lbl_original.Text = "Original";
            // 
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(19, 36);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 155;
            this.lbl_atributo.Text = "Atributo";
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.Location = new System.Drawing.Point(553, 59);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(15, 14);
            this.chk_todos.TabIndex = 154;
            this.chk_todos.UseVisualStyleBackColor = true;
            this.chk_todos.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_telefono
            // 
            this.chk_telefono.AutoSize = true;
            this.chk_telefono.Location = new System.Drawing.Point(553, 221);
            this.chk_telefono.Name = "chk_telefono";
            this.chk_telefono.Size = new System.Drawing.Size(15, 14);
            this.chk_telefono.TabIndex = 150;
            this.chk_telefono.UseVisualStyleBackColor = true;
            this.chk_telefono.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_numero_documento
            // 
            this.chk_numero_documento.AutoSize = true;
            this.chk_numero_documento.Location = new System.Drawing.Point(553, 194);
            this.chk_numero_documento.Name = "chk_numero_documento";
            this.chk_numero_documento.Size = new System.Drawing.Size(15, 14);
            this.chk_numero_documento.TabIndex = 149;
            this.chk_numero_documento.UseVisualStyleBackColor = true;
            this.chk_numero_documento.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_direccion
            // 
            this.chk_direccion.AutoSize = true;
            this.chk_direccion.Location = new System.Drawing.Point(553, 248);
            this.chk_direccion.Name = "chk_direccion";
            this.chk_direccion.Size = new System.Drawing.Size(15, 14);
            this.chk_direccion.TabIndex = 148;
            this.chk_direccion.UseVisualStyleBackColor = true;
            this.chk_direccion.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_mail
            // 
            this.chk_mail.AutoSize = true;
            this.chk_mail.Location = new System.Drawing.Point(553, 302);
            this.chk_mail.Name = "chk_mail";
            this.chk_mail.Size = new System.Drawing.Size(15, 14);
            this.chk_mail.TabIndex = 147;
            this.chk_mail.UseVisualStyleBackColor = true;
            this.chk_mail.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_fecha_nacimiento
            // 
            this.chk_fecha_nacimiento.AutoSize = true;
            this.chk_fecha_nacimiento.Location = new System.Drawing.Point(553, 275);
            this.chk_fecha_nacimiento.Name = "chk_fecha_nacimiento";
            this.chk_fecha_nacimiento.Size = new System.Drawing.Size(15, 14);
            this.chk_fecha_nacimiento.TabIndex = 146;
            this.chk_fecha_nacimiento.UseVisualStyleBackColor = true;
            this.chk_fecha_nacimiento.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_tipo_documento
            // 
            this.chk_tipo_documento.AutoSize = true;
            this.chk_tipo_documento.Location = new System.Drawing.Point(553, 167);
            this.chk_tipo_documento.Name = "chk_tipo_documento";
            this.chk_tipo_documento.Size = new System.Drawing.Size(15, 14);
            this.chk_tipo_documento.TabIndex = 145;
            this.chk_tipo_documento.UseVisualStyleBackColor = true;
            this.chk_tipo_documento.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_username
            // 
            this.chk_username.AutoSize = true;
            this.chk_username.Location = new System.Drawing.Point(553, 86);
            this.chk_username.Name = "chk_username";
            this.chk_username.Size = new System.Drawing.Size(15, 14);
            this.chk_username.TabIndex = 143;
            this.chk_username.UseVisualStyleBackColor = true;
            this.chk_username.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_apellido
            // 
            this.chk_apellido.AutoSize = true;
            this.chk_apellido.Location = new System.Drawing.Point(553, 140);
            this.chk_apellido.Name = "chk_apellido";
            this.chk_apellido.Size = new System.Drawing.Size(15, 14);
            this.chk_apellido.TabIndex = 141;
            this.chk_apellido.UseVisualStyleBackColor = true;
            this.chk_apellido.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // chk_nombre
            // 
            this.chk_nombre.AutoSize = true;
            this.chk_nombre.Location = new System.Drawing.Point(553, 113);
            this.chk_nombre.Name = "chk_nombre";
            this.chk_nombre.Size = new System.Drawing.Size(15, 14);
            this.chk_nombre.TabIndex = 140;
            this.chk_nombre.UseVisualStyleBackColor = true;
            this.chk_nombre.CheckedChanged += new System.EventHandler(this.common_checkBox_check);
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 97;
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
            // button_modificar
            // 
            this.button_modificar.Enabled = false;
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_modificar.Location = new System.Drawing.Point(12, 486);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 96;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click_1);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 486);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 95;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // lbl_mail
            // 
            this.lbl_mail.AutoSize = true;
            this.lbl_mail.Location = new System.Drawing.Point(22, 308);
            this.lbl_mail.Name = "lbl_mail";
            this.lbl_mail.Size = new System.Drawing.Size(26, 13);
            this.lbl_mail.TabIndex = 228;
            this.lbl_mail.Text = "Mail";
            // 
            // txt_mail
            // 
            this.txt_mail.Location = new System.Drawing.Point(313, 299);
            this.txt_mail.Name = "txt_mail";
            this.txt_mail.Size = new System.Drawing.Size(233, 20);
            this.txt_mail.TabIndex = 227;
            // 
            // lbl_apellido
            // 
            this.lbl_apellido.AutoSize = true;
            this.lbl_apellido.Location = new System.Drawing.Point(22, 140);
            this.lbl_apellido.Name = "lbl_apellido";
            this.lbl_apellido.Size = new System.Drawing.Size(44, 13);
            this.lbl_apellido.TabIndex = 226;
            this.lbl_apellido.Text = "Apellido";
            // 
            // txt_apellido
            // 
            this.txt_apellido.Location = new System.Drawing.Point(313, 136);
            this.txt_apellido.Name = "txt_apellido";
            this.txt_apellido.Size = new System.Drawing.Size(233, 20);
            this.txt_apellido.TabIndex = 225;
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(22, 112);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 224;
            this.lbl_nombre.Text = "Nombre";
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(313, 109);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(233, 20);
            this.txt_nombre.TabIndex = 223;
            // 
            // cmb_tipo_documento
            // 
            this.cmb_tipo_documento.FormattingEnabled = true;
            this.cmb_tipo_documento.Location = new System.Drawing.Point(313, 163);
            this.cmb_tipo_documento.Name = "cmb_tipo_documento";
            this.cmb_tipo_documento.Size = new System.Drawing.Size(233, 21);
            this.cmb_tipo_documento.TabIndex = 222;
            // 
            // lbl_fecha_nacimiento
            // 
            this.lbl_fecha_nacimiento.AutoSize = true;
            this.lbl_fecha_nacimiento.Location = new System.Drawing.Point(22, 280);
            this.lbl_fecha_nacimiento.Name = "lbl_fecha_nacimiento";
            this.lbl_fecha_nacimiento.Size = new System.Drawing.Size(108, 13);
            this.lbl_fecha_nacimiento.TabIndex = 221;
            this.lbl_fecha_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // lbl_direccion
            // 
            this.lbl_direccion.AutoSize = true;
            this.lbl_direccion.Location = new System.Drawing.Point(22, 252);
            this.lbl_direccion.Name = "lbl_direccion";
            this.lbl_direccion.Size = new System.Drawing.Size(52, 13);
            this.lbl_direccion.TabIndex = 220;
            this.lbl_direccion.Text = "Direccion";
            // 
            // lbl_telefono
            // 
            this.lbl_telefono.AutoSize = true;
            this.lbl_telefono.Location = new System.Drawing.Point(22, 224);
            this.lbl_telefono.Name = "lbl_telefono";
            this.lbl_telefono.Size = new System.Drawing.Size(49, 13);
            this.lbl_telefono.TabIndex = 219;
            this.lbl_telefono.Text = "Teléfono";
            // 
            // lbl_numero_doc
            // 
            this.lbl_numero_doc.AutoSize = true;
            this.lbl_numero_doc.Location = new System.Drawing.Point(22, 196);
            this.lbl_numero_doc.Name = "lbl_numero_doc";
            this.lbl_numero_doc.Size = new System.Drawing.Size(117, 13);
            this.lbl_numero_doc.TabIndex = 218;
            this.lbl_numero_doc.Text = "Numero de Documento";
            // 
            // lbl_tipo_documento
            // 
            this.lbl_tipo_documento.AutoSize = true;
            this.lbl_tipo_documento.Location = new System.Drawing.Point(22, 168);
            this.lbl_tipo_documento.Name = "lbl_tipo_documento";
            this.lbl_tipo_documento.Size = new System.Drawing.Size(99, 13);
            this.lbl_tipo_documento.TabIndex = 217;
            this.lbl_tipo_documento.Text = "Tipo de documento";
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(22, 84);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(96, 13);
            this.lbl_username.TabIndex = 214;
            this.lbl_username.Text = "Nombre de usuario";
            // 
            // dtp_fecha_nacimiento
            // 
            this.dtp_fecha_nacimiento.Location = new System.Drawing.Point(313, 272);
            this.dtp_fecha_nacimiento.Name = "dtp_fecha_nacimiento";
            this.dtp_fecha_nacimiento.Size = new System.Drawing.Size(233, 20);
            this.dtp_fecha_nacimiento.TabIndex = 213;
            // 
            // txt_direccion
            // 
            this.txt_direccion.Location = new System.Drawing.Point(313, 245);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(233, 20);
            this.txt_direccion.TabIndex = 212;
            // 
            // txt_telefono
            // 
            this.txt_telefono.Location = new System.Drawing.Point(313, 218);
            this.txt_telefono.Name = "txt_telefono";
            this.txt_telefono.Size = new System.Drawing.Size(233, 20);
            this.txt_telefono.TabIndex = 211;
            // 
            // txt_numero_documento
            // 
            this.txt_numero_documento.Location = new System.Drawing.Point(313, 191);
            this.txt_numero_documento.Name = "txt_numero_documento";
            this.txt_numero_documento.Size = new System.Drawing.Size(233, 20);
            this.txt_numero_documento.TabIndex = 210;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(313, 82);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(233, 20);
            this.txt_username.TabIndex = 207;
            // 
            // button_seleccionarRoles
            // 
            this.button_seleccionarRoles.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_seleccionarRoles.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_seleccionarRoles.Location = new System.Drawing.Point(29, 399);
            this.button_seleccionarRoles.Name = "button_seleccionarRoles";
            this.button_seleccionarRoles.Size = new System.Drawing.Size(197, 45);
            this.button_seleccionarRoles.TabIndex = 229;
            this.button_seleccionarRoles.Text = "Seleccionar Roles";
            this.button_seleccionarRoles.UseVisualStyleBackColor = true;
            this.button_seleccionarRoles.Click += new System.EventHandler(this.button_seleccionarRoles_Click);
            // 
            // _lbl_mail
            // 
            this._lbl_mail.AutoSize = true;
            this._lbl_mail.Location = new System.Drawing.Point(159, 307);
            this._lbl_mail.Name = "_lbl_mail";
            this._lbl_mail.Size = new System.Drawing.Size(26, 13);
            this._lbl_mail.TabIndex = 240;
            this._lbl_mail.Text = "Mail";
            // 
            // _lbl_apellido
            // 
            this._lbl_apellido.AutoSize = true;
            this._lbl_apellido.Location = new System.Drawing.Point(159, 139);
            this._lbl_apellido.Name = "_lbl_apellido";
            this._lbl_apellido.Size = new System.Drawing.Size(44, 13);
            this._lbl_apellido.TabIndex = 239;
            this._lbl_apellido.Text = "Apellido";
            // 
            // _lbl_nombre
            // 
            this._lbl_nombre.AutoSize = true;
            this._lbl_nombre.Location = new System.Drawing.Point(159, 111);
            this._lbl_nombre.Name = "_lbl_nombre";
            this._lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this._lbl_nombre.TabIndex = 238;
            this._lbl_nombre.Text = "Nombre";
            // 
            // _lbl_fecha_nacimiento
            // 
            this._lbl_fecha_nacimiento.AutoSize = true;
            this._lbl_fecha_nacimiento.Location = new System.Drawing.Point(159, 279);
            this._lbl_fecha_nacimiento.Name = "_lbl_fecha_nacimiento";
            this._lbl_fecha_nacimiento.Size = new System.Drawing.Size(108, 13);
            this._lbl_fecha_nacimiento.TabIndex = 237;
            this._lbl_fecha_nacimiento.Text = "Fecha de Nacimiento";
            // 
            // _lbl_direccion
            // 
            this._lbl_direccion.AutoSize = true;
            this._lbl_direccion.Location = new System.Drawing.Point(159, 251);
            this._lbl_direccion.Name = "_lbl_direccion";
            this._lbl_direccion.Size = new System.Drawing.Size(52, 13);
            this._lbl_direccion.TabIndex = 236;
            this._lbl_direccion.Text = "Direccion";
            // 
            // _lbl_telefono
            // 
            this._lbl_telefono.AutoSize = true;
            this._lbl_telefono.Location = new System.Drawing.Point(159, 223);
            this._lbl_telefono.Name = "_lbl_telefono";
            this._lbl_telefono.Size = new System.Drawing.Size(49, 13);
            this._lbl_telefono.TabIndex = 235;
            this._lbl_telefono.Text = "Teléfono";
            // 
            // _lbl_numero_doc
            // 
            this._lbl_numero_doc.AutoSize = true;
            this._lbl_numero_doc.Location = new System.Drawing.Point(159, 195);
            this._lbl_numero_doc.Name = "_lbl_numero_doc";
            this._lbl_numero_doc.Size = new System.Drawing.Size(117, 13);
            this._lbl_numero_doc.TabIndex = 234;
            this._lbl_numero_doc.Text = "Numero de Documento";
            // 
            // _lbl_tipo_documento
            // 
            this._lbl_tipo_documento.AutoSize = true;
            this._lbl_tipo_documento.Location = new System.Drawing.Point(159, 167);
            this._lbl_tipo_documento.Name = "_lbl_tipo_documento";
            this._lbl_tipo_documento.Size = new System.Drawing.Size(99, 13);
            this._lbl_tipo_documento.TabIndex = 233;
            this._lbl_tipo_documento.Text = "Tipo de documento";
            // 
            // _lbl_username
            // 
            this._lbl_username.AutoSize = true;
            this._lbl_username.Location = new System.Drawing.Point(159, 83);
            this._lbl_username.Name = "_lbl_username";
            this._lbl_username.Size = new System.Drawing.Size(96, 13);
            this._lbl_username.TabIndex = 230;
            this._lbl_username.Text = "Nombre de usuario";
            // 
            // Usuario_modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this._lbl_mail);
            this.Controls.Add(this._lbl_apellido);
            this.Controls.Add(this._lbl_nombre);
            this.Controls.Add(this._lbl_fecha_nacimiento);
            this.Controls.Add(this._lbl_direccion);
            this.Controls.Add(this._lbl_telefono);
            this.Controls.Add(this._lbl_numero_doc);
            this.Controls.Add(this._lbl_tipo_documento);
            this.Controls.Add(this._lbl_username);
            this.Controls.Add(this.button_seleccionarRoles);
            this.Controls.Add(this.lbl_mail);
            this.Controls.Add(this.txt_mail);
            this.Controls.Add(this.lbl_apellido);
            this.Controls.Add(this.txt_apellido);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.txt_nombre);
            this.Controls.Add(this.cmb_tipo_documento);
            this.Controls.Add(this.lbl_fecha_nacimiento);
            this.Controls.Add(this.lbl_direccion);
            this.Controls.Add(this.lbl_telefono);
            this.Controls.Add(this.lbl_numero_doc);
            this.Controls.Add(this.lbl_tipo_documento);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.dtp_fecha_nacimiento);
            this.Controls.Add(this.txt_direccion);
            this.Controls.Add(this.txt_telefono);
            this.Controls.Add(this.txt_numero_documento);
            this.Controls.Add(this.txt_username);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.lbl_original);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.chk_todos);
            this.Controls.Add(this.chk_telefono);
            this.Controls.Add(this.chk_numero_documento);
            this.Controls.Add(this.chk_direccion);
            this.Controls.Add(this.chk_mail);
            this.Controls.Add(this.chk_fecha_nacimiento);
            this.Controls.Add(this.chk_tipo_documento);
            this.Controls.Add(this.chk_username);
            this.Controls.Add(this.chk_apellido);
            this.Controls.Add(this.chk_nombre);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Usuario_modificar";
            this.Text = "Usuario_modificar";
            this.Load += new System.EventHandler(this.Usuario_modificar_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.Label lbl_original;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.CheckBox chk_telefono;
        private System.Windows.Forms.CheckBox chk_numero_documento;
        private System.Windows.Forms.CheckBox chk_direccion;
        private System.Windows.Forms.CheckBox chk_mail;
        private System.Windows.Forms.CheckBox chk_fecha_nacimiento;
        private System.Windows.Forms.CheckBox chk_tipo_documento;
        private System.Windows.Forms.CheckBox chk_username;
        private System.Windows.Forms.CheckBox chk_apellido;
        private System.Windows.Forms.CheckBox chk_nombre;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Label lbl_mail;
        private System.Windows.Forms.TextBox txt_mail;
        private System.Windows.Forms.Label lbl_apellido;
        private System.Windows.Forms.TextBox txt_apellido;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.ComboBox cmb_tipo_documento;
        private System.Windows.Forms.Label lbl_fecha_nacimiento;
        private System.Windows.Forms.Label lbl_direccion;
        private System.Windows.Forms.Label lbl_telefono;
        private System.Windows.Forms.Label lbl_numero_doc;
        private System.Windows.Forms.Label lbl_tipo_documento;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.DateTimePicker dtp_fecha_nacimiento;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.TextBox txt_telefono;
        private System.Windows.Forms.TextBox txt_numero_documento;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Button button_seleccionarRoles;
        private System.Windows.Forms.Label _lbl_mail;
        private System.Windows.Forms.Label _lbl_apellido;
        private System.Windows.Forms.Label _lbl_nombre;
        private System.Windows.Forms.Label _lbl_fecha_nacimiento;
        private System.Windows.Forms.Label _lbl_direccion;
        private System.Windows.Forms.Label _lbl_telefono;
        private System.Windows.Forms.Label _lbl_numero_doc;
        private System.Windows.Forms.Label _lbl_tipo_documento;
        private System.Windows.Forms.Label _lbl_username;
    }
}