using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using proyecto_w.Login;
using proyecto_w.ABM_Afiliado;

namespace proyecto_w.ABM_Afiliado
{
    public partial class AltaFamiliarForm : Form
    {
        public AltaFamiliarForm()
        {
            InitializeComponent();
            cargarComboBox("Proyecto_W.Afiliado", "afil_doc_tipo", cbxTipoDoc);
            cbxTipoDoc.Items.Add("DNI");
            cargarComboBox("Proyecto_W.Afiliado", "afil_sexo", cbxSexo);
            cbxSexo.Items.Add("F");
            cbxSexo.Items.Add("M");
            cargarComboBox("Proyecto_W.Afiliado", "afil_estado_civil", cbxEstadoCivil);
            cbxEstadoCivil.Items.Add("S");
            cbxEstadoCivil.Items.Add("Ca");
            cbxEstadoCivil.Items.Add("V");
            cbxEstadoCivil.Items.Add("Co");
            cbxEstadoCivil.Items.Add("D");
            cargarComboBox("Proyecto_W.Afiliado", "afil_plan_cod", cbxPlanMedico);
            cbxPlanMedico.Items.Add(555555);

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string queryAlta;
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            /* Begin - Declaracion de variables para cada campo en el form Alta */
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string tipodoc = cbxTipoDoc.Text;
            string nrodoc = txtNroDoc.Text;
            string direccion = txtDireccion.Text;
            string telefono = txtTelefono.Text;
            string mail = txtMail.Text;
            string fechanac = dtmFechaNac.Text;
            string sexo = cbxSexo.Text;
            string estadocivil = cbxEstadoCivil.Text;
            string cantfamiliares = txtCantFamiliares.Text;
            string planmed = cbxPlanMedico.Text;
            /* End - Declaracion de variables para cada campo en el form Alta */

            if (validarCamposVacios()) return;

            queryAlta = string.Format("INSERT INTO PROYECTO_W.Afiliado (afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_sexo, afil_plan_cod, afil_cant_pers_a_cargo, afil_estado_civil, afil_mail, afil_fecha_nac) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", nombre, apellido, tipodoc, nrodoc, direccion, telefono, sexo, planmed, cantfamiliares, estadocivil, mail, fechanac);
            connectionSQL.ejecutarQuery(queryAlta);
            MessageBox.Show("Afiliado dado de alta");
            this.Close();


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

        public void cargarComboBox(string tabla, string campo, ComboBox comboBox)
        {
            ConexionSQL connectionSQL = ConexionSQL.Instance;

            string query = "SELECT DISTINCT ";
            query += campo;
            query += " FROM ";
            query += tabla;
            DataTable items = connectionSQL.ejecutarQuery(query);
            comboBox.Items.Clear();
            foreach (DataRow fila in items.Rows)
            {
                comboBox.Items.Add(fila[0]);
            }


        }

    }
}
