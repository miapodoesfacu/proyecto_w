using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proyecto_w.ABM_Profesional
{
    public partial class frmABMProfesional : Form
    {
        public frmABMProfesional()
        {
            InitializeComponent();
        }

        private void grdConsulta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            this.txtFiltro.Text = "hola";
        }
    }
}
