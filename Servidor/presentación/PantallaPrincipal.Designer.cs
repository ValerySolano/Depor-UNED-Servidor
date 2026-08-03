/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class PantallaPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PantallaPrincipal));
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            panel3 = new Panel();
            label1 = new Label();
            btnSalir = new Button();
            btnVentas = new Button();
            btnVendedores = new Button();
            btnLocalidadesPartido = new Button();
            btnLocalidades = new Button();
            btnPartidos = new Button();
            btnClientes = new Button();
            label2 = new Label();
            panel2 = new Panel();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.GrayText;
            pictureBox1.Image = Properties.Resources.escudo;
            pictureBox1.Location = new Point(109, 5);
            pictureBox1.Margin = new Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 104);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGreen;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnVentas);
            panel1.Controls.Add(btnVendedores);
            panel1.Controls.Add(btnLocalidadesPartido);
            panel1.Controls.Add(btnLocalidades);
            panel1.Controls.Add(btnPartidos);
            panel1.Controls.Add(btnClientes);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(336, 519);
            panel1.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(0, 64, 0);
            label4.Font = new Font("Sitka Banner", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(93, 194);
            label4.Name = "label4";
            label4.Size = new Size(129, 23);
            label4.TabIndex = 12;
            label4.Text = "MENÚ PRINCIPAL";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 64, 0);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 112);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(336, 70);
            panel3.TabIndex = 11;
            // 
            // label1
            // 
            label1.Font = new Font("Times New Roman", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(10, 0);
            label1.Name = "label1";
            label1.Size = new Size(307, 70);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA DE VENTA DE BOLETOS FÚTBOL";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.Red;
            btnSalir.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonHighlight;
            btnSalir.Location = new Point(35, 427);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(185, 34);
            btnSalir.TabIndex = 9;
            btnSalir.Text = "SALIR";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnVentas
            // 
            btnVentas.BackColor = Color.LimeGreen;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = SystemColors.ButtonHighlight;
            btnVentas.Location = new Point(35, 387);
            btnVentas.Margin = new Padding(3, 2, 3, 2);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(185, 26);
            btnVentas.TabIndex = 7;
            btnVentas.Text = "Ventas";
            btnVentas.UseVisualStyleBackColor = false;
            btnVentas.Click += btnVentas_Click;
            // 
            // btnVendedores
            // 
            btnVendedores.BackColor = Color.LimeGreen;
            btnVendedores.FlatStyle = FlatStyle.Flat;
            btnVendedores.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVendedores.ForeColor = SystemColors.ButtonHighlight;
            btnVendedores.Location = new Point(35, 289);
            btnVendedores.Margin = new Padding(3, 2, 3, 2);
            btnVendedores.Name = "btnVendedores";
            btnVendedores.Size = new Size(185, 31);
            btnVendedores.TabIndex = 6;
            btnVendedores.Text = "Vendedores";
            btnVendedores.UseVisualStyleBackColor = false;
            btnVendedores.Click += button5_Click;
            // 
            // btnLocalidadesPartido
            // 
            btnLocalidadesPartido.BackColor = Color.LimeGreen;
            btnLocalidadesPartido.FlatStyle = FlatStyle.Flat;
            btnLocalidadesPartido.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocalidadesPartido.ForeColor = SystemColors.ButtonHighlight;
            btnLocalidadesPartido.Location = new Point(35, 352);
            btnLocalidadesPartido.Margin = new Padding(3, 2, 3, 2);
            btnLocalidadesPartido.Name = "btnLocalidadesPartido";
            btnLocalidadesPartido.Size = new Size(185, 31);
            btnLocalidadesPartido.TabIndex = 5;
            btnLocalidadesPartido.Text = "Localidades por Partido";
            btnLocalidadesPartido.UseVisualStyleBackColor = false;
            btnLocalidadesPartido.Click += btnLocalidadesPartido_Click;
            // 
            // btnLocalidades
            // 
            btnLocalidades.BackColor = Color.LimeGreen;
            btnLocalidades.FlatStyle = FlatStyle.Flat;
            btnLocalidades.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLocalidades.ForeColor = SystemColors.ButtonHighlight;
            btnLocalidades.Location = new Point(37, 219);
            btnLocalidades.Margin = new Padding(3, 2, 3, 2);
            btnLocalidades.Name = "btnLocalidades";
            btnLocalidades.Size = new Size(185, 31);
            btnLocalidades.TabIndex = 4;
            btnLocalidades.Text = "Localidades";
            btnLocalidades.UseVisualStyleBackColor = false;
            btnLocalidades.Click += btnLocalidades_Click;
            // 
            // btnPartidos
            // 
            btnPartidos.BackColor = Color.LimeGreen;
            btnPartidos.FlatStyle = FlatStyle.Flat;
            btnPartidos.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPartidos.ForeColor = SystemColors.ButtonHighlight;
            btnPartidos.Location = new Point(37, 254);
            btnPartidos.Margin = new Padding(3, 2, 3, 2);
            btnPartidos.Name = "btnPartidos";
            btnPartidos.Size = new Size(185, 31);
            btnPartidos.TabIndex = 3;
            btnPartidos.Text = "Partidos";
            btnPartidos.UseVisualStyleBackColor = false;
            btnPartidos.Click += btnPartidos_Click;
            // 
            // btnClientes
            // 
            btnClientes.BackColor = Color.LimeGreen;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = SystemColors.ButtonHighlight;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(35, 324);
            btnClientes.Margin = new Padding(3, 2, 3, 2);
            btnClientes.Name = "btnClientes";
            btnClientes.Size = new Size(185, 24);
            btnClientes.TabIndex = 2;
            btnClientes.Text = "Clientes";
            btnClientes.UseVisualStyleBackColor = false;
            btnClientes.Click += btnClientes_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(0, 64, 0);
            label2.Location = new Point(155, 43);
            label2.Name = "label2";
            label2.Size = new Size(272, 31);
            label2.TabIndex = 3;
            label2.Text = "Bienvenido al Sistema";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(337, 0);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(613, 308);
            panel2.TabIndex = 4;
            // 
            // label3
            // 
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Times New Roman", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 64, 0);
            label3.Location = new Point(-1, 101);
            label3.Name = "label3";
            label3.Size = new Size(581, 81);
            label3.TabIndex = 6;
            label3.Text = "Gestione clientes,partidos, localidades y ventas de boletos";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            pictureBox2.Dock = DockStyle.Bottom;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(336, 257);
            pictureBox2.Margin = new Padding(3, 2, 3, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(614, 262);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 5;
            pictureBox2.TabStop = false;
            // 
            // PantallaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(950, 519);
            Controls.Add(pictureBox2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "PantallaPrincipal";
            StartPosition = FormStartPosition.CenterParent;
            Text = " ";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private PictureBox pictureBox2;
        private Button btnVendedores;
        private Button btnLocalidadesPartido;
        private Button btnLocalidades;
        private Button btnPartidos;
        private Button btnClientes;
        private Button btnSalir;
        private Button btnVentas;
        private Label label3;
        private Panel panel3;
        private Label label1;
        private Label label4;
    }
}

