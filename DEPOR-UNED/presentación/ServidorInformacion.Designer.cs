namespace presentación
{
    partial class ServidorInformacion
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
            groupBox1 = new GroupBox();
            LabelEstado = new Label();
            label1 = new Label();
            btnAdministracion = new Button();
            btnDetener = new Button();
            btnIniciar = new Button();
            cliente = new GroupBox();
            LstClientesConectados = new ListBox();
            gridbitacora = new GroupBox();
            txtBitacora = new TextBox();
            groupBox1.SuspendLayout();
            cliente.SuspendLayout();
            gridbitacora.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(LabelEstado);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnAdministracion);
            groupBox1.Controls.Add(btnDetener);
            groupBox1.Controls.Add(btnIniciar);
            groupBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(732, 180);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información del servidor";
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelEstado.Location = new Point(126, 42);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(113, 31);
            LabelEstado.TabIndex = 4;
            LabelEstado.Text = "Sin Iniciar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(29, 42);
            label1.Name = "label1";
            label1.Size = new Size(91, 31);
            label1.TabIndex = 3;
            label1.Text = "Estado:";
            // 
            // btnAdministracion
            // 
            btnAdministracion.Location = new Point(515, 114);
            btnAdministracion.Name = "btnAdministracion";
            btnAdministracion.Size = new Size(195, 47);
            btnAdministracion.TabIndex = 2;
            btnAdministracion.Text = "Administracion";
            btnAdministracion.UseVisualStyleBackColor = false;
            btnAdministracion.Click += BtnAdministracion_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(190, 118);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(187, 43);
            btnDetener.TabIndex = 1;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = false;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(29, 118);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(155, 43);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // cliente
            // 
            cliente.Controls.Add(LstClientesConectados);
            cliente.Location = new Point(12, 222);
            cliente.Name = "cliente";
            cliente.Size = new Size(318, 307);
            cliente.TabIndex = 1;
            cliente.TabStop = false;
            cliente.Text = "Clientes Conectados";
            // 
            // LstClientesConectados
            // 
            LstClientesConectados.FormattingEnabled = true;
            LstClientesConectados.Location = new Point(16, 37);
            LstClientesConectados.Name = "LstClientesConectados";
            LstClientesConectados.Size = new Size(287, 264);
            LstClientesConectados.TabIndex = 0;
            // 
            // gridbitacora
            // 
            gridbitacora.Controls.Add(txtBitacora);
            gridbitacora.Location = new Point(387, 222);
            gridbitacora.Name = "gridbitacora";
            gridbitacora.Size = new Size(341, 307);
            gridbitacora.TabIndex = 2;
            gridbitacora.TabStop = false;
            gridbitacora.Text = "Bitácora";
            // 
            // txtBitacora
            // 
            txtBitacora.Location = new Point(6, 26);
            txtBitacora.Multiline = true;
            txtBitacora.Name = "txtBitacora";
            txtBitacora.Size = new Size(329, 275);
            txtBitacora.TabIndex = 1;
            // 
            // ServidorInformacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(746, 541);
            Controls.Add(gridbitacora);
            Controls.Add(cliente);
            Controls.Add(groupBox1);
            Name = "ServidorInformacion";
            Text = "Form1";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            cliente.ResumeLayout(false);
            gridbitacora.ResumeLayout(false);
            gridbitacora.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label LabelEstado;
        private Label label1;
        private Button btnAdministracion;
        private Button btnDetener;
        private Button btnIniciar;
        private GroupBox cliente;
        private GroupBox gridbitacora;
        private TextBox txtBitacora;
        private ListBox LstClientesConectados;
    }
}