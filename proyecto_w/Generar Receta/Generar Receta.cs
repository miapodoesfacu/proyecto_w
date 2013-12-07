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
using System.Text.RegularExpressions;

namespace proyecto_w.Generar_Receta
{
    public partial class Generar_Receta_Form : Form
    {
        public uint turno_nro;
        public Generar_Receta_Form(uint nro_turno)
        {
            InitializeComponent();
            turno_nro = nro_turno;
        }

        private void Generar_Receta_Load(object sender, EventArgs e)
        {
            ConexionSQL sqlConn = ConexionSQL.Instance;
            String queryMedicamentosCBX = 
                string.Format("SELECT DISTINCT medicamento_nombre FROM PROYECTO_W.Medicamento");
            DataTable Meds = sqlConn.ejecutarQuery(queryMedicamentosCBX);
            uint medCount = 0;
            while (medCount < Meds.Rows.Count)
            {
                cbxMed1.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed2.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed3.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed4.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                cbxMed5.Items.Add(Meds.Rows[(int)medCount][0].ToString());
                medCount = medCount + 1;
            }
            

            

        }

        private void txtCant1_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant1.Text, @"^\d+$")) { txtCant1.Text = String.Empty; }
        }

        private void txtCant2_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant2.Text, @"^\d+$")) { txtCant2.Text = String.Empty; }
        }

        private void txtCant3_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant3.Text, @"^\d+$")) { txtCant3.Text = String.Empty; }
        }

        private void txtCant4_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant4.Text, @"^\d+$")) { txtCant4.Text = String.Empty; }
        }

        private void txtCant5_TextChanged(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtCant5.Text, @"^\d+$")) { txtCant5.Text = String.Empty; }
        }
    }
}
