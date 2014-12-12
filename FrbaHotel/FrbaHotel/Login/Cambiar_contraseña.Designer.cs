namespace FrbaHotel.Login
{
    partial class Cambiar_contraseña
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
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.txt_pass = new System.Windows.Forms.TextBox();
            this.lbl_pass = new System.Windows.Forms.Label();
            this.lbl_repetir_pass = new System.Windows.Forms.Label();
            this.txt_repetir_pass = new System.Windows.Forms.TextBox();
            this.lbl_4omas = new System.Windows.Forms.Label();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_aceptar
            // 
            this.button_aceptar.Enabled = false;
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.button_aceptar.Location = new System.Drawing.Point(13, 91);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 26;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(237, 91);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 27;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
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
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 139);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(384, 22);
            this.stat_BarraEstado.TabIndex = 29;
            this.stat_BarraEstado.Text = "Estado";
            // 
            // txt_pass
            // 
            this.txt_pass.Location = new System.Drawing.Point(141, 28);
            this.txt_pass.Name = "txt_pass";
            this.txt_pass.PasswordChar = '*';
            this.txt_pass.Size = new System.Drawing.Size(220, 20);
            this.txt_pass.TabIndex = 4;
            this.txt_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            // 
            // lbl_pass
            // 
            this.lbl_pass.AutoSize = true;
            this.lbl_pass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbl_pass.Location = new System.Drawing.Point(25, 31);
            this.lbl_pass.Name = "lbl_pass";
            this.lbl_pass.Size = new System.Drawing.Size(96, 13);
            this.lbl_pass.TabIndex = 5;
            this.lbl_pass.Text = "Contraseña Nueva";
            // 
            // lbl_repetir_pass
            // 
            this.lbl_repetir_pass.AutoSize = true;
            this.lbl_repetir_pass.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lbl_repetir_pass.Location = new System.Drawing.Point(25, 68);
            this.lbl_repetir_pass.Name = "lbl_repetir_pass";
            this.lbl_repetir_pass.Size = new System.Drawing.Size(97, 13);
            this.lbl_repetir_pass.TabIndex = 31;
            this.lbl_repetir_pass.Text = "Repetir contraseña";
            // 
            // txt_repetir_pass
            // 
            this.txt_repetir_pass.Location = new System.Drawing.Point(141, 65);
            this.txt_repetir_pass.Name = "txt_repetir_pass";
            this.txt_repetir_pass.PasswordChar = '*';
            this.txt_repetir_pass.Size = new System.Drawing.Size(220, 20);
            this.txt_repetir_pass.TabIndex = 30;
            this.txt_repetir_pass.TextChanged += new System.EventHandler(this.txt_pass_TextChanged);
            // 
            // lbl_4omas
            // 
            this.lbl_4omas.AutoSize = true;
            this.lbl_4omas.Location = new System.Drawing.Point(12, 9);
            this.lbl_4omas.Name = "lbl_4omas";
            this.lbl_4omas.Size = new System.Drawing.Size(241, 13);
            this.lbl_4omas.TabIndex = 32;
            this.lbl_4omas.Text = "Ingrese la contraseña nueva (4 o más caracteres)";
            // 
            // Cambiar_contraseña
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.lbl_4omas);
            this.Controls.Add(this.lbl_repetir_pass);
            this.Controls.Add(this.txt_repetir_pass);
            this.Controls.Add(this.lbl_pass);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.txt_pass);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.MaximumSize = new System.Drawing.Size(400, 200);
            this.MinimumSize = new System.Drawing.Size(400, 200);
            this.Name = "Cambiar_contraseña";
            this.Text = "Cambiar_contraseña";
            this.Load += new System.EventHandler(this.Cambiar_contraseña_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.TextBox txt_pass;
        private System.Windows.Forms.Label lbl_pass;
        private System.Windows.Forms.Label lbl_repetir_pass;
        private System.Windows.Forms.TextBox txt_repetir_pass;
        private System.Windows.Forms.Label lbl_4omas;
    }
}