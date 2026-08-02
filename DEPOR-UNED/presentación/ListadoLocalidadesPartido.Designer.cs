/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class ListadoLocalidadesPartido
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
            DatosLoalidadesPartido = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Rival = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Hora = new DataGridViewTextBoxColumn();
            Activo = new DataGridViewCheckBoxColumn();
            IdLocalidad = new DataGridViewTextBoxColumn();
            Localidad = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            CantidadDisponible = new DataGridViewTextBoxColumn();
            btnNuevo = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DatosLoalidadesPartido).BeginInit();
            SuspendLayout();
            // 
            // DatosLoalidadesPartido
            // 
            DatosLoalidadesPartido.AllowUserToAddRows = false;
            DatosLoalidadesPartido.AllowUserToDeleteRows = false;
            DatosLoalidadesPartido.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DatosLoalidadesPartido.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosLoalidadesPartido.Columns.AddRange(new DataGridViewColumn[] { Id, Rival, Fecha, Hora, Activo, IdLocalidad, Localidad, Precio, CantidadDisponible });
            DatosLoalidadesPartido.Location = new Point(0, 87);
            DatosLoalidadesPartido.Margin = new Padding(3, 2, 3, 2);
            DatosLoalidadesPartido.Name = "DatosLoalidadesPartido";
            DatosLoalidadesPartido.RowHeadersWidth = 51;
            DatosLoalidadesPartido.Size = new Size(732, 242);
            DatosLoalidadesPartido.TabIndex = 0;
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
            // Activo
            // 
            Activo.Frozen = true;
            Activo.HeaderText = "Activo";
            Activo.MinimumWidth = 6;
            Activo.Name = "Activo";
            Activo.ReadOnly = true;
            Activo.Width = 47;
            // 
            // IdLocalidad
            // 
            IdLocalidad.Frozen = true;
            IdLocalidad.HeaderText = "IdLocalidad";
            IdLocalidad.MinimumWidth = 6;
            IdLocalidad.Name = "IdLocalidad";
            IdLocalidad.ReadOnly = true;
            IdLocalidad.Width = 93;
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
            // Precio
            // 
            Precio.Frozen = true;
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 65;
            // 
            // CantidadDisponible
            // 
            CantidadDisponible.Frozen = true;
            CantidadDisponible.HeaderText = "Cantidad Disponible";
            CantidadDisponible.MinimumWidth = 6;
            CantidadDisponible.Name = "CantidadDisponible";
            CantidadDisponible.ReadOnly = true;
            CantidadDisponible.Width = 127;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = SystemColors.ButtonHighlight;
            btnNuevo.Location = new Point(596, 52);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(136, 31);
            btnNuevo.TabIndex = 1;
            btnNuevo.Text = "+Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(64, 64, 64);
            label1.Location = new Point(10, 29);
            label1.Name = "label1";
            label1.Size = new Size(283, 22);
            label1.TabIndex = 2;
            label1.Text = "Lista De Localidades Por Partido";
            // 
            // ListadoLocalidadesPartido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 329);
            Controls.Add(DatosLoalidadesPartido);
            Controls.Add(label1);
            Controls.Add(btnNuevo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListadoLocalidadesPartido";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ListadoLocalidadesPartido";
            Load += ListadoLocalidadesPartido_Load;
            ((System.ComponentModel.ISupportInitialize)DatosLoalidadesPartido).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosLoalidadesPartido;
        private Button btnNuevo;
        private Label label1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Rival;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Hora;
        private DataGridViewCheckBoxColumn Activo;
        private DataGridViewTextBoxColumn IdLocalidad;
        private DataGridViewTextBoxColumn Localidad;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn CantidadDisponible;
    }
}
