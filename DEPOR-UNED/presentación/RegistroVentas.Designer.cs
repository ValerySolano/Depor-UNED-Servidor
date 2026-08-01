/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    partial class RegistroVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroVentas));
            panelMain = new Panel();
            titleLabel = new Label();
            separator = new Panel();
            lblId = new Label();
            idBorder = new Panel();
            idInner = new Panel();
            textBoxId = new TextBox();
            lblCliente = new Label();
            clienteBorder = new Panel();
            comboCliente = new ComboBox();
            lblPartido = new Label();
            partidoBorder = new Panel();
            comboPartido = new ComboBox();
            lblLocalidad = new Label();
            localidadBorder = new Panel();
            comboLocalidad = new ComboBox();
            lblCantidad = new Label();
            cantidadBorder = new Panel();
            textBoxCantidad = new TextBox();
            lblVendedor = new Label();
            vendedorBorder = new Panel();
            comboVendedor = new ComboBox();
            lblFecha = new Label();
            dateTimePickerVenta = new DateTimePicker();
            amountCard = new Panel();
            labelMontoTitulo = new Label();
            labelMontoSimbolo = new Label();
            labelMonto = new Label();
            pictureCard = new Panel();
            pictureBox = new PictureBox();
            btnCalcular = new Button();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            panelMain.SuspendLayout();
            idBorder.SuspendLayout();
            idInner.SuspendLayout();
            clienteBorder.SuspendLayout();
            partidoBorder.SuspendLayout();
            localidadBorder.SuspendLayout();
            cantidadBorder.SuspendLayout();
            vendedorBorder.SuspendLayout();
            amountCard.SuspendLayout();
            pictureCard.SuspendLayout();
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
            panelMain.Controls.Add(lblCliente);
            panelMain.Controls.Add(clienteBorder);
            panelMain.Controls.Add(lblPartido);
            panelMain.Controls.Add(partidoBorder);
            panelMain.Controls.Add(lblLocalidad);
            panelMain.Controls.Add(localidadBorder);
            panelMain.Controls.Add(lblCantidad);
            panelMain.Controls.Add(cantidadBorder);
            panelMain.Controls.Add(lblVendedor);
            panelMain.Controls.Add(vendedorBorder);
            panelMain.Controls.Add(lblFecha);
            panelMain.Controls.Add(dateTimePickerVenta);
            panelMain.Controls.Add(amountCard);
            panelMain.Controls.Add(pictureCard);
            panelMain.Controls.Add(btnCalcular);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnLimpiar);
            panelMain.Controls.Add(btnSalir);
            panelMain.Location = new Point(10, 9);
            panelMain.Margin = new Padding(3, 2, 3, 2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(711, 320);
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
            titleLabel.Text = "REGISTRO DE VENTAS";
            // 
            // separator
            // 
            separator.BackColor = Color.FromArgb(3, 78, 162);
            separator.Location = new Point(18, 39);
            separator.Margin = new Padding(3, 2, 3, 2);
            separator.Name = "separator";
            separator.Size = new Size(606, 8);
            separator.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 60);
            lblId.Name = "lblId";
            lblId.Size = new Size(52, 15);
            lblId.TabIndex = 2;
            lblId.Text = "Id Venta:";
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
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(18, 94);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(47, 15);
            lblCliente.TabIndex = 4;
            lblCliente.Text = "Cliente:";
            // 
            // clienteBorder
            // 
            clienteBorder.BackColor = Color.FromArgb(3, 78, 162);
            clienteBorder.Controls.Add(comboCliente);
            clienteBorder.Location = new Point(114, 92);
            clienteBorder.Margin = new Padding(3, 2, 3, 2);
            clienteBorder.Name = "clienteBorder";
            clienteBorder.Size = new Size(235, 24);
            clienteBorder.TabIndex = 5;
            // 
            // comboCliente
            // 
            comboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            comboCliente.FormattingEnabled = true;
            comboCliente.Items.AddRange(new object[] { "Seleccione cliente" });
            comboCliente.Location = new Point(4, 3);
            comboCliente.Margin = new Padding(3, 2, 3, 2);
            comboCliente.Name = "comboCliente";
            comboCliente.Size = new Size(230, 23);
            comboCliente.TabIndex = 0;
            // 
            // lblPartido
            // 
            lblPartido.AutoSize = true;
            lblPartido.Location = new Point(18, 128);
            lblPartido.Name = "lblPartido";
            lblPartido.Size = new Size(48, 15);
            lblPartido.TabIndex = 6;
            lblPartido.Text = "Partido:";
            // 
            // partidoBorder
            // 
            partidoBorder.BackColor = Color.FromArgb(3, 78, 162);
            partidoBorder.Controls.Add(comboPartido);
            partidoBorder.Location = new Point(114, 124);
            partidoBorder.Margin = new Padding(3, 2, 3, 2);
            partidoBorder.Name = "partidoBorder";
            partidoBorder.Size = new Size(235, 24);
            partidoBorder.TabIndex = 7;
            // 
            // comboPartido
            // 
            comboPartido.DropDownStyle = ComboBoxStyle.DropDownList;
            comboPartido.FormattingEnabled = true;
            comboPartido.Items.AddRange(new object[] { "Seleccione partido" });
            comboPartido.Location = new Point(4, 3);
            comboPartido.Margin = new Padding(3, 2, 3, 2);
            comboPartido.Name = "comboPartido";
            comboPartido.Size = new Size(230, 23);
            comboPartido.TabIndex = 0;
            comboPartido.SelectedIndexChanged += ComboPartido_SelectedIndexChanged;
            // 
            // lblLocalidad
            // 
            lblLocalidad.AutoSize = true;
            lblLocalidad.Location = new Point(18, 160);
            lblLocalidad.Name = "lblLocalidad";
            lblLocalidad.Size = new Size(61, 15);
            lblLocalidad.TabIndex = 8;
            lblLocalidad.Text = "Localidad:";
            // 
            // localidadBorder
            // 
            localidadBorder.BackColor = Color.FromArgb(3, 78, 162);
            localidadBorder.Controls.Add(comboLocalidad);
            localidadBorder.Location = new Point(114, 158);
            localidadBorder.Margin = new Padding(3, 2, 3, 2);
            localidadBorder.Name = "localidadBorder";
            localidadBorder.Size = new Size(235, 24);
            localidadBorder.TabIndex = 9;
            // 
            // comboLocalidad
            // 
            comboLocalidad.DropDownStyle = ComboBoxStyle.DropDownList;
            comboLocalidad.FormattingEnabled = true;
            comboLocalidad.Items.AddRange(new object[] { "Seleccione localidad" });
            comboLocalidad.Location = new Point(4, 3);
            comboLocalidad.Margin = new Padding(3, 2, 3, 2);
            comboLocalidad.Name = "comboLocalidad";
            comboLocalidad.Size = new Size(230, 23);
            comboLocalidad.TabIndex = 0;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(18, 194);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(58, 15);
            lblCantidad.TabIndex = 10;
            lblCantidad.Text = "Cantidad:";
            // 
            // cantidadBorder
            // 
            cantidadBorder.BackColor = Color.FromArgb(3, 78, 162);
            cantidadBorder.Controls.Add(textBoxCantidad);
            cantidadBorder.Location = new Point(114, 190);
            cantidadBorder.Margin = new Padding(3, 2, 3, 2);
            cantidadBorder.Name = "cantidadBorder";
            cantidadBorder.Size = new Size(122, 24);
            cantidadBorder.TabIndex = 11;
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
            // lblVendedor
            // 
            lblVendedor.AutoSize = true;
            lblVendedor.Location = new Point(18, 226);
            lblVendedor.Name = "lblVendedor";
            lblVendedor.Size = new Size(60, 15);
            lblVendedor.TabIndex = 12;
            lblVendedor.Text = "Vendedor:";
            // 
            // vendedorBorder
            // 
            vendedorBorder.BackColor = Color.FromArgb(3, 78, 162);
            vendedorBorder.Controls.Add(comboVendedor);
            vendedorBorder.Location = new Point(114, 224);
            vendedorBorder.Margin = new Padding(3, 2, 3, 2);
            vendedorBorder.Name = "vendedorBorder";
            vendedorBorder.Size = new Size(260, 24);
            vendedorBorder.TabIndex = 13;
            // 
            // comboVendedor
            // 
            comboVendedor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboVendedor.FormattingEnabled = true;
            comboVendedor.Items.AddRange(new object[] { "Seleccione vendedor" });
            comboVendedor.Location = new Point(4, 3);
            comboVendedor.Margin = new Padding(3, 2, 3, 2);
            comboVendedor.Name = "comboVendedor";
            comboVendedor.Size = new Size(255, 23);
            comboVendedor.TabIndex = 0;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(18, 260);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(73, 15);
            lblFecha.TabIndex = 14;
            lblFecha.Text = "Fecha Venta:";
            // 
            // dateTimePickerVenta
            // 
            dateTimePickerVenta.Format = DateTimePickerFormat.Short;
            dateTimePickerVenta.Location = new Point(114, 256);
            dateTimePickerVenta.Margin = new Padding(3, 2, 3, 2);
            dateTimePickerVenta.Name = "dateTimePickerVenta";
            dateTimePickerVenta.Size = new Size(132, 23);
            dateTimePickerVenta.TabIndex = 15;
            // 
            // amountCard
            // 
            amountCard.BackColor = Color.White;
            amountCard.BorderStyle = BorderStyle.FixedSingle;
            amountCard.Controls.Add(labelMontoTitulo);
            amountCard.Controls.Add(labelMontoSimbolo);
            amountCard.Controls.Add(labelMonto);
            amountCard.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amountCard.Location = new Point(420, 51);
            amountCard.Margin = new Padding(3, 2, 3, 2);
            amountCard.Name = "amountCard";
            amountCard.Size = new Size(188, 68);
            amountCard.TabIndex = 16;
            // 
            // labelMontoTitulo
            // 
            labelMontoTitulo.AutoSize = true;
            labelMontoTitulo.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelMontoTitulo.Location = new Point(10, 9);
            labelMontoTitulo.Name = "labelMontoTitulo";
            labelMontoTitulo.Size = new Size(90, 19);
            labelMontoTitulo.TabIndex = 0;
            labelMontoTitulo.Text = "Monto Total";
            // 
            // labelMontoSimbolo
            // 
            labelMontoSimbolo.AutoSize = true;
            labelMontoSimbolo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            labelMontoSimbolo.Location = new Point(14, 33);
            labelMontoSimbolo.Name = "labelMontoSimbolo";
            labelMontoSimbolo.Size = new Size(26, 30);
            labelMontoSimbolo.TabIndex = 1;
            labelMontoSimbolo.Text = "¢";
            // 
            // labelMonto
            // 
            labelMonto.AutoSize = true;
            labelMonto.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelMonto.Location = new Point(40, 33);
            labelMonto.Name = "labelMonto";
            labelMonto.Size = new Size(58, 30);
            labelMonto.TabIndex = 2;
            labelMonto.Text = "0.00";
            // 
            // pictureCard
            // 
            pictureCard.BackColor = Color.FromArgb(245, 246, 250);
            pictureCard.Controls.Add(pictureBox);
            pictureCard.Location = new Point(420, 122);
            pictureCard.Margin = new Padding(3, 2, 3, 2);
            pictureCard.Name = "pictureCard";
            pictureCard.Size = new Size(187, 120);
            pictureCard.TabIndex = 17;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(10, 9);
            pictureBox.Margin = new Padding(3, 2, 3, 2);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(164, 109);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnCalcular
            // 
            btnCalcular.BackColor = Color.FromArgb(102, 51, 153);
            btnCalcular.FlatStyle = FlatStyle.Flat;
            btnCalcular.ForeColor = Color.White;
            btnCalcular.Location = new Point(96, 287);
            btnCalcular.Margin = new Padding(3, 2, 3, 2);
            btnCalcular.Name = "btnCalcular";
            btnCalcular.Size = new Size(122, 30);
            btnCalcular.TabIndex = 18;
            btnCalcular.Text = "  Calcular";
            btnCalcular.UseVisualStyleBackColor = false;
            btnCalcular.Click += BtnCalcular_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(236, 287);
            btnGuardar.Margin = new Padding(3, 2, 3, 2);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(122, 30);
            btnGuardar.TabIndex = 19;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += BtnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(376, 287);
            btnLimpiar.Margin = new Padding(3, 2, 3, 2);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(122, 30);
            btnLimpiar.TabIndex = 20;
            btnLimpiar.Text = "  Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(516, 287);
            btnSalir.Margin = new Padding(3, 2, 3, 2);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(122, 30);
            btnSalir.TabIndex = 21;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // RegistroVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(732, 332);
            Controls.Add(panelMain);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 2, 3, 2);
            Name = "RegistroVentas";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Registro de Ventas";
            Load += RegistroVentas_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            idBorder.ResumeLayout(false);
            idInner.ResumeLayout(false);
            idInner.PerformLayout();
            clienteBorder.ResumeLayout(false);
            partidoBorder.ResumeLayout(false);
            localidadBorder.ResumeLayout(false);
            cantidadBorder.ResumeLayout(false);
            cantidadBorder.PerformLayout();
            vendedorBorder.ResumeLayout(false);
            amountCard.ResumeLayout(false);
            amountCard.PerformLayout();
            pictureCard.ResumeLayout(false);
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
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Panel clienteBorder;
        private System.Windows.Forms.ComboBox comboCliente;
        private System.Windows.Forms.Label lblPartido;
        private System.Windows.Forms.Panel partidoBorder;
        private System.Windows.Forms.ComboBox comboPartido;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Panel localidadBorder;
        private System.Windows.Forms.ComboBox comboLocalidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblVendedor;
        private System.Windows.Forms.Panel vendedorBorder;
        private System.Windows.Forms.ComboBox comboVendedor;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dateTimePickerVenta;
        private System.Windows.Forms.Panel pictureCard;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Panel amountCard;
        private System.Windows.Forms.Label labelMontoTitulo;
        private System.Windows.Forms.Label labelMontoSimbolo;
        private System.Windows.Forms.Label labelMonto;
        private Panel cantidadBorder;
        private TextBox textBoxCantidad;
    }
}

