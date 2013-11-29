namespace proyecto_w.Registro_de_Llegada
{
    partial class frmRegistrarLlegada
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
            this.txtFiltroAfiliado = new System.Windows.Forms.Label();
            this.txtFiltroNombre = new System.Windows.Forms.Label();
            this.txtFiltroApellido = new System.Windows.Forms.Label();
            this.txtFiltroEspecialidad = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cbxEspecialidad = new System.Windows.Forms.ComboBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grdProfesionales = new System.Windows.Forms.DataGridView();
            this.NroProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApellidoProfesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lblTurnos = new System.Windows.Forms.Label();
            this.grdTurnos = new System.Windows.Forms.DataGridView();
            this.NumeroTurno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodAfiliado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Profesional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBono = new System.Windows.Forms.Label();
            this.txtBono = new System.Windows.Forms.TextBox();
            this.btnRegistrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFiltroAfiliado
            // 
            this.txtFiltroAfiliado.AutoSize = true;
            this.txtFiltroAfiliado.Location = new System.Drawing.Point(19, 24);
            this.txtFiltroAfiliado.Name = "txtFiltroAfiliado";
            this.txtFiltroAfiliado.Size = new System.Drawing.Size(56, 13);
            this.txtFiltroAfiliado.TabIndex = 0;
            this.txtFiltroAfiliado.Text = "N° Afiliado";
            // 
            // txtFiltroNombre
            // 
            this.txtFiltroNombre.AutoSize = true;
            this.txtFiltroNombre.Location = new System.Drawing.Point(19, 52);
            this.txtFiltroNombre.Name = "txtFiltroNombre";
            this.txtFiltroNombre.Size = new System.Drawing.Size(99, 13);
            this.txtFiltroNombre.TabIndex = 1;
            this.txtFiltroNombre.Text = "Nombre Profesional";
            // 
            // txtFiltroApellido
            // 
            this.txtFiltroApellido.AutoSize = true;
            this.txtFiltroApellido.Location = new System.Drawing.Point(19, 80);
            this.txtFiltroApellido.Name = "txtFiltroApellido";
            this.txtFiltroApellido.Size = new System.Drawing.Size(99, 13);
            this.txtFiltroApellido.TabIndex = 2;
            this.txtFiltroApellido.Text = "Apellido Profesional";
            // 
            // txtFiltroEspecialidad
            // 
            this.txtFiltroEspecialidad.AutoSize = true;
            this.txtFiltroEspecialidad.Location = new System.Drawing.Point(19, 108);
            this.txtFiltroEspecialidad.Name = "txtFiltroEspecialidad";
            this.txtFiltroEspecialidad.Size = new System.Drawing.Size(67, 13);
            this.txtFiltroEspecialidad.TabIndex = 3;
            this.txtFiltroEspecialidad.Text = "Especialidad";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 77);
            this.textBox1.MaxLength = 10;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(143, 21);
            this.textBox2.MaxLength = 8;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(143, 49);
            this.textBox3.MaxLength = 10;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 6;
            // 
            // cbxEspecialidad
            // 
            this.cbxEspecialidad.FormattingEnabled = true;
            this.cbxEspecialidad.Location = new System.Drawing.Point(143, 105);
            this.cbxEspecialidad.Name = "cbxEspecialidad";
            this.cbxEspecialidad.Size = new System.Drawing.Size(121, 21);
            this.cbxEspecialidad.TabIndex = 7;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(87, 142);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 8;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // grdProfesionales
            // 
            this.grdProfesionales.AllowUserToAddRows = false;
            this.grdProfesionales.AllowUserToDeleteRows = false;
            this.grdProfesionales.AllowUserToResizeColumns = false;
            this.grdProfesionales.AllowUserToResizeRows = false;
            this.grdProfesionales.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdProfesionales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdProfesionales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NroProfesional,
            this.NombreProfesional,
            this.ApellidoProfesional});
            this.grdProfesionales.Location = new System.Drawing.Point(289, 21);
            this.grdProfesionales.MultiSelect = false;
            this.grdProfesionales.Name = "grdProfesionales";
            this.grdProfesionales.ReadOnly = true;
            this.grdProfesionales.RowHeadersVisible = false;
            this.grdProfesionales.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdProfesionales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdProfesionales.Size = new System.Drawing.Size(302, 105);
            this.grdProfesionales.TabIndex = 9;
            // 
            // NroProfesional
            // 
            this.NroProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NroProfesional.DataPropertyName = "prof_cod";
            this.NroProfesional.Frozen = true;
            this.NroProfesional.HeaderText = "N° Profesional";
            this.NroProfesional.Name = "NroProfesional";
            this.NroProfesional.ReadOnly = true;
            // 
            // NombreProfesional
            // 
            this.NombreProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NombreProfesional.DataPropertyName = "prof_nombre";
            this.NombreProfesional.Frozen = true;
            this.NombreProfesional.HeaderText = "Nombre";
            this.NombreProfesional.Name = "NombreProfesional";
            this.NombreProfesional.ReadOnly = true;
            // 
            // ApellidoProfesional
            // 
            this.ApellidoProfesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.ApellidoProfesional.DataPropertyName = "prof_apellido";
            this.ApellidoProfesional.Frozen = true;
            this.ApellidoProfesional.HeaderText = "Apellido";
            this.ApellidoProfesional.Name = "ApellidoProfesional";
            this.ApellidoProfesional.ReadOnly = true;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(399, 142);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 10;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // lblTurnos
            // 
            this.lblTurnos.AutoSize = true;
            this.lblTurnos.Location = new System.Drawing.Point(255, 183);
            this.lblTurnos.Name = "lblTurnos";
            this.lblTurnos.Size = new System.Drawing.Size(97, 13);
            this.lblTurnos.TabIndex = 11;
            this.lblTurnos.Text = "Turnos Disponibles";
            // 
            // grdTurnos
            // 
            this.grdTurnos.AllowUserToAddRows = false;
            this.grdTurnos.AllowUserToDeleteRows = false;
            this.grdTurnos.AllowUserToResizeColumns = false;
            this.grdTurnos.AllowUserToResizeRows = false;
            this.grdTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdTurnos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.grdTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTurnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroTurno,
            this.Fecha,
            this.CodAfiliado,
            this.Profesional});
            this.grdTurnos.Location = new System.Drawing.Point(102, 200);
            this.grdTurnos.MultiSelect = false;
            this.grdTurnos.Name = "grdTurnos";
            this.grdTurnos.ReadOnly = true;
            this.grdTurnos.RowHeadersVisible = false;
            this.grdTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.grdTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdTurnos.Size = new System.Drawing.Size(402, 83);
            this.grdTurnos.TabIndex = 12;
            // 
            // NumeroTurno
            // 
            this.NumeroTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.NumeroTurno.DataPropertyName = "turno_nro";
            this.NumeroTurno.Frozen = true;
            this.NumeroTurno.HeaderText = "N° Turno";
            this.NumeroTurno.Name = "NumeroTurno";
            this.NumeroTurno.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Fecha.DataPropertyName = "turno_fecha";
            this.Fecha.Frozen = true;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // CodAfiliado
            // 
            this.CodAfiliado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.CodAfiliado.DataPropertyName = "turno_afil_nro";
            this.CodAfiliado.Frozen = true;
            this.CodAfiliado.HeaderText = "Código Afiliado";
            this.CodAfiliado.Name = "CodAfiliado";
            this.CodAfiliado.ReadOnly = true;
            // 
            // Profesional
            // 
            this.Profesional.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Profesional.DataPropertyName = "turno_prof_cod";
            this.Profesional.Frozen = true;
            this.Profesional.HeaderText = "Código Profesional";
            this.Profesional.Name = "Profesional";
            this.Profesional.ReadOnly = true;
            // 
            // lblBono
            // 
            this.lblBono.AutoSize = true;
            this.lblBono.Location = new System.Drawing.Point(173, 304);
            this.lblBono.Name = "lblBono";
            this.lblBono.Size = new System.Drawing.Size(91, 13);
            this.lblBono.TabIndex = 13;
            this.lblBono.Text = "N° Bono Consulta";
            // 
            // txtBono
            // 
            this.txtBono.Enabled = false;
            this.txtBono.Location = new System.Drawing.Point(279, 301);
            this.txtBono.MaxLength = 6;
            this.txtBono.Name = "txtBono";
            this.txtBono.Size = new System.Drawing.Size(100, 20);
            this.txtBono.TabIndex = 14;
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(235, 343);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(128, 23);
            this.btnRegistrar.TabIndex = 15;
            this.btnRegistrar.Text = "Registrar Llegada";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // frmRegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 385);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.txtBono);
            this.Controls.Add(this.lblBono);
            this.Controls.Add(this.grdTurnos);
            this.Controls.Add(this.lblTurnos);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.grdProfesionales);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cbxEspecialidad);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtFiltroEspecialidad);
            this.Controls.Add(this.txtFiltroApellido);
            this.Controls.Add(this.txtFiltroNombre);
            this.Controls.Add(this.txtFiltroAfiliado);
            this.Name = "frmRegistrarLlegada";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registrar Llegada";
            ((System.ComponentModel.ISupportInitialize)(this.grdProfesionales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtFiltroAfiliado;
        private System.Windows.Forms.Label txtFiltroNombre;
        private System.Windows.Forms.Label txtFiltroApellido;
        private System.Windows.Forms.Label txtFiltroEspecialidad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox cbxEspecialidad;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.DataGridView grdProfesionales;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProfesional;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApellidoProfesional;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label lblTurnos;
        private System.Windows.Forms.DataGridView grdTurnos;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroTurno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodAfiliado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Profesional;
        private System.Windows.Forms.Label lblBono;
        private System.Windows.Forms.TextBox txtBono;
        private System.Windows.Forms.Button btnRegistrar;
    }
}