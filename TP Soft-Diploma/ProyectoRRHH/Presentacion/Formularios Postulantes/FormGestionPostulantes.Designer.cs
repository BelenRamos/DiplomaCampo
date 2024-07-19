namespace Presentacion
{
    partial class FormGestionPostulantes
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
            this.dgvPostulantes = new System.Windows.Forms.DataGridView();
            this.btnAgregarPostulante = new System.Windows.Forms.Button();
            this.btnModificarPostulante = new System.Windows.Forms.Button();
            this.btnEliminarPostulante = new System.Windows.Forms.Button();
            this.comboCandidatos = new System.Windows.Forms.ComboBox();
            this.btnCandidato = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPostulantes
            // 
            this.dgvPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostulantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPostulantes.Location = new System.Drawing.Point(0, 0);
            this.dgvPostulantes.Name = "dgvPostulantes";
            this.dgvPostulantes.Size = new System.Drawing.Size(523, 221);
            this.dgvPostulantes.TabIndex = 0;
            // 
            // btnAgregarPostulante
            // 
            this.btnAgregarPostulante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPostulante.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPostulante.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarPostulante.Location = new System.Drawing.Point(32, 289);
            this.btnAgregarPostulante.Name = "btnAgregarPostulante";
            this.btnAgregarPostulante.Size = new System.Drawing.Size(121, 33);
            this.btnAgregarPostulante.TabIndex = 1;
            this.btnAgregarPostulante.Text = "Agregar";
            this.btnAgregarPostulante.UseVisualStyleBackColor = true;
            this.btnAgregarPostulante.Click += new System.EventHandler(this.btnAgregarPostulante_Click);
            // 
            // btnModificarPostulante
            // 
            this.btnModificarPostulante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarPostulante.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarPostulante.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarPostulante.Location = new System.Drawing.Point(211, 289);
            this.btnModificarPostulante.Name = "btnModificarPostulante";
            this.btnModificarPostulante.Size = new System.Drawing.Size(121, 33);
            this.btnModificarPostulante.TabIndex = 2;
            this.btnModificarPostulante.Text = "Modificar";
            this.btnModificarPostulante.UseVisualStyleBackColor = true;
            this.btnModificarPostulante.Click += new System.EventHandler(this.btnModificarPostulante_Click);
            // 
            // btnEliminarPostulante
            // 
            this.btnEliminarPostulante.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarPostulante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarPostulante.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarPostulante.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarPostulante.Location = new System.Drawing.Point(390, 347);
            this.btnEliminarPostulante.Name = "btnEliminarPostulante";
            this.btnEliminarPostulante.Size = new System.Drawing.Size(121, 33);
            this.btnEliminarPostulante.TabIndex = 3;
            this.btnEliminarPostulante.Text = "Eliminar";
            this.btnEliminarPostulante.UseVisualStyleBackColor = false;
            this.btnEliminarPostulante.Click += new System.EventHandler(this.btnEliminarPostulante_Click);
            // 
            // comboCandidatos
            // 
            this.comboCandidatos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboCandidatos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.comboCandidatos.ForeColor = System.Drawing.Color.RosyBrown;
            this.comboCandidatos.FormattingEnabled = true;
            this.comboCandidatos.Items.AddRange(new object[] {
            "Candidatos",
            "No candidatos"});
            this.comboCandidatos.Location = new System.Drawing.Point(32, 239);
            this.comboCandidatos.Name = "comboCandidatos";
            this.comboCandidatos.Size = new System.Drawing.Size(121, 28);
            this.comboCandidatos.TabIndex = 4;
            // 
            // btnCandidato
            // 
            this.btnCandidato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCandidato.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnCandidato.ForeColor = System.Drawing.Color.Tan;
            this.btnCandidato.Location = new System.Drawing.Point(390, 289);
            this.btnCandidato.Name = "btnCandidato";
            this.btnCandidato.Size = new System.Drawing.Size(121, 33);
            this.btnCandidato.TabIndex = 5;
            this.btnCandidato.Text = "Candidato";
            this.btnCandidato.UseVisualStyleBackColor = true;
            // 
            // FormGestionPostulantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.btnCandidato);
            this.Controls.Add(this.comboCandidatos);
            this.Controls.Add(this.btnEliminarPostulante);
            this.Controls.Add(this.btnModificarPostulante);
            this.Controls.Add(this.btnAgregarPostulante);
            this.Controls.Add(this.dgvPostulantes);
            this.Name = "FormGestionPostulantes";
            this.Text = "GestionPostulantes";
            this.Load += new System.EventHandler(this.FormGestionPostulantes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPostulantes;
        private System.Windows.Forms.Button btnAgregarPostulante;
        private System.Windows.Forms.Button btnModificarPostulante;
        private System.Windows.Forms.Button btnEliminarPostulante;
        private System.Windows.Forms.ComboBox comboCandidatos;
        private System.Windows.Forms.Button btnCandidato;
    }
}