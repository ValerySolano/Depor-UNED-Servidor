/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    partial class LocalidadesPartido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalidadesPartido));
            panelMain = new Panel();
            titleLabel = new Label();
            separator = new Panel();
            lblIdRegistro = new Label();
            idBorder = new Panel();
            idInner = new Panel();
            textBoxIdRegistro = new TextBox();
            lblPartido = new Label();
            partidoBorder = new Panel();
            comboPartido = new ComboBox();
            lblFecha = new Label();
            dateTimePickerFecha = new DateTimePicker();
            lblHora = new Label();
            dateTimePickerHora = new DateTimePicker();
            lblLocalidad = new Label();
            localidadBorder = new Panel();
            comboLocalidad = new ComboBox();
            lblCantidad = new Label();
            cantidadBorder = new Panel();
            textBoxCantidad = new TextBox();
            imageCard = new Panel();
            pictureBox = new PictureBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panelMain.SuspendLayout();
            idBorder.SuspendLayout();
            idInner.SuspendLayout();
            partidoBorder.SuspendLayout();
            localidadBorder.SuspendLayout();
            cantidadBorder.SuspendLayout();
            imageCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLight;
            panelMain.Controls.Add(titleLabel);
            panelMain.Controls.Add(separator);
            panelMain.Controls.Add(lblIdRegistro);
            panelMain.Controls.Add(idBorder);
            panelMain.Controls.Add(lblPartido);
            panelMain.Controls.Add(partidoBorder);
            panelMain.Controls.Add(lblFecha);
            panelMain.Controls.Add(dateTimePickerFecha);
            panelMain.Controls.Add(lblHora);
            panelMain.Controls.Add(dateTimePickerHora);
            panelMain.Controls.Add(lblLocalidad);
            panelMain.Controls.Add(localidadBorder);
            panelMain.Controls.Add(lblCantidad);
            panelMain.Controls.Add(cantidadBorder);
            panelMain.Controls.Add(imageCard);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnLimpiar);
            panelMain.Controls.Add(btnSalir);
            panelMain.Location = new Point(10, 9);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(647, 320);
            panelMain.TabIndex = 0;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(3, 78, 162);
            titleLabel.Location = new Point(18, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(408, 21);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "ASIGNAR LOCALIDADES A PARTIDO";
            // 
            // separator
            // 
            separator.BackColor = Color.FromArgb(3, 78, 162);
            separator.Location = new Point(18, 39);
            separator.Margin = new Padding(3, 2, 3, 2);
            separator.Name = "separator";
            separator.Size = new Size(621, 8);
            separator.TabIndex = 1;
            // 
            // lblIdRegistro
            // 
            lblIdRegistro.AutoSize = true;
            lblIdRegistro.Location = new Point(18, 63);
            lblIdRegistro.Name = "lblIdRegistro";
            lblIdRegistro.Size = new Size(66, 15);
            lblIdRegistro.TabIndex = 2;
            lblIdRegistro.Text = "Id Registro:";
            // 
            // idBorder
            // 
            idBorder.BackColor = Color.FromArgb(3, 78, 162);
            idBorder.Controls.Add(idInner);
            idBorder.Location = new Point(114, 60);
            idBorder.Margin = new Padding(3, 2, 3, 2);
            idBorder.Name = "idBorder";
            idBorder.Size = new Size(192, 24);
            idBorder.TabIndex = 3;
            // 
            // idInner
            // 
            idInner.BackColor = Color.White;
            idInner.Controls.Add(textBoxIdRegistro);
            idInner.Location = new Point(2, 2);
            idInner.Margin = new Padding(3, 2, 3, 2);
            idInner.Name = "idInner";
            idInner.Size = new Size(189, 21);
            idInner.TabIndex = 0;
            // 
            // textBoxIdRegistro
            // 
            textBoxIdRegistro.BorderStyle = BorderStyle.None;
            textBoxIdRegistro.Location = new Point(5, 4);
            textBoxIdRegistro.Margin = new Padding(3, 2, 3, 2);
            textBoxIdRegistro.Name = "textBoxIdRegistro";
            textBoxIdRegistro.Size = new Size(175, 16);
            textBoxIdRegistro.TabIndex = 0;
            // 
            // lblPartido
            // 
            lblPartido.AutoSize = true;
            lblPartido.Location = new Point(18, 94);
            lblPartido.Name = "lblPartido";
            lblPartido.Size = new Size(48, 15);
            lblPartido.TabIndex = 4;
            lblPartido.Text = "Partido:";
            // 
            // partidoBorder
            // 
            partidoBorder.BackColor = Color.FromArgb(3, 78, 162);
            partidoBorder.Controls.Add(comboPartido);
            partidoBorder.Location = new Point(114, 92);
            partidoBorder.Margin = new Padding(3, 2, 3, 2);
            partidoBorder.Name = "partidoBorder";
            partidoBorder.Size = new Size(222, 24);
            partidoBorder.TabIndex = 5;
            // 
            // comboPartido
            // 
            comboPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPartido.FormattingEnabled = true;
            comboPartido.Items.AddRange(new object[] { "Seleccione partido" });
            comboPartido.Location = new Point(4, 3);
            comboPartido.Margin = new Padding(3, 2, 3, 2);
            comboPartido.Name = "comboPartido";
            comboPartido.Size = new Size(217, 23);
            comboPartido.TabIndex = 0;
            comboPartido.SelectedValueChanged += comboPartido_SelectedValueChanged;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(18, 128);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(82, 15);
            lblFecha.TabIndex = 6;
            lblFecha.Text = "Fecha Partido:";
            // 
            // dateTimePickerFecha
            // 
            dateTimePickerFecha.Enabled = false;
            dateTimePickerFecha.Format = DateTimePickerFormat.Short;
            dateTimePickerFecha.Location = new Point(114, 124);
            dateTimePickerFecha.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerFecha.Name = "dateTimePickerFecha";
            dateTimePickerFecha.Size = new Size(132, 23);
            dateTimePickerFecha.TabIndex = 7;
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Location = new Point(18, 158);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(77, 15);
            lblHora.TabIndex = 8;
            lblHora.Text = "Hora Partido:";
            // 
            // dateTimePickerHora
            // 
            dateTimePickerHora.Enabled = false;
            dateTimePickerHora.Format = DateTimePickerFormat.Time;
            dateTimePickerHora.Location = new Point(114, 154);
            dateTimePickerHora.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerHora.Name = "dateTimePickerHora";
            dateTimePickerHora.ShowUpDown = true;
            dateTimePickerHora.Size = new Size(88, 23);
            dateTimePickerHora.TabIndex = 9;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(18, 189);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(61, 15);
            lblLocalidad.TabIndex = 10;
            lblLocalidad.Text = "Localidad:";
            // 
            // localidadBorder
            // 
            localidadBorder.BackColor = Color.FromArgb(3, 78, 162);
            localidadBorder.Controls.Add(comboLocalidad);
            localidadBorder.Location = new Point(114, 186);
            localidadBorder.Margin = new Padding(3, 2, 3, 2);
            localidadBorder.Name = "localidadBorder";
            localidadBorder.Size = new Size(268, 24);
            localidadBorder.TabIndex = 11;
            // 
            // comboLocalidad
            // 
            comboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLocalidad.FormattingEnabled = true;
            comboLocalidad.Items.AddRange(new object[] { "Seleccione localidad" });
            comboLocalidad.Location = new Point(4, 3);
            comboLocalidad.Margin = new Padding(3, 2, 3, 2);
            comboLocalidad.Name = "comboLocalidad";
            comboLocalidad.Size = new Size(264, 23);
            comboLocalidad.TabIndex = 0;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(18, 220);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(117, 15);
            lblCantidad.TabIndex = 12;
            lblCantidad.Text = "Cantidad Disponible:";
            // 
            // cantidadBorder
            // 
            cantidadBorder.BackColor = Color.FromArgb(3, 78, 162);
            cantidadBorder.Controls.Add(textBoxCantidad);
            cantidadBorder.Location = new Point(149, 218);
            cantidadBorder.Margin = new Padding(3, 2, 3, 2);
            cantidadBorder.Name = "cantidadBorder";
            cantidadBorder.Size = new Size(122, 24);
            cantidadBorder.TabIndex = 13;
            // 
            // textBoxCantidad
            // 
            textBoxCantidad.BorderStyle = BorderStyle.None;
            textBoxCantidad.Location = new Point(5, 4);
            textBoxCantidad.Margin = new Padding(3, 2, 3, 2);
            textBoxCantidad.Name = "textBoxCantidad";
            textBoxCantidad.Size = new Size(112, 16);
            textBoxCantidad.TabIndex = 0;
            // 
            // imageCard
            // 
            imageCard.BackColor = Color.FromArgb(245, 246, 250);
            imageCard.Controls.Add(pictureBox);
            imageCard.Location = new Point(420, 60);
            imageCard.Margin = new Padding(3, 2, 3, 2);
            imageCard.Name = "imageCard";
            imageCard.Size = new Size(172, 136);
            imageCard.TabIndex = 14;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(18, 5);
            pictureBox.Margin = new Padding(3, 2, 3, 2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(140, 129);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(18, 270);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(144, 36);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(218, 270);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(144, 36);
            btnLimpiar.TabIndex = 17;
            btnLimpiar.Text = "  Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(420, 270);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(122, 36);
            btnSalir.TabIndex = 18;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // LocalidadesPartido
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(659, 338);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "LocalidadesPartido";
            StartPosition = FormStartPosition.CenterParent;
            Text = "-";
            Load += LocalidadesPartido_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            idBorder.ResumeLayout(false);
            idInner.ResumeLayout(false);
            idInner.PerformLayout();
            partidoBorder.ResumeLayout(false);
            localidadBorder.ResumeLayout(false);
            cantidadBorder.ResumeLayout(false);
            cantidadBorder.PerformLayout();
            imageCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Panel separator;
        private System.Windows.Forms.Label lblIdRegistro;
        private System.Windows.Forms.Panel idBorder;
        private System.Windows.Forms.Panel idInner;
        private System.Windows.Forms.TextBox textBoxIdRegistro;
        private System.Windows.Forms.Label lblPartido;
        private System.Windows.Forms.Panel partidoBorder;
        private System.Windows.Forms.ComboBox comboPartido;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dateTimePickerFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dateTimePickerHora;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Panel localidadBorder;
        private System.Windows.Forms.ComboBox comboLocalidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Panel cantidadBorder;
        private System.Windows.Forms.TextBox textBoxCantidad;
        private System.Windows.Forms.Panel imageCard;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
    }
}

