namespace FrbaHotel
{
    partial class MenuPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.button_mostrar_hoteles = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.combo_objeto = new System.Windows.Forms.ToolStripComboBox();
            this.combo_operacion = new System.Windows.Forms.ToolStripComboBox();
            this.lbl_bienvenido = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.button_logout = new System.Windows.Forms.Button();
            this.button_ir = new System.Windows.Forms.Button();
            this.imagenHotel = new System.Windows.Forms.PictureBox();
            this.dgv_hoteles = new System.Windows.Forms.DataGridView();
            this.barra_progreso = new System.Windows.Forms.ToolStripProgressBar();
            this.label_progreso = new System.Windows.Forms.ToolStripStatusLabel();
            this.stat_BarraEstado = new System.Windows.Forms.StatusStrip();
            this.lbl_usuario = new System.Windows.Forms.Label();
            this.grp_formularios = new System.Windows.Forms.GroupBox();
            this.dgv_roles = new System.Windows.Forms.DataGridView();
            this.button_cambiar_pass = new System.Windows.Forms.Button();
            this.lbl_fecha = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenHotel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoteles)).BeginInit();
            this.stat_BarraEstado.SuspendLayout();
            this.grp_formularios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).BeginInit();
            this.SuspendLayout();
            // 
            // button_mostrar_hoteles
            // 
            this.button_mostrar_hoteles.Location = new System.Drawing.Point(12, 60);
            this.button_mostrar_hoteles.Name = "button_mostrar_hoteles";
            this.button_mostrar_hoteles.Size = new System.Drawing.Size(127, 57);
            this.button_mostrar_hoteles.TabIndex = 0;
            this.button_mostrar_hoteles.Text = "Mostrar Hoteles";
            this.button_mostrar_hoteles.UseVisualStyleBackColor = true;
            this.button_mostrar_hoteles.Click += new System.EventHandler(this.button_mostrar_hoteles_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.combo_objeto,
            this.combo_operacion});
            this.menuStrip1.Location = new System.Drawing.Point(12, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(273, 27);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // combo_objeto
            // 
            this.combo_objeto.Name = "combo_objeto";
            this.combo_objeto.Size = new System.Drawing.Size(121, 23);
            this.combo_objeto.Text = "Seleccione Objeto";
            this.combo_objeto.SelectedIndexChanged += new System.EventHandler(this.combo_objeto_SelectedIndexChanged);
            // 
            // combo_operacion
            // 
            this.combo_operacion.Name = "combo_operacion";
            this.combo_operacion.Size = new System.Drawing.Size(140, 23);
            this.combo_operacion.Text = "Seleccione Operacion";
            this.combo_operacion.SelectedIndexChanged += new System.EventHandler(this.combo_operacion_SelectedIndexChanged);
            // 
            // lbl_bienvenido
            // 
            this.lbl_bienvenido.AutoSize = true;
            this.lbl_bienvenido.Location = new System.Drawing.Point(403, 9);
            this.lbl_bienvenido.Name = "lbl_bienvenido";
            this.lbl_bienvenido.Size = new System.Drawing.Size(60, 13);
            this.lbl_bienvenido.TabIndex = 6;
            this.lbl_bienvenido.Text = "Bienvenido";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(406, 29);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(80, 25);
            this.button_login.TabIndex = 7;
            this.button_login.Text = "Loguearse";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_logout
            // 
            this.button_logout.Location = new System.Drawing.Point(492, 29);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(80, 25);
            this.button_logout.TabIndex = 8;
            this.button_logout.Text = "Desloguearse";
            this.button_logout.UseVisualStyleBackColor = true;
            this.button_logout.Visible = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // button_ir
            // 
            this.button_ir.Location = new System.Drawing.Point(279, 18);
            this.button_ir.Name = "button_ir";
            this.button_ir.Size = new System.Drawing.Size(40, 20);
            this.button_ir.TabIndex = 9;
            this.button_ir.Text = "IR";
            this.button_ir.UseVisualStyleBackColor = true;
            this.button_ir.Click += new System.EventHandler(this.button_ir_Click);
            // 
            // imagenHotel
            // 
            this.imagenHotel.Image = global::FrbaHotel.Properties.Resources.imagenHotel;
            this.imagenHotel.InitialImage = ((System.Drawing.Image)(resources.GetObject("imagenHotel.InitialImage")));
            this.imagenHotel.Location = new System.Drawing.Point(249, 80);
            this.imagenHotel.Name = "imagenHotel";
            this.imagenHotel.Size = new System.Drawing.Size(335, 356);
            this.imagenHotel.TabIndex = 10;
            this.imagenHotel.TabStop = false;
            // 
            // dgv_hoteles
            // 
            this.dgv_hoteles.AllowUserToAddRows = false;
            this.dgv_hoteles.AllowUserToDeleteRows = false;
            this.dgv_hoteles.AllowUserToOrderColumns = true;
            this.dgv_hoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoteles.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dgv_hoteles.Location = new System.Drawing.Point(13, 124);
            this.dgv_hoteles.MultiSelect = false;
            this.dgv_hoteles.Name = "dgv_hoteles";
            this.dgv_hoteles.ReadOnly = true;
            this.dgv_hoteles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_hoteles.Size = new System.Drawing.Size(230, 312);
            this.dgv_hoteles.TabIndex = 11;
            this.dgv_hoteles.MouseHover += new System.EventHandler(this.dgv_hoteles_MouseHover);
            this.dgv_hoteles.MouseLeave += new System.EventHandler(this.dgv_hoteles_MouseLeave);
            this.dgv_hoteles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_hoteles_CellContentClick);
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
            this.label_progreso,
            this.lbl_fecha});
            this.stat_BarraEstado.Location = new System.Drawing.Point(0, 439);
            this.stat_BarraEstado.Name = "stat_BarraEstado";
            this.stat_BarraEstado.Size = new System.Drawing.Size(584, 22);
            this.stat_BarraEstado.TabIndex = 3;
            this.stat_BarraEstado.Text = "Estado";
            // 
            // lbl_usuario
            // 
            this.lbl_usuario.AutoSize = true;
            this.lbl_usuario.Location = new System.Drawing.Point(470, 9);
            this.lbl_usuario.Name = "lbl_usuario";
            this.lbl_usuario.Size = new System.Drawing.Size(33, 13);
            this.lbl_usuario.TabIndex = 12;
            this.lbl_usuario.Text = "guest";
            // 
            // grp_formularios
            // 
            this.grp_formularios.Controls.Add(this.button_ir);
            this.grp_formularios.Location = new System.Drawing.Point(13, 9);
            this.grp_formularios.Name = "grp_formularios";
            this.grp_formularios.Size = new System.Drawing.Size(330, 45);
            this.grp_formularios.TabIndex = 13;
            this.grp_formularios.TabStop = false;
            this.grp_formularios.Text = "Formularios Disponibles";
            // 
            // dgv_roles
            // 
            this.dgv_roles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_roles.Location = new System.Drawing.Point(13, 311);
            this.dgv_roles.Name = "dgv_roles";
            this.dgv_roles.Size = new System.Drawing.Size(230, 125);
            this.dgv_roles.TabIndex = 14;
            this.dgv_roles.Visible = false;
            this.dgv_roles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_roles_CellContentClick);
            // 
            // button_cambiar_pass
            // 
            this.button_cambiar_pass.Location = new System.Drawing.Point(349, 29);
            this.button_cambiar_pass.Name = "button_cambiar_pass";
            this.button_cambiar_pass.Size = new System.Drawing.Size(137, 25);
            this.button_cambiar_pass.TabIndex = 15;
            this.button_cambiar_pass.Text = "Cambiar Contraseña";
            this.button_cambiar_pass.UseVisualStyleBackColor = true;
            this.button_cambiar_pass.Visible = false;
            this.button_cambiar_pass.Click += new System.EventHandler(this.button_cambiar_pass_Click);
            // 
            // lbl_fecha
            // 
            this.lbl_fecha.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lbl_fecha.Name = "lbl_fecha";
            this.lbl_fecha.Size = new System.Drawing.Size(38, 17);
            this.lbl_fecha.Text = "Fecha";
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 461);
            this.Controls.Add(this.button_cambiar_pass);
            this.Controls.Add(this.dgv_roles);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grp_formularios);
            this.Controls.Add(this.lbl_usuario);
            this.Controls.Add(this.dgv_hoteles);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.lbl_bienvenido);
            this.Controls.Add(this.stat_BarraEstado);
            this.Controls.Add(this.button_mostrar_hoteles);
            this.Controls.Add(this.imagenHotel);
            this.MaximumSize = new System.Drawing.Size(600, 500);
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imagenHotel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoteles)).EndInit();
            this.stat_BarraEstado.ResumeLayout(false);
            this.stat_BarraEstado.PerformLayout();
            this.grp_formularios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_roles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_mostrar_hoteles;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox combo_operacion;
        private System.Windows.Forms.ToolStripComboBox combo_objeto;
        private System.Windows.Forms.Label lbl_bienvenido;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.Button button_ir;
        private System.Windows.Forms.PictureBox imagenHotel;
        private System.Windows.Forms.DataGridView dgv_hoteles;
        private System.Windows.Forms.ToolStripProgressBar barra_progreso;
        private System.Windows.Forms.ToolStripStatusLabel label_progreso;
        private System.Windows.Forms.StatusStrip stat_BarraEstado;
        private System.Windows.Forms.Label lbl_usuario;
        private System.Windows.Forms.GroupBox grp_formularios;
        private System.Windows.Forms.DataGridView dgv_roles;
        private System.Windows.Forms.Button button_cambiar_pass;
        private System.Windows.Forms.ToolStripStatusLabel lbl_fecha;
    }
}