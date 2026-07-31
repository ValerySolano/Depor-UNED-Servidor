/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
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
            btnNuevo = new Button();
            label1 = new Label();
            Id = new DataGridViewTextBoxColumn();
            Identificacion = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Apellido = new DataGridViewTextBoxColumn();
            FechaNacimiento = new DataGridViewTextBoxColumn();
            FechaRegistro = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)DatosPartidos).BeginInit();
            SuspendLayout();
            // 
            // DatosPartidos
            // 
            DatosPartidos.AllowUserToAddRows = false;
            DatosPartidos.AllowUserToDeleteRows = false;
            DatosPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosPartidos.Columns.AddRange(new DataGridViewColumn[] { Id, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro });
            DatosPartidos.Location = new Point(1, 52);
            DatosPartidos.Name = "DatosPartidos";
            DatosPartidos.RowHeadersWidth = 51;
            DatosPartidos.Size = new Size(759, 338);
            DatosPartidos.TabIndex = 1;
            // 
            // btnNuevo
            // 
            btnNuevo.BackColor = Color.Green;
            btnNuevo.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevo.ForeColor = SystemColors.ButtonHighlight;
            btnNuevo.Location = new Point(612, 13);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(148, 39);
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
            label1.Location = new Point(43, 13);
            label1.Name = "label1";
            label1.Size = new Size(255, 31);
            label1.TabIndex = 4;
            label1.Text = "Listado de Vendedores";
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
            // ListadoVendedores
            // 
            Load += ListadoVendedores_Load;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(762, 390);
            Controls.Add(label1);
            Controls.Add(btnNuevo);
            Controls.Add(DatosPartidos);
            Name = "ListadoVendedores";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListadoVendedores";
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
