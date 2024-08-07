﻿namespace Presentacion
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostulantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPostulantes
            // 
            this.dgvPostulantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostulantes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvPostulantes.Location = new System.Drawing.Point(0, 0);
            this.dgvPostulantes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvPostulantes.Name = "dgvPostulantes";
            this.dgvPostulantes.Size = new System.Drawing.Size(523, 238);
            this.dgvPostulantes.TabIndex = 0;
            // 
            // btnAgregarPostulante
            // 
            this.btnAgregarPostulante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarPostulante.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarPostulante.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarPostulante.Location = new System.Drawing.Point(37, 311);
            this.btnAgregarPostulante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAgregarPostulante.Name = "btnAgregarPostulante";
            this.btnAgregarPostulante.Size = new System.Drawing.Size(141, 36);
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
            this.btnModificarPostulante.Location = new System.Drawing.Point(201, 311);
            this.btnModificarPostulante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnModificarPostulante.Name = "btnModificarPostulante";
            this.btnModificarPostulante.Size = new System.Drawing.Size(141, 36);
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
            this.btnEliminarPostulante.Location = new System.Drawing.Point(369, 311);
            this.btnEliminarPostulante.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnEliminarPostulante.Name = "btnEliminarPostulante";
            this.btnEliminarPostulante.Size = new System.Drawing.Size(141, 36);
            this.btnEliminarPostulante.TabIndex = 3;
            this.btnEliminarPostulante.Text = "Eliminar";
            this.btnEliminarPostulante.UseVisualStyleBackColor = false;
            this.btnEliminarPostulante.Click += new System.EventHandler(this.btnEliminarPostulante_Click);
            // 
            // comboCandidatos
            // 
            this.comboCandidatos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboCandidatos.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.comboCandidatos.ForeColor = System.Drawing.Color.Black;
            this.comboCandidatos.FormattingEnabled = true;
            this.comboCandidatos.Location = new System.Drawing.Point(37, 257);
            this.comboCandidatos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboCandidatos.Name = "comboCandidatos";
            this.comboCandidatos.Size = new System.Drawing.Size(140, 28);
            this.comboCandidatos.TabIndex = 4;
            // 
            // FormGestionPostulantes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.comboCandidatos);
            this.Controls.Add(this.btnEliminarPostulante);
            this.Controls.Add(this.btnModificarPostulante);
            this.Controls.Add(this.btnAgregarPostulante);
            this.Controls.Add(this.dgvPostulantes);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FormGestionPostulantes";
            this.Text = "Gestion de Postulantes";
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
    }
}