namespace Presentacion.Formularios_OL
{
    partial class FormPerfilarOL
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
            this.listaPerfiles = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listaPerfiles
            // 
            this.listaPerfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.listaPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaPerfiles.Font = new System.Drawing.Font("Arial", 12F);
            this.listaPerfiles.FormattingEnabled = true;
            this.listaPerfiles.ItemHeight = 18;
            this.listaPerfiles.Location = new System.Drawing.Point(243, 12);
            this.listaPerfiles.Name = "listaPerfiles";
            this.listaPerfiles.Size = new System.Drawing.Size(218, 126);
            this.listaPerfiles.TabIndex = 1;
            // 
            // FormPerfilarOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(473, 168);
            this.Controls.Add(this.listaPerfiles);
            this.Name = "FormPerfilarOL";
            this.Text = "PerfilarOL";
            this.Load += new System.EventHandler(this.FormPerfilarOL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaPerfiles;
    }
}