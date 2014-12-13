namespace FrbaHotel.ABM_de_Habitacion
{
    partial class Habitacion_alta
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
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.cmb_tipo_habitacion = new System.Windows.Forms.ComboBox();
            this._obli_tipoDoc = new System.Windows.Forms.Label();
            this._obli_mail = new System.Windows.Forms.Label();
            this._obli_apellido = new System.Windows.Forms.Label();
            this._obli_nombre = new System.Windows.Forms.Label();
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.lbl_informacion_obligatoria = new System.Windows.Forms.Label();
            this.lbl_tipo_habitacion = new System.Windows.Forms.Label();
            this.lbl_frente = new System.Windows.Forms.Label();
            this.lbl_numero = new System.Windows.Forms.Label();
            this.lbl_piso = new System.Windows.Forms.Label();
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.txt_piso = new System.Windows.Forms.TextBox();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.rb_VistaExterior = new System.Windows.Forms.RadioButton();
            this.rb_VistaInterior = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 339);
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
            // cmb_tipo_habitacion
            // 
            this.cmb_tipo_habitacion.FormattingEnabled = true;
            this.cmb_tipo_habitacion.Location = new System.Drawing.Point(213, 141);
            this.cmb_tipo_habitacion.Name = "cmb_tipo_habitacion";
            this.cmb_tipo_habitacion.Size = new System.Drawing.Size(192, 21);
            this.cmb_tipo_habitacion.TabIndex = 5;
            // 
            // _obli_tipoDoc
            // 
            this._obli_tipoDoc.AutoSize = true;
            this._obli_tipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_tipoDoc.ForeColor = System.Drawing.Color.Red;
            this._obli_tipoDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_tipoDoc.Location = new System.Drawing.Point(411, 142);
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
            this._obli_mail.Location = new System.Drawing.Point(478, 115);
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
            this._obli_apellido.Location = new System.Drawing.Point(335, 86);
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
            this._obli_nombre.Location = new System.Drawing.Point(335, 55);
            this._obli_nombre.Name = "_obli_nombre";
            this._obli_nombre.Size = new System.Drawing.Size(15, 20);
            this._obli_nombre.TabIndex = 188;
            this._obli_nombre.Text = "*";
            // 
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(39, 8);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 187;
            this.lbl_atributo.Text = "Atributo";
            // 
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Location = new System.Drawing.Point(39, 173);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(63, 13);
            this.lbl_descripcion.TabIndex = 177;
            this.lbl_descripcion.Text = "Descripción";
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(213, 168);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(329, 98);
            this.txt_descripcion.TabIndex = 6;
            // 
            // lbl_informacion_obligatoria
            // 
            this.lbl_informacion_obligatoria.AutoSize = true;
            this.lbl_informacion_obligatoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_informacion_obligatoria.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_informacion_obligatoria.Location = new System.Drawing.Point(212, 300);
            this.lbl_informacion_obligatoria.Name = "lbl_informacion_obligatoria";
            this.lbl_informacion_obligatoria.Size = new System.Drawing.Size(168, 18);
            this.lbl_informacion_obligatoria.TabIndex = 197;
            this.lbl_informacion_obligatoria.Text = "* Información obligatoria";
            // 
            // lbl_tipo_habitacion
            // 
            this.lbl_tipo_habitacion.AutoSize = true;
            this.lbl_tipo_habitacion.Location = new System.Drawing.Point(39, 144);
            this.lbl_tipo_habitacion.Name = "lbl_tipo_habitacion";
            this.lbl_tipo_habitacion.Size = new System.Drawing.Size(95, 13);
            this.lbl_tipo_habitacion.TabIndex = 176;
            this.lbl_tipo_habitacion.Text = "Tipo de habitación";
            // 
            // lbl_frente
            // 
            this.lbl_frente.AutoSize = true;
            this.lbl_frente.Location = new System.Drawing.Point(39, 115);
            this.lbl_frente.Name = "lbl_frente";
            this.lbl_frente.Size = new System.Drawing.Size(37, 13);
            this.lbl_frente.TabIndex = 175;
            this.lbl_frente.Text = "Frente";
            // 
            // lbl_numero
            // 
            this.lbl_numero.AutoSize = true;
            this.lbl_numero.Location = new System.Drawing.Point(39, 86);
            this.lbl_numero.Name = "lbl_numero";
            this.lbl_numero.Size = new System.Drawing.Size(44, 13);
            this.lbl_numero.TabIndex = 174;
            this.lbl_numero.Text = "Número";
            // 
            // lbl_piso
            // 
            this.lbl_piso.AutoSize = true;
            this.lbl_piso.Location = new System.Drawing.Point(39, 57);
            this.lbl_piso.Name = "lbl_piso";
            this.lbl_piso.Size = new System.Drawing.Size(27, 13);
            this.lbl_piso.TabIndex = 173;
            this.lbl_piso.Text = "Piso";
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(230, 8);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(77, 31);
            this.lbl_modificado.TabIndex = 172;
            this.lbl_modificado.Text = "Valor";
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(213, 84);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(116, 20);
            this.txt_numero.TabIndex = 2;
            this.txt_numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            // 
            // txt_piso
            // 
            this.txt_piso.Location = new System.Drawing.Point(213, 55);
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(116, 20);
            this.txt_piso.TabIndex = 1;
            this.txt_piso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_aceptar.Location = new System.Drawing.Point(12, 284);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 7;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 284);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 8;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // rb_VistaExterior
            // 
            this.rb_VistaExterior.AutoSize = true;
            this.rb_VistaExterior.Location = new System.Drawing.Point(238, 113);
            this.rb_VistaExterior.Name = "rb_VistaExterior";
            this.rb_VistaExterior.Size = new System.Drawing.Size(86, 17);
            this.rb_VistaExterior.TabIndex = 3;
            this.rb_VistaExterior.TabStop = true;
            this.rb_VistaExterior.Text = "Vista Exterior";
            this.rb_VistaExterior.UseVisualStyleBackColor = true;
            // 
            // rb_VistaInterior
            // 
            this.rb_VistaInterior.AutoSize = true;
            this.rb_VistaInterior.Location = new System.Drawing.Point(374, 113);
            this.rb_VistaInterior.Name = "rb_VistaInterior";
            this.rb_VistaInterior.Size = new System.Drawing.Size(83, 17);
            this.rb_VistaInterior.TabIndex = 4;
            this.rb_VistaInterior.TabStop = true;
            this.rb_VistaInterior.Text = "Vista Interior";
            this.rb_VistaInterior.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(548, 168);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 20);
            this.label1.TabIndex = 198;
            this.label1.Text = "*";
            // 
            // Habitacion_alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rb_VistaInterior);
            this.Controls.Add(this.rb_VistaExterior);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.cmb_tipo_habitacion);
            this.Controls.Add(this._obli_tipoDoc);
            this.Controls.Add(this._obli_mail);
            this.Controls.Add(this._obli_apellido);
            this.Controls.Add(this._obli_nombre);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.lbl_descripcion);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.lbl_informacion_obligatoria);
            this.Controls.Add(this.lbl_tipo_habitacion);
            this.Controls.Add(this.lbl_frente);
            this.Controls.Add(this.lbl_numero);
            this.Controls.Add(this.lbl_piso);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.txt_piso);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(600, 400);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "Habitacion_alta";
            this.Text = "Habitacion_alta";
            this.Load += new System.EventHandler(this.Habitacion_alta_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.ComboBox cmb_tipo_habitacion;
        private System.Windows.Forms.Label _obli_tipoDoc;
        private System.Windows.Forms.Label _obli_mail;
        private System.Windows.Forms.Label _obli_apellido;
        private System.Windows.Forms.Label _obli_nombre;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.Label lbl_informacion_obligatoria;
        private System.Windows.Forms.Label lbl_tipo_habitacion;
        private System.Windows.Forms.Label lbl_frente;
        private System.Windows.Forms.Label lbl_numero;
        private System.Windows.Forms.Label lbl_piso;
        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.TextBox txt_piso;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.RadioButton rb_VistaExterior;
        private System.Windows.Forms.RadioButton rb_VistaInterior;
        private System.Windows.Forms.Label label1;
    }
}