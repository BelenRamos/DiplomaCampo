namespace Presentacion.Formulario_de_Reporte
{
    partial class FormReportePostulantes
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
            this.btnGenerarReportePostulantes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvDataPostulantes = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPostulantes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGenerarReportePostulantes
            // 
            this.btnGenerarReportePostulantes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReportePostulantes.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReportePostulantes.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnGenerarReportePostulantes.Location = new System.Drawing.Point(318, 328);
            this.btnGenerarReportePostulantes.Name = "btnGenerarReportePostulantes";
            this.btnGenerarReportePostulantes.Size = new System.Drawing.Size(105, 35);
            this.btnGenerarReportePostulantes.TabIndex = 11;
            this.btnGenerarReportePostulantes.Text = "Guardar PDF";
            this.btnGenerarReportePostulantes.UseVisualStyleBackColor = true;
            this.btnGenerarReportePostulantes.Click += new System.EventHandler(this.btnGenerarReportePostulantes_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(19, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 86);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(71)))), ((int)(((byte)(97)))));
            this.label5.Location = new System.Drawing.Point(272, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(187, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Reporte de Postulantes";
            // 
            // dgvDataPostulantes
            // 
            this.dgvDataPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataPostulantes.Location = new System.Drawing.Point(19, 100);
            this.dgvDataPostulantes.Name = "dgvDataPostulantes";
            this.dgvDataPostulantes.Size = new System.Drawing.Size(711, 212);
            this.dgvDataPostulantes.TabIndex = 9;
            // 
            // FormReportePostulantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(748, 369);
            this.Controls.Add(this.btnGenerarReportePostulantes);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDataPostulantes);
            this.Name = "FormReportePostulantes";
            this.Text = "FormReportePostulantes";
            this.Load += new System.EventHandler(this.FormReportePostulantes_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataPostulantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReportePostulantes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDataPostulantes;
    }
}