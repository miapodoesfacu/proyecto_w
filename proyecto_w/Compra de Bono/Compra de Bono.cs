﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using proyecto_w.Utilities.Conexion;
using System.Data.SqlClient;

namespace proyecto_w.Compra_de_Bono
{
    public partial class frmCompra_de_Bono : Form
    {
        public frmCompra_de_Bono()
        {
            InitializeComponent();

            cmbCDB_Tipo.Items.Add("Farmacia");
            cmbCDB_Tipo.Items.Add("Consulta");
        }

        private void cmbCDB_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
        }

        private void btnCDB_RealizarCompra_Click(object sender, EventArgs e)
        {
            // CHEQUEAR AFIL_NRO, CANTIDAD > 0 , ANTES DE ENVIAR LA QUERY
            lblCDB_Status.Text = "HACIENDO";
            ConexionSQL connectionSQL = ConexionSQL.Instance;
            uint PLAN_COD, SUMA;

            DateTime fecha = new DateTime(2014,9,9); //Fecha del sys
                                   
            String queryCompra = string.Format("exec PROYECTO_W.SP_COMPRABONOADMIN {0},'{1}',{2},'2014-9-9'",
                txtCDB_AfilNro.Text, cmbCDB_Tipo.Text, txtCDB_Cantidad.Text);
            String queryDatos = string.Format("SELECT * FROM PROYECTO_W.F_COMPRABONO_DATOS ({0},'{1}',{2},'2014-9-9')",
                txtCDB_AfilNro.Text, cmbCDB_Tipo.Text, txtCDB_Cantidad.Text);
            // TENDRIA QUE ENVIARSE LA FECHA ACTUAL, PERO ESTAMO PROBANDO NOMA
            
            
            try
            { 
                connectionSQL.ejecutarQuery(queryCompra);
            }
            catch (SqlException )
             {
                lblCDB_Status.Text = "Datos no validos";   
             }
            if (lblCDB_Status.Text != "Datos no validos")
            {
                DataTable datosCompra = connectionSQL.ejecutarQuery(queryDatos);
                lblCDB_Status.Text = "Compra realizada, suma a pagar: " + datosCompra.Rows[0][0].ToString() + 
                        ". Plan: " + datosCompra.Rows[0][1].ToString();
                if (cmbCDB_Tipo.Text == "Farmacia")
                    lblCDB_Status.Text = lblCDB_Status.Text + ". \nFecha vencimiento: " + fecha.AddDays(60).ToString();
            }
            
        }

        private void txtCDB_AfilNro_TextChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
        }

        private void txtCDB_Cantidad_TextChanged(object sender, EventArgs e)
        {
            lblCDB_Status.Text = "Ingreso de datos";
        }

                        
    }
}
