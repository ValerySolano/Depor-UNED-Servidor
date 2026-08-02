/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class RegistroVendedor
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
            panel1 = new Panel();
            label8 = new Label();
            label1 = new Label();
            dateTimePickerRegistro = new DateTimePicker();
            label6 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            dateTimePickerNacimiento = new DateTimePicker();
            textBoxIdentificacion = new TextBox();
            label5 = new Label();
            label3 = new Label();
            textBoxApellido = new TextBox();
            textBoxNombre = new TextBox();
            label4 = new Label();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(dateTimePickerRegistro);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(dateTimePickerNacimiento);
            panel1.Controls.Add(textBoxIdentificacion);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(textBoxApellido);
            panel1.Controls.Add(textBoxNombre);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(12, 9);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 234);
            panel1.TabIndex = 23;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(112, 9);
            label8.Name = "label8";
            label8.Size = new Size(151, 15);
            label8.TabIndex = 7;
            label8.Text = "REGISTRO DE VENDEDORES";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 40);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Vendedor:";
            // 
            // dateTimePickerRegistro
            // 
            dateTimePickerRegistro.Format = DateTimePickerFormat.Short;
            dateTimePickerRegistro.Location = new Point(139, 204);
            dateTimePickerRegistro.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerRegistro.Name = "dateTimePickerRegistro";
            dateTimePickerRegistro.Size = new Size(208, 23);
            dateTimePickerRegistro.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 204);
            label6.Name = "label6";
            label6.Size = new Size(83, 15);
            label6.TabIndex = 5;
            label6.Text = "Fecha Ingreso:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 38);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 23);
            textBox1.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(19, 74);
            label2.Name = "label2";
            label2.Size = new Size(82, 15);
            label2.TabIndex = 1;
            label2.Text = "Identificación:";
            // 
            // dateTimePickerNacimiento
            // 
            dateTimePickerNacimiento.Format = DateTimePickerFormat.Short;
            dateTimePickerNacimiento.Location = new Point(139, 166);
            dateTimePickerNacimiento.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerNacimiento.Name = "dateTimePickerNacimiento";
            dateTimePickerNacimiento.Size = new Size(208, 23);
            dateTimePickerNacimiento.TabIndex = 14;
            // 
            // textBoxIdentificacion
            // 
            textBoxIdentificacion.Location = new Point(139, 69);
            textBoxIdentificacion.Margin = new Padding(3, 2, 3, 2);
            textBoxIdentificacion.Name = "textBoxIdentificacion";
            textBoxIdentificacion.Size = new Size(208, 23);
            textBoxIdentificacion.TabIndex = 11;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 170);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha Nacimiento:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 104);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(139, 132);
            textBoxApellido.Margin = new Padding(3, 2, 3, 2);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(208, 23);
            textBoxApellido.TabIndex = 13;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(139, 101);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(208, 23);
            textBoxNombre.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(19, 137);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 3;
            label4.Text = "Apellido:";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(56, 248);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 30);
            btnGuardar.TabIndex = 24;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(178, 248);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 30);
            btnLimpiar.TabIndex = 25;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(301, 248);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(105, 30);
            btnSalir.TabIndex = 26;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // RegistroVendedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 290);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnSalir);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegistroVendedor";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegistroVendedor";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label8;
        private Label label1;
        private DateTimePicker dateTimePickerRegistro;
        private Label label6;
        private TextBox textBox1;
        private Label label2;
        private DateTimePicker dateTimePickerNacimiento;
        private TextBox textBoxIdentificacion;
        private Label label5;
        private Label label3;
        private TextBox textBoxApellido;
        private TextBox textBoxNombre;
        private Label label4;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnSalir;
    }
}
