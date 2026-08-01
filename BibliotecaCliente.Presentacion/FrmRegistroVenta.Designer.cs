namespace BibliotecaCliente.Presentacion
{
    partial class FrmRegistroVenta
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
            Label labelPartido;
            Label label2;
            Label label3;
            label1 = new Label();
            panel1 = new Panel();
            btnLimpiar = new Button();
            btnGuardar = new Button();
            btnSalir = new Button();
            btnCalcular = new Button();
            panel2 = new Panel();
            comboPartido = new ComboBox();
            comboLocalidad = new ComboBox();
            txtCantidad = new TextBox();
            panel3 = new Panel();
            labelTotal = new Label();
            labelPrecio = new Label();
            labelCantidad = new Label();
            label6 = new Label();
            label5 = new Label();
            labelCan = new Label();
            label4 = new Label();
            labelPartido = new Label();
            label2 = new Label();
            label3 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // labelPartido
            // 
            labelPartido.AutoSize = true;
            labelPartido.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPartido.Location = new Point(30, 24);
            labelPartido.Name = "labelPartido";
            labelPartido.Size = new Size(64, 20);
            labelPartido.TabIndex = 0;
            labelPartido.Text = "Partido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(30, 89);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Localidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(30, 152);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 2;
            label3.Text = "Cantidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(204, -1);
            label1.Name = "label1";
            label1.Size = new Size(251, 31);
            label1.TabIndex = 0;
            label1.Text = "Registrar Nueva Venta";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnCalcular);
            panel1.Location = new Point(11, 288);
            panel1.Name = "panel1";
            panel1.Size = new Size(677, 68);
            panel1.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(351, 19);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(158, 40);
            btnLimpiar.TabIndex = 23;
            btnLimpiar.Text = "  Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(172, 19);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(173, 40);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(516, 19);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(158, 40);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(102, 51, 153);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(3, 19);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(163, 40);
            btnCalcular.TabIndex = 19;
            btnCalcular.Text = "  Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboPartido);
            panel2.Controls.Add(comboLocalidad);
            panel2.Controls.Add(txtCantidad);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(labelPartido);
            panel2.Location = new Point(12, 46);
            panel2.Name = "panel2";
            panel2.Size = new Size(508, 215);
            panel2.TabIndex = 4;
            // 
            // comboPartido
            // 
            comboPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPartido.FormattingEnabled = true;
            comboPartido.Items.AddRange(new object[] { "Seleccione partido" });
            comboPartido.Location = new Point(171, 24);
            comboPartido.Name = "comboPartido";
            comboPartido.Size = new Size(299, 28);
            comboPartido.TabIndex = 7;
            // 
            // comboLocalidad
            // 
            comboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLocalidad.FormattingEnabled = true;
            comboLocalidad.Items.AddRange(new object[] { "Seleccione localidad" });
            comboLocalidad.Location = new Point(171, 86);
            comboLocalidad.Name = "comboLocalidad";
            comboLocalidad.Size = new Size(299, 28);
            comboLocalidad.TabIndex = 6;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(171, 145);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(299, 27);
            txtCantidad.TabIndex = 5;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelTotal);
            panel3.Controls.Add(labelPrecio);
            panel3.Controls.Add(labelCantidad);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(labelCan);
            panel3.Controls.Add(label4);
            panel3.Location = new Point(527, 45);
            panel3.Name = "panel3";
            panel3.Size = new Size(163, 218);
            panel3.TabIndex = 5;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.Location = new Point(65, 131);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(0, 20);
            labelTotal.TabIndex = 6;
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrecio.Location = new Point(75, 87);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(0, 20);
            labelPrecio.TabIndex = 5;
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCantidad.Location = new Point(94, 41);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(0, 20);
            labelCantidad.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 131);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 3;
            label6.Text = "Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(16, 87);
            label5.Name = "label5";
            label5.Size = new Size(53, 20);
            label5.TabIndex = 2;
            label5.Text = "Precio:";
            // 
            // labelCan
            // 
            labelCan.AutoSize = true;
            labelCan.Location = new Point(16, 42);
            labelCan.Name = "labelCan";
            labelCan.Size = new Size(72, 20);
            labelCan.TabIndex = 1;
            labelCan.Text = "Cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 11);
            label4.Name = "label4";
            label4.Size = new Size(69, 20);
            label4.TabIndex = 0;
            label4.Text = "Resumen";
            // 
            // FrmRegistroVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 368);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "FrmRegistroVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRegistroVenta";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Panel panel2;
        private Button btnLimpiar;
        private Button btnGuardar;
        private Button btnSalir;
        private Button btnCalcular;
        private TextBox txtCantidad;
        private ComboBox comboPartido;
        private ComboBox comboLocalidad;
        private Panel panel3;
        private Label label6;
        private Label label5;
        private Label labelCan;
        private Label label4;
        private Label labelCantidad;
        private Label labelTotal;
        private Label labelPrecio;
    }
}