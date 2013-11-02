using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proyecto_w.ABM_Afiliado
{
    public partial class AltaAfiliadoForm : Form
    {
        public AltaAfiliadoForm()
        {
            InitializeComponent();
            cbxTipoDoc.Items.Add("DNI");
            cbxSexo.Items.Add("Femenino");
            cbxSexo.Items.Add("Masculino");
            cbxEstadoCivil.Items.Add("Soltero/a");
            cbxEstadoCivil.Items.Add("Casado/a");
            cbxEstadoCivil.Items.Add("Viudo/a");
            cbxEstadoCivil.Items.Add("Concubinato");
            cbxEstadoCivil.Items.Add("Divorciado/a");
        }
    }
}
