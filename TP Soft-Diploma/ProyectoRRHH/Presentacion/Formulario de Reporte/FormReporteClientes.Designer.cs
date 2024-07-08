namespace Presentacion.Formulario_de_Reporte
{
    partial class FormReporteClientes
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
            this.dgvDataClientes = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerarReporteCliente = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataClientes)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataClientes
            // 
            this.dgvDataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataClientes.Location = new System.Drawing.Point(12, 107);
            this.dgvDataClientes.Name = "dgvDataClientes";
            this.dgvDataClientes.Size = new System.Drawing.Size(711, 212);
            this.dgvDataClientes.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 86);
            this.panel1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.label5.Location = new System.Drawing.Point(272, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Reporte de Clientes";
            // 
            // btnGenerarReporteCliente
            // 
            this.btnGenerarReporteCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporteCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporteCliente.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnGenerarReporteCliente.Location = new System.Drawing.Point(311, 335);
            this.btnGenerarReporteCliente.Name = "btnGenerarReporteCliente";
            this.btnGenerarReporteCliente.Size = new System.Drawing.Size(105, 35);
            this.btnGenerarReporteCliente.TabIndex = 8;
            this.btnGenerarReporteCliente.Text = "Guardar PDF";
            this.btnGenerarReporteCliente.UseVisualStyleBackColor = true;
            this.btnGenerarReporteCliente.Click += new System.EventHandler(this.btnGenerarReporteCliente_Click);
            // 
            // FormReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 382);
            this.Controls.Add(this.btnGenerarReporteCliente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvDataClientes);
            this.Name = "FormReporte";
            this.Text = "FormReporte";
            this.Load += new System.EventHandler(this.FormReporte_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataClientes)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataClientes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGenerarReporteCliente;
    }
}