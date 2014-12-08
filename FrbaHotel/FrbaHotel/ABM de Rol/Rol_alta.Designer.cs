namespace FrbaHotel.ABM_de_Rol
{
    partial class Rol_alta
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
            this.list_funciones = new System.Windows.Forms.CheckedListBox();
            this.grp_activo = new System.Windows.Forms.GroupBox();
            this.lbl_inactivo = new System.Windows.Forms.Label();
            this.lbl_activo = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rb_activo = new System.Windows.Forms.RadioButton();
            this.rb_inactivo = new System.Windows.Forms.RadioButton();
            this._obli_tipoDoc = new System.Windows.Forms.Label();
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.lbl_funciones = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this._obli_nombre = new System.Windows.Forms.Label();
            this.stat_BarraEstado.SuspendLayout();
            this.grp_activo.SuspendLayout();
            this.SuspendLayout();
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 539);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 232;
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
            // list_funciones
            // 
            this.list_funciones.CheckOnClick = true;
            this.list_funciones.FormattingEnabled = true;
            this.list_funciones.Location = new System.Drawing.Point(237, 105);
            this.list_funciones.Name = "list_funciones";
            this.list_funciones.Size = new System.Drawing.Size(306, 259);
            this.list_funciones.TabIndex = 203;
            // 
            // grp_activo
            // 
            this.grp_activo.Controls.Add(this.lbl_inactivo);
            this.grp_activo.Controls.Add(this.lbl_activo);
            this.grp_activo.Controls.Add(this.label6);
            this.grp_activo.Controls.Add(this.rb_activo);
            this.grp_activo.Controls.Add(this.rb_inactivo);
            this.grp_activo.Location = new System.Drawing.Point(13, 369);
            this.grp_activo.Name = "grp_activo";
            this.grp_activo.Size = new System.Drawing.Size(560, 82);
            this.grp_activo.TabIndex = 226;
            this.grp_activo.TabStop = false;
            this.grp_activo.Text = "Seleccione actividad";
            // 
            // lbl_inactivo
            // 
            this.lbl_inactivo.AutoSize = true;
            this.lbl_inactivo.Location = new System.Drawing.Point(403, 32);
            this.lbl_inactivo.Name = "lbl_inactivo";
            this.lbl_inactivo.Size = new System.Drawing.Size(57, 13);
            this.lbl_inactivo.TabIndex = 204;
            this.lbl_inactivo.Text = "INACTIVO";
            // 
            // lbl_activo
            // 
            this.lbl_activo.AutoSize = true;
            this.lbl_activo.Location = new System.Drawing.Point(101, 32);
            this.lbl_activo.Name = "lbl_activo";
            this.lbl_activo.Size = new System.Drawing.Size(46, 13);
            this.lbl_activo.TabIndex = 203;
            this.lbl_activo.Text = "ACTIVO";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(109, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 20);
            this.label6.TabIndex = 202;
            this.label6.Text = "*";
            // 
            // rb_activo
            // 
            this.rb_activo.AutoSize = true;
            this.rb_activo.Location = new System.Drawing.Point(121, 63);
            this.rb_activo.Name = "rb_activo";
            this.rb_activo.Size = new System.Drawing.Size(14, 13);
            this.rb_activo.TabIndex = 9;
            this.rb_activo.TabStop = true;
            this.rb_activo.UseVisualStyleBackColor = true;
            // 
            // rb_inactivo
            // 
            this.rb_inactivo.AutoSize = true;
            this.rb_inactivo.Location = new System.Drawing.Point(425, 63);
            this.rb_inactivo.Name = "rb_inactivo";
            this.rb_inactivo.Size = new System.Drawing.Size(14, 13);
            this.rb_inactivo.TabIndex = 13;
            this.rb_inactivo.TabStop = true;
            this.rb_inactivo.UseVisualStyleBackColor = true;
            // 
            // _obli_tipoDoc
            // 
            this._obli_tipoDoc.AutoSize = true;
            this._obli_tipoDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_tipoDoc.ForeColor = System.Drawing.Color.Red;
            this._obli_tipoDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_tipoDoc.Location = new System.Drawing.Point(549, 105);
            this._obli_tipoDoc.Name = "_obli_tipoDoc";
            this._obli_tipoDoc.Size = new System.Drawing.Size(15, 20);
            this._obli_tipoDoc.TabIndex = 225;
            this._obli_tipoDoc.Text = "*";
            // 
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(40, 12);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 222;
            this.lbl_atributo.Text = "Atributo";
            // 
            // lbl_funciones
            // 
            this.lbl_funciones.AutoSize = true;
            this.lbl_funciones.Location = new System.Drawing.Point(52, 110);
            this.lbl_funciones.Name = "lbl_funciones";
            this.lbl_funciones.Size = new System.Drawing.Size(103, 13);
            this.lbl_funciones.TabIndex = 216;
            this.lbl_funciones.Text = "Finciones asignadas";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(50, 72);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 214;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(231, 12);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(77, 31);
            this.lbl_modificado.TabIndex = 213;
            this.lbl_modificado.Text = "Valor";
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_aceptar.Location = new System.Drawing.Point(13, 468);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 211;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(438, 468);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 212;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(237, 69);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(306, 20);
            this.txt_nombre.TabIndex = 205;
            // 
            // _obli_nombre
            // 
            this._obli_nombre.AutoSize = true;
            this._obli_nombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._obli_nombre.ForeColor = System.Drawing.Color.Red;
            this._obli_nombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._obli_nombre.Location = new System.Drawing.Point(549, 70);
            this._obli_nombre.Name = "_obli_nombre";
            this._obli_nombre.Size = new System.Drawing.Size(15, 20);
            this._obli_nombre.TabIndex = 223;
            this._obli_nombre.Text = "*";
            // 
            // Rol_alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.list_funciones);
            this.Controls.Add(this.grp_activo);
            this.Controls.Add(this._obli_tipoDoc);
            this.Controls.Add(this._obli_nombre);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.lbl_funciones);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.txt_nombre);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Rol_alta";
            this.Text = "Rol_alta";
            this.Load += new System.EventHandler(this.Rol_alta_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.grp_activo.ResumeLayout(false);
            this.grp_activo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.CheckedListBox list_funciones;
        private System.Windows.Forms.GroupBox grp_activo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rb_activo;
        private System.Windows.Forms.RadioButton rb_inactivo;
        private System.Windows.Forms.Label _obli_tipoDoc;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.Label lbl_funciones;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label _obli_nombre;
        private System.Windows.Forms.Label lbl_inactivo;
        private System.Windows.Forms.Label lbl_activo;
    }
}