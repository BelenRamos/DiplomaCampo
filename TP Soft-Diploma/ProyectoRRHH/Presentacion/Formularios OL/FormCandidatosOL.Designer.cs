namespace Presentacion.Formularios_OL
{
    partial class FormCandidatosOL
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
            this.listaCandidatos = new System.Windows.Forms.ListView();
            this.btnSeleccionCandidato = new System.Windows.Forms.Button();
            this.btnPreseleccion = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listaCandidatos
            // 
            this.listaCandidatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(230)))), ((int)(((byte)(195)))));
            this.listaCandidatos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listaCandidatos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaCandidatos.HideSelection = false;
            this.listaCandidatos.Location = new System.Drawing.Point(205, 12);
            this.listaCandidatos.Name = "listaCandidatos";
            this.listaCandidatos.Size = new System.Drawing.Size(310, 143);
            this.listaCandidatos.TabIndex = 0;
            this.listaCandidatos.UseCompatibleStateImageBehavior = false;
            // 
            // btnSeleccionCandidato
            // 
            this.btnSeleccionCandidato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionCandidato.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnSeleccionCandidato.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(193)))));
            this.btnSeleccionCandidato.Location = new System.Drawing.Point(12, 63);
            this.btnSeleccionCandidato.Name = "btnSeleccionCandidato";
            this.btnSeleccionCandidato.Size = new System.Drawing.Size(171, 33);
            this.btnSeleccionCandidato.TabIndex = 13;
            this.btnSeleccionCandidato.Text = "Seleccionar Postulante";
            this.btnSeleccionCandidato.UseVisualStyleBackColor = true;
            this.btnSeleccionCandidato.Click += new System.EventHandler(this.btnSeleccionCandidato_Click);
            // 
            // btnPreseleccion
            // 
            this.btnPreseleccion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreseleccion.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnPreseleccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(193)))));
            this.btnPreseleccion.Location = new System.Drawing.Point(12, 24);
            this.btnPreseleccion.Name = "btnPreseleccion";
            this.btnPreseleccion.Size = new System.Drawing.Size(171, 33);
            this.btnPreseleccion.TabIndex = 12;
            this.btnPreseleccion.Text = "Re-hacer preseleccion";
            this.btnPreseleccion.UseVisualStyleBackColor = true;
            this.btnPreseleccion.Click += new System.EventHandler(this.btnPreseleccion_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(196)))), ((int)(((byte)(193)))));
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCerrar.Location = new System.Drawing.Point(12, 102);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(171, 33);
            this.btnCerrar.TabIndex = 14;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // FormCandidatosOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(528, 170);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnSeleccionCandidato);
            this.Controls.Add(this.btnPreseleccion);
            this.Controls.Add(this.listaCandidatos);
            this.Name = "FormCandidatosOL";
            this.Text = "FormPostulantesOL";
            this.Load += new System.EventHandler(this.FormPostulantesOL_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listaCandidatos;
        private System.Windows.Forms.Button btnSeleccionCandidato;
        private System.Windows.Forms.Button btnPreseleccion;
        private System.Windows.Forms.Button btnCerrar;
    }
}