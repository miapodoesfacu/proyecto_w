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
using proyecto_w.Generar_Receta;

namespace proyecto_w.Registro_Resultado_Atencion
{
    public partial class Registro_Resultado_Atencion_Form : Form
    {
        public Registro_Resultado_Atencion_Form()
        {
            InitializeComponent();
        }

        private void btnRegistrarResultadoAtencion_Click(object sender, EventArgs e)
        {
            ConexionSQL sqlConexion = ConexionSQL.Instance;
            bool noError = true;
            int Concretado = 0;
            if (checkConcretado.Checked)
                Concretado = 1;
            String queryConcretado =
                string.Format("EXEC PROYECTO_W.SP_TURNO_CONCRETADO {0},'{1}','{2}',{3}",
                    txtTurnoNro.Text, txtSintoma.Text, txtDiagnostico.Text, Concretado);
//@TURNO_NRO NUMERIC(18,0), @SINTOMAS VARCHAR(255), @DIAGNOSTICO VARCHAR(255), @CONCRETADO TINYINT)
            try
            {
                sqlConexion.ejecutarQuery(queryConcretado);
            }
            catch (SqlException ex)
            {
                lblStatus.Text = ex.Message;
                noError = false;
            }

            if (/*noError &*/ checkConReceta.Checked)
            {
                Generar_Receta_Form genReceta = new Generar_Receta_Form(System.UInt32.Parse(txtTurnoNro.Text));
                this.Hide();
                genReceta.ShowDialog();
                this.Show();
            }

            if (noError)
                lblStatus.Text = "Registrado correctamente";
        }

        private void txtTurnoNro_TextChanged(object sender, EventArgs e)
        {
            lblStatus.Text = "Ingresando Datos";
        }
    }
}
