/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    partial class ListadoPartido
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
            Rival = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Hora = new DataGridViewTextBoxColumn();
            Activo = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            btnNuevoPartido = new Button();
            ((System.ComponentModel.ISupportInitialize)DatosPartidos).BeginInit();
            SuspendLayout();
            // 
            // DatosPartidos
            // 
            DatosPartidos.AllowUserToAddRows = false;
            DatosPartidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DatosPartidos.Columns.AddRange(new DataGridViewColumn[] { Id, Rival, Fecha, Hora, Activo });
            DatosPartidos.Location = new Point(-1, 90);
            DatosPartidos.Name = "DatosPartidos";
            DatosPartidos.RowHeadersWidth = 51;
            DatosPartidos.Size = new Size(680, 352);
            DatosPartidos.TabIndex = 0;
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
            // Rival
            // 
            Rival.Frozen = true;
            Rival.HeaderText = "Rival";
            Rival.MinimumWidth = 6;
            Rival.Name = "Rival";
            Rival.ReadOnly = true;
            Rival.Width = 125;
            // 
            // Fecha
            // 
            Fecha.Frozen = true;
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.ReadOnly = true;
            Fecha.Width = 125;
            // 
            // Hora
            // 
            Hora.Frozen = true;
            Hora.HeaderText = "Hora";
            Hora.MinimumWidth = 6;
            Hora.Name = "Hora";
            Hora.ReadOnly = true;
            Hora.Width = 125;
            // 
            // Activo
            // 
            Activo.Frozen = true;
            Activo.HeaderText = "Activo";
            Activo.MinimumWidth = 6;
            Activo.Name = "Activo";
            Activo.ReadOnly = true;
            Activo.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 20);
            label1.Name = "label1";
            label1.Size = new Size(135, 41);
            label1.TabIndex = 1;
            label1.Text = "Partidos";
            // 
            // btnNuevoPartido
            // 
            btnNuevoPartido.BackColor = Color.Green;
            btnNuevoPartido.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevoPartido.ForeColor = SystemColors.ButtonHighlight;
            btnNuevoPartido.Location = new Point(510, 45);
            btnNuevoPartido.Name = "btnNuevoPartido";
            btnNuevoPartido.Size = new Size(169, 39);
            btnNuevoPartido.TabIndex = 2;
            btnNuevoPartido.Text = "+Nuevo";
            btnNuevoPartido.UseVisualStyleBackColor = false;
            btnNuevoPartido.Click += btnNuevoPartido_Click;
            // 
            // ListadoPartido
            // 
            Load += ListadoPartido_Load;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 443);
            Controls.Add(btnNuevoPartido);
            Controls.Add(label1);
            Controls.Add(DatosPartidos);
            Name = "ListadoPartido";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ListadoPartido";
            ((System.ComponentModel.ISupportInitialize)DatosPartidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView DatosPartidos;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn Rival;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Hora;
        private Label label1;
        private Button btnNuevoPartido;
        private DataGridViewCheckBoxColumn Activo;
    }
}
