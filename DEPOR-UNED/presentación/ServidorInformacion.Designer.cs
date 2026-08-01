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
            groupBox1.Location = new Point(10, 9);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(640, 135);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Información del servidor";
            // 
            // LabelEstado
            // 
            LabelEstado.AutoSize = true;
            LabelEstado.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LabelEstado.Location = new Point(110, 32);
            LabelEstado.Name = "LabelEstado";
            LabelEstado.Size = new Size(95, 25);
            LabelEstado.TabIndex = 4;
            LabelEstado.Text = "Sin Iniciar";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 32);
            label1.Name = "label1";
            label1.Size = new Size(76, 25);
            label1.TabIndex = 3;
            label1.Text = "Estado:";
            // 
            // btnAdministracion
            // 
            btnAdministracion.Location = new Point(451, 86);
            btnAdministracion.Margin = new Padding(3, 2, 3, 2);
            btnAdministracion.Name = "btnAdministracion";
            btnAdministracion.Size = new Size(171, 35);
            btnAdministracion.TabIndex = 2;
            btnAdministracion.Text = "Administracion";
            btnAdministracion.UseVisualStyleBackColor = false;
            btnAdministracion.Click += BtnAdministracion_Click;
            // 
            // btnDetener
            // 
            btnDetener.Location = new Point(166, 88);
            btnDetener.Margin = new Padding(3, 2, 3, 2);
            btnDetener.Name = "btnDetener";
            btnDetener.Size = new Size(164, 32);
            btnDetener.TabIndex = 1;
            btnDetener.Text = "Detener";
            btnDetener.UseVisualStyleBackColor = false;
            btnDetener.Click += btnDetener_Click;
            // 
            // btnIniciar
            // 
            btnIniciar.Location = new Point(25, 88);
            btnIniciar.Margin = new Padding(3, 2, 3, 2);
            btnIniciar.Name = "btnIniciar";
            btnIniciar.Size = new Size(136, 32);
            btnIniciar.TabIndex = 0;
            btnIniciar.Text = "Iniciar";
            btnIniciar.UseVisualStyleBackColor = false;
            btnIniciar.Click += btnIniciar_Click;
            // 
            // cliente
            // 
            cliente.Controls.Add(LstClientesConectados);
            cliente.Location = new Point(10, 166);
            cliente.Margin = new Padding(3, 2, 3, 2);
            cliente.Name = "cliente";
            cliente.Padding = new Padding(3, 2, 3, 2);
            cliente.Size = new Size(278, 230);
            cliente.TabIndex = 1;
            cliente.TabStop = false;
            cliente.Text = "Clientes Conectados";
            // 
            // LstClientesConectados
            // 
            LstClientesConectados.FormattingEnabled = true;
            LstClientesConectados.Location = new Point(14, 28);
            LstClientesConectados.Margin = new Padding(3, 2, 3, 2);
            LstClientesConectados.Name = "LstClientesConectados";
            LstClientesConectados.Size = new Size(252, 199);
            LstClientesConectados.TabIndex = 0;
            // 
            // gridbitacora
            // 
            gridbitacora.Controls.Add(txtBitacora);
            gridbitacora.Location = new Point(339, 166);
            gridbitacora.Margin = new Padding(3, 2, 3, 2);
            gridbitacora.Name = "gridbitacora";
            gridbitacora.Padding = new Padding(3, 2, 3, 2);
            gridbitacora.Size = new Size(298, 230);
            gridbitacora.TabIndex = 2;
            gridbitacora.TabStop = false;
            gridbitacora.Text = "Bitácora";
            // 
            // txtBitacora
            // 
            txtBitacora.Location = new Point(5, 20);
            txtBitacora.Margin = new Padding(3, 2, 3, 2);
            txtBitacora.Multiline = true;
            txtBitacora.Name = "txtBitacora";
            txtBitacora.Size = new Size(288, 207);
            txtBitacora.TabIndex = 1;
            // 
            // ServidorInformacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(653, 406);
            Controls.Add(gridbitacora);
            Controls.Add(cliente);
            Controls.Add(groupBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ServidorInformacion";
            Text = "Aplicación para la vista de acciones y acceso al Panel Administrativo";
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