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
            this.tabDataTurnos = new System.Windows.Forms.TabPage();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dataTunos = new System.Windows.Forms.DataGridView();
            this.TabTurnos.SuspendLayout();
            this.tabCalendario.SuspendLayout();
            this.tabDataTurnos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTunos)).BeginInit();
            this.SuspendLayout();
            // 
            // TabTurnos
            // 
            this.TabTurnos.Controls.Add(this.tabCalendario);
            this.TabTurnos.Controls.Add(this.tabDataTurnos);
            this.TabTurnos.Location = new System.Drawing.Point(-1, 51);
            this.TabTurnos.Name = "TabTurnos";
            this.TabTurnos.SelectedIndex = 0;
            this.TabTurnos.Size = new System.Drawing.Size(516, 300);
            this.TabTurnos.TabIndex = 0;
            // 
            // tabCalendario
            // 
            this.tabCalendario.Controls.Add(this.monthCalendar1);
            this.tabCalendario.Location = new System.Drawing.Point(4, 22);
            this.tabCalendario.Name = "tabCalendario";
            this.tabCalendario.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendario.Size = new System.Drawing.Size(508, 274);
            this.tabCalendario.TabIndex = 0;
            this.tabCalendario.Text = "Calendario";
            this.tabCalendario.UseVisualStyleBackColor = true;
            // 
            // tabDataTurnos
            // 
            this.tabDataTurnos.Controls.Add(this.dataTunos);
            this.tabDataTurnos.Location = new System.Drawing.Point(4, 22);
            this.tabDataTurnos.Name = "tabDataTurnos";
            this.tabDataTurnos.Padding = new System.Windows.Forms.Padding(3);
            this.tabDataTurnos.Size = new System.Drawing.Size(508, 274);
            this.tabDataTurnos.TabIndex = 1;
            this.tabDataTurnos.Text = "Lista de Turnos";
            this.tabDataTurnos.UseVisualStyleBackColor = true;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.CalendarDimensions = new System.Drawing.Size(2, 1);
            this.monthCalendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar1.Location = new System.Drawing.Point(3, 3);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 0;
            // 
            // dataTunos
            // 
            this.dataTunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataTunos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataTunos.Location = new System.Drawing.Point(3, 3);
            this.dataTunos.Name = "dataTunos";
            this.dataTunos.Size = new System.Drawing.Size(502, 268);
            this.dataTunos.TabIndex = 0;
            // 
            // FormPortaldeTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(721, 347);
            this.Controls.Add(this.TabTurnos);
            this.Name = "FormPortaldeTurnos";
            this.Text = "FormPortaldeTurnos";
            this.TabTurnos.ResumeLayout(false);
            this.tabCalendario.ResumeLayout(false);
            this.tabDataTurnos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataTunos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TabTurnos;
        private System.Windows.Forms.TabPage tabCalendario;
        private System.Windows.Forms.TabPage tabDataTurnos;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dataTunos;
    }
}