namespace FrbaHotel.ABM_de_Hotel
{
    partial class Recarga_Estrella
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
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.lbl_recarga = new System.Windows.Forms.Label();
            this.lbl_fecha = new System.Windows.Forms.Label();
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.button_aceptar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.txt_recarga = new System.Windows.Forms.TextBox();
            this.dtp_fecha = new System.Windows.Forms.DateTimePicker();
            this.stat_BarraEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // stat_BarraEstado
            // 
            this.stat_BarraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.barra_progreso,
            this.label_progreso});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 540);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 211;
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
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(33, 75);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 210;
            this.lbl_atributo.Text = "Atributo";
            // 
            // lbl_recarga
            // 
            this.lbl_recarga.AutoSize = true;
            this.lbl_recarga.Location = new System.Drawing.Point(43, 171);
            this.lbl_recarga.Name = "lbl_recarga";
            this.lbl_recarga.Size = new System.Drawing.Size(48, 13);
            this.lbl_recarga.TabIndex = 209;
            this.lbl_recarga.Text = "Recarga";
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.AutoSize = true;
            this.lbl_fecha.Location = new System.Drawing.Point(43, 139);
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(37, 13);
            this.lbl_fecha.TabIndex = 208;
            this.lbl_fecha.Text = "Fecha";
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(224, 75);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(77, 31);
            this.lbl_modificado.TabIndex = 207;
            this.lbl_modificado.Text = "Valor";
            this.lbl_modificado.Click += new System.EventHandler(this.lbl_modificado_Click);
            // 
            // button_aceptar
            // 
            this.button_aceptar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_aceptar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_aceptar.Location = new System.Drawing.Point(12, 245);
            this.button_aceptar.Name = "button_aceptar";
            this.button_aceptar.Size = new System.Drawing.Size(135, 45);
            this.button_aceptar.TabIndex = 205;
            this.button_aceptar.Text = "Aceptar";
            this.button_aceptar.UseVisualStyleBackColor = true;
            this.button_aceptar.Click += new System.EventHandler(this.button_aceptar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 245);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 206;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // txt_recarga
            // 
            this.txt_recarga.Location = new System.Drawing.Point(230, 168);
            this.txt_recarga.Name = "txt_recarga";
            this.txt_recarga.Size = new System.Drawing.Size(207, 20);
            this.txt_recarga.TabIndex = 204;
            this.txt_recarga.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_recarga_KeyPress);
            // 
            // dtp_fecha
            // 
            this.dtp_fecha.Location = new System.Drawing.Point(230, 132);
            this.dtp_fecha.Name = "dtp_fecha";
            this.dtp_fecha.Size = new System.Drawing.Size(207, 20);
            this.dtp_fecha.TabIndex = 212;
            // 
            // Recarga_Estrella
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 562);
            this.Controls.Add(this.dtp_fecha);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.lbl_recarga);
            this.Controls.Add(this.lbl_fecha);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.button_aceptar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.txt_recarga);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Recarga_Estrella";
            this.Text = "Recarga_Estrella";
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.Label lbl_recarga;
        private System.Windows.Forms.Label lbl_fecha;
        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.Button button_aceptar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.TextBox txt_recarga;
        private System.Windows.Forms.DateTimePicker dtp_fecha;
    }
}