﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proyecto_w.ABM_Afiliado
{
    public partial class frmABMAfiliado : Form
    {
        public frmABMAfiliado()
        {
            InitializeComponent();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaAfiliadoForm frm = new AltaAfiliadoForm();
            frm.ShowDialog();
        }

    }
}
