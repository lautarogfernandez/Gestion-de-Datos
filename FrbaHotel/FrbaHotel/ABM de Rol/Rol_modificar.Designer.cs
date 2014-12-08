namespace FrbaHotel.ABM_de_Rol
{
    partial class Rol_modificar
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
            this.rb_activo = new System.Windows.Forms.RadioButton();
            this.rb_inactivo = new System.Windows.Forms.RadioButton();
            this.lbl_atributo = new System.Windows.Forms.Label();
            this.lbl_funciones = new System.Windows.Forms.Label();
            this.lbl_nombre = new System.Windows.Forms.Label();
            this.lbl_modificado = new System.Windows.Forms.Label();
            this.button_modificar = new System.Windows.Forms.Button();
            this.button_volver = new System.Windows.Forms.Button();
            this.txt_nombre = new System.Windows.Forms.TextBox();
            this.lbl_original = new System.Windows.Forms.Label();
            this.chk_todos = new System.Windows.Forms.CheckBox();
            this.chk_telefono = new System.Windows.Forms.CheckBox();
            this.chk_tipos_regimenes = new System.Windows.Forms.CheckBox();
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
            this.stat_BarraEstado.TabIndex = 244;
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
            this.list_funciones.Location = new System.Drawing.Point(345, 99);
            this.list_funciones.Name = "list_funciones";
            this.list_funciones.Size = new System.Drawing.Size(205, 259);
            this.list_funciones.TabIndex = 233;
            // 
            // grp_activo
            // 
            this.grp_activo.Controls.Add(this.lbl_inactivo);
            this.grp_activo.Controls.Add(this.chk_telefono);
            this.grp_activo.Controls.Add(this.lbl_activo);
            this.grp_activo.Controls.Add(this.rb_activo);
            this.grp_activo.Controls.Add(this.rb_inactivo);
            this.grp_activo.Location = new System.Drawing.Point(13, 363);
            this.grp_activo.Name = "grp_activo";
            this.grp_activo.Size = new System.Drawing.Size(560, 82);
            this.grp_activo.TabIndex = 243;
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
            // lbl_atributo
            // 
            this.lbl_atributo.AutoSize = true;
            this.lbl_atributo.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_atributo.Location = new System.Drawing.Point(7, 4);
            this.lbl_atributo.Name = "lbl_atributo";
            this.lbl_atributo.Size = new System.Drawing.Size(108, 31);
            this.lbl_atributo.TabIndex = 240;
            this.lbl_atributo.Text = "Atributo";
            // 
            // lbl_funciones
            // 
            this.lbl_funciones.AutoSize = true;
            this.lbl_funciones.Location = new System.Drawing.Point(12, 99);
            this.lbl_funciones.Name = "lbl_funciones";
            this.lbl_funciones.Size = new System.Drawing.Size(103, 13);
            this.lbl_funciones.TabIndex = 239;
            this.lbl_funciones.Text = "Finciones asignadas";
            // 
            // lbl_nombre
            // 
            this.lbl_nombre.AutoSize = true;
            this.lbl_nombre.Location = new System.Drawing.Point(10, 61);
            this.lbl_nombre.Name = "lbl_nombre";
            this.lbl_nombre.Size = new System.Drawing.Size(44, 13);
            this.lbl_nombre.TabIndex = 238;
            this.lbl_nombre.Text = "Nombre";
            // 
            // lbl_modificado
            // 
            this.lbl_modificado.AutoSize = true;
            this.lbl_modificado.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_modificado.Location = new System.Drawing.Point(339, 4);
            this.lbl_modificado.Name = "lbl_modificado";
            this.lbl_modificado.Size = new System.Drawing.Size(77, 31);
            this.lbl_modificado.TabIndex = 237;
            this.lbl_modificado.Text = "Valor";
            // 
            // button_modificar
            // 
            this.button_modificar.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_modificar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.button_modificar.Location = new System.Drawing.Point(13, 462);
            this.button_modificar.Name = "button_modificar";
            this.button_modificar.Size = new System.Drawing.Size(135, 45);
            this.button_modificar.TabIndex = 235;
            this.button_modificar.Text = "Modificar";
            this.button_modificar.UseVisualStyleBackColor = true;
            // 
            // button_volver
            // 
            this.button_volver.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_volver.ForeColor = System.Drawing.SystemColors.MenuText;
            this.button_volver.Location = new System.Drawing.Point(438, 462);
            this.button_volver.Name = "button_volver";
            this.button_volver.Size = new System.Drawing.Size(135, 45);
            this.button_volver.TabIndex = 236;
            this.button_volver.Text = "Volver";
            this.button_volver.UseVisualStyleBackColor = true;
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(345, 63);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(205, 20);
            this.txt_nombre.TabIndex = 234;
            // 
            // lbl_original
            // 
            this.lbl_original.AutoSize = true;
            this.lbl_original.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_original.Location = new System.Drawing.Point(181, 4);
            this.lbl_original.Name = "lbl_original";
            this.lbl_original.Size = new System.Drawing.Size(107, 31);
            this.lbl_original.TabIndex = 245;
            this.lbl_original.Text = "Original";
            // 
            // chk_todos
            // 
            this.chk_todos.AutoSize = true;
            this.chk_todos.Location = new System.Drawing.Point(558, 66);
            this.chk_todos.Name = "chk_todos";
            this.chk_todos.Size = new System.Drawing.Size(15, 14);
            this.chk_todos.TabIndex = 248;
            this.chk_todos.UseVisualStyleBackColor = true;
            // 
            // chk_telefono
            // 
            this.chk_telefono.AutoSize = true;
            this.chk_telefono.Location = new System.Drawing.Point(121, 0);
            this.chk_telefono.Name = "chk_telefono";
            this.chk_telefono.Size = new System.Drawing.Size(15, 14);
            this.chk_telefono.TabIndex = 247;
            this.chk_telefono.UseVisualStyleBackColor = true;
            // 
            // chk_tipos_regimenes
            // 
            this.chk_tipos_regimenes.AutoSize = true;
            this.chk_tipos_regimenes.Location = new System.Drawing.Point(558, 101);
            this.chk_tipos_regimenes.Name = "chk_tipos_regimenes";
            this.chk_tipos_regimenes.Size = new System.Drawing.Size(15, 14);
            this.chk_tipos_regimenes.TabIndex = 246;
            this.chk_tipos_regimenes.UseVisualStyleBackColor = true;
            // 
            // Rol_modificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.chk_todos);
            this.Controls.Add(this.chk_tipos_regimenes);
            this.Controls.Add(this.lbl_original);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.list_funciones);
            this.Controls.Add(this.grp_activo);
            this.Controls.Add(this.lbl_atributo);
            this.Controls.Add(this.lbl_funciones);
            this.Controls.Add(this.lbl_nombre);
            this.Controls.Add(this.lbl_modificado);
            this.Controls.Add(this.button_modificar);
            this.Controls.Add(this.button_volver);
            this.Controls.Add(this.txt_nombre);
            this.MaximumSize = new System.Drawing.Size(600, 600);
            this.MinimumSize = new System.Drawing.Size(600, 600);
            this.Name = "Rol_modificar";
            this.Text = "Rol_modificar";
            this.Load += new System.EventHandler(this.Rol_modificar_Load);
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
        private System.Windows.Forms.Label lbl_inactivo;
        private System.Windows.Forms.Label lbl_activo;
        private System.Windows.Forms.RadioButton rb_activo;
        private System.Windows.Forms.RadioButton rb_inactivo;
        private System.Windows.Forms.Label lbl_atributo;
        private System.Windows.Forms.Label lbl_funciones;
        private System.Windows.Forms.Label lbl_nombre;
        private System.Windows.Forms.Label lbl_modificado;
        private System.Windows.Forms.Button button_modificar;
        private System.Windows.Forms.Button button_volver;
        private System.Windows.Forms.TextBox txt_nombre;
        private System.Windows.Forms.Label lbl_original;
        private System.Windows.Forms.CheckBox chk_telefono;
        private System.Windows.Forms.CheckBox chk_todos;
        private System.Windows.Forms.CheckBox chk_tipos_regimenes;
    }
}