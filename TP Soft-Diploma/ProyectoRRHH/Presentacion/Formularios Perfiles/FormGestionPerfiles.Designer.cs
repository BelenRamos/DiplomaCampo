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
            this.btnEliminarPerfil = new System.Windows.Forms.Button();
            this.btnModificarPerfil = new System.Windows.Forms.Button();
            this.btnAgregarPerfil = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listaPerfiles
            // 
            this.listaPerfiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(152)))), ((int)(((byte)(214)))));
            this.listaPerfiles.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaPerfiles.Font = new System.Drawing.Font("Arial", 12F);
            this.listaPerfiles.FormattingEnabled = true;
            this.listaPerfiles.ItemHeight = 18;
            this.listaPerfiles.Location = new System.Drawing.Point(293, 12);
            this.listaPerfiles.Name = "listaPerfiles";
            this.listaPerfiles.Size = new System.Drawing.Size(218, 360);
            this.listaPerfiles.TabIndex = 0;
            // 
            // btnEliminarPerfil
            // 
            this.btnEliminarPerfil.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPerfil.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarPerfil.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarPerfil.Location = new System.Drawing.Point(81, 235);
            this.btnEliminarPerfil.Name = "btnEliminarPerfil";
            this.btnEliminarPerfil.Size = new System.Drawing.Size(121, 33);
            this.btnEliminarPerfil.TabIndex = 11;
            this.btnEliminarPerfil.Text = "Eliminar Perfil";
            this.btnEliminarPerfil.UseVisualStyleBackColor = false;
            this.btnEliminarPerfil.Click += new System.EventHandler(this.btnEliminarPerfil_Click);
            // 
            // btnModificarPerfil
            // 
            this.btnModificarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPerfil.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarPerfil.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarPerfil.Location = new System.Drawing.Point(81, 174);
            this.btnModificarPerfil.Name = "btnModificarPerfil";
            this.btnModificarPerfil.Size = new System.Drawing.Size(121, 33);
            this.btnModificarPerfil.TabIndex = 10;
            this.btnModificarPerfil.Text = "Modificar Perfil";
            this.btnModificarPerfil.UseVisualStyleBackColor = true;
            this.btnModificarPerfil.Click += new System.EventHandler(this.btnModificarPerfil_Click);
            // 
            // btnAgregarPerfil
            // 
            this.btnAgregarPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPerfil.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPerfil.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarPerfil.Location = new System.Drawing.Point(81, 78);
            this.btnAgregarPerfil.Name = "btnAgregarPerfil";
            this.btnAgregarPerfil.Size = new System.Drawing.Size(121, 70);
            this.btnAgregarPerfil.TabIndex = 9;
            this.btnAgregarPerfil.Text = "Crear Nuevo Perfil";
            this.btnAgregarPerfil.UseVisualStyleBackColor = true;
            this.btnAgregarPerfil.Click += new System.EventHandler(this.btnAgregarPerfil_Click);
            // 
            // FormGestionPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.btnEliminarPerfil);
            this.Controls.Add(this.btnModificarPerfil);
            this.Controls.Add(this.btnAgregarPerfil);
            this.Controls.Add(this.listaPerfiles);
            this.Name = "FormGestionPerfiles";
            this.Text = "FormGestionPerfiles";
            this.Load += new System.EventHandler(this.FormGestionPerfiles_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listaPerfiles;
        private System.Windows.Forms.Button btnEliminarPerfil;
        private System.Windows.Forms.Button btnModificarPerfil;
        private System.Windows.Forms.Button btnAgregarPerfil;
    }
}