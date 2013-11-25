using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;

namespace proyecto_w.ABM_Compra_de_Bono
{
    public partial class frmCompraDeBono : Form
    {
        public frmCompraDeBono()
        {
            InitializeComponent();
        }

        private void btnCompraBono_Click(object sender, EventArgs e)
        {
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            String querySQL = string.Format("exec PROYECTO_W.SP_COMPRABONOADMIN {0},'{1}',{2},'2014-9-9'", 
                txtCompraBono_afilNro.Text, txtCompraBono_tipo.Text, txtCompraBono_cant.Text);
            // TENDRIA QUE ENVIARSE LA FECHA ACTUAL, PERO ESTAMO PROBANDO NOMA
            connectionSQL.ejecutarQuery(querySQL);
        }

    
    }
}
