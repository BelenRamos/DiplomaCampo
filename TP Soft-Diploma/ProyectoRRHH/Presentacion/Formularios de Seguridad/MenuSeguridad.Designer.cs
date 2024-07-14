namespace Presentacion.Formularios_de_Seguridad
{
    partial class MenuSeguridad
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
            this.btnGestionUsuarios = new System.Windows.Forms.Button();
            this.btnGestionGrupos = new System.Windows.Forms.Button();
            this.btnGestionPermisos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGestionUsuarios
            // 
            this.btnGestionUsuarios.BackgroundImage = global::Presentacion.Properties.Resources.icons_usuario;
            this.btnGestionUsuarios.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGestionUsuarios.Location = new System.Drawing.Point(502, 170);
            this.btnGestionUsuarios.Name = "btnGestionUsuarios";
            this.btnGestionUsuarios.Size = new System.Drawing.Size(115, 101);
            this.btnGestionUsuarios.TabIndex = 2;
            this.btnGestionUsuarios.Text = "Usuarios";
            this.btnGestionUsuarios.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionUsuarios.UseVisualStyleBackColor = true;
            this.btnGestionUsuarios.Click += new System.EventHandler(this.btnGestionUsuarios_Click);
            // 
            // btnGestionGrupos
            // 
            this.btnGestionGrupos.BackgroundImage = global::Presentacion.Properties.Resources.icons_grupo;
            this.btnGestionGrupos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGestionGrupos.Location = new System.Drawing.Point(308, 170);
            this.btnGestionGrupos.Name = "btnGestionGrupos";
            this.btnGestionGrupos.Size = new System.Drawing.Size(115, 101);
            this.btnGestionGrupos.TabIndex = 1;
            this.btnGestionGrupos.Text = "Grupos";
            this.btnGestionGrupos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionGrupos.UseVisualStyleBackColor = true;
            this.btnGestionGrupos.Click += new System.EventHandler(this.btnGestionGrupos_Click);
            // 
            // btnGestionPermisos
            // 
            this.btnGestionPermisos.BackgroundImage = global::Presentacion.Properties.Resources.icons_derechos_de_los_usuarios;
            this.btnGestionPermisos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGestionPermisos.Location = new System.Drawing.Point(108, 170);
            this.btnGestionPermisos.Name = "btnGestionPermisos";
            this.btnGestionPermisos.Size = new System.Drawing.Size(122, 101);
            this.btnGestionPermisos.TabIndex = 0;
            this.btnGestionPermisos.Text = "Permisos";
            this.btnGestionPermisos.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGestionPermisos.UseVisualStyleBackColor = true;
            this.btnGestionPermisos.Click += new System.EventHandler(this.btmGestionPermisos);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(303, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Gestiones de Seguridad";
            // 
            // MenuSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(723, 357);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGestionUsuarios);
            this.Controls.Add(this.btnGestionGrupos);
            this.Controls.Add(this.btnGestionPermisos);
            this.Name = "MenuSeguridad";
            this.Text = "MenuSeguridad";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGestionPermisos;
        private System.Windows.Forms.Button btnGestionGrupos;
        private System.Windows.Forms.Button btnGestionUsuarios;
        private System.Windows.Forms.Label label1;
    }
}