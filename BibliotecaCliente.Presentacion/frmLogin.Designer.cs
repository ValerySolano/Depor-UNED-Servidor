namespace BibliotecaCliente.Presentacion
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelIdentifiacion = new Label();
            txtIdentificacion = new TextBox();
            btnIniciarSession = new Button();
            label1 = new Label();
            labelConexionError = new Label();
            labelConexion = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(labelIdentifiacion);
            panel1.Controls.Add(txtIdentificacion);
            panel1.Location = new Point(178, 78);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 124);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // labelIdentifiacion
            // 
            labelIdentifiacion.AutoSize = true;
            labelIdentifiacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIdentifiacion.Location = new Point(3, 38);
            labelIdentifiacion.Name = "labelIdentifiacion";
            labelIdentifiacion.Size = new Size(120, 21);
            labelIdentifiacion.TabIndex = 2;
            labelIdentifiacion.Text = "Identificación:";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(145, 41);
            txtIdentificacion.Margin = new Padding(3, 2, 3, 2);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(207, 23);
            txtIdentificacion.TabIndex = 2;
            // 
            // btnIniciarSession
            // 
            btnIniciarSession.Location = new Point(260, 219);
            btnIniciarSession.Margin = new Padding(3, 2, 3, 2);
            btnIniciarSession.Name = "btnIniciarSession";
            btnIniciarSession.Size = new Size(195, 37);
            btnIniciarSession.TabIndex = 1;
            btnIniciarSession.Text = "Iniciar Sesión";
            btnIniciarSession.UseVisualStyleBackColor = true;
            btnIniciarSession.Click += btnIniciarSession_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(228, 9);
            label1.Name = "label1";
            label1.Size = new Size(265, 30);
            label1.TabIndex = 2;
            label1.Text = "Sistema de venta en linea ";
            // 
            // labelConexionError
            // 
            labelConexionError.AutoSize = true;
            labelConexionError.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConexionError.ForeColor = Color.Green;
            labelConexionError.Location = new Point(182, 270);
            labelConexionError.Name = "labelConexionError";
            labelConexionError.Size = new Size(0, 21);
            labelConexionError.TabIndex = 3;
            labelConexionError.TextAlign = ContentAlignment.TopCenter;
            // 
            // labelConexion
            // 
            labelConexion.AutoSize = true;
            labelConexion.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelConexion.ForeColor = Color.Green;
            labelConexion.Location = new Point(299, 55);
            labelConexion.Name = "labelConexion";
            labelConexion.Size = new Size(0, 21);
            labelConexion.TabIndex = 4;
            labelConexion.TextAlign = ContentAlignment.TopCenter;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(692, 300);
            Controls.Add(labelConexion);
            Controls.Add(labelConexionError);
            Controls.Add(label1);
            Controls.Add(btnIniciarSession);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DEPOR-UNED VENTA";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private TextBox txtIdentificacion;
        private Button btnIniciarSession;
        private Label labelIdentifiacion;
        private Label label1;
        private Label labelConexionError;
        private Label labelConexion;
    }
}
