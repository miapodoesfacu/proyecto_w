using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w
{
    public partial class frmLogin : Form
    {

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string queryLogin = string.Format("SELECT * FROM Usuario WHERE Username='{0}' AND Password='{1}'",username,password);
            DataTable table = connectionSQL.ejecutarQuery(queryLogin);
            if (table.Rows.Count == 1)
            {
                /*TODO: Debo cargar el formulario que elije el rol en caso de tener mas de un rol*/
                //MessageBox.Show(table.Rows[0][0].ToString());
            }
            else
            {
                MessageBox.Show("Credenciales Incorrectas. Porfavor intene nuevamente");
                txtUsername.Text = "";
            }
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrEmpty(txtUsername.Text) & !string.IsNullOrEmpty(txtPassword.Text);
            txtPassword.Enabled = !string.IsNullOrEmpty(txtUsername.Text);
            if (!txtPassword.Enabled) txtPassword.Text = "";
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            btnLogin.Enabled = !string.IsNullOrEmpty(txtPassword.Text);
        }

    }
}
