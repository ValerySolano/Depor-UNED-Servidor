namespace BibliotecaCliente.Presentacion
{
    partial class FrmPanelCliente
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
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            IdVenta = new DataGridViewTextBoxColumn();
            Rival = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Hora = new DataGridViewTextBoxColumn();
            Activo = new DataGridViewTextBoxColumn();
            IDLocalidad = new DataGridViewTextBoxColumn();
            NombreLocalidad = new DataGridViewTextBoxColumn();
            Vendedor = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            FechaCompra = new DataGridViewTextBoxColumn();
            TipoCompra = new DataGridViewTextBoxColumn();
            labelUser = new Label();
            label1 = new Label();
            btNueva = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Location = new Point(10, 58);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(942, 271);
            panel1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdVenta, Rival, Fecha, Hora, Activo, IDLocalidad, NombreLocalidad, Vendedor, Cantidad, FechaCompra, TipoCompra });
            dataGridView1.Location = new Point(12, 16);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(929, 244);
            dataGridView1.TabIndex = 0;
            // 
            // IdVenta
            // 
            IdVenta.HeaderText = "ID";
            IdVenta.MinimumWidth = 6;
            IdVenta.Name = "IdVenta";
            IdVenta.ReadOnly = true;
            IdVenta.Width = 43;
            // 
            // Rival
            // 
            Rival.HeaderText = "Rival";
            Rival.MinimumWidth = 6;
            Rival.Name = "Rival";
            Rival.ReadOnly = true;
            Rival.Width = 57;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 63;
            // 
            // Hora
            // 
            Hora.HeaderText = "Hora";
            Hora.MinimumWidth = 6;
            Hora.Name = "Hora";
            Hora.ReadOnly = true;
            Hora.Width = 58;
            // 
            // Activo
            // 
            Activo.HeaderText = "Activo";
            Activo.MinimumWidth = 6;
            Activo.Name = "Activo";
            Activo.ReadOnly = true;
            Activo.Width = 66;
            // 
            // IDLocalidad
            // 
            IDLocalidad.HeaderText = "ID Localidad";
            IDLocalidad.MinimumWidth = 6;
            IDLocalidad.Name = "IDLocalidad";
            IDLocalidad.ReadOnly = true;
            IDLocalidad.Width = 97;
            // 
            // NombreLocalidad
            // 
            NombreLocalidad.HeaderText = "Localidad";
            NombreLocalidad.MinimumWidth = 6;
            NombreLocalidad.Name = "NombreLocalidad";
            NombreLocalidad.ReadOnly = true;
            NombreLocalidad.Width = 83;
            // 
            // Vendedor
            // 
            Vendedor.HeaderText = "Vendedor";
            Vendedor.MinimumWidth = 6;
            Vendedor.Name = "Vendedor";
            Vendedor.ReadOnly = true;
            Vendedor.Width = 82;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 80;
            // 
            // FechaCompra
            // 
            FechaCompra.HeaderText = "Fecha Compra";
            FechaCompra.MinimumWidth = 6;
            FechaCompra.Name = "FechaCompra";
            FechaCompra.ReadOnly = true;
            FechaCompra.Width = 109;
            // 
            // TipoCompra
            // 
            TipoCompra.HeaderText = "TipoCompra";
            TipoCompra.MinimumWidth = 6;
            TipoCompra.Name = "TipoCompra";
            TipoCompra.ReadOnly = true;
            TipoCompra.Width = 98;
            // 
            // labelUser
            // 
            labelUser.AutoSize = true;
            labelUser.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelUser.Location = new Point(23, 24);
            labelUser.Name = "labelUser";
            labelUser.Size = new Size(81, 25);
            labelUser.TabIndex = 1;
            labelUser.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(374, 16);
            label1.Name = "label1";
            label1.Size = new Size(232, 32);
            label1.TabIndex = 2;
            label1.Text = "Historial de compras";
            // 
            // btNueva
            // 
            btNueva.Location = new Point(718, 24);
            btNueva.Margin = new Padding(3, 2, 3, 2);
            btNueva.Name = "btNueva";
            btNueva.Size = new Size(138, 30);
            btNueva.TabIndex = 3;
            btNueva.Text = "Nueva";
            btNueva.UseVisualStyleBackColor = true;
            btNueva.Click += btNueva_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Firebrick;
            btnSalir.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.Location = new Point(862, 25);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(89, 29);
            btnSalir.TabIndex = 4;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // FrmPanelCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(966, 333);
            ControlBox = false;
            Controls.Add(btnSalir);
            Controls.Add(btNueva);
            Controls.Add(label1);
            Controls.Add(labelUser);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "FrmPanelCliente";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel Del Cliente";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdVenta;
        private DataGridViewTextBoxColumn Rival;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn Activo;
        private DataGridViewTextBoxColumn IDLocalidad;
        private DataGridViewTextBoxColumn NombreLocalidad;
        private DataGridViewTextBoxColumn Vendedor;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn FechaCompra;
        private DataGridViewTextBoxColumn TipoCompra;
        private Label labelUser;
        private Label label1;
        private Button btNueva;
        private Button btnSalir;
    }
}