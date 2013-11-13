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
            this.SuspendLayout();
            // 
            // btnABMAfiliado
            // 
            this.btnABMAfiliado.Location = new System.Drawing.Point(49, 54);
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
            this.btnABMRol.Location = new System.Drawing.Point(146, 53);
            this.btnABMRol.Name = "btnABMRol";
            this.btnABMRol.Size = new System.Drawing.Size(75, 23);
            this.btnABMRol.TabIndex = 1;
            this.btnABMRol.Text = "ABMRol";
            this.btnABMRol.UseVisualStyleBackColor = true;
            this.btnABMRol.Click += new System.EventHandler(this.btnABMRol_Click);
            // 
            // MainWindowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 289);
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
    }
}