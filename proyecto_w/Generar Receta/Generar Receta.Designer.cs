namespace proyecto_w.Generar_Receta
{
    partial class Generar_Receta_Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbxMed1 = new System.Windows.Forms.ComboBox();
            this.lblMedicamentos = new System.Windows.Forms.Label();
            this.cbxMed2 = new System.Windows.Forms.ComboBox();
            this.cbxMed3 = new System.Windows.Forms.ComboBox();
            this.cbxMed4 = new System.Windows.Forms.ComboBox();
            this.cbxMed5 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cbxMed1
            // 
            this.cbxMed1.FormattingEnabled = true;
            this.cbxMed1.Location = new System.Drawing.Point(12, 25);
            this.cbxMed1.Name = "cbxMed1";
            this.cbxMed1.Size = new System.Drawing.Size(424, 21);
            this.cbxMed1.TabIndex = 0;
            // 
            // lblMedicamentos
            // 
            this.lblMedicamentos.AutoSize = true;
            this.lblMedicamentos.Location = new System.Drawing.Point(146, 9);
            this.lblMedicamentos.Name = "lblMedicamentos";
            this.lblMedicamentos.Size = new System.Drawing.Size(76, 13);
            this.lblMedicamentos.TabIndex = 1;
            this.lblMedicamentos.Text = "Medicamentos";
            // 
            // cbxMed2
            // 
            this.cbxMed2.FormattingEnabled = true;
            this.cbxMed2.Location = new System.Drawing.Point(12, 52);
            this.cbxMed2.Name = "cbxMed2";
            this.cbxMed2.Size = new System.Drawing.Size(424, 21);
            this.cbxMed2.TabIndex = 2;
            // 
            // cbxMed3
            // 
            this.cbxMed3.FormattingEnabled = true;
            this.cbxMed3.Location = new System.Drawing.Point(12, 79);
            this.cbxMed3.Name = "cbxMed3";
            this.cbxMed3.Size = new System.Drawing.Size(424, 21);
            this.cbxMed3.TabIndex = 3;
            // 
            // cbxMed4
            // 
            this.cbxMed4.FormattingEnabled = true;
            this.cbxMed4.Location = new System.Drawing.Point(12, 106);
            this.cbxMed4.Name = "cbxMed4";
            this.cbxMed4.Size = new System.Drawing.Size(424, 21);
            this.cbxMed4.TabIndex = 4;
            // 
            // cbxMed5
            // 
            this.cbxMed5.FormattingEnabled = true;
            this.cbxMed5.Location = new System.Drawing.Point(12, 133);
            this.cbxMed5.Name = "cbxMed5";
            this.cbxMed5.Size = new System.Drawing.Size(424, 21);
            this.cbxMed5.TabIndex = 5;
            // 
            // Generar_Receta_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 273);
            this.Controls.Add(this.cbxMed5);
            this.Controls.Add(this.cbxMed4);
            this.Controls.Add(this.cbxMed3);
            this.Controls.Add(this.cbxMed2);
            this.Controls.Add(this.lblMedicamentos);
            this.Controls.Add(this.cbxMed1);
            this.Name = "Generar_Receta_Form";
            this.Text = "Generar_Receta";
            this.Load += new System.EventHandler(this.Generar_Receta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMed1;
        private System.Windows.Forms.Label lblMedicamentos;
        private System.Windows.Forms.ComboBox cbxMed2;
        private System.Windows.Forms.ComboBox cbxMed3;
        private System.Windows.Forms.ComboBox cbxMed4;
        private System.Windows.Forms.ComboBox cbxMed5;


    }
}