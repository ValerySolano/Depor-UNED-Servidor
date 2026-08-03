/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace presentación
{
    partial class RegistroLocalidades
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroLocalidades));
            panelMain = new Panel();
            titleLabel = new Label();
            separator = new Panel();
            lblId = new Label();
            idBorder = new Panel();
            idInner = new Panel();
            textBoxId = new TextBox();
            lblNombre = new Label();
            nombreBorder = new Panel();
            nombreInner = new Panel();
            textBoxNombre = new TextBox();
            lblPrecio = new Label();
            lblSimbolo = new Label();
            precioBorder = new Panel();
            precioInner = new Panel();
            numericPrecio = new NumericUpDown();
            imageCard = new Panel();
            pictureBox = new PictureBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panelMain.SuspendLayout();
            idBorder.SuspendLayout();
            idInner.SuspendLayout();
            nombreBorder.SuspendLayout();
            nombreInner.SuspendLayout();
            precioBorder.SuspendLayout();
            precioInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericPrecio).BeginInit();
            imageCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLight;
            panelMain.Controls.Add(titleLabel);
            panelMain.Controls.Add(separator);
            panelMain.Controls.Add(lblId);
            panelMain.Controls.Add(idBorder);
            panelMain.Controls.Add(lblNombre);
            panelMain.Controls.Add(nombreBorder);
            panelMain.Controls.Add(lblPrecio);
            panelMain.Controls.Add(lblSimbolo);
            panelMain.Controls.Add(precioBorder);
            panelMain.Controls.Add(imageCard);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnLimpiar);
            panelMain.Controls.Add(btnSalir);
            panelMain.Location = new Point(10, 9);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(665, 297);
            panelMain.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(3, 78, 162);
            titleLabel.Location = new Point(18, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(368, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "REGISTRO DE LOCALIDADES";
            // 
            // separator
            // 
            separator.BackColor = Color.FromArgb(3, 78, 162);
            separator.Location = new Point(18, 39);
            separator.Margin = new Padding(3, 2, 3, 2);
            separator.Name = "separator";
            separator.Size = new Size(630, 3);
            separator.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 60);
            lblId.Name = "lblId";
            lblId.Size = new Size(74, 15);
            lblId.TabIndex = 2;
            lblId.Text = "Id Localidad:";
            // 
            // idBorder
            // 
            idBorder.BackColor = Color.FromArgb(3, 78, 162);
            idBorder.Controls.Add(idInner);
            idBorder.Location = new Point(114, 57);
            idBorder.Margin = new Padding(3, 2, 3, 2);
            idBorder.Name = "idBorder";
            idBorder.Size = new Size(192, 24);
            idBorder.TabIndex = 3;
            // 
            // idInner
            // 
            idInner.BackColor = Color.White;
            idInner.Controls.Add(textBoxId);
            idInner.Location = new Point(2, 2);
            idInner.Margin = new Padding(3, 2, 3, 2);
            idInner.Name = "idInner";
            idInner.Size = new Size(189, 21);
            idInner.TabIndex = 0;
            // 
            // textBoxId
            // 
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Location = new Point(5, 4);
            textBoxId.Margin = new Padding(3, 2, 3, 2);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(175, 16);
            textBoxId.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 94);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(124, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre de Localidad:";
            // 
            // nombreBorder
            // 
            nombreBorder.BackColor = Color.FromArgb(3, 78, 162);
            nombreBorder.Controls.Add(nombreInner);
            nombreBorder.Location = new Point(18, 112);
            nombreBorder.Margin = new Padding(3, 2, 3, 2);
            nombreBorder.Name = "nombreBorder";
            nombreBorder.Size = new Size(368, 24);
            nombreBorder.TabIndex = 5;
            // 
            // nombreInner
            // 
            nombreInner.BackColor = Color.White;
            nombreInner.Controls.Add(textBoxNombre);
            nombreInner.Location = new Point(2, 2);
            nombreInner.Margin = new Padding(3, 2, 3, 2);
            nombreInner.Name = "nombreInner";
            nombreInner.Size = new Size(364, 21);
            nombreInner.TabIndex = 0;
            // 
            // textBoxNombre
            // 
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Location = new Point(5, 4);
            textBoxNombre.Margin = new Padding(3, 2, 3, 2);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(350, 16);
            textBoxNombre.TabIndex = 1;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(18, 148);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(43, 15);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Precio:";
            // 
            // lblSimbolo
            // 
            lblSimbolo.AutoSize = true;
            lblSimbolo.Location = new Point(114, 150);
            lblSimbolo.Name = "lblSimbolo";
            lblSimbolo.Size = new Size(13, 15);
            lblSimbolo.TabIndex = 7;
            lblSimbolo.Text = "¢";
            // 
            // precioBorder
            // 
            precioBorder.BackColor = Color.FromArgb(3, 78, 162);
            precioBorder.Controls.Add(precioInner);
            precioBorder.Location = new Point(131, 147);
            precioBorder.Margin = new Padding(3, 2, 3, 2);
            precioBorder.Name = "precioBorder";
            precioBorder.Size = new Size(122, 24);
            precioBorder.TabIndex = 8;
            // 
            // precioInner
            // 
            precioInner.BackColor = Color.White;
            precioInner.Controls.Add(numericPrecio);
            precioInner.Location = new Point(2, 2);
            precioInner.Margin = new Padding(3, 2, 3, 2);
            precioInner.Name = "precioInner";
            precioInner.Size = new Size(119, 21);
            precioInner.TabIndex = 0;
            // 
            // numericPrecio
            // 
            numericPrecio.BorderStyle = BorderStyle.None;
            numericPrecio.DecimalPlaces = 2;
            numericPrecio.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
            numericPrecio.Location = new Point(5, 3);
            numericPrecio.Margin = new Padding(3, 2, 3, 2);
            numericPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericPrecio.Name = "numericPrecio";
            numericPrecio.Size = new Size(105, 19);
            numericPrecio.TabIndex = 2;
            // 
            // imageCard
            // 
            imageCard.BackColor = Color.FromArgb(245, 246, 250);
            imageCard.Controls.Add(pictureBox);
            imageCard.Location = new Point(420, 57);
            imageCard.Margin = new Padding(3, 2, 3, 2);
            imageCard.Name = "imageCard";
            imageCard.Size = new Size(186, 165);
            imageCard.TabIndex = 9;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(3, 3);
            pictureBox.Margin = new Padding(3, 2, 3, 2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(179, 158);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(49, 240);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(144, 36);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(243, 240);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(142, 36);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "  Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(438, 240);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(122, 36);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            // 
            // RegistroLocalidades
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 310);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegistroLocalidades";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de Localidades";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            idBorder.ResumeLayout(false);
            idInner.ResumeLayout(false);
            idInner.PerformLayout();
            nombreBorder.ResumeLayout(false);
            nombreInner.ResumeLayout(false);
            nombreInner.PerformLayout();
            precioBorder.ResumeLayout(false);
            precioInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericPrecio).EndInit();
            imageCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.Panel idBorder;
        private System.Windows.Forms.Panel idInner;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Panel nombreBorder;
        private System.Windows.Forms.Panel nombreInner;
        private System.Windows.Forms.TextBox textBoxNombre;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblSimbolo;
        private System.Windows.Forms.Panel precioBorder;
        private System.Windows.Forms.Panel precioInner;
        private System.Windows.Forms.NumericUpDown numericPrecio;
        private System.Windows.Forms.Panel imageCard;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
    }
}

