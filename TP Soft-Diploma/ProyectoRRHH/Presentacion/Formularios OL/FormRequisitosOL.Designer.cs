namespace Presentacion.Formularios_OL
{
    partial class FormRequisitosOL
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
            this.listRequisitos = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listRequisitos
            // 
            this.listRequisitos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(114)))), ((int)(((byte)(125)))));
            this.listRequisitos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRequisitos.Font = new System.Drawing.Font("Arial Narrow", 12.25F);
            this.listRequisitos.FormattingEnabled = true;
            this.listRequisitos.ItemHeight = 20;
            this.listRequisitos.Location = new System.Drawing.Point(0, 0);
            this.listRequisitos.Name = "listRequisitos";
            this.listRequisitos.Size = new System.Drawing.Size(278, 230);
            this.listRequisitos.TabIndex = 0;
            // 
            // FormRequisitosOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 230);
            this.Controls.Add(this.listRequisitos);
            this.Name = "FormRequisitosOL";
            this.Text = "Requistos de la Oferta Laboral";
            this.Load += new System.EventHandler(this.FormRequisitosOL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listRequisitos;
    }
}