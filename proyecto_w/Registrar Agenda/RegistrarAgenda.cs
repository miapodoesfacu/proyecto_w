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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            ConexionSQL sqlConexion = ConexionSQL.Instance;
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from PROYECTO_W.Profesional where prof_fecha_nac < @fecha_prueba";
            //cmd.Parameters.Add ("@p_Date", SqlDbType.DateTime).Value = dtpJobDate.Value;
            cmd.Parameters.Add("@fecha_prueba", SqlDbType.DateTime).Value = dtp_ini.Value;


            this.gridTesting.DataSource = sqlConexion.ejecutarQueryConSP(cmd);

        }


    }
}
