/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class ListadoVentas
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
            DatosVentas = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Cliente = new DataGridViewTextBoxColumn();
            Rival = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Hora = new DataGridViewTextBoxColumn();
            PartidoActivo = new DataGridViewTextBoxColumn();
            IdLocalidad = new DataGridViewTextBoxColumn();
            Localidad = new DataGridViewTextBoxColumn();
            Vendedor = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            FechaVenta = new DataGridViewTextBoxColumn();
            MontoTotal = new DataGridViewTextBoxColumn();
            TipoVenta = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnNuevo = new Button();
            ((System.ComponentModel.ISupportInitialize)DatosVentas).BeginInit();
            SuspendLayout();
            // 
            // DatosVentas
            // 
            DatosVentas.AllowUserToAddRows = false;
            DatosVentas.AllowUserToDeleteRows = false;
            DatosVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DatosVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosVentas.Columns.AddRange(new DataGridViewColumn[] { Id, Cliente, Rival, Fecha, Hora, PartidoActivo, IdLocalidad, Localidad, Vendedor, Cantidad, FechaVenta, MontoTotal, TipoVenta });
            DatosVentas.Location = new Point(2, 49);
            DatosVentas.Margin = new Padding(3, 2, 3, 2);
            DatosVentas.Name = "DatosVentas";
            DatosVentas.RowHeadersWidth = 51;
            DatosVentas.Size = new Size(1097, 208);
            DatosVentas.TabIndex = 0;
            // 
            // Id
            // 
            Id.Frozen = true;
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 43;
            // 
            // Cliente
            // 
            Cliente.Frozen = true;
            Cliente.HeaderText = "Cliente";
            Cliente.MinimumWidth = 6;
            Cliente.Name = "Cliente";
            Cliente.ReadOnly = true;
            Cliente.Width = 69;
            // 
            // Rival
            // 
            Rival.Frozen = true;
            Rival.HeaderText = "Rival";
            Rival.MinimumWidth = 6;
            Rival.Name = "Rival";
            Rival.ReadOnly = true;
            Rival.Width = 57;
            // 
            // Fecha
            // 
            Fecha.Frozen = true;
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 63;
            // 
            // Hora
            // 
            Hora.Frozen = true;
            Hora.HeaderText = "Hora";
            Hora.MinimumWidth = 6;
            Hora.Name = "Hora";
            Hora.ReadOnly = true;
            Hora.Width = 58;
            // 
            // PartidoActivo
            // 
            PartidoActivo.Frozen = true;
            PartidoActivo.HeaderText = "Activo";
            PartidoActivo.MinimumWidth = 6;
            PartidoActivo.Name = "PartidoActivo";
            PartidoActivo.ReadOnly = true;
            PartidoActivo.Width = 66;
            // 
            // IdLocalidad
            // 
            IdLocalidad.Frozen = true;
            IdLocalidad.HeaderText = "Id Localidad";
            IdLocalidad.MinimumWidth = 6;
            IdLocalidad.Name = "IdLocalidad";
            IdLocalidad.ReadOnly = true;
            IdLocalidad.Width = 96;
            // 
            // Localidad
            // 
            Localidad.Frozen = true;
            Localidad.HeaderText = "Localidad";
            Localidad.MinimumWidth = 6;
            Localidad.Name = "Localidad";
            Localidad.ReadOnly = true;
            Localidad.Width = 83;
            // 
            // Vendedor
            // 
            Vendedor.Frozen = true;
            Vendedor.HeaderText = "Vendedor";
            Vendedor.MinimumWidth = 6;
            Vendedor.Name = "Vendedor";
            Vendedor.ReadOnly = true;
            Vendedor.Width = 82;
            // 
            // Cantidad
            // 
            Cantidad.Frozen = true;
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.ReadOnly = true;
            Cantidad.Width = 80;
            // 
            // FechaVenta
            // 
            FechaVenta.Frozen = true;
            FechaVenta.HeaderText = "FechaVenta";
            FechaVenta.MinimumWidth = 6;
            FechaVenta.Name = "FechaVenta";
            FechaVenta.ReadOnly = true;
            FechaVenta.Width = 92;
            // 
            // MontoTotal
            // 
            MontoTotal.Frozen = true;
            MontoTotal.HeaderText = "Monto Total";
            MontoTotal.MinimumWidth = 6;
            MontoTotal.Name = "MontoTotal";
            MontoTotal.ReadOnly = true;
            MontoTotal.Width = 96;
            // 
            // TipoVenta
            // 
            TipoVenta.Frozen = true;
            TipoVenta.HeaderText = "Tipo Venta";
            TipoVenta.MinimumWidth = 6;
            TipoVenta.Name = "TipoVenta";
            TipoVenta.ReadOnly = true;
            TipoVenta.Width = 87;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(193, 31);
            label1.TabIndex = 1;
            label1.Text = "Lista de Ventas";
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = SystemColors.ButtonHighlight;
            btnNuevo.Location = new Point(954, 9);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(145, 35);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = "+Nueva Venta";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += Venta_Click;
            // 
            // ListadoVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 261);
            Controls.Add(btnNuevo);
            Controls.Add(label1);
            Controls.Add(DatosVentas);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListadoVentas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ListadoVentas";
            Load += ListadoVentas_Load;
            ((System.ComponentModel.ISupportInitialize)DatosVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosVentas;
        private Label label1;
        private Button btnNuevo;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Cliente;
        private DataGridViewTextBoxColumn Rival;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewTextBoxColumn PartidoActivo;
        private DataGridViewTextBoxColumn IdLocalidad;
        private DataGridViewTextBoxColumn Localidad;
        private DataGridViewTextBoxColumn Vendedor;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn FechaVenta;
        private DataGridViewTextBoxColumn MontoTotal;
        private DataGridViewTextBoxColumn TipoVenta;
    }
}
