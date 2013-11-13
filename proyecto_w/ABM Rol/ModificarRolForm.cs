using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.ABM_Rol
{
    public partial class frmModificarRol : Form
    {
        private string rol;
        ConexionSQL connectionSQL = ConexionSQL.Instance;
        private DataTable funcionalidades;
        public frmModificarRol()
        {
            InitializeComponent();
        }
        public frmModificarRol(List<String> funciones, string rol) 
        {
            InitializeComponent();
            this.txtNombreRol.Text = rol;
            this.rol = rol;
            string query = string.Format("SELECT func_nombre FROM PROYECTO_W.Funcionalidad");
            this.funcionalidades = this.connectionSQL.ejecutarQuery(query);
            List<String> funcionalidadesString = new List<string>();
            for (int i = 0; i < this.funcionalidades.Rows.Count; i++) 
            {
                funcionalidadesString.Add(this.funcionalidades.Rows[i][0].ToString());
            }
            this.lstFuncionalidad.DataSource = funcionalidadesString;
            for(int i=0;i<this.funcionalidades.Rows.Count;i++)
            {
                if (funciones.IndexOf(this.funcionalidades.Rows[i]["func_nombre"].ToString()) != -1)
                    this.lstFuncionalidad.SetSelected(i, true);
                else
                    this.lstFuncionalidad.SetSelected(i, false);
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
          string checkEnable;
          if (this.chkEnable.Checked) checkEnable = "H";
          else checkEnable = "D";
          string queryEnable = string.Format("UPDATE R SET rol_estado='{0}'  FROM PROYECTO_W.Rol AS R WHERE rol_nombre = '{1}'", checkEnable, this.rol);
          this.connectionSQL.ejecutarQuery(queryEnable);
          string queryName = string.Format("UPDATE R SET rol_nombre = '{0}' FROM PROYECTO_W.Rol AS R WHERE R.rol_nombre = '{1}'", this.txtNombreRol.Text, this.rol);
          connectionSQL.ejecutarQuery(queryName);
          string queryState;
          for (int i = 0; i < this.funcionalidades.Rows.Count; i++)
          {
              if (this.lstFuncionalidad.SelectedItems.IndexOf(this.funcionalidades.Rows[i][0].ToString()) != -1) checkEnable = "H";
              else checkEnable = "D";
              queryState = string.Format("UPDATE FR SET FR.funcxrol_estado='{0}' FROM PROYECTO_W.FuncionalidadPorRol AS FR JOIN PROYECTO_W.Rol AS R ON R.rol_cod = FR.funcxrol_rol_cod JOIN PROYECTO_W.Funcionalidad AS F ON F.func_cod = FR.funcxrol_func_cod WHERE F.func_nombre = '{1}' AND R.rol_nombre='{2}'", checkEnable, this.lstFuncionalidad.SelectedItems[this.lstFuncionalidad.SelectedItems.IndexOf(this.funcionalidades.Rows[i][0])].ToString(), this.rol);
              this.connectionSQL.ejecutarQuery(queryState);
          }
        }
    }
}
