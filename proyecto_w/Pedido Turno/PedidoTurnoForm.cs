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
    }
}