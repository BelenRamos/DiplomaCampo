namespace Presentacion.Formularios_de_Seguridad.Gestion_Grupos
{
    partial class FormGestionGrupos
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
            this.dataGrupos = new System.Windows.Forms.DataGridView();
            this.btnBajaGrupos = new System.Windows.Forms.Button();
            this.btnModificarGrupos = new System.Windows.Forms.Button();
            this.btnAltaGrupos = new System.Windows.Forms.Button();
            this.treeGrupos = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrupos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGrupos
            // 
            this.dataGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrupos.Location = new System.Drawing.Point(12, 34);
            this.dataGrupos.Name = "dataGrupos";
            this.dataGrupos.Size = new System.Drawing.Size(384, 206);
            this.dataGrupos.TabIndex = 0;
            // 
            // btnBajaGrupos
            // 
            this.btnBajaGrupos.BackColor = System.Drawing.Color.RosyBrown;
            this.btnBajaGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBajaGrupos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnBajaGrupos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnBajaGrupos.Location = new System.Drawing.Point(450, 174);
            this.btnBajaGrupos.Name = "btnBajaGrupos";
            this.btnBajaGrupos.Size = new System.Drawing.Size(121, 33);
            this.btnBajaGrupos.TabIndex = 12;
            this.btnBajaGrupos.Text = "Eliminar";
            this.btnBajaGrupos.UseVisualStyleBackColor = false;
            this.btnBajaGrupos.Click += new System.EventHandler(this.btnBajaGrupos_Click);
            // 
            // btnModificarGrupos
            // 
            this.btnModificarGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarGrupos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarGrupos.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarGrupos.Location = new System.Drawing.Point(450, 119);
            this.btnModificarGrupos.Name = "btnModificarGrupos";
            this.btnModificarGrupos.Size = new System.Drawing.Size(121, 33);
            this.btnModificarGrupos.TabIndex = 11;
            this.btnModificarGrupos.Text = "Modificar";
            this.btnModificarGrupos.UseVisualStyleBackColor = true;
            this.btnModificarGrupos.Click += new System.EventHandler(this.btnModificarGrupos_Click);
            // 
            // btnAltaGrupos
            // 
            this.btnAltaGrupos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAltaGrupos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAltaGrupos.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAltaGrupos.Location = new System.Drawing.Point(450, 62);
            this.btnAltaGrupos.Name = "btnAltaGrupos";
            this.btnAltaGrupos.Size = new System.Drawing.Size(121, 33);
            this.btnAltaGrupos.TabIndex = 10;
            this.btnAltaGrupos.Text = "Agregar";
            this.btnAltaGrupos.UseVisualStyleBackColor = true;
            this.btnAltaGrupos.Click += new System.EventHandler(this.btnAltaGrupos_Click);
            // 
            // treeGrupos
            // 
            this.treeGrupos.BackColor = System.Drawing.SystemColors.ControlLight;
            this.treeGrupos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeGrupos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.treeGrupos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.treeGrupos.Location = new System.Drawing.Point(48, 246);
            this.treeGrupos.Name = "treeGrupos";
            this.treeGrupos.Size = new System.Drawing.Size(281, 111);
            this.treeGrupos.TabIndex = 13;
            // 
            // FormGestionGrupos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(626, 399);
            this.Controls.Add(this.treeGrupos);
            this.Controls.Add(this.btnBajaGrupos);
            this.Controls.Add(this.btnModificarGrupos);
            this.Controls.Add(this.btnAltaGrupos);
            this.Controls.Add(this.dataGrupos);
            this.Name = "FormGestionGrupos";
            this.Text = "FormGestionGrupos";
            this.Load += new System.EventHandler(this.FormGestionGrupos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrupos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGrupos;
        private System.Windows.Forms.Button btnBajaGrupos;
        private System.Windows.Forms.Button btnModificarGrupos;
        private System.Windows.Forms.Button btnAltaGrupos;
        private System.Windows.Forms.TreeView treeGrupos;
    }
}