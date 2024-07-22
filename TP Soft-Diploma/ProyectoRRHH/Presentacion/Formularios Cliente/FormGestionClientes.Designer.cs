namespace Presentacion
{
    partial class FormGestionClientes
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataClientes = new System.Windows.Forms.DataGridView();
            this.btnEliminarCliente = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnAgregarCliente = new System.Windows.Forms.Button();
            this.tabClientes = new System.Windows.Forms.TabControl();
            this.tabGestioanr = new System.Windows.Forms.TabPage();
            this.tabMensajes = new System.Windows.Forms.TabPage();
            this.dgvMensajes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).BeginInit();
            this.tabClientes.SuspendLayout();
            this.tabGestioanr.SuspendLayout();
            this.tabMensajes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).BeginInit();
            this.SuspendLayout();
            // 
            // dataClientes
            // 
            this.dataClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataClientes.Location = new System.Drawing.Point(3, 3);
            this.dataClientes.Name = "dataClientes";
            this.dataClientes.Size = new System.Drawing.Size(509, 224);
            this.dataClientes.TabIndex = 0;
            // 
            // btnEliminarCliente
            // 
            this.btnEliminarCliente.BackColor = System.Drawing.Color.RosyBrown;
            this.btnEliminarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnEliminarCliente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.btnEliminarCliente.Location = new System.Drawing.Point(349, 277);
            this.btnEliminarCliente.Name = "btnEliminarCliente";
            this.btnEliminarCliente.Size = new System.Drawing.Size(121, 33);
            this.btnEliminarCliente.TabIndex = 8;
            this.btnEliminarCliente.Text = "Eliminar";
            this.btnEliminarCliente.UseVisualStyleBackColor = false;
            this.btnEliminarCliente.Click += new System.EventHandler(this.btnEliminarCliente_Click);
            // 
            // btnModificarCliente
            // 
            this.btnModificarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnModificarCliente.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnModificarCliente.Location = new System.Drawing.Point(202, 277);
            this.btnModificarCliente.Name = "btnModificarCliente";
            this.btnModificarCliente.Size = new System.Drawing.Size(121, 33);
            this.btnModificarCliente.TabIndex = 7;
            this.btnModificarCliente.Text = "Modificar";
            this.btnModificarCliente.UseVisualStyleBackColor = true;
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);
            // 
            // btnAgregarCliente
            // 
            this.btnAgregarCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarCliente.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold);
            this.btnAgregarCliente.ForeColor = System.Drawing.Color.RosyBrown;
            this.btnAgregarCliente.Location = new System.Drawing.Point(51, 277);
            this.btnAgregarCliente.Name = "btnAgregarCliente";
            this.btnAgregarCliente.Size = new System.Drawing.Size(121, 33);
            this.btnAgregarCliente.TabIndex = 6;
            this.btnAgregarCliente.Text = "Agregar";
            this.btnAgregarCliente.UseVisualStyleBackColor = true;
            this.btnAgregarCliente.Click += new System.EventHandler(this.btnAgregarCliente_Click);
            // 
            // tabClientes
            // 
            this.tabClientes.Controls.Add(this.tabGestioanr);
            this.tabClientes.Controls.Add(this.tabMensajes);
            this.tabClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabClientes.Font = new System.Drawing.Font("Arial Narrow", 9F, System.Drawing.FontStyle.Bold);
            this.tabClientes.Location = new System.Drawing.Point(0, 0);
            this.tabClientes.Name = "tabClientes";
            this.tabClientes.SelectedIndex = 0;
            this.tabClientes.Size = new System.Drawing.Size(523, 392);
            this.tabClientes.TabIndex = 9;
            // 
            // tabGestioanr
            // 
            this.tabGestioanr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(71)))), ((int)(((byte)(100)))));
            this.tabGestioanr.Controls.Add(this.dataClientes);
            this.tabGestioanr.Controls.Add(this.btnEliminarCliente);
            this.tabGestioanr.Controls.Add(this.btnAgregarCliente);
            this.tabGestioanr.Controls.Add(this.btnModificarCliente);
            this.tabGestioanr.Location = new System.Drawing.Point(4, 25);
            this.tabGestioanr.Name = "tabGestioanr";
            this.tabGestioanr.Padding = new System.Windows.Forms.Padding(3);
            this.tabGestioanr.Size = new System.Drawing.Size(515, 363);
            this.tabGestioanr.TabIndex = 0;
            this.tabGestioanr.Text = "Gestiones de clientes";
            // 
            // tabMensajes
            // 
            this.tabMensajes.Controls.Add(this.dgvMensajes);
            this.tabMensajes.Location = new System.Drawing.Point(4, 22);
            this.tabMensajes.Name = "tabMensajes";
            this.tabMensajes.Padding = new System.Windows.Forms.Padding(3);
            this.tabMensajes.Size = new System.Drawing.Size(515, 366);
            this.tabMensajes.TabIndex = 1;
            this.tabMensajes.Text = "Bandeja de mensajes";
            this.tabMensajes.UseVisualStyleBackColor = true;
            // 
            // dgvMensajes
            // 
            this.dgvMensajes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMensajes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMensajes.Location = new System.Drawing.Point(3, 3);
            this.dgvMensajes.Name = "dgvMensajes";
            this.dgvMensajes.Size = new System.Drawing.Size(509, 360);
            this.dgvMensajes.TabIndex = 0;
            // 
            // FormGestionClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(62)))));
            this.ClientSize = new System.Drawing.Size(523, 392);
            this.Controls.Add(this.tabClientes);
            this.Name = "FormGestionClientes";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormGestionClientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataClientes)).EndInit();
            this.tabClientes.ResumeLayout(false);
            this.tabGestioanr.ResumeLayout(false);
            this.tabMensajes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMensajes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataClientes;
        private System.Windows.Forms.Button btnEliminarCliente;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnAgregarCliente;
        private System.Windows.Forms.TabControl tabClientes;
        private System.Windows.Forms.TabPage tabGestioanr;
        private System.Windows.Forms.TabPage tabMensajes;
        private System.Windows.Forms.DataGridView dgvMensajes;
    }
}

