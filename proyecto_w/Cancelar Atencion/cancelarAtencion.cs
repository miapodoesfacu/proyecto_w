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

namespace proyecto_w.Cancelar_Atencion
{
    public partial class frmCancelarAtencion : Form
    {
        public frmCancelarAtencion()
        {
            InitializeComponent();
            cbxCancel_quien.Items.Add("Profesional");
            cbxCancel_quien.Items.Add("Afiliado");
        }

        private void cbxCancel_quien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2010,9,9); //Fecha del sys

            ConexionSQL CONEXION = ConexionSQL.Instance;

            String quien = "nadie";
            if (cbxCancel_quien.Text == "Profesional")
                quien = "MEDICO";
            if (cbxCancel_quien.Text == "Afiliado")
                quien = "PACIENTE";
            if (quien != "nadie")
            {
                String QUERY = string.Format("EXEC PROYECTO_W.SP_CANCELAR {0},'{1}','{2}','1990-25-12'", txtCancel_turno_nro.Text,
                       quien, txtCancel_motivo.Text);
                Boolean queryFail = false;
                try
                {
                    CONEXION.ejecutarQuery(QUERY);
                }
                catch (SqlException ex)
                {
                    lblCancel_status.Text = ex.Message;
                    queryFail = true;
                }
                if (!queryFail) lblCancel_status.Text = "Atención cancelada";
            }
            else lblCancel_status.Text = "Datos invalidos";
        }

       
    }
}
