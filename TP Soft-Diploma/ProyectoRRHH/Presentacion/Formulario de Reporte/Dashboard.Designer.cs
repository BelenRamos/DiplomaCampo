namespace Presentacion.Formulario_de_Reporte
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGenerarReporteCliente = new System.Windows.Forms.Button();
            this.pbClientes = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerarReportePostulante = new System.Windows.Forms.Button();
            this.pbPostulantes = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnGenerarReporteCliente);
            this.panel1.Controls.Add(this.pbClientes);
            this.panel1.Location = new System.Drawing.Point(135, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(496, 121);
            this.panel1.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.label5.Location = new System.Drawing.Point(41, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 23);
            this.label5.TabIndex = 13;
            this.label5.Text = "Clientes en Mentalità";
            // 
            // btnGenerarReporteCliente
            // 
            this.btnGenerarReporteCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporteCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporteCliente.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnGenerarReporteCliente.Location = new System.Drawing.Point(340, 52);
            this.btnGenerarReporteCliente.Name = "btnGenerarReporteCliente";
            this.btnGenerarReporteCliente.Size = new System.Drawing.Size(121, 44);
            this.btnGenerarReporteCliente.TabIndex = 7;
            this.btnGenerarReporteCliente.Text = "Generar Reporte ";
            this.btnGenerarReporteCliente.UseVisualStyleBackColor = true;
            this.btnGenerarReporteCliente.Click += new System.EventHandler(this.btnGenerarReporteCliente_Click);
            // 
            // pbClientes
            // 
            this.pbClientes.Cursor = System.Windows.Forms.Cursors.Default;
            this.pbClientes.Location = new System.Drawing.Point(35, 63);
            this.pbClientes.MarqueeAnimationSpeed = 1;
            this.pbClientes.Name = "pbClientes";
            this.pbClientes.Size = new System.Drawing.Size(258, 23);
            this.pbClientes.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.btnGenerarReportePostulante);
            this.panel2.Controls.Add(this.pbPostulantes);
            this.panel2.Location = new System.Drawing.Point(135, 187);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(496, 121);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(20)))));
            this.label1.Location = new System.Drawing.Point(41, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "Postulantes en Mentalità";
            // 
            // btnGenerarReportePostulante
            // 
            this.btnGenerarReportePostulante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReportePostulante.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReportePostulante.ForeColor = System.Drawing.Color.SaddleBrown;
            this.btnGenerarReportePostulante.Location = new System.Drawing.Point(340, 52);
            this.btnGenerarReportePostulante.Name = "btnGenerarReportePostulante";
            this.btnGenerarReportePostulante.Size = new System.Drawing.Size(121, 44);
            this.btnGenerarReportePostulante.TabIndex = 7;
            this.btnGenerarReportePostulante.Text = "Generar Reporte ";
            this.btnGenerarReportePostulante.UseVisualStyleBackColor = true;
            this.btnGenerarReportePostulante.Click += new System.EventHandler(this.btnGenerarReportePostulante_Click);
            // 
            // pbPostulantes
            // 
            this.pbPostulantes.Location = new System.Drawing.Point(35, 63);
            this.pbPostulantes.Name = "pbPostulantes";
            this.pbPostulantes.Size = new System.Drawing.Size(258, 23);
            this.pbPostulantes.TabIndex = 0;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 320);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pbClientes;
        private System.Windows.Forms.Button btnGenerarReporteCliente;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnGenerarReportePostulante;
        private System.Windows.Forms.ProgressBar pbPostulantes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
    }
}