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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (validarCamposVacios()) return;
        }

        private bool validarCamposVacios()
        {
            if (txtNombre.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar nombre.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNombre.Focus();
                return true;
            }
            if (txtApellido.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar apellido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtApellido.Focus();
                return true;
            }
            if (cbxTipoDoc.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar tipo de documento.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxTipoDoc.Focus();
                return true;
            }
            if (txtDireccion.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar dirección.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDireccion.Focus();
                return true;
            }
            if (txtTelefono.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar telefono.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTelefono.Focus();
                return true;
            }
            if (txtMail.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar mail.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtMail.Focus();
                return true;
            }
            if (cbxSexo.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar sexo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxSexo.Focus();
                return true;
            }
            if (cbxEstadoCivil.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar estado civil.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxEstadoCivil.Focus();
                return true;
            }
            if (txtCantFamiliares.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar cantidad de hijos o familiares a cargo.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtCantFamiliares.Focus();
                return true;
            }
            if (cbxPlanMedico.Text.Trim() == "")
            {
                MessageBox.Show("Ingresar plan medico.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cbxPlanMedico.Focus();
                return true;
            }

            return false;
        }

        private bool validarCamposTipos()
        {
            if txtNombre.GetType(
        }

    }
}
