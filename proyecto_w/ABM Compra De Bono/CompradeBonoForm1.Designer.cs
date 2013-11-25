namespace proyecto_w.ABM_Compra_de_Bono
{
    partial class frmCompraDeBono
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
            this.btnCompraBono = new System.Windows.Forms.Button();
            this.lblCBF1 = new System.Windows.Forms.Label();
            this.txtCompraBono_afilNro = new System.Windows.Forms.TextBox();
            this.label2cbf2 = new System.Windows.Forms.Label();
            this.label3cbf3 = new System.Windows.Forms.Label();
            this.label4cbf3 = new System.Windows.Forms.Label();
            this.txtCompraBono_tipo = new System.Windows.Forms.TextBox();
            this.txtCompraBono_cant = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCompraBono
            // 
            this.btnCompraBono.Location = new System.Drawing.Point(291, 71);
            this.btnCompraBono.Name = "btnCompraBono";
            this.btnCompraBono.Size = new System.Drawing.Size(108, 23);
            this.btnCompraBono.TabIndex = 0;
            this.btnCompraBono.Text = "hacer compra";
            this.btnCompraBono.UseVisualStyleBackColor = true;
            this.btnCompraBono.Click += new System.EventHandler(this.btnCompraBono_Click);
            // 
            // lblCBF1
            // 
            this.lblCBF1.AutoSize = true;
            this.lblCBF1.Location = new System.Drawing.Point(18, 26);
            this.lblCBF1.Name = "lblCBF1";
            this.lblCBF1.Size = new System.Drawing.Size(292, 13);
            this.lblCBF1.TabIndex = 1;
            this.lblCBF1.Text = "está choto porque es para probar si anda el procedure noma";
            // 
            // txtCompraBono_afilNro
            // 
            this.txtCompraBono_afilNro.Location = new System.Drawing.Point(21, 143);
            this.txtCompraBono_afilNro.Name = "txtCompraBono_afilNro";
            this.txtCompraBono_afilNro.Size = new System.Drawing.Size(100, 20);
            this.txtCompraBono_afilNro.TabIndex = 2;
            // 
            // label2cbf2
            // 
            this.label2cbf2.AutoSize = true;
            this.label2cbf2.Location = new System.Drawing.Point(46, 111);
            this.label2cbf2.Name = "label2cbf2";
            this.label2cbf2.Size = new System.Drawing.Size(41, 13);
            this.label2cbf2.TabIndex = 3;
            this.label2cbf2.Text = "afil_nro";
            // 
            // label3cbf3
            // 
            this.label3cbf3.AutoSize = true;
            this.label3cbf3.Location = new System.Drawing.Point(151, 111);
            this.label3cbf3.Name = "label3cbf3";
            this.label3cbf3.Size = new System.Drawing.Size(103, 13);
            this.label3cbf3.TabIndex = 4;
            this.label3cbf3.Text = "Farmacia o Consulta";
            // 
            // label4cbf3
            // 
            this.label4cbf3.AutoSize = true;
            this.label4cbf3.Location = new System.Drawing.Point(328, 111);
            this.label4cbf3.Name = "label4cbf3";
            this.label4cbf3.Size = new System.Drawing.Size(48, 13);
            this.label4cbf3.TabIndex = 5;
            this.label4cbf3.Text = "cantidad";
            // 
            // txtCompraBono_tipo
            // 
            this.txtCompraBono_tipo.Location = new System.Drawing.Point(154, 143);
            this.txtCompraBono_tipo.Name = "txtCompraBono_tipo";
            this.txtCompraBono_tipo.Size = new System.Drawing.Size(100, 20);
            this.txtCompraBono_tipo.TabIndex = 6;
            // 
            // txtCompraBono_cant
            // 
            this.txtCompraBono_cant.Location = new System.Drawing.Point(299, 143);
            this.txtCompraBono_cant.Name = "txtCompraBono_cant";
            this.txtCompraBono_cant.Size = new System.Drawing.Size(100, 20);
            this.txtCompraBono_cant.TabIndex = 7;
            // 
            // frmCompraDeBono
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 262);
            this.Controls.Add(this.txtCompraBono_cant);
            this.Controls.Add(this.txtCompraBono_tipo);
            this.Controls.Add(this.label4cbf3);
            this.Controls.Add(this.label3cbf3);
            this.Controls.Add(this.label2cbf2);
            this.Controls.Add(this.txtCompraBono_afilNro);
            this.Controls.Add(this.lblCBF1);
            this.Controls.Add(this.btnCompraBono);
            this.Name = "frmCompraDeBono";
            this.Text = "ABMCompradeBonoForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCompraBono;
        private System.Windows.Forms.Label lblCBF1;
        private System.Windows.Forms.TextBox txtCompraBono_afilNro;
        private System.Windows.Forms.Label label2cbf2;
        private System.Windows.Forms.Label label3cbf3;
        private System.Windows.Forms.Label label4cbf3;
        private System.Windows.Forms.TextBox txtCompraBono_tipo;
        private System.Windows.Forms.TextBox txtCompraBono_cant;
    }
}