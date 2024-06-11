namespace Presentacion.Formularios_OL
{
    partial class FormGestionOL
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
            this.dgvOfertasLaborales = new System.Windows.Forms.DataGridView();
            this.btnPublicar = new System.Windows.Forms.Button();
            this.comboPerfiles = new System.Windows.Forms.ComboBox();
            this.btnEliminarOL = new System.Windows.Forms.Button();
            this.btnModificarOL = new System.Windows.Forms.Button();
            this.btnAgregarOL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertasLaborales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOfertasLaborales
            // 
            this.dgvOfertasLaborales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertasLaborales.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvOfertasLaborales.Location = new System.Drawing.Point(0, 0);
            this.dgvOfertasLaborales.Name = "dgvOfertasLaborales";
            this.dgvOfertasLaborales.Size = new System.Drawing.Size(786, 301);
            this.dgvOfertasLaborales.TabIndex = 0;
            // 
            // btnPublicar
            // 
            this.btnPublicar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPublicar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnPublicar.ForeColor = System.Drawing.Color.Tan;
            this.btnPublicar.Location = new System.Drawing.Point(825, 213);
            this.btnPublicar.Name = "btnPublicar";
            this.btnPublicar.Size = new System.Drawing.Size(121, 33);
            this.btnPublicar.TabIndex = 10;
            this.btnPublicar.Text = "Publicar";
            this.btnPublicar.UseVisualStyleBackColor = true;
            // 
            // comboPerfiles
            // 
            this.comboPerfiles.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboPerfiles.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.comboPerfiles.ForeColor = System.Drawing.Color.RosyBrown;
            this.comboPerfiles.FormattingEnabled = true;
            this.comboPerfiles.Items.AddRange(new object[] {
            "Candidatos",
            "No candidatos"});
            this.comboPerfiles.Location = new System.Drawing.Point(825, 39);
            this.comboPerfiles.Name = "comboPerfiles";
            this.comboPerfiles.Size = new System.Drawing.Size(121, 28);
            this.comboPerfiles.TabIndex = 9;
            // 
            // btnEliminarOL
            // 
            this.btnEliminarOL.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarOL.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarOL.Location = new System.Drawing.Point(825, 174);
            this.btnEliminarOL.Name = "btnEliminarOL";
            this.btnEliminarOL.Size = new System.Drawing.Size(121, 33);
            this.btnEliminarOL.TabIndex = 8;
            this.btnEliminarOL.Text = "Eliminar";
            this.btnEliminarOL.UseVisualStyleBackColor = false;
            this.btnEliminarOL.Click += new System.EventHandler(this.btnEliminarOL_Click);
            // 
            // btnModificarOL
            // 
            this.btnModificarOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarOL.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarOL.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarOL.Location = new System.Drawing.Point(825, 135);
            this.btnModificarOL.Name = "btnModificarOL";
            this.btnModificarOL.Size = new System.Drawing.Size(121, 33);
            this.btnModificarOL.TabIndex = 7;
            this.btnModificarOL.Text = "Modificar";
            this.btnModificarOL.UseVisualStyleBackColor = true;
            this.btnModificarOL.Click += new System.EventHandler(this.btnModificarOL_Click);
            // 
            // btnAgregarOL
            // 
            this.btnAgregarOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarOL.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarOL.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarOL.Location = new System.Drawing.Point(825, 96);
            this.btnAgregarOL.Name = "btnAgregarOL";
            this.btnAgregarOL.Size = new System.Drawing.Size(121, 33);
            this.btnAgregarOL.TabIndex = 6;
            this.btnAgregarOL.Text = "Agregar";
            this.btnAgregarOL.UseVisualStyleBackColor = true;
            this.btnAgregarOL.Click += new System.EventHandler(this.btnAgregarOL_Click);
            // 
            // FormGestionOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(968, 301);
            this.Controls.Add(this.btnPublicar);
            this.Controls.Add(this.comboPerfiles);
            this.Controls.Add(this.btnEliminarOL);
            this.Controls.Add(this.btnModificarOL);
            this.Controls.Add(this.btnAgregarOL);
            this.Controls.Add(this.dgvOfertasLaborales);
            this.Name = "FormGestionOL";
            this.Text = "FormGestionOL";
            this.Load += new System.EventHandler(this.FormGestionOL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertasLaborales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOfertasLaborales;
        private System.Windows.Forms.Button btnPublicar;
        private System.Windows.Forms.ComboBox comboPerfiles;
        private System.Windows.Forms.Button btnEliminarOL;
        private System.Windows.Forms.Button btnModificarOL;
        private System.Windows.Forms.Button btnAgregarOL;
    }
}