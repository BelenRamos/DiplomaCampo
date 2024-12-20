﻿namespace Presentacion.Formularios_OL
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
            this.btnEliminarOL = new System.Windows.Forms.Button();
            this.btnModificarOL = new System.Windows.Forms.Button();
            this.btnAgregarOL = new System.Windows.Forms.Button();
            this.btnSeleccionCandidato = new System.Windows.Forms.Button();
            this.btnRequistosOl = new System.Windows.Forms.Button();
            this.btnPerfilar = new System.Windows.Forms.Button();
            this.dgvOfertasLaborales = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertasLaborales)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEliminarOL
            // 
            this.btnEliminarOL.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarOL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarOL.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarOL.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarOL.Location = new System.Drawing.Point(45, 271);
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
            this.btnModificarOL.Location = new System.Drawing.Point(45, 232);
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
            this.btnAgregarOL.Location = new System.Drawing.Point(45, 190);
            this.btnAgregarOL.Name = "btnAgregarOL";
            this.btnAgregarOL.Size = new System.Drawing.Size(121, 33);
            this.btnAgregarOL.TabIndex = 6;
            this.btnAgregarOL.Text = "Agregar";
            this.btnAgregarOL.UseVisualStyleBackColor = true;
            this.btnAgregarOL.Click += new System.EventHandler(this.btnAgregarOL_Click);
            // 
            // btnSeleccionCandidato
            // 
            this.btnSeleccionCandidato.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionCandidato.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionCandidato.ForeColor = System.Drawing.Color.Tan;
            this.btnSeleccionCandidato.Location = new System.Drawing.Point(390, 246);
            this.btnSeleccionCandidato.Name = "btnSeleccionCandidato";
            this.btnSeleccionCandidato.Size = new System.Drawing.Size(121, 25);
            this.btnSeleccionCandidato.TabIndex = 11;
            this.btnSeleccionCandidato.Text = "Seleccion";
            this.btnSeleccionCandidato.UseVisualStyleBackColor = true;
            this.btnSeleccionCandidato.Click += new System.EventHandler(this.btnSeleccionCandidato_Click);
            // 
            // btnRequistosOl
            // 
            this.btnRequistosOl.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRequistosOl.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.btnRequistosOl.ForeColor = System.Drawing.Color.CadetBlue;
            this.btnRequistosOl.Location = new System.Drawing.Point(390, 190);
            this.btnRequistosOl.Name = "btnRequistosOl";
            this.btnRequistosOl.Size = new System.Drawing.Size(121, 32);
            this.btnRequistosOl.TabIndex = 12;
            this.btnRequistosOl.Text = "Requisitos";
            this.btnRequistosOl.UseVisualStyleBackColor = true;
            this.btnRequistosOl.Click += new System.EventHandler(this.btnRequistosOl_Click);
            // 
            // btnPerfilar
            // 
            this.btnPerfilar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPerfilar.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPerfilar.ForeColor = System.Drawing.Color.Tan;
            this.btnPerfilar.Location = new System.Drawing.Point(390, 277);
            this.btnPerfilar.Name = "btnPerfilar";
            this.btnPerfilar.Size = new System.Drawing.Size(121, 27);
            this.btnPerfilar.TabIndex = 13;
            this.btnPerfilar.Text = "Asignar Perfil";
            this.btnPerfilar.UseVisualStyleBackColor = true;
            this.btnPerfilar.Click += new System.EventHandler(this.btnPerfilar_Click);
            // 
            // dgvOfertasLaborales
            // 
            this.dgvOfertasLaborales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOfertasLaborales.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvOfertasLaborales.Location = new System.Drawing.Point(0, 0);
            this.dgvOfertasLaborales.Name = "dgvOfertasLaborales";
            this.dgvOfertasLaborales.Size = new System.Drawing.Size(523, 173);
            this.dgvOfertasLaborales.TabIndex = 14;
            // 
            // FormGestionOL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 329);
            this.Controls.Add(this.dgvOfertasLaborales);
            this.Controls.Add(this.btnPerfilar);
            this.Controls.Add(this.btnRequistosOl);
            this.Controls.Add(this.btnSeleccionCandidato);
            this.Controls.Add(this.btnEliminarOL);
            this.Controls.Add(this.btnModificarOL);
            this.Controls.Add(this.btnAgregarOL);
            this.Name = "FormGestionOL";
            this.Text = "FormGestionOL";
            this.Load += new System.EventHandler(this.FormGestionOL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOfertasLaborales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnEliminarOL;
        private System.Windows.Forms.Button btnModificarOL;
        private System.Windows.Forms.Button btnAgregarOL;
        private System.Windows.Forms.Button btnSeleccionCandidato;
        private System.Windows.Forms.Button btnRequistosOl;
        private System.Windows.Forms.Button btnPerfilar;
        private System.Windows.Forms.DataGridView dgvOfertasLaborales;
    }
}