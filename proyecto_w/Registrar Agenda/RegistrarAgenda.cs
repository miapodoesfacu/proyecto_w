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
        private bool CompareStringAscii(String str1, String str2)
        {
            byte[] a1 = Encoding.ASCII.GetBytes(str1);
            byte[] a2 = Encoding.ASCII.GetBytes(str2);
            uint st1 = 0, st2 = 0;
            uint uni = (uint) str1.Length;
            uni = (uint)Math.Pow((double)10, (double)uni);
            foreach (byte b in a1)
            {
                st1 += b * uni;
                uni = uni / 10;
            }
            uni = (uint)str2.Length;
            uni = (uint)Math.Pow((double)10, (double)uni);
            foreach (byte b in a2)
            {
                st2 += b * uni;
                uni = uni / 10;
            }
            if (st2 >= st1)
                return true;
            else return false;
        }
        public frmRegistrarAgenda()
        {
            InitializeComponent();
            int minutos = 00;
            
            
            TimeSpan timeAux = new TimeSpan(07, minutos, 00);
                       
            while(CompareStringAscii(timeAux.ToString(),"19:59:59"))
            {
                timeAux = new TimeSpan(07, minutos, 00);
                cbxLun_ini.Items.Add(timeAux.ToString());
                cbxLun_fin.Items.Add(timeAux.ToString());
                cbxMa_ini.Items.Add(timeAux.ToString());
                cbxMa_fin.Items.Add(timeAux.ToString());
                cbxMi_ini.Items.Add(timeAux.ToString());
                cbxMi_fin.Items.Add(timeAux.ToString());
                cbxJu_ini.Items.Add(timeAux.ToString());
                cbxJu_fin.Items.Add(timeAux.ToString());
                cbxVi_ini.Items.Add(timeAux.ToString());
                cbxVi_fin.Items.Add(timeAux.ToString());

                if ((!CompareStringAscii(timeAux.ToString(), "09:59:59")) &
                    CompareStringAscii(timeAux.ToString(), "15:00:00"))
                {
                    cbxSa_ini.Items.Add(timeAux.ToString());
                    cbxSa_fin.Items.Add(timeAux.ToString());
                }

                minutos += 30;

            }
        }
/* CREATE PROCEDURE PROYECTO_W.SP_REGISTRAR_AGENDA
@PROF_DNI NUMERIC(18,0), @DIA_CHECK VARCHAR(255), @DESDE DATE, @HASTA DATE,
	@HORA_INI TIME, @HORA_FIN TIME */

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtProfCod.Text == "")
            {
                lblStatus.Text = "Debe ingresar número de documento del profesional";
                return;
            }
            if (dtp_ini.Value > dtp_fin.Value)
            {
                lblStatus.Text = "Fecha de comienzo debe ser \n menor o igual que fecha final";
                return;
            }

            if (!(CompareStringAscii(cbxLun_ini.Text, cbxLun_fin.Text)
                & CompareStringAscii(cbxMa_ini.Text, cbxMa_fin.Text)
                & CompareStringAscii(cbxMi_ini.Text, cbxMi_fin.Text)
                & CompareStringAscii(cbxJu_ini.Text, cbxJu_fin.Text)
                & CompareStringAscii(cbxVi_ini.Text, cbxVi_fin.Text)
                & CompareStringAscii(cbxSa_ini.Text, cbxSa_fin.Text)
                ))
            
            {
                lblStatus.Text = "Horario de inicio debe ser \n menor o igual que horario final";
                return;
            }


            
            ConexionSQL sqlConexion = ConexionSQL.Instance;
            lblStatus.Text = "EJECUTANDO";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = 
                "EXEC PROYECTO_W.SP_REGISTRAR_AGENDA @PROF_DNI,@DIA_CHECK,@DESDE,@HASTA,@HORA_INI,@HORA_FIN";
            cmd.Parameters.Add("@PROF_DNI", SqlDbType.Int).Value = txtProfCod.Text;
            cmd.Parameters.Add("@DESDE", SqlDbType.Date).Value = dtp_ini.Value;
            cmd.Parameters.Add("@HASTA", SqlDbType.Date).Value = dtp_fin.Value;

            // LUNES
            if (checkLunes.Checked)
            {
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 1;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxLun_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxLun_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    lblStatus.Text = EXC.Message.ToString();
                }
            }
          

            //MARTES
            if (checkMartes.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 2;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMa_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMa_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    lblStatus.Text = EXC.Message.ToString();
                }
            }

            //MIERCOLES
            if (checkMie.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 3;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxMi_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxMi_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    lblStatus.Text = EXC.Message.ToString();
                }
            }

            //JUEVES
            if (checkJue.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 4;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxJu_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxJu_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    lblStatus.Text = EXC.Message.ToString();
                }
            }

            //VIERNES
            if (checkVie.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 5;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxVi_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxVi_fin.Text;

                try
                {
                    sqlConexion.ejecutarQueryConSP(cmd);
                }
                catch (SqlException EXC)
                {
                    lblStatus.Text = EXC.Message.ToString();
                }
            }

            //SABADO
            if (checkSa.Checked)
            {
                cmd.Parameters.RemoveAt("@DIA_CHECK");
                cmd.Parameters.RemoveAt("@HORA_INI");
                cmd.Parameters.RemoveAt("@HORA_FIN");
                cmd.Parameters.Add("@DIA_CHECK", SqlDbType.Int).Value = 6;
                cmd.Parameters.Add("@HORA_INI", SqlDbType.Time).Value = cbxSa_ini.Text;
                cmd.Parameters.Add("@HORA_FIN", SqlDbType.Time).Value = cbxSa_fin.Text;

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
}
