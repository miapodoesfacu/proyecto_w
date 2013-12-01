namespace proyecto_w.Registro_de_Resultado
{
    partial class RegistrarDiagnostico
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
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblDiagnostico = new System.Windows.Forms.Label();
            this.lblSintoma = new System.Windows.Forms.Label();
            this.txtSintoma = new System.Windows.Forms.TextBox();
            this.txtTurno = new System.Windows.Forms.TextBox();
            this.txtDiagnostico = new System.Windows.Forms.RichTextBox();
            this.btnReceta = new System.Windows.Forms.Button();
            this.btnDiagnostico = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(42, 26);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(50, 13);
            this.lblTurno.TabIndex = 0;
            this.lblTurno.Text = "N° Turno";
            // 
            // lblDiagnostico
            // 
            this.lblDiagnostico.AutoSize = true;
            this.lblDiagnostico.Location = new System.Drawing.Point(42, 78);
            this.lblDiagnostico.Name = "lblDiagnostico";
            this.lblDiagnostico.Size = new System.Drawing.Size(63, 13);
            this.lblDiagnostico.TabIndex = 1;
            this.lblDiagnostico.Text = "Diagnostico";
            // 
            // lblSintoma
            // 
            this.lblSintoma.AutoSize = true;
            this.lblSintoma.Location = new System.Drawing.Point(42, 52);
            this.lblSintoma.Name = "lblSintoma";
            this.lblSintoma.Size = new System.Drawing.Size(47, 13);
            this.lblSintoma.TabIndex = 2;
            this.lblSintoma.Text = "Síntoma";
            // 
            // txtSintoma
            // 
            this.txtSintoma.Location = new System.Drawing.Point(124, 49);
            this.txtSintoma.Name = "txtSintoma";
            this.txtSintoma.Size = new System.Drawing.Size(100, 20);
            this.txtSintoma.TabIndex = 3;
            // 
            // txtTurno
            // 
            this.txtTurno.Location = new System.Drawing.Point(124, 23);
            this.txtTurno.Name = "txtTurno";
            this.txtTurno.Size = new System.Drawing.Size(100, 20);
            this.txtTurno.TabIndex = 5;
            // 
            // txtDiagnostico
            // 
            this.txtDiagnostico.Location = new System.Drawing.Point(124, 78);
            this.txtDiagnostico.MaxLength = 255;
            this.txtDiagnostico.Name = "txtDiagnostico";
            this.txtDiagnostico.Size = new System.Drawing.Size(268, 96);
            this.txtDiagnostico.TabIndex = 6;
            this.txtDiagnostico.Text = "";
            // 
            // btnReceta
            // 
            this.btnReceta.Location = new System.Drawing.Point(92, 191);
            this.btnReceta.Name = "btnReceta";
            this.btnReceta.Size = new System.Drawing.Size(95, 23);
            this.btnReceta.TabIndex = 7;
            this.btnReceta.Text = "Generar Receta";
            this.btnReceta.UseVisualStyleBackColor = true;
            // 
            // btnDiagnostico
            // 
            this.btnDiagnostico.Location = new System.Drawing.Point(226, 191);
            this.btnDiagnostico.Name = "btnDiagnostico";
            this.btnDiagnostico.Size = new System.Drawing.Size(125, 23);
            this.btnDiagnostico.TabIndex = 8;
            this.btnDiagnostico.Text = "Registrar Diagnostico";
            this.btnDiagnostico.UseVisualStyleBackColor = true;
            // 
            // RegistrarDiagnostico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 243);
            this.Controls.Add(this.btnDiagnostico);
            this.Controls.Add(this.btnReceta);
            this.Controls.Add(this.txtDiagnostico);
            this.Controls.Add(this.txtTurno);
            this.Controls.Add(this.txtSintoma);
            this.Controls.Add(this.lblSintoma);
            this.Controls.Add(this.lblDiagnostico);
            this.Controls.Add(this.lblTurno);
            this.Name = "RegistrarDiagnostico";
            this.Text = "RegistrarDiagnostico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblDiagnostico;
        private System.Windows.Forms.Label lblSintoma;
        private System.Windows.Forms.TextBox txtSintoma;
        private System.Windows.Forms.TextBox txtTurno;
        private System.Windows.Forms.RichTextBox txtDiagnostico;
        private System.Windows.Forms.Button btnReceta;
        private System.Windows.Forms.Button btnDiagnostico;
    }
}