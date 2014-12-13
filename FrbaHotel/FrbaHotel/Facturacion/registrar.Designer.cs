namespace FrbaHotel.Facturacion
{
    partial class registrar
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
            this.button_facturar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.button_pagar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_estadia = new System.Windows.Forms.TextBox();
            this.rb_efectivo = new System.Windows.Forms.RadioButton();
            this.rb_tarjeta = new System.Windows.Forms.RadioButton();
            this.l_t = new System.Windows.Forms.Label();
            this.l_b = new System.Windows.Forms.Label();
            this.txt_banco = new System.Windows.Forms.TextBox();
            this.txt_tarjeta = new System.Windows.Forms.TextBox();
            this.stat_BarraEstado.SuspendLayout();
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
            this.stat_BarraEstado.TabIndex = 29;
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
            // button_facturar
            // 
            this.button_facturar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_facturar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_facturar.Location = new System.Drawing.Point(207, 113);
            this.button_facturar.Name = "button_facturar";
            this.button_facturar.Size = new System.Drawing.Size(143, 45);
            this.button_facturar.TabIndex = 27;
            this.button_facturar.Text = "Facturar";
            this.button_facturar.UseVisualStyleBackColor = true;
            this.button_facturar.Click += new System.EventHandler(this.button_facturar_Click);
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(437, 476);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 28;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            this.button_volver.Click += new System.EventHandler(this.button_volver_Click);
            // 
            // button_pagar
            // 
            this.button_pagar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_pagar.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_pagar.Location = new System.Drawing.Point(172, 373);
            this.button_pagar.Name = "button_pagar";
            this.button_pagar.Size = new System.Drawing.Size(193, 45);
            this.button_pagar.TabIndex = 26;
            this.button_pagar.Text = "Registrar Pago";
            this.button_pagar.UseVisualStyleBackColor = true;
            this.button_pagar.Visible = false;
            this.button_pagar.Click += new System.EventHandler(this.button_pagar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Ingrese una estadía  y presiones el boton factutar";
            // 
            // txt_estadia
            // 
            this.txt_estadia.Location = new System.Drawing.Point(217, 58);
            this.txt_estadia.Name = "txt_estadia";
            this.txt_estadia.Size = new System.Drawing.Size(143, 20);
            this.txt_estadia.TabIndex = 32;
            this.txt_estadia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_estadia_KeyPress);
            // 
            // rb_efectivo
            // 
            this.rb_efectivo.AutoSize = true;
            this.rb_efectivo.Location = new System.Drawing.Point(182, 217);
            this.rb_efectivo.Name = "rb_efectivo";
            this.rb_efectivo.Size = new System.Drawing.Size(64, 17);
            this.rb_efectivo.TabIndex = 33;
            this.rb_efectivo.TabStop = true;
            this.rb_efectivo.Text = "Efectivo";
            this.rb_efectivo.UseVisualStyleBackColor = true;
            this.rb_efectivo.Visible = false;
            // 
            // rb_tarjeta
            // 
            this.rb_tarjeta.AutoSize = true;
            this.rb_tarjeta.Location = new System.Drawing.Point(317, 217);
            this.rb_tarjeta.Name = "rb_tarjeta";
            this.rb_tarjeta.Size = new System.Drawing.Size(58, 17);
            this.rb_tarjeta.TabIndex = 34;
            this.rb_tarjeta.TabStop = true;
            this.rb_tarjeta.Text = "Tarjeta";
            this.rb_tarjeta.UseVisualStyleBackColor = true;
            this.rb_tarjeta.Visible = false;
            this.rb_tarjeta.CheckedChanged += new System.EventHandler(this.rb_tarjeta_CheckedChanged);
            // 
            // l_t
            // 
            this.l_t.AutoSize = true;
            this.l_t.Location = new System.Drawing.Point(337, 290);
            this.l_t.Name = "l_t";
            this.l_t.Size = new System.Drawing.Size(55, 13);
            this.l_t.TabIndex = 35;
            this.l_t.Text = "Nº Tarjeta";
            this.l_t.Visible = false;
            // 
            // l_b
            // 
            this.l_b.AutoSize = true;
            this.l_b.Location = new System.Drawing.Point(337, 255);
            this.l_b.Name = "l_b";
            this.l_b.Size = new System.Drawing.Size(38, 13);
            this.l_b.TabIndex = 36;
            this.l_b.Text = "Banco";
            this.l_b.Visible = false;
            // 
            // txt_banco
            // 
            this.txt_banco.Location = new System.Drawing.Point(411, 252);
            this.txt_banco.Name = "txt_banco";
            this.txt_banco.Size = new System.Drawing.Size(143, 20);
            this.txt_banco.TabIndex = 37;
            this.txt_banco.Visible = false;
            // 
            // txt_tarjeta
            // 
            this.txt_tarjeta.Location = new System.Drawing.Point(411, 283);
            this.txt_tarjeta.Name = "txt_tarjeta";
            this.txt_tarjeta.Size = new System.Drawing.Size(143, 20);
            this.txt_tarjeta.TabIndex = 38;
            this.txt_tarjeta.Visible = false;
            this.txt_tarjeta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_estadia_KeyPress);
            // 
            // registrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.txt_tarjeta);
            this.Controls.Add(this.txt_banco);
            this.Controls.Add(this.l_b);
            this.Controls.Add(this.l_t);
            this.Controls.Add(this.rb_tarjeta);
            this.Controls.Add(this.rb_efectivo);
            this.Controls.Add(this.txt_estadia);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_facturar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.button_pagar);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "registrar";
            this.Text = "registrar";
            this.Load += new System.EventHandler(this.registrar_Load);
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.Button button_facturar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.Button button_pagar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_estadia;
        private System.Windows.Forms.RadioButton rb_efectivo;
        private System.Windows.Forms.RadioButton rb_tarjeta;
        private System.Windows.Forms.Label l_t;
        private System.Windows.Forms.Label l_b;
        private System.Windows.Forms.TextBox txt_banco;
        private System.Windows.Forms.TextBox txt_tarjeta;
    }
}