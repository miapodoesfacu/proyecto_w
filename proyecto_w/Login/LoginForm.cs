using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using proyecto_w.Login;

namespace proyecto_w
{
    public partial class frmLogin : Form
    {
        private String rolSelected;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string queryLogin, querySQL;
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            queryLogin = string.Format("SELECT UsuarioID, Username, Password FROM Usuario WHERE Username='{0}' AND Password='{1}'", username, password);
            DataTable users = connectionSQL.ejecutarQuery(queryLogin);
            if (users.Rows.Count == 1)
            {
                queryLogin = string.Format("SELECT R.RolID, R.Nombre FROM Rol AS R, UsuarioRol AS UR WHERE UR.UsuarioID={0} AND UR.RolID=R.RolID", users.Rows[0][0]);
                DataTable rols = connectionSQL.ejecutarQuery(queryLogin);
                /*TODO: Debo cargar el formulario que elije el rol en caso de tener mas de un rol*/
                this.Hide();
                if (rols.Rows.Count > 1)
                {
                    List<String> rols_strings = new List<string>();

                    for (int i = 0; i < rols.Rows.Count; i++)
                    {
                        rols_strings.Add(rols.Rows[i]["nombre"].ToString());
                    }
                    frmRols rolsForm = new frmRols();
                    rolsForm.setRoles(rols_strings);
                    rolsForm.ShowDialog();
                    this.rolSelected = rolsForm.rolSelected;
                }
                else
                {
                    this.rolSelected = rols.Rows[0]["Nombre"].ToString();
                }
                querySQL = string.Format("SELECT F.Nombre FROM Funcionabilidad AS F JOIN RolFuncionabilidad AS RF ON RF.FuncionabilidadID=F.FuncionabilidadID JOIN Rol AS R ON R.RolID=RF.RolID WHERE R.Nombre='{0}'", rolSelected);
                DataTable functions = connectionSQL.ejecutarQuery(querySQL);

                List<String> functionsStrings = new List<string>();
                for (int i = 0; i < functions.Rows.Count; i++)
                {
                    functionsStrings.Add(functions.Rows[i]["Nombre"].ToString());
                }

                MainWindowForm mainWindow = new MainWindowForm();
                mainWindow.setFunctions(functionsStrings);
                mainWindow.Show();
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
