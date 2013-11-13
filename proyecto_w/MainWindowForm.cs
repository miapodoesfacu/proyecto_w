using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.ABM_Afiliado;
using proyecto_w.ABM_Rol;

namespace proyecto_w
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
        }

        public void setFunctions(List<String> functionList)
        {
            //TODO: Hacer visible los botones en base a las funcionabilidades que tengo en la 
            System.Console.Write(functionList.ToString());
            if (functionList.IndexOf("ABM_AFILIADO") != -1) btnABMAfiliado.Show();
            if (functionList.IndexOf("ABM_ROL") != -1) btnABMRol.Show();
        }

        //private void btnABMAfiliado_Click(object sender, EventArgs e)
        //{
        //    this.Hide();
        //    frmABMAfiliado afiliadoForm = new frmABMAfiliado();
        //    afiliadoForm.ShowDialog();
        //    this.Show();
        //}

        private void btnABMAfiliado_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            frmABMAfiliado afiliadoForm = new frmABMAfiliado();
            afiliadoForm.ShowDialog();
            this.Show();
        }

        private void btnABMRol_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmABMRol rolForm = new frmABMRol();
            rolForm.ShowDialog();
            this.Show();
        }
    }
}
