namespace Presentacion.Formularios_de_Seguridad.Gestion_de_Usuarios
{
    partial class FormGestionUsuarios
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
            this.dataUsuarios = new System.Windows.Forms.DataGridView();
            this.btnBajaUsuario = new System.Windows.Forms.Button();
            this.btnModificarUsuario = new System.Windows.Forms.Button();
            this.btnAltaUsuario = new System.Windows.Forms.Button();
            this.btnPermisosUsuarios = new System.Windows.Forms.Button();
            this.btnSessionManager = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // dataUsuarios
            // 
            this.dataUsuarios.AllowUserToAddRows = false;
            this.dataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUsuarios.Location = new System.Drawing.Point(177, 44);
            this.dataUsuarios.Name = "dataUsuarios";
            this.dataUsuarios.Size = new System.Drawing.Size(393, 148);
            this.dataUsuarios.TabIndex = 0;
            // 
            // btnBajaUsuario
            // 
            this.btnBajaUsuario.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBajaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaUsuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnBajaUsuario.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnBajaUsuario.Location = new System.Drawing.Point(449, 213);
            this.btnBajaUsuario.Name = "btnBajaUsuario";
            this.btnBajaUsuario.Size = new System.Drawing.Size(121, 33);
            this.btnBajaUsuario.TabIndex = 6;
            this.btnBajaUsuario.Text = "Eliminar";
            this.btnBajaUsuario.UseVisualStyleBackColor = false;
            this.btnBajaUsuario.Click += new System.EventHandler(this.btnBajaUsuario_Click);
            // 
            // btnModificarUsuario
            // 
            this.btnModificarUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarUsuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarUsuario.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarUsuario.Location = new System.Drawing.Point(313, 213);
            this.btnModificarUsuario.Name = "btnModificarUsuario";
            this.btnModificarUsuario.Size = new System.Drawing.Size(121, 33);
            this.btnModificarUsuario.TabIndex = 5;
            this.btnModificarUsuario.Text = "Modificar";
            this.btnModificarUsuario.UseVisualStyleBackColor = true;
            this.btnModificarUsuario.Click += new System.EventHandler(this.btnModificarUsuario_Click);
            // 
            // btnAltaUsuario
            // 
            this.btnAltaUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaUsuario.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAltaUsuario.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAltaUsuario.Location = new System.Drawing.Point(177, 213);
            this.btnAltaUsuario.Name = "btnAltaUsuario";
            this.btnAltaUsuario.Size = new System.Drawing.Size(121, 33);
            this.btnAltaUsuario.TabIndex = 4;
            this.btnAltaUsuario.Text = "Agregar";
            this.btnAltaUsuario.UseVisualStyleBackColor = true;
            this.btnAltaUsuario.Click += new System.EventHandler(this.btnAltaUsuario_Click);
            // 
            // btnPermisosUsuarios
            // 
            this.btnPermisosUsuarios.BackColor = System.Drawing.Color.RosyBrown;
            this.btnPermisosUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPermisosUsuarios.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnPermisosUsuarios.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnPermisosUsuarios.Location = new System.Drawing.Point(23, 62);
            this.btnPermisosUsuarios.Name = "btnPermisosUsuarios";
            this.btnPermisosUsuarios.Size = new System.Drawing.Size(121, 56);
            this.btnPermisosUsuarios.TabIndex = 7;
            this.btnPermisosUsuarios.Text = "Permisos del Usuario";
            this.btnPermisosUsuarios.UseVisualStyleBackColor = false;
            this.btnPermisosUsuarios.Click += new System.EventHandler(this.btnPermisosUsuarios_Click);
            // 
            // btnSessionManager
            // 
            this.btnSessionManager.BackColor = System.Drawing.Color.RosyBrown;
            this.btnSessionManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSessionManager.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnSessionManager.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnSessionManager.Location = new System.Drawing.Point(23, 124);
            this.btnSessionManager.Name = "btnSessionManager";
            this.btnSessionManager.Size = new System.Drawing.Size(121, 56);
            this.btnSessionManager.TabIndex = 8;
            this.btnSessionManager.Text = "Gestion de Sesiones";
            this.btnSessionManager.UseVisualStyleBackColor = false;
            this.btnSessionManager.Click += new System.EventHandler(this.btnSessionManager_Click);
            // 
            // FormGestionUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(601, 277);
            this.Controls.Add(this.btnSessionManager);
            this.Controls.Add(this.btnPermisosUsuarios);
            this.Controls.Add(this.btnBajaUsuario);
            this.Controls.Add(this.btnModificarUsuario);
            this.Controls.Add(this.btnAltaUsuario);
            this.Controls.Add(this.dataUsuarios);
            this.Name = "FormGestionUsuarios";
            this.Text = "FormGestionUsuarios";
            this.Load += new System.EventHandler(this.FormGestionUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataUsuarios;
        private System.Windows.Forms.Button btnBajaUsuario;
        private System.Windows.Forms.Button btnModificarUsuario;
        private System.Windows.Forms.Button btnAltaUsuario;
        private System.Windows.Forms.Button btnPermisosUsuarios;
        private System.Windows.Forms.Button btnSessionManager;
    }
}