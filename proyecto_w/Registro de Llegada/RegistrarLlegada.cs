using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Registro_de_Llegada
{
    public partial class frmRegistrarLlegada : Form
    {
        private ConexionSQL conn = ConexionSQL.Instance;

        private void onlyNumbers(KeyPressEventArgs ev)
        {
            if (!Char.IsControl(ev.KeyChar) && !Char.IsNumber(ev.KeyChar))
                ev.Handled = true;
        }

        public frmRegistrarLlegada()
        {
            InitializeComponent();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            query = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = this.conn.ejecutarQuery(query).Rows;

            cbxEspecialidadFilter.Items.Add("Vacio");
            cbxEspecialidadFilter.SelectedIndex = 0;
            foreach (DataRow especialidad in especialidades)
            {
                cbxEspecialidadFilter.Items.Add(especialidad["esp_descripcion"].ToString());
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string apellido = this.txtLastnameFilter.Text;
            string nombre = this.txtNameFilter.Text;
            string especialidad = this.cbxEspecialidadFilter.SelectedItem.ToString();

            if (apellido != "" || nombre != "" || especialidad != "Vacio")
            {
                string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");

                List<String> conditions = new List<String>();

                if (apellido != "")
                    conditions.Add(string.Format("prof_apellido='{0}'", apellido));
                //conditions.Add();

                if (nombre != "")
                    conditions.Add(string.Format("prof_nombre='{0}'", nombre));
                //  conditions[conditions.Length] = string.Format("prof_nombre='{0}'", apellido);
                //conditions.Add();

                if (especialidad != "Vacio")
                    query = string.Format("SELECT P.prof_cod, P.prof_nombre, P.prof_apellido FROM PROYECTO_W.Profesional AS P JOIN PROYECTO_W.EspecialidadPorProfesional AS EP ON EP.espxprof_prof_cod=P.prof_cod JOIN PROYECTO_W.Especialidad AS E ON E.esp_cod=EP.espxprof_esp_cod WHERE E.esp_descripcion='{0}'", especialidad);

                if(conditions.Count > 0)
                {
                    if (query.Contains("WHERE"))
                        query += string.Format(" AND {0}", string.Join(" AND ", conditions.ToArray()));
                    else
                        query += string.Format(" WHERE {0}", string.Join(" AND ", conditions.ToArray()));
                }
                

                this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = this.conn.ejecutarQuery(query);
            this.txtNameFilter.Text = "";
            this.txtLastnameFilter.Text = "";
            this.cbxEspecialidadFilter.SelectedIndex = 0;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (this.txtAfilNro.Text == "")
                MessageBox.Show("Debe Ingresar Numero de Afiliado");
            else
            {
                int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];  
                string prof_cod = Convert.ToString(selectedRow.Cells["NroProfesional"].Value);           

                string date = string.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now);
                string query = string.Format("SELECT T.turno_nro, A.afil_nombre, A.afil_apellido, T.turno_fecha FROM PROYECTO_W.Turno AS T JOIN PROYECTO_W.Afiliado AS A ON A.afil_nro=T.turno_afil_nro WHERE T.turno_fecha<CONVERT(DATETIME, '{0}', 120) AND A.afil_nro={1} AND T.turno_estado = 'P' AND T.turno_prof_cod={2}", date, this.txtAfilNro.Text, prof_cod);
                DataTable results = this.conn.ejecutarQuery(query);
                int amount_results = results.Rows.Count;
                this.grdTurnos.DataSource = results;

                if(amount_results > 0)
                    this.txtBono.Enabled = true;
                else
                    this.txtBono.Enabled = false;
            }
        }

        private void txtAfilNro_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            this.txtBono.Enabled = false;
            this.txtAfilNro.Text = "";
            this.grdTurnos.DataSource = null;
        }

        private void txtBono_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.onlyNumbers(e);
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string query = string.Format("SELECT BC.bonocons_estado FROM PROYECTO_W.BonoConsulta AS BC WHERE BC.bonocons_cod={0}", this.txtBono.Text);
            DataTable results = this.conn.ejecutarQuery(query);
            if (results.Rows[0][0].ToString() == "S")
            {
                query = string.Format("UPDATE PROYECTO_W.BonoConsulta SET bonocons_estado='U' WHERE bonocons_cod={0}", this.txtBono.Text);
                this.conn.ejecutarQuery(query);

                int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];  
                string prof_cod = Convert.ToString(selectedRow.Cells["NroProfesional"].Value);           
                string date = string.Format("{0:yyyy-M-d HH:mm:ss}", DateTime.Now);
                query = string.Format("SELECT T.turno_nro FROM PROYECTO_W.Turno AS T JOIN PROYECTO_W.Afiliado AS A ON A.afil_nro=T.turno_afil_nro WHERE T.turno_fecha<CONVERT(DATETIME, '{0}', 120) AND A.afil_nro={1} AND T.turno_estado = 'P' AND T.turno_prof_cod={2}", date, this.txtAfilNro.Text, prof_cod);

                /*int selectedrowindex = grdProfesionales.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = grdProfesionales.Rows[selectedrowindex];
                string turnoNro = Convert.ToString(selectedRow.Cells["NumeroTurno"].Value);
                */
                string turnoNro = this.conn.ejecutarQuery(query).Rows[0][0].ToString();

                query = string.Format("UPDATE PROYECTO_W.Turno SET turno_estado='A' WHERE turno_nro={0}", turnoNro);
                this.conn.ejecutarQuery(query);

                query = string.Format("SELECT afil_nro_consultas FROM PROYECTO_W.Afiliado WHERE afil_nro={0}", this.txtAfilNro.Text);
                int nroConsultas = int.Parse(this.conn.ejecutarQuery(query).Rows[0][0].ToString());

                query = string.Format("INSERT INTO PROYECTO_W.TurnoLlegada VALUES ({0}, {1}, {2})", turnoNro, nroConsultas + 1, this.txtBono.Text);
                this.conn.ejecutarQuery(query);

                query = string.Format("UPDATE PROYECTO_W.Afiliado SET afil_nro_consultas={0} WHERE afil_nro={1}", nroConsultas + 1, this.txtAfilNro.Text);
                this.conn.ejecutarQuery(query);

                MessageBox.Show("Consulta Registrada");
                this.txtBono.Enabled = false;
                this.txtAfilNro.Text = "";
                this.grdTurnos.DataSource = null;
            }
            else
                MessageBox.Show("El Bono Consulta ya fue utilizado");
        }
    }
}
