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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(labelIdentifiacion);
            panel1.Controls.Add(txtIdentificacion);
            panel1.Location = new Point(56, 72);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 165);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // labelIdentifiacion
            // 
            labelIdentifiacion.AutoSize = true;
            labelIdentifiacion.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIdentifiacion.Location = new Point(3, 51);
            labelIdentifiacion.Name = "labelIdentifiacion";
            labelIdentifiacion.Size = new Size(147, 28);
            labelIdentifiacion.TabIndex = 2;
            labelIdentifiacion.Text = "Identificación:";
            // 
            // txtIdentificacion
            // 
            txtIdentificacion.Location = new Point(166, 55);
            txtIdentificacion.Name = "txtIdentificacion";
            txtIdentificacion.Size = new Size(236, 27);
            txtIdentificacion.TabIndex = 2;
            // 
            // btnIniciarSession
            // 
            btnIniciarSession.Location = new Point(163, 256);
            btnIniciarSession.Name = "btnIniciarSession";
            btnIniciarSession.Size = new Size(223, 49);
            btnIniciarSession.TabIndex = 1;
            btnIniciarSession.Text = "Iniciar Sesión";
            btnIniciarSession.UseVisualStyleBackColor = true;
            btnIniciarSession.Click += btnIniciarSession_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(99, 18);
            label1.Name = "label1";
            label1.Size = new Size(341, 38);
            label1.TabIndex = 2;
            label1.Text = "Sistema de venta en linea ";
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 327);
            Controls.Add(label1);
            Controls.Add(btnIniciarSession);
            Controls.Add(panel1);
            Name = "frmLogin";
            Text = "Form1";
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
    }
}
