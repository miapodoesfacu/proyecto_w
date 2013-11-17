using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.ABM_Afiliado
{
    public partial class frmABMAfiliado : Form
    {
        private ConexionSQL connectSQL = ConexionSQL.Instance;
        public frmABMAfiliado()
        {
            InitializeComponent();
            string query = string.Format("SELECT afil_nro, afil_nombre, afil_apellido, afil_doc_tipo, afil_doc_nro, afil_direccion, afil_telefono, afil_mail,afil_fecha_nac, afil_sexo, afil_estado_civil, Pl.plan_descripcion FROM PROYECTO_W.Afiliado AS A JOIN [GD2C2013].[PROYECTO_W].[Plan] AS Pl ON pl.plan_cod = A.afil_plan_cod");
            DataTable resultAfil = this.connectSQL.ejecutarQuery(query);
            this.grdConsulta.DataSource = resultAfil;
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            AltaAfiliadoForm frm = new AltaAfiliadoForm();
            frm.ShowDialog();
        }
    }
}
