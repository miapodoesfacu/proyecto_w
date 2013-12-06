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


namespace proyecto_w.Registrar_Agenda
{
    public partial class frmRegistrarAgenda : Form
    {
        public frmRegistrarAgenda()
        {
            InitializeComponent();

        }
/* CREATE PROCEDURE PROYECTO_W.SP_REGISTRAR_AGENDA
@PROF_DNI NUMERIC(18,0), @DIA_CHECK VARCHAR(255), @DESDE DATE, @HASTA DATE,
	@HORA_INI TIME, @HORA_FIN TIME */

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ConexionSQL sqlConexion = ConexionSQL.Instance;
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = 
                "EXEC PROYECTO_W.SP_REGISTRAR_AGENDA @PROF_DNI,@DIA_CHECK,@DESDE,@HASTA,@HORA_INI,@HORA_FIN";
            cmd.Parameters.Add("@PROF_DNI", SqlDbType.Int).Value = txtProfCod.Text.ToString();
            cmd.Parameters.Add("@DESDE", SqlDbType.Date).Value = dtp_ini.Value;
            cmd.Parameters.Add("@HASTA", SqlDbType.Date).Value = dtp_fin.Value;

            if (checkLunes.Checked)
            {
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.VarChar).Value = "Lunes";
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;
            }
            try
            {
                sqlConexion.ejecutarQueryConSP(cmd);
            }
            catch (SqlException EXC)
            {
                lblStatus.Text = EXC.Message.ToString();
            }

            

        }


    }
}
