namespace Presentacion.Formularios_de_Seguridad
{
    partial class FormGestionPermisos
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
            this.treePermisos = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // treePermisos
            // 
            this.treePermisos.Location = new System.Drawing.Point(173, 12);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(318, 265);
            this.treePermisos.TabIndex = 1;
            // 
            // FormGestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 333);
            this.Controls.Add(this.treePermisos);
            this.Name = "FormGestionPermisos";
            this.Text = "FormGestionPermisos";
            this.Load += new System.EventHandler(this.FormGestionPermisos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treePermisos;
    }
}