namespace proyecto_w
{
    partial class MainWindowForm
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
            this.btnABMAfiliado = new System.Windows.Forms.Button();
            this.btnABMRol = new System.Windows.Forms.Button();
            this.btnABMProfesional = new System.Windows.Forms.Button();
            this.btnCompraDeBono = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnABMAfiliado
            // 
            this.btnABMAfiliado.Location = new System.Drawing.Point(12, 12);
            this.btnABMAfiliado.Name = "btnABMAfiliado";
            this.btnABMAfiliado.Size = new System.Drawing.Size(75, 23);
            this.btnABMAfiliado.TabIndex = 0;
            this.btnABMAfiliado.Text = "ABMAfiliados";
            this.btnABMAfiliado.UseVisualStyleBackColor = true;
            this.btnABMAfiliado.Visible = false;
            this.btnABMAfiliado.Click += new System.EventHandler(this.btnABMAfiliado_Click_1);
            // 
            // btnABMRol
            // 
            this.btnABMRol.Location = new System.Drawing.Point(127, 12);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(75, 23);
            this.btnABMRol.TabIndex = 1;
            this.btnABMRol.Text = "ABMRol";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Click += new System.EventHandler(this.btnABMRol_Click);
            // 
            // btnABMProfesional
            // 
            this.btnABMProfesional.Location = new System.Drawing.Point(241, 12);
            this.btnABMProfesional.Name = "btnABMProfesional";
            this.btnABMProfesional.Size = new System.Drawing.Size(93, 23);
            this.btnABMProfesional.TabIndex = 2;
            this.btnABMProfesional.Text = "ABMProfesional";
            this.btnABMProfesional.UseVisualStyleBackColor = true;
            this.btnABMProfesional.Click += new System.EventHandler(this.btnABMProfesional_Click);
            // 
            // btnCompraDeBono
            // 
            this.btnCompraDeBono.Location = new System.Drawing.Point(12, 52);
            this.btnCompraDeBono.Name = "btnCompraDeBono";
            this.btnCompraDeBono.Size = new System.Drawing.Size(121, 23);
            this.btnCompraDeBono.TabIndex = 3;
            this.btnCompraDeBono.Text = "Compra de Bono";
            this.btnCompraDeBono.UseVisualStyleBackColor = true;
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 289);
            this.Controls.Add(this.btnCompraDeBono);
            this.Controls.Add(this.btnABMProfesional);
            this.Controls.Add(this.btnABMRol);
            this.Controls.Add(this.btnABMAfiliado);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindowForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TP Clinica";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnABMAfiliado;
        private System.Windows.Forms.Button btnABMRol;
        private System.Windows.Forms.Button btnABMProfesional;
        private System.Windows.Forms.Button btnCompraDeBono;
    }
}