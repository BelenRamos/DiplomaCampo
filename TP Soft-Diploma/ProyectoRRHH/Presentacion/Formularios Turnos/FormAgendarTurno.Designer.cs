namespace Presentacion.Formularios_Turnos
{
    partial class FormAgendarTurno
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
            this.calenderAgenda = new System.Windows.Forms.MonthCalendar();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.cbHorarios = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // calenderAgenda
            // 
            this.calenderAgenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.calenderAgenda.Location = new System.Drawing.Point(0, 0);
            this.calenderAgenda.Name = "calenderAgenda";
            this.calenderAgenda.TabIndex = 2;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnGuardar.Location = new System.Drawing.Point(0, 206);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(247, 35);
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar ";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // cbHorarios
            // 
            this.cbHorarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbHorarios.FormattingEnabled = true;
            this.cbHorarios.Location = new System.Drawing.Point(0, 162);
            this.cbHorarios.Name = "cbHorarios";
            this.cbHorarios.Size = new System.Drawing.Size(247, 21);
            this.cbHorarios.TabIndex = 3;
            // 
            // FormAgendarTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(247, 241);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cbHorarios);
            this.Controls.Add(this.calenderAgenda);
            this.Name = "FormAgendarTurno";
            this.Text = "Agendar Turno";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MonthCalendar calenderAgenda;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox cbHorarios;
    }
}