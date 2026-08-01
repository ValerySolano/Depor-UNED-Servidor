/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    partial class RegistroClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroClientes));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBoxIdentificacion = new TextBox();
            textBoxNombre = new TextBox();
            textBoxApellido = new TextBox();
            dateTimePickerNacimiento = new DateTimePicker();
            dateTimePickerRegistro = new DateTimePicker();
            checkBoxActivo = new CheckBox();
            labelActivoSi = new Label();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 40);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Id Cliente:";
            label1.Click += label1_Click;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 104);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 170);
            label5.Name = "label5";
            label5.Size = new Size(106, 15);
            label5.TabIndex = 4;
            label5.Text = "Fecha Nacimiento:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 204);
            label6.Name = "label6";
            label6.Size = new Size(87, 15);
            label6.TabIndex = 5;
            label6.Text = "Fecha Registro:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 238);
            label7.Name = "label7";
            label7.Size = new Size(44, 15);
            label7.TabIndex = 6;
            label7.Text = "Activo:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(112, 9);
            label8.Name = "label8";
            label8.Size = new Size(129, 15);
            label8.TabIndex = 7;
            label8.Text = "REGISTRO DE CLIENTES";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(10, 10);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 90);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(139, 38);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(208, 23);
            textBox1.TabIndex = 9;
            // 
            // textBoxIdentificacion
            // 
            textBoxIdentificacion.Location = new Point(139, 69);
            textBoxIdentificacion.Margin = new Padding(3, 2, 3, 2);
            textBoxIdentificacion.Name = "textBoxIdentificacion";
            textBoxIdentificacion.Size = new Size(208, 23);
            textBoxIdentificacion.TabIndex = 11;
            // 
            // textBoxNombre
            // 
            textBoxNombre.Location = new Point(139, 101);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(208, 23);
            textBoxNombre.TabIndex = 12;
            // 
            // textBoxApellido
            // 
            textBoxApellido.Location = new Point(139, 132);
            textBoxApellido.Margin = new Padding(3, 2, 3, 2);
            textBoxApellido.Name = "textBoxApellido";
            textBoxApellido.Size = new Size(208, 23);
            textBoxApellido.TabIndex = 13;
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
            // dateTimePickerRegistro
            // 
            dateTimePickerRegistro.Format = DateTimePickerFormat.Short;
            dateTimePickerRegistro.Location = new Point(139, 204);
            dateTimePickerRegistro.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerRegistro.Name = "dateTimePickerRegistro";
            dateTimePickerRegistro.Size = new Size(208, 23);
            dateTimePickerRegistro.TabIndex = 15;
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.Location = new Point(105, 238);
            checkBoxActivo.Margin = new Padding(3, 2, 3, 2);
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.Size = new Size(18, 15);
            checkBoxActivo.TabIndex = 16;
            // 
            // labelActivoSi
            // 
            labelActivoSi.AutoSize = true;
            labelActivoSi.Location = new Point(128, 237);
            labelActivoSi.Name = "labelActivoSi";
            labelActivoSi.Size = new Size(16, 15);
            labelActivoSi.TabIndex = 17;
            labelActivoSi.Text = "Sí";
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(175, 285);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(105, 30);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(298, 285);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 30);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(420, 285);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(105, 30);
            btnSalir.TabIndex = 21;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(checkBoxActivo);
            panel1.Controls.Add(labelActivoSi);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
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
            panel1.Location = new Point(121, 11);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(425, 269);
            panel1.TabIndex = 22;
            // 
            // RegistroClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(606, 331);
            Controls.Add(panel1);
            Controls.Add(btnGuardar);
            Controls.Add(btnLimpiar);
            Controls.Add(btnSalir);
            Controls.Add(pictureBox1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegistroClientes";
            StartPosition = FormStartPosition.CenterParent;
            Text = "RegistroClientes";
            Load += RegistroClientes_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBoxIdentificacion;
        private TextBox textBoxNombre;
        private TextBox textBoxApellido;
        private DateTimePicker dateTimePickerNacimiento;
        private DateTimePicker dateTimePickerRegistro;
        private CheckBox checkBoxActivo;
        private Label labelActivoSi;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnSalir;
        private Panel panel1;
    }
}
