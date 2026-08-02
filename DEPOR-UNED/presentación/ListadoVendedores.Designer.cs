/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class ListadoVendedores
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
            DatosPartidos = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Identificacion = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            FechaRegistro = new DataGridViewTextBoxColumn();
            btnNuevo = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)DatosPartidos).BeginInit();
            SuspendLayout();
            // 
            // DatosPartidos
            // 
            DatosPartidos.AllowUserToAddRows = false;
            DatosPartidos.AllowUserToDeleteRows = false;
            DatosPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosPartidos.Columns.AddRange(new DataGridViewColumn[] { Id, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro });
            DatosPartidos.Location = new Point(1, 39);
            DatosPartidos.Margin = new Padding(3, 2, 3, 2);
            DatosPartidos.Name = "DatosPartidos";
            DatosPartidos.RowHeadersWidth = 51;
            DatosPartidos.Size = new Size(664, 254);
            DatosPartidos.TabIndex = 1;
            // 
            // Id
            // 
            Id.Frozen = true;
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Visible = false;
            Id.Width = 125;
            // 
            // Identificacion
            // 
            Identificacion.Frozen = true;
            Identificacion.HeaderText = "Identifcacion";
            Identificacion.MinimumWidth = 6;
            Identificacion.Name = "Identificacion";
            Identificacion.ReadOnly = true;
            Identificacion.Width = 125;
            // 
            // Nombre
            // 
            Nombre.Frozen = true;
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Apellido
            // 
            Apellido.Frozen = true;
            Apellido.HeaderText = "Apellido";
            Apellido.MinimumWidth = 6;
            Apellido.Name = "Apellido";
            Apellido.ReadOnly = true;
            Apellido.Width = 125;
            // 
            // FechaNacimiento
            // 
            FechaNacimiento.Frozen = true;
            FechaNacimiento.HeaderText = "Fecha Nacimiento";
            FechaNacimiento.MinimumWidth = 6;
            FechaNacimiento.Name = "FechaNacimiento";
            FechaNacimiento.ReadOnly = true;
            FechaNacimiento.Width = 180;
            // 
            // FechaRegistro
            // 
            FechaRegistro.Frozen = true;
            FechaRegistro.HeaderText = "Fecha Registro";
            FechaRegistro.MinimumWidth = 6;
            FechaRegistro.Name = "FechaRegistro";
            FechaRegistro.ReadOnly = true;
            FechaRegistro.Width = 150;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = SystemColors.ButtonHighlight;
            btnNuevo.Location = new Point(536, 10);
            btnNuevo.Margin = new Padding(3, 2, 3, 2);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(130, 29);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = "+Nuevo";
            btnNuevo.UseVisualStyleBackColor = false;
            btnNuevo.Click += btnNuevoPartido_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(38, 10);
            label1.Name = "label1";
            label1.Size = new Size(214, 25);
            label1.TabIndex = 4;
            label1.Text = "Listado de Vendedores";
            // 
            // ListadoVendedores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 292);
            Controls.Add(label1);
            Controls.Add(btnNuevo);
            Controls.Add(DatosPartidos);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListadoVendedores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ListadoVendedores";
            Load += ListadoVendedores_Load;
            ((System.ComponentModel.ISupportInitialize)DatosPartidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosPartidos;
        private Button btnNuevo;
        private Label label1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Identificacion;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Apellido;
        private DataGridViewTextBoxColumn FechaNacimiento;
        private DataGridViewTextBoxColumn FechaRegistro;
    }
}
