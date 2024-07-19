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
            this.btnBajaEliminar = new System.Windows.Forms.Button();
            this.btnModificarPermiso = new System.Windows.Forms.Button();
            this.btnAltaPermiso = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treePermisos
            // 
            this.treePermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.treePermisos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treePermisos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.treePermisos.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.treePermisos.Location = new System.Drawing.Point(201, 38);
            this.treePermisos.Name = "treePermisos";
            this.treePermisos.Size = new System.Drawing.Size(299, 320);
            this.treePermisos.TabIndex = 1;
            // 
            // btnBajaEliminar
            // 
            this.btnBajaEliminar.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBajaEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaEliminar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnBajaEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnBajaEliminar.Location = new System.Drawing.Point(40, 149);
            this.btnBajaEliminar.Name = "btnBajaEliminar";
            this.btnBajaEliminar.Size = new System.Drawing.Size(121, 33);
            this.btnBajaEliminar.TabIndex = 9;
            this.btnBajaEliminar.Text = "Eliminar";
            this.btnBajaEliminar.UseVisualStyleBackColor = false;
            // 
            // btnModificarPermiso
            // 
            this.btnModificarPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPermiso.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarPermiso.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarPermiso.Location = new System.Drawing.Point(40, 91);
            this.btnModificarPermiso.Name = "btnModificarPermiso";
            this.btnModificarPermiso.Size = new System.Drawing.Size(121, 33);
            this.btnModificarPermiso.TabIndex = 8;
            this.btnModificarPermiso.Text = "Modificar";
            this.btnModificarPermiso.UseVisualStyleBackColor = true;
            // 
            // btnAltaPermiso
            // 
            this.btnAltaPermiso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaPermiso.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAltaPermiso.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAltaPermiso.Location = new System.Drawing.Point(40, 38);
            this.btnAltaPermiso.Name = "btnAltaPermiso";
            this.btnAltaPermiso.Size = new System.Drawing.Size(121, 33);
            this.btnAltaPermiso.TabIndex = 7;
            this.btnAltaPermiso.Text = "Agregar";
            this.btnAltaPermiso.UseVisualStyleBackColor = true;
            // 
            // FormGestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.btnBajaEliminar);
            this.Controls.Add(this.btnModificarPermiso);
            this.Controls.Add(this.btnAltaPermiso);
            this.Controls.Add(this.treePermisos);
            this.Name = "FormGestionPermisos";
            this.Text = "FormGestionPermisos";
            this.Load += new System.EventHandler(this.FormGestionPermisos_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treePermisos;
        private System.Windows.Forms.Button btnBajaEliminar;
        private System.Windows.Forms.Button btnModificarPermiso;
        private System.Windows.Forms.Button btnAltaPermiso;
    }
}