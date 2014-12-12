namespace FrbaHotel.ABM_de_Habitacion
{
    partial class Habitacion_modificar
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
            this.chk_descripcion = new System.Windows.Forms.CheckBox();
            this.chk_frente = new System.Windows.Forms.CheckBox();
            this.chk_numero = new System.Windows.Forms.CheckBox();
            this.chk_piso = new System.Windows.Forms.CheckBox();
            this.txt_descripcion = new System.Windows.Forms.TextBox();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.txt_piso = new System.Windows.Forms.TextBox();
            this._lbl_descripcion = new System.Windows.Forms.Label();
            this._lbl_tipo_habitacion = new System.Windows.Forms.Label();
            this._lbl_frente = new System.Windows.Forms.Label();
            this._lbl_numero = new System.Windows.Forms.Label();
            this._lbl_piso = new System.Windows.Forms.Label();
            this.lbl_descripcion = new System.Windows.Forms.Label();
            this.lbl_tipo_habitacion = new System.Windows.Forms.Label();
            this.lbl_frente = new System.Windows.Forms.Label();
            this.lbl_numero = new System.Windows.Forms.Label();
            this.lbl_piso = new System.Windows.Forms.Label();
            this.chk_baja = new System.Windows.Forms.CheckBox();
            this.cmb_baja = new System.Windows.Forms.ComboBox();
            this._lbl_baja = new System.Windows.Forms.Label();
            this.lbl_baja = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.cmb_frente = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(315, 25);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(145, 31);
            this.lbl_modificado.TabIndex = 114;
            this.lbl_modificado.Text = "Modificado";
            // 
            // lbl_original
            // 
            this.lbl_original.AutoSize = true;
            this.lbl_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_original.Location = new System.Drawing.Point(165, 23);
            this.lbl_original.Name = "lbl_original";
            this.lbl_original.Size = new System.Drawing.Size(107, 31);
            this.lbl_original.TabIndex = 113;
            this.lbl_original.Text = "Original";
            // 
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(17, 23);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 112;
            this.lbl_atributo.Text = "Atributo";
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.Location = new System.Drawing.Point(550, 40);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(15, 14);
            this.chk_todos.TabIndex = 111;
            this.chk_todos.UseVisualStyleBackColor = true;
            this.chk_todos.CheckedChanged += new System.EventHandler(this.check_todos_change);
            // 
            // chk_descripcion
            // 
            this.chk_descripcion.AutoSize = true;
            this.chk_descripcion.Location = new System.Drawing.Point(550, 188);
            this.chk_descripcion.Name = "chk_descripcion";
            this.chk_descripcion.Size = new System.Drawing.Size(15, 14);
            this.chk_descripcion.TabIndex = 110;
            this.chk_descripcion.UseVisualStyleBackColor = true;
            this.chk_descripcion.CheckedChanged += new System.EventHandler(this.chk_baja_CheckedChanged);
            // 
            // chk_frente
            // 
            this.chk_frente.AutoSize = true;
            this.chk_frente.Location = new System.Drawing.Point(550, 133);
            this.chk_frente.Name = "chk_frente";
            this.chk_frente.Size = new System.Drawing.Size(15, 14);
            this.chk_frente.TabIndex = 108;
            this.chk_frente.UseVisualStyleBackColor = true;
            this.chk_frente.CheckedChanged += new System.EventHandler(this.chk_baja_CheckedChanged);
            // 
            // chk_numero
            // 
            this.chk_numero.AutoSize = true;
            this.chk_numero.Location = new System.Drawing.Point(550, 104);
            this.chk_numero.Name = "chk_numero";
            this.chk_numero.Size = new System.Drawing.Size(15, 14);
            this.chk_numero.TabIndex = 107;
            this.chk_numero.UseVisualStyleBackColor = true;
            this.chk_numero.CheckedChanged += new System.EventHandler(this.chk_baja_CheckedChanged);
            // 
            // chk_piso
            // 
            this.chk_piso.AutoSize = true;
            this.chk_piso.Location = new System.Drawing.Point(550, 75);
            this.chk_piso.Name = "chk_piso";
            this.chk_piso.Size = new System.Drawing.Size(15, 14);
            this.chk_piso.TabIndex = 106;
            this.chk_piso.UseVisualStyleBackColor = true;
            this.chk_piso.CheckedChanged += new System.EventHandler(this.chk_baja_CheckedChanged);
            // 
            // txt_descripcion
            // 
            this.txt_descripcion.Location = new System.Drawing.Point(321, 185);
            this.txt_descripcion.Multiline = true;
            this.txt_descripcion.Name = "txt_descripcion";
            this.txt_descripcion.Size = new System.Drawing.Size(210, 120);
            this.txt_descripcion.TabIndex = 104;
            this.txt_descripcion.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // txt_numero
            // 
            this.txt_numero.Location = new System.Drawing.Point(321, 101);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(210, 20);
            this.txt_numero.TabIndex = 102;
            this.txt_numero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            this.txt_numero.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // txt_piso
            // 
            this.txt_piso.Location = new System.Drawing.Point(321, 72);
            this.txt_piso.Name = "txt_piso";
            this.txt_piso.Size = new System.Drawing.Size(210, 20);
            this.txt_piso.TabIndex = 101;
            this.txt_piso.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_piso_KeyPress);
            this.txt_piso.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // _lbl_descripcion
            // 
            this._lbl_descripcion.AutoSize = true;
            this._lbl_descripcion.Location = new System.Drawing.Point(165, 188);
            this._lbl_descripcion.Name = "_lbl_descripcion";
            this._lbl_descripcion.Size = new System.Drawing.Size(63, 13);
            this._lbl_descripcion.TabIndex = 100;
            this._lbl_descripcion.Text = "Descripción";
            // 
            // _lbl_tipo_habitacion
            // 
            this._lbl_tipo_habitacion.AutoSize = true;
            this._lbl_tipo_habitacion.Location = new System.Drawing.Point(165, 159);
            this._lbl_tipo_habitacion.Name = "_lbl_tipo_habitacion";
            this._lbl_tipo_habitacion.Size = new System.Drawing.Size(95, 13);
            this._lbl_tipo_habitacion.TabIndex = 99;
            this._lbl_tipo_habitacion.Text = "Tipo de habitación";
            // 
            // _lbl_frente
            // 
            this._lbl_frente.AutoSize = true;
            this._lbl_frente.Location = new System.Drawing.Point(165, 130);
            this._lbl_frente.Name = "_lbl_frente";
            this._lbl_frente.Size = new System.Drawing.Size(37, 13);
            this._lbl_frente.TabIndex = 98;
            this._lbl_frente.Text = "Frente";
            // 
            // _lbl_numero
            // 
            this._lbl_numero.AutoSize = true;
            this._lbl_numero.Location = new System.Drawing.Point(165, 101);
            this._lbl_numero.Name = "_lbl_numero";
            this._lbl_numero.Size = new System.Drawing.Size(44, 13);
            this._lbl_numero.TabIndex = 97;
            this._lbl_numero.Text = "Número";
            // 
            // _lbl_piso
            // 
            this._lbl_piso.AutoSize = true;
            this._lbl_piso.Location = new System.Drawing.Point(165, 72);
            this._lbl_piso.Name = "_lbl_piso";
            this._lbl_piso.Size = new System.Drawing.Size(27, 13);
            this._lbl_piso.TabIndex = 96;
            this._lbl_piso.Text = "Piso";
            // 
            // lbl_descripcion
            // 
            this.lbl_descripcion.AutoSize = true;
            this.lbl_descripcion.Location = new System.Drawing.Point(17, 188);
            this.lbl_descripcion.Name = "lbl_descripcion";
            this.lbl_descripcion.Size = new System.Drawing.Size(63, 13);
            this.lbl_descripcion.TabIndex = 95;
            this.lbl_descripcion.Text = "Descripción";
            // 
            // lbl_tipo_habitacion
            // 
            this.lbl_tipo_habitacion.AutoSize = true;
            this.lbl_tipo_habitacion.Location = new System.Drawing.Point(17, 159);
            this.lbl_tipo_habitacion.Name = "lbl_tipo_habitacion";
            this.lbl_tipo_habitacion.Size = new System.Drawing.Size(95, 13);
            this.lbl_tipo_habitacion.TabIndex = 94;
            this.lbl_tipo_habitacion.Text = "Tipo de habitación";
            // 
            // lbl_frente
            // 
            this.lbl_frente.AutoSize = true;
            this.lbl_frente.Location = new System.Drawing.Point(17, 130);
            this.lbl_frente.Name = "lbl_frente";
            this.lbl_frente.Size = new System.Drawing.Size(37, 13);
            this.lbl_frente.TabIndex = 93;
            this.lbl_frente.Text = "Frente";
            // 
            // lbl_numero
            // 
            this.lbl_numero.AutoSize = true;
            this.lbl_numero.Location = new System.Drawing.Point(17, 101);
            this.lbl_numero.Name = "lbl_numero";
            this.lbl_numero.Size = new System.Drawing.Size(44, 13);
            this.lbl_numero.TabIndex = 92;
            this.lbl_numero.Text = "Número";
            // 
            // lbl_piso
            // 
            this.lbl_piso.AutoSize = true;
            this.lbl_piso.Location = new System.Drawing.Point(17, 72);
            this.lbl_piso.Name = "lbl_piso";
            this.lbl_piso.Size = new System.Drawing.Size(27, 13);
            this.lbl_piso.TabIndex = 91;
            this.lbl_piso.Text = "Piso";
            // 
            // chk_baja
            // 
            this.chk_baja.AutoSize = true;
            this.chk_baja.Location = new System.Drawing.Point(551, 326);
            this.chk_baja.Name = "chk_baja";
            this.chk_baja.Size = new System.Drawing.Size(15, 14);
            this.chk_baja.TabIndex = 120;
            this.chk_baja.UseVisualStyleBackColor = true;
            this.chk_baja.CheckedChanged += new System.EventHandler(this.chk_baja_CheckedChanged);
            // 
            // cmb_baja
            // 
            this.cmb_baja.FormattingEnabled = true;
            this.cmb_baja.Items.AddRange(new object[] {
            "NO"});
            this.cmb_baja.Location = new System.Drawing.Point(322, 323);
            this.cmb_baja.Name = "cmb_baja";
            this.cmb_baja.Size = new System.Drawing.Size(210, 21);
            this.cmb_baja.TabIndex = 119;
            this.cmb_baja.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // _lbl_baja
            // 
            this._lbl_baja.AutoSize = true;
            this._lbl_baja.Location = new System.Drawing.Point(166, 325);
            this._lbl_baja.Name = "_lbl_baja";
            this._lbl_baja.Size = new System.Drawing.Size(28, 13);
            this._lbl_baja.TabIndex = 118;
            this._lbl_baja.Text = "Baja";
            // 
            // lbl_baja
            // 
            this.lbl_baja.AutoSize = true;
            this.lbl_baja.Location = new System.Drawing.Point(18, 325);
            this.lbl_baja.Name = "lbl_baja";
            this.lbl_baja.Size = new System.Drawing.Size(28, 13);
            this.lbl_baja.TabIndex = 117;
            this.lbl_baja.Text = "Baja";
            // 
            // button_modificar
            // 
            this.button_modificar.Enabled = false;
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_modificar.Location = new System.Drawing.Point(7, 350);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 116;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            this.button_modificar.Click += new System.EventHandler(this.button_modificar_Click);
            this.button_modificar.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(432, 350);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 115;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click_1);
            // 
            // cmb_frente
            // 
            this.cmb_frente.FormattingEnabled = true;
            this.cmb_frente.Items.AddRange(new object[] {
            "Vista Exterior",
            "Vista Interior"});
            this.cmb_frente.Location = new System.Drawing.Point(321, 128);
            this.cmb_frente.Name = "cmb_frente";
            this.cmb_frente.Size = new System.Drawing.Size(210, 21);
            this.cmb_frente.TabIndex = 121;
            this.cmb_frente.EnabledChanged += new System.EventHandler(this.control_enabled_change);
            // 
            // Habitacion_modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.cmb_frente);
            this.Controls.Add(this.chk_baja);
            this.Controls.Add(this.cmb_baja);
            this.Controls.Add(this._lbl_baja);
            this.Controls.Add(this.lbl_baja);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.lbl_original);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.chk_todos);
            this.Controls.Add(this.chk_descripcion);
            this.Controls.Add(this.chk_frente);
            this.Controls.Add(this.chk_numero);
            this.Controls.Add(this.chk_piso);
            this.Controls.Add(this.txt_descripcion);
            this.Controls.Add(this.txt_numero);
            this.Controls.Add(this.txt_piso);
            this.Controls.Add(this._lbl_descripcion);
            this.Controls.Add(this._lbl_tipo_habitacion);
            this.Controls.Add(this._lbl_frente);
            this.Controls.Add(this._lbl_numero);
            this.Controls.Add(this._lbl_piso);
            this.Controls.Add(this.lbl_descripcion);
            this.Controls.Add(this.lbl_tipo_habitacion);
            this.Controls.Add(this.lbl_frente);
            this.Controls.Add(this.lbl_numero);
            this.Controls.Add(this.lbl_piso);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Habitacion_modificar";
            this.Text = "Habitacion_modificar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.Label lbl_original;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.CheckBox chk_descripcion;
        private System.Windows.Forms.CheckBox chk_frente;
        private System.Windows.Forms.CheckBox chk_numero;
        private System.Windows.Forms.CheckBox chk_piso;
        private System.Windows.Forms.TextBox txt_descripcion;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.TextBox txt_piso;
        private System.Windows.Forms.Label _lbl_descripcion;
        private System.Windows.Forms.Label _lbl_tipo_habitacion;
        private System.Windows.Forms.Label _lbl_frente;
        private System.Windows.Forms.Label _lbl_numero;
        private System.Windows.Forms.Label _lbl_piso;
        private System.Windows.Forms.Label lbl_descripcion;
        private System.Windows.Forms.Label lbl_tipo_habitacion;
        private System.Windows.Forms.Label lbl_frente;
        private System.Windows.Forms.Label lbl_numero;
        private System.Windows.Forms.Label lbl_piso;
        private System.Windows.Forms.CheckBox chk_baja;
        private System.Windows.Forms.ComboBox cmb_baja;
        private System.Windows.Forms.Label _lbl_baja;
        private System.Windows.Forms.Label lbl_baja;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.ComboBox cmb_frente;
    }
}