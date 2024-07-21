namespace Presentacion.Formularios_Perfiles
{
    partial class FormGestionPerfiles
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
            this.listaPerfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(152)))), ((int)(((byte)(214)))));
            this.listaPerfiles.Dock = System.Windows.Forms.DockStyle.Right;
            this.listaPerfiles.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaPerfiles.FormattingEnabled = true;
            this.listaPerfiles.ItemHeight = 24;
            this.listaPerfiles.Location = new System.Drawing.Point(305, 0);
            this.listaPerfiles.Name = "listaPerfiles";
            this.listaPerfiles.Size = new System.Drawing.Size(218, 392);
            this.listaPerfiles.TabIndex = 0;
            // 
            // FormGestionPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.listaPerfiles);
            this.Name = "FormGestionPerfiles";
            this.Text = "FormGestionPerfiles";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaPerfiles;
    }
}