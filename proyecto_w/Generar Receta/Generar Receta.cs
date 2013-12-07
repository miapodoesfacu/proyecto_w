using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace proyecto_w.Generar_Receta
{
    public partial class Generar_Receta_Form : Form
    {
        public uint turno_nro;
        public Generar_Receta_Form(uint nro_turno)
        {
            InitializeComponent();
            turno_nro = nro_turno;
        }

        private void Generar_Receta_Load(object sender, EventArgs e)
        {
        }
    }
}
