namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    partial class FormSesiones
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
            this.btnGenerarReporteSM = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDataSesiones = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnFiltro = new System.Windows.Forms.Button();
            this.dtpFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSesiones)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarReporteSM
            // 
            this.btnGenerarReporteSM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporteSM.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporteSM.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnGenerarReporteSM.Location = new System.Drawing.Point(238, 341);
            this.btnGenerarReporteSM.Name = "btnGenerarReporteSM";
            this.btnGenerarReporteSM.Size = new System.Drawing.Size(105, 35);
            this.btnGenerarReporteSM.TabIndex = 14;
            this.btnGenerarReporteSM.Text = "Guardar PDF";
            this.btnGenerarReporteSM.UseVisualStyleBackColor = true;
            this.btnGenerarReporteSM.Click += new System.EventHandler(this.btnGenerarReporteSM_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(7, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 60);
            this.panel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(71)))), ((int)(((byte)(97)))));
            this.label5.Location = new System.Drawing.Point(223, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Reporte Logs";
            // 
            // dgvDataSesiones
            // 
            this.dgvDataSesiones.AllowUserToAddRows = false;
            this.dgvDataSesiones.AllowUserToDeleteRows = false;
            this.dgvDataSesiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataSesiones.Location = new System.Drawing.Point(7, 112);
            this.dgvDataSesiones.Name = "dgvDataSesiones";
            this.dgvDataSesiones.ReadOnly = true;
            this.dgvDataSesiones.Size = new System.Drawing.Size(573, 212);
            this.dgvDataSesiones.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(71)))), ((int)(((byte)(97)))));
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 15;
            this.label1.Text = "Fecha Desde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(71)))), ((int)(((byte)(97)))));
            this.label2.Location = new System.Drawing.Point(259, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha Hasta";
            // 
            // btnFiltro
            // 
            this.btnFiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltro.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.btnFiltro.ForeColor = System.Drawing.Color.DarkOrange;
            this.btnFiltro.Location = new System.Drawing.Point(508, 73);
            this.btnFiltro.Name = "btnFiltro";
            this.btnFiltro.Size = new System.Drawing.Size(66, 24);
            this.btnFiltro.TabIndex = 17;
            this.btnFiltro.Text = "Filtrar";
            this.btnFiltro.UseVisualStyleBackColor = true;
            this.btnFiltro.Click += new System.EventHandler(this.btnFiltro_Click);
            // 
            // dtpFechaDesde
            // 
            this.dtpFechaDesde.Location = new System.Drawing.Point(106, 73);
            this.dtpFechaDesde.Name = "dtpFechaDesde";
            this.dtpFechaDesde.Size = new System.Drawing.Size(147, 20);
            this.dtpFechaDesde.TabIndex = 18;
            // 
            // dtpFechaHasta
            // 
            this.dtpFechaHasta.Location = new System.Drawing.Point(342, 73);
            this.dtpFechaHasta.Name = "dtpFechaHasta";
            this.dtpFechaHasta.Size = new System.Drawing.Size(147, 20);
            this.dtpFechaHasta.TabIndex = 19;
            // 
            // FormSesiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(586, 388);
            this.Controls.Add(this.dtpFechaHasta);
            this.Controls.Add(this.dtpFechaDesde);
            this.Controls.Add(this.btnFiltro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGenerarReporteSM);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDataSesiones);
            this.Name = "FormSesiones";
            this.Text = "FormSesiones";
            this.Load += new System.EventHandler(this.FormSesiones_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataSesiones)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReporteSM;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDataSesiones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFiltro;
        private System.Windows.Forms.DateTimePicker dtpFechaDesde;
        private System.Windows.Forms.DateTimePicker dtpFechaHasta;
    }
}