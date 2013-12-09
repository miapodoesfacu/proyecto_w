using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using System.Data.SqlClient;
using proyecto_w.Login;

namespace proyecto_w.Cancelar_Atencion
{
    public partial class frmCancelarAtencion : Form
    {
        public frmCancelarAtencion()
        {
            InitializeComponent();

            if (frmLogin.user == "profesional")
            {
                cbxCancel_quien.Items.Add("Profesional");
            }
            else if (frmLogin.user == "afiliado")
            {
                cbxCancel_quien.Items.Add("Afiliado");
            }
            else
            {
                cbxCancel_quien.Items.Add("Profesional");
                cbxCancel_quien.Items.Add("Afiliado");
            }
        }

        private void cbxCancel_quien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (cbxCancel_quien.Text == "")
            {
                lblCancel_status.Text = "Debe seleccionar quién cancela";
                return;
            }
            
            ConexionSQL CONEXION = ConexionSQL.Instance;
            if (txtCancel_turno_nro.Text == "")
            {
                MessageBox.Show("No ingreso un numero de turno", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            String quien = "nadie";
            if (cbxCancel_quien.Text == "Profesional")
                quien = "MEDICO";
            if (cbxCancel_quien.Text == "Afiliado")
                quien = "PACIENTE";
            if (quien != "nadie")
            {
                String QUERY = string.Format("EXEC PROYECTO_W.SP_CANCELAR {0},'{1}','{2}'", txtCancel_turno_nro.Text,
                       quien, txtCancel_motivo.Text);
                Boolean queryFail = false;
                try
                {
                    CONEXION.ejecutarQuery(QUERY);
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    queryFail = true;
                }
                if (!queryFail) lblCancel_status.Text = "Atención cancelada";
            }
            else MessageBox.Show("Datos invalidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void txtnroturno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

       
    }
}
