namespace FrbaHotel.Login
{
    partial class Formulario_login
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
            this.button_volver = new System.Windows.Forms.Button();
            this.grp_usuario_y_pass = new System.Windows.Forms.GroupBox();
            this._lbl_password = new System.Windows.Forms.Label();
            this._lbl_nombre_usuario = new System.Windows.Forms.Label();
            this._txt_password = new System.Windows.Forms.TextBox();
            this._txt_usuario = new System.Windows.Forms.TextBox();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.grp_usuario_y_pass.SuspendLayout();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_aceptar.Location = new System.Drawing.Point(13, 89);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 16;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(237, 89);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 17;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // grp_usuario_y_pass
            // 
            this.grp_usuario_y_pass.Controls.Add(this._lbl_password);
            this.grp_usuario_y_pass.Controls.Add(this._lbl_nombre_usuario);
            this.grp_usuario_y_pass.Controls.Add(this._txt_password);
            this.grp_usuario_y_pass.Controls.Add(this._txt_usuario);
            this.grp_usuario_y_pass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.grp_usuario_y_pass.Location = new System.Drawing.Point(13, 13);
            this.grp_usuario_y_pass.Name = "grp_usuario_y_pass";
            this.grp_usuario_y_pass.Size = new System.Drawing.Size(359, 70);
            this.grp_usuario_y_pass.TabIndex = 18;
            this.grp_usuario_y_pass.TabStop = false;
            this.grp_usuario_y_pass.Text = "Usuario y contraseña";
            this.grp_usuario_y_pass.Enter += new System.EventHandler(this.grp_usuario_y_pass_Enter);
            // 
            // _lbl_password
            // 
            this._lbl_password.AutoSize = true;
            this._lbl_password.ForeColor = System.Drawing.SystemColors.WindowText;
            this._lbl_password.Location = new System.Drawing.Point(16, 47);
            this._lbl_password.Name = "_lbl_password";
            this._lbl_password.Size = new System.Drawing.Size(61, 13);
            this._lbl_password.TabIndex = 3;
            this._lbl_password.Text = "Contraseña";
            // 
            // _lbl_nombre_usuario
            // 
            this._lbl_nombre_usuario.AutoSize = true;
            this._lbl_nombre_usuario.ForeColor = System.Drawing.SystemColors.WindowText;
            this._lbl_nombre_usuario.Location = new System.Drawing.Point(16, 21);
            this._lbl_nombre_usuario.Name = "_lbl_nombre_usuario";
            this._lbl_nombre_usuario.Size = new System.Drawing.Size(96, 13);
            this._lbl_nombre_usuario.TabIndex = 2;
            this._lbl_nombre_usuario.Text = "Nombre de usuario";
            // 
            // _txt_password
            // 
            this._txt_password.Location = new System.Drawing.Point(133, 44);
            this._txt_password.Name = "_txt_password";
            this._txt_password.PasswordChar = '*';
            this._txt_password.Size = new System.Drawing.Size(220, 20);
            this._txt_password.TabIndex = 1;
            // 
            // _txt_usuario
            // 
            this._txt_usuario.Location = new System.Drawing.Point(133, 18);
            this._txt_usuario.Name = "_txt_usuario";
            this._txt_usuario.Size = new System.Drawing.Size(220, 20);
            this._txt_usuario.TabIndex = 0;
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 139);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(384, 22);
            this.stat_BarraEstado.TabIndex = 25;
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
            // Formulario_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.grp_usuario_y_pass);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Formulario_login";
            this.Text = "Formulario_login";
            this.grp_usuario_y_pass.ResumeLayout(false);
            this.grp_usuario_y_pass.PerformLayout();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.GroupBox grp_usuario_y_pass;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.TextBox _txt_password;
        private System.Windows.Forms.TextBox _txt_usuario;
        private System.Windows.Forms.Label _lbl_password;
        private System.Windows.Forms.Label _lbl_nombre_usuario;
    }
}