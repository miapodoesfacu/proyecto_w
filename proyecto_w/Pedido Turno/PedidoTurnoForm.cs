using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.Pedido_Turno
{
    public partial class PedidoTurnoForm : Form
    {
        private string prof_cod = "";
        public PedidoTurnoForm()
        {
            InitializeComponent();

            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            grdProfesionales.DataSource = conn.ejecutarQuery(query);
            query = string.Format("SELECT esp_descripcion FROM PROYECTO_W.Especialidad");
            DataRowCollection especialidades = conn.ejecutarQuery(query).Rows;

            cbxEspecialidadFilter.Items.Add("Vacio");
            cbxEspecialidadFilter.SelectedIndex = 0;
            foreach (DataRow especialidad in especialidades)
            {
                cbxEspecialidadFilter.Items.Add(especialidad["esp_descripcion"].ToString());
            }
            cbTurnos.Items.Add("Hora del Turno a Registrar");
            cbTurnos.SelectedIndex = 0;
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            ConexionSQL conn = new ConexionSQL();
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

                if (conditions.Count > 0)
                {
                    if (query.Contains("WHERE"))
                        query += string.Format(" AND {0}", string.Join(" AND ", conditions.ToArray()));
                    else
                        query += string.Format(" WHERE {0}", string.Join(" AND ", conditions.ToArray()));
                }


                this.grdProfesionales.DataSource = conn.ejecutarQuery(query);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ConexionSQL conn = new ConexionSQL();
            string query = string.Format("SELECT prof_cod, prof_nombre, prof_apellido FROM PROYECTO_W.Profesional");
            this.grdProfesionales.DataSource = conn.ejecutarQuery(query);
            this.txtNameFilter.Text = "";
            this.txtLastnameFilter.Text = "";
            this.cbxEspecialidadFilter.SelectedIndex = 0;
            this.grdDias.DataSource = null;
            this.grdTurnos.DataSource = null;
            this.cbTurnos.SelectedIndex = -1;
        }

        private void btnselec_profesional_Click(object sender, EventArgs e)
        {
            if (validar_seleccion() == true)
            {
                ConexionSQL conn = new ConexionSQL();
                prof_cod = grdProfesionales.SelectedCells[0].Value.ToString();
                string query;
                query = string.Format("DECLARE @FECHA DATETIME SET @FECHA = PROYECTO_W.F_FECHA_CONFIG()");
                query += string.Format(" SELECT fecha_fecha AS Fecha, (CASE DATEPART(DW, fecha_fecha) WHEN 1 THEN 'Lunes' WHEN 2 THEN 'Martes' WHEN 3 THEN 'Miercoles' WHEN 4 THEN 'Jueves' WHEN 5 THEN 'Viernes' WHEN 6 THEN 'Sabado' WHEN 7 THEN 'Domingo' END) AS Dia");
                query += string.Format(" FROM PROYECTO_W.Profesional JOIN PROYECTO_W.AgendaProfesional ON prof_cod = agen_prof_cod JOIN PROYECTO_W.Fecha ON agen_cod = fecha_agen_cod");
                query += string.Format(" WHERE prof_cod = {0} AND fecha_fecha >= @FECHA", prof_cod);
                query += string.Format(" ORDER BY fecha_fecha");
                grdDias.DataSource = conn.ejecutarQuery(query);
            }
        }

        private bool validar_seleccion()
        {
            if (grdProfesionales.SelectedCells.Count == 0)
            {
                MessageBox.Show("No selecciono ningun profesional", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else
                return true;
        }

        private void btnselec_dia_Click(object sender, EventArgs e)
        {
            if (validar_seleccion_dia() == true)
            {
                ConexionSQL conn = new ConexionSQL();
                string query;
                string fecha = grdDias.SelectedCells[0].Value.ToString();
                query = string.Format("SELECT turno_nro as Turno, CAST(turno_fecha AS TIME(0)) AS Hora, turno_afil_nro as Afiliado");
                query += string.Format(" FROM PROYECTO_W.Turno");
                query += string.Format(" WHERE CAST(turno_fecha AS DATE) = '{0}' AND turno_prof_cod = {1} AND turno_estado = 'P'", fecha, prof_cod);
                query += string.Format(" ORDER BY turno_fecha");
                grdTurnos.DataSource = conn.ejecutarQuery(query);
            }
        }

        private bool validar_seleccion_dia()
        {
            if (grdDias.SelectedCells.Count == 0)
            {
                MessageBox.Show("No selecciono ningun dia", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            else return true;
        }
    }
}