/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
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
            labelPartido.Location = new Point(26, 18);
            labelPartido.Name = "labelPartido";
            labelPartido.Size = new Size(50, 15);
            labelPartido.TabIndex = 0;
            labelPartido.Text = "Partido:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(26, 67);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Localidad:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(26, 114);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 2;
            label3.Text = "Cantidad:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(178, -1);
            label1.Name = "label1";
            label1.Size = new Size(210, 25);
            label1.TabIndex = 0;
            label1.Text = "Registrar Nueva Venta";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnLimpiar);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnCalcular);
            panel1.Location = new Point(10, 216);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(592, 51);
            panel1.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(307, 14);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(138, 30);
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
            btnGuardar.Location = new Point(150, 14);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(151, 30);
            btnGuardar.TabIndex = 20;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(452, 14);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(138, 30);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(102, 51, 153);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(3, 14);
            btnCalcular.Margin = new Padding(3, 2, 3, 2);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(143, 30);
            btnCalcular.TabIndex = 19;
            btnCalcular.Text = "  Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += btnCalcular_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(comboPartido);
            panel2.Controls.Add(comboLocalidad);
            panel2.Controls.Add(txtCantidad);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(labelPartido);
            panel2.Location = new Point(10, 34);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(444, 161);
            panel2.TabIndex = 4;
            // 
            // comboPartido
            // 
            comboPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPartido.FormattingEnabled = true;
            comboPartido.Items.AddRange(new object[] { "Seleccione partido" });
            comboPartido.Location = new Point(150, 18);
            comboPartido.Margin = new Padding(3, 2, 3, 2);
            comboPartido.Name = "comboPartido";
            comboPartido.Size = new Size(262, 23);
            comboPartido.TabIndex = 7;
            // 
            // comboLocalidad
            // 
            comboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLocalidad.FormattingEnabled = true;
            comboLocalidad.Items.AddRange(new object[] { "Seleccione localidad" });
            comboLocalidad.Location = new Point(150, 64);
            comboLocalidad.Margin = new Padding(3, 2, 3, 2);
            comboLocalidad.Name = "comboLocalidad";
            comboLocalidad.Size = new Size(262, 23);
            comboLocalidad.TabIndex = 6;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(150, 109);
            txtCantidad.Margin = new Padding(3, 2, 3, 2);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(262, 23);
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
            panel3.Location = new Point(461, 34);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(143, 164);
            panel3.TabIndex = 5;
            // 
            // labelTotal
            // 
            labelTotal.AutoSize = true;
            labelTotal.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTotal.Location = new Point(57, 98);
            labelTotal.Name = "labelTotal";
            labelTotal.Size = new Size(0, 15);
            labelTotal.TabIndex = 6;
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelPrecio.Location = new Point(66, 65);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(0, 15);
            labelPrecio.TabIndex = 5;
            // 
            // labelCantidad
            // 
            labelCantidad.AutoSize = true;
            labelCantidad.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCantidad.Location = new Point(82, 31);
            labelCantidad.Name = "labelCantidad";
            labelCantidad.Size = new Size(0, 15);
            labelCantidad.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(14, 98);
            label6.Name = "label6";
            label6.Size = new Size(35, 15);
            label6.TabIndex = 3;
            label6.Text = "Total:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 65);
            label5.Name = "label5";
            label5.Size = new Size(43, 15);
            label5.TabIndex = 2;
            label5.Text = "Precio:";
            // 
            // labelCan
            // 
            labelCan.AutoSize = true;
            labelCan.Location = new Point(14, 32);
            labelCan.Name = "labelCan";
            labelCan.Size = new Size(58, 15);
            labelCan.TabIndex = 1;
            labelCan.Text = "Cantidad:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(35, 8);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 0;
            label4.Text = "Resumen";
            // 
            // FrmRegistroVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 276);
            ControlBox = false;
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
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