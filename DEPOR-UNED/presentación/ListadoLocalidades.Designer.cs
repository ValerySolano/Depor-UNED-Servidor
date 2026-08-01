/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    partial class ListadoLocalidades
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
            DatosLocalidades = new DataGridView();
            Id = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            label1 = new Label();
            btnNuevoLocalidad = new Button();
            ((System.ComponentModel.ISupportInitialize)DatosLocalidades).BeginInit();
            SuspendLayout();
            // 
            // DatosLocalidades
            // 
            DatosLocalidades.AllowUserToAddRows = false;
            DatosLocalidades.AllowUserToDeleteRows = false;
            DatosLocalidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosLocalidades.Columns.AddRange(new DataGridViewColumn[] { Id, Nombre, Precio });
            DatosLocalidades.Location = new Point(2, 60);
            DatosLocalidades.Margin = new Padding(3, 2, 3, 2);
            DatosLocalidades.Name = "DatosLocalidades";
            DatosLocalidades.RowHeadersWidth = 51;
            DatosLocalidades.Size = new Size(376, 182);
            DatosLocalidades.TabIndex = 0;
            // 
            // Id
            // 
            Id.Frozen = true;
            Id.HeaderText = "ID";
            Id.MinimumWidth = 6;
            Id.Name = "Id";
            Id.ReadOnly = true;
            Id.Width = 125;
            // 
            // Nombre
            // 
            Nombre.Frozen = true;
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.ReadOnly = true;
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.Frozen = true;
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.ReadOnly = true;
            Precio.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 7);
            label1.Name = "label1";
            label1.Size = new Size(182, 21);
            label1.TabIndex = 1;
            label1.Text = "Listado de Localidades";
            // 
            // btnNuevoLocalidad
            // 
            btnNuevoLocalidad.BackColor = Color.DarkGreen;
            btnNuevoLocalidad.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoLocalidad.ForeColor = SystemColors.ButtonHighlight;
            btnNuevoLocalidad.Location = new Point(274, 26);
            btnNuevoLocalidad.Margin = new Padding(3, 2, 3, 2);
            btnNuevoLocalidad.Name = "btnNuevoLocalidad";
            btnNuevoLocalidad.Size = new Size(104, 29);
            btnNuevoLocalidad.TabIndex = 2;
            btnNuevoLocalidad.Text = "+Nuevo";
            btnNuevoLocalidad.UseVisualStyleBackColor = false;
            btnNuevoLocalidad.Click += btnNuevoLocalidad_Click;
            // 
            // ListadoLocalidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 244);
            Controls.Add(btnNuevoLocalidad);
            Controls.Add(label1);
            Controls.Add(DatosLocalidades);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ListadoLocalidades";
            StartPosition = FormStartPosition.CenterParent;
            Text = "ListadoLocalidades";
            Load += ListadoLocalidades_Load;
            ((System.ComponentModel.ISupportInitialize)DatosLocalidades).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosLocalidades;
        private Label label1;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private Button btnNuevoLocalidad;
    }
}
