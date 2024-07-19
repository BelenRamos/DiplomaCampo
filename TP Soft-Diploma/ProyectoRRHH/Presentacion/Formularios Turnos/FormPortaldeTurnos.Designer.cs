namespace Presentacion
{
    partial class FormPortaldeTurnos
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
            this.TabTurnos = new System.Windows.Forms.TabControl();
            this.tabCalendario = new System.Windows.Forms.TabPage();
            this.clndFechas = new System.Windows.Forms.MonthCalendar();
            this.tabDataTurnos = new System.Windows.Forms.TabPage();
            this.dataTurnos = new System.Windows.Forms.DataGridView();
            this.tabDataReuniones = new System.Windows.Forms.TabPage();
            this.dataReuniones = new System.Windows.Forms.DataGridView();
            this.btnEliminarFecha = new System.Windows.Forms.Button();
            this.btnAgendarReunion = new System.Windows.Forms.Button();
            this.btnAgendarTurno = new System.Windows.Forms.Button();
            this.TabTurnos.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            this.tabDataTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTurnos)).BeginInit();
            this.tabDataReuniones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataReuniones)).BeginInit();
            this.SuspendLayout();
            // 
            // TabTurnos
            // 
            this.TabTurnos.Controls.Add(this.tabCalendario);
            this.TabTurnos.Controls.Add(this.tabDataTurnos);
            this.TabTurnos.Controls.Add(this.tabDataReuniones);
            this.TabTurnos.Location = new System.Drawing.Point(12, 12);
            this.TabTurnos.Name = "TabTurnos";
            this.TabTurnos.SelectedIndex = 0;
            this.TabTurnos.Size = new System.Drawing.Size(499, 300);
            this.TabTurnos.TabIndex = 0;
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.clndFechas);
            this.tabCalendario.Location = new System.Drawing.Point(4, 22);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(508, 274);
            this.tabCalendario.TabIndex = 0;
            this.tabCalendario.Text = "Calendario";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // clndFechas
            // 
            this.clndFechas.Location = new System.Drawing.Point(35, 18);
            this.clndFechas.Name = "clndFechas";
            this.clndFechas.TabIndex = 0;
            // 
            // tabDataTurnos
            // 
            this.tabDataTurnos.Controls.Add(this.dataTurnos);
            this.tabDataTurnos.Location = new System.Drawing.Point(4, 22);
            this.tabDataTurnos.Name = "tabDataTurnos";
            this.tabDataTurnos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataTurnos.Size = new System.Drawing.Size(491, 274);
            this.tabDataTurnos.TabIndex = 1;
            this.tabDataTurnos.Text = "Lista de Turnos";
            this.tabDataTurnos.UseVisualStyleBackColor = true;
            // 
            // dataTurnos
            // 
            this.dataTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTurnos.Location = new System.Drawing.Point(3, 3);
            this.dataTurnos.Name = "dataTurnos";
            this.dataTurnos.Size = new System.Drawing.Size(485, 268);
            this.dataTurnos.TabIndex = 0;
            // 
            // tabDataReuniones
            // 
            this.tabDataReuniones.Controls.Add(this.dataReuniones);
            this.tabDataReuniones.Location = new System.Drawing.Point(4, 22);
            this.tabDataReuniones.Name = "tabDataReuniones";
            this.tabDataReuniones.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataReuniones.Size = new System.Drawing.Size(508, 274);
            this.tabDataReuniones.TabIndex = 2;
            this.tabDataReuniones.Text = "Lista de Reuniones";
            this.tabDataReuniones.UseVisualStyleBackColor = true;
            // 
            // dataReuniones
            // 
            this.dataReuniones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataReuniones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataReuniones.Location = new System.Drawing.Point(3, 3);
            this.dataReuniones.Name = "dataReuniones";
            this.dataReuniones.Size = new System.Drawing.Size(502, 268);
            this.dataReuniones.TabIndex = 0;
            // 
            // btnEliminarFecha
            // 
            this.btnEliminarFecha.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarFecha.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarFecha.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarFecha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarFecha.Location = new System.Drawing.Point(383, 330);
            this.btnEliminarFecha.Name = "btnEliminarFecha";
            this.btnEliminarFecha.Size = new System.Drawing.Size(121, 33);
            this.btnEliminarFecha.TabIndex = 9;
            this.btnEliminarFecha.Text = "Eliminar";
            this.btnEliminarFecha.UseVisualStyleBackColor = false;
            this.btnEliminarFecha.Click += new System.EventHandler(this.btnEliminarFecha_Click);
            // 
            // btnAgendarReunion
            // 
            this.btnAgendarReunion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendarReunion.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgendarReunion.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgendarReunion.Location = new System.Drawing.Point(19, 331);
            this.btnAgendarReunion.Name = "btnAgendarReunion";
            this.btnAgendarReunion.Size = new System.Drawing.Size(121, 33);
            this.btnAgendarReunion.TabIndex = 7;
            this.btnAgendarReunion.Text = "Agendar Reunion";
            this.btnAgendarReunion.UseVisualStyleBackColor = true;
            this.btnAgendarReunion.Click += new System.EventHandler(this.btnAgendarReunion_Click);
            // 
            // btnAgendarTurno
            // 
            this.btnAgendarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgendarTurno.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Bold);
            this.btnAgendarTurno.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgendarTurno.Location = new System.Drawing.Point(199, 331);
            this.btnAgendarTurno.Name = "btnAgendarTurno";
            this.btnAgendarTurno.Size = new System.Drawing.Size(121, 33);
            this.btnAgendarTurno.TabIndex = 10;
            this.btnAgendarTurno.Text = "Agendar Turno";
            this.btnAgendarTurno.UseVisualStyleBackColor = true;
            this.btnAgendarTurno.Click += new System.EventHandler(this.btnAgendarTurno_Click);
            // 
            // FormPortaldeTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.btnAgendarTurno);
            this.Controls.Add(this.btnEliminarFecha);
            this.Controls.Add(this.btnAgendarReunion);
            this.Controls.Add(this.TabTurnos);
            this.Name = "FormPortaldeTurnos";
            this.Text = "FormPortaldeTurnos";
            this.Load += new System.EventHandler(this.FormPortaldeTurnos_Load);
            this.TabTurnos.ResumeLayout(false);
            this.tabCalendario.ResumeLayout(false);
            this.tabDataTurnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTurnos)).EndInit();
            this.tabDataReuniones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataReuniones)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabTurnos;
        private System.Windows.Forms.TabPage tabCalendario;
        private System.Windows.Forms.TabPage tabDataTurnos;
        private System.Windows.Forms.MonthCalendar clndFechas;
        private System.Windows.Forms.DataGridView dataTurnos;
        private System.Windows.Forms.Button btnEliminarFecha;
        private System.Windows.Forms.Button btnAgendarReunion;
        private System.Windows.Forms.Button btnAgendarTurno;
        private System.Windows.Forms.TabPage tabDataReuniones;
        private System.Windows.Forms.DataGridView dataReuniones;
    }
}