using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaHotel.Login
{
    public partial class Formulario_login : Form
    {
        public Formulario_login()
        {
            InitializeComponent();
        }

        private void grp_usuario_y_pass_Enter(object sender, EventArgs e)
        {

        }

        private void button_volver_Click(object sender, EventArgs e)
        {
            MenuPrincipal menuPrincipal = new MenuPrincipal();
            menuPrincipal.Show();
            this.Hide();
        }
    }
}
