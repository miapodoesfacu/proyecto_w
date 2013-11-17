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
    public partial class AltaAfiliadoForm : Form
    {
        private ConexionSQL connectionSQL = ConexionSQL.Instance;
        public AltaAfiliadoForm()
        {
            InitializeComponent();
           // cargarComboBox("Proyecto_W.Afiliado", "afil_doc_tipo", cbxTipoDoc);
           // cargarComboBox("Proyecto_W.Afiliado", "afil_sexo", cbxSexo);
            cbxTipoDoc.Items.Add("DNI");
            cbxTipoDoc.SelectedIndex = 0;

            cbxSexo.Items.Add("No determinado"); //Null
            cbxSexo.Items.Add("Femenino"); //F
            cbxSexo.Items.Add("Masculino"); //M
            cbxSexo.SelectedIndex = 0;
//            cargarComboBox("Proyecto_W.Afiliado", "afil_estado_civil", cbxEstadoCivil);

            cbxEstadoCivil.Items.Add("No determinado");
            cbxEstadoCivil.Items.Add("Soltero"); //S
            cbxEstadoCivil.Items.Add("Casado"); //Ca
            cbxEstadoCivil.Items.Add("Viudo"); //V
            cbxEstadoCivil.Items.Add("Concubinato"); //Co
            cbxEstadoCivil.Items.Add("Divorsiado"); //D
            cbxEstadoCivil.SelectedIndex = 0;

            string query = string.Format("SELECT plan_descripcion FROM [GD2C2013].[PROYECTO_W].[Plan]");
            DataRowCollection planes = this.connectionSQL.ejecutarQuery(query).Rows;

            foreach (DataRow row in planes) 
                cbxPlanMedico.Items.Add(row["plan_descripcion"]);

            cbxPlanMedico.SelectedIndex = 0;

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

          //if (validarCamposTipos()) return;

          //Hacer el insert del afiliado - HECHO
          //Si el afiliado tiene como estado civil 'casado' o 'en concubinato' mostrar una pantalla
          //de alta. Se deberá crear otro form tanto para conyugues como hijos que sea COPIA EXACTA del form
          // Alta Afiliado pero sin preguntar por conyugue o hijo.
          //Una vez registrado el conyugue, hacer un for por la cantidad de hijos y preguntar
          //por cada uno si lo quiere afiliar, y abrir una pantalla de alta.

            queryAlta = string.Format("INSERT INTO PROYECTO_W.Afiliado (afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_sexo, afil_plan_cod, afil_cant_pers_a_cargo, afil_estado_civil, afil_mail, afil_fecha_nac) VALUES('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', '{10}', '{11}')", nombre, apellido, tipodoc, nrodoc, direccion, telefono, sexo, planmed, cantfamiliares, estadocivil, mail, fechanac);
            connectionSQL.ejecutarQuery(queryAlta);
            MessageBox.Show("Afiliado dado de alta");
            this.Close();

            //verificacion por conyuge
            if (estadocivil.Equals("Ca") || estadocivil.Equals("Co"))
            {
                var win_conyugue = MessageBox.Show("¿Desea afiliar a su conyugue?","Atención", MessageBoxButtons.YesNo);
                if (win_conyugue == DialogResult.No)
                    this.Close();
                else
                {
                    AltaFamiliarForm frm = new AltaFamiliarForm();
                    frm.ShowDialog();
                    this.Close();
                }

            }
            //verificacion por conyuge

            //verificacion por hijo o familiares a cargo
            for (int i = 0; i < Convert.ToInt16(txtCantFamiliares.Text); i++)
            {
                var win_familiar = MessageBox.Show("¿Desea afiliar a otro familiar?", "Atención", MessageBoxButtons.YesNo);
                if (win_familiar == DialogResult.No)
                    this.Close();
                else
                {
                    AltaFamiliarForm frm = new AltaFamiliarForm();
                    frm.ShowDialog();
                    this.Hide();
                }
            }
            //verificacion por hijo o familiares a cargo
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
            string query = string.Format("SELECT DISTINCT {0} FROM {1}", campo, tabla);
            DataTable items = this.connectionSQL.ejecutarQuery(query);
            comboBox.Items.Clear();
            foreach (DataRow fila in items.Rows)
            {
                comboBox.Items.Add(fila[0]);
            }


        }

        private void txtCantFamiliares_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsControl(e.KeyChar) && !Char.IsNumber(e.KeyChar))
                e.Handled = true;
        }

        //private bool validarCamposTipos()
        //{
        //    if txtNombre.GetType()
        //}

    }
}
