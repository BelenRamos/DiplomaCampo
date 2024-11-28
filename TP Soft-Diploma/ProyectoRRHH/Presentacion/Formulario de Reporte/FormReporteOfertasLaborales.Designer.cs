namespace Presentacion.Formulario_de_Reporte
{
    partial class FormReporteOfertasLaborales
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
            this.btnGenerarReporteOL = new System.Windows.Forms.Button();
            this.lvReportes = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerarReporteOL
            // 
            this.btnGenerarReporteOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReporteOL.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnGenerarReporteOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(119)))), ((int)(((byte)(117)))));
            this.btnGenerarReporteOL.Location = new System.Drawing.Point(140, 253);
            this.btnGenerarReporteOL.Name = "btnGenerarReporteOL";
            this.btnGenerarReporteOL.Size = new System.Drawing.Size(119, 29);
            this.btnGenerarReporteOL.TabIndex = 17;
            this.btnGenerarReporteOL.Text = "Abrir en Excel";
            this.btnGenerarReporteOL.UseVisualStyleBackColor = true;
            this.btnGenerarReporteOL.Click += new System.EventHandler(this.btnGenerarReporteOL_Click);
            // 
            // lvReportes
            // 
            this.lvReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(193)))));
            this.lvReportes.HideSelection = false;
            this.lvReportes.Location = new System.Drawing.Point(12, 57);
            this.lvReportes.Name = "lvReportes";
            this.lvReportes.Size = new System.Drawing.Size(372, 181);
            this.lvReportes.TabIndex = 18;
            this.lvReportes.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 14F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(119)))), ((int)(((byte)(117)))));
            this.label1.Location = new System.Drawing.Point(83, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 23);
            this.label1.TabIndex = 19;
            this.label1.Text = "Reporte de Ofertas Laborales";
            // 
            // FormReporteOfertasLaborales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(400, 312);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvReportes);
            this.Controls.Add(this.btnGenerarReporteOL);
            this.Name = "FormReporteOfertasLaborales";
            this.Text = "FormReporteOfertasLaborales";
            this.Load += new System.EventHandler(this.FormReporteOfertasLaborales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReporteOL;
        private System.Windows.Forms.ListView lvReportes;
        private System.Windows.Forms.Label label1;
    }
}