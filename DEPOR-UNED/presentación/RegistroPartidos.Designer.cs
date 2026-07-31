/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/namespace presentación
{
    partial class RegistroPartidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistroPartidos));
            panelMain = new Panel();
            dateTimeHora = new DateTimePicker();
            checkBoxActivo = new CheckBox();
            label1 = new Label();
            label7 = new Label();
            dateTimePickerNacimiento = new DateTimePicker();
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
            imageCard = new Panel();
            pictureBox = new PictureBox();
            btnGuardar = new Button();
            btnLimpiar = new Button();
            btnSalir = new Button();
            dateTimePickerHora = new DateTimePicker();
            btnHoraAhora = new Button();
            btnHora15 = new Button();
            btnHora20 = new Button();
            panelMain.SuspendLayout();
            idBorder.SuspendLayout();
            idInner.SuspendLayout();
            nombreBorder.SuspendLayout();
            nombreInner.SuspendLayout();
            imageCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.ControlLight;
            panelMain.Controls.Add(dateTimeHora);
            panelMain.Controls.Add(checkBoxActivo);
            panelMain.Controls.Add(label1);
            panelMain.Controls.Add(label7);
            panelMain.Controls.Add(dateTimePickerNacimiento);
            panelMain.Controls.Add(titleLabel);
            panelMain.Controls.Add(separator);
            panelMain.Controls.Add(lblId);
            panelMain.Controls.Add(idBorder);
            panelMain.Controls.Add(lblNombre);
            panelMain.Controls.Add(nombreBorder);
            panelMain.Controls.Add(lblPrecio);
            panelMain.Controls.Add(imageCard);
            panelMain.Controls.Add(btnGuardar);
            panelMain.Controls.Add(btnLimpiar);
            panelMain.Controls.Add(btnSalir);
            panelMain.Location = new Point(20, 12);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(678, 393);
            panelMain.TabIndex = 1;
            // 
            // dateTimeHora
            // 
            dateTimeHora.Format = DateTimePickerFormat.Time;
            dateTimeHora.Location = new Point(127, 208);
            dateTimeHora.Name = "dateTimeHora";
            dateTimeHora.Size = new Size(223, 27);
            dateTimeHora.TabIndex = 21;
            // 
            // checkBoxActivo
            // 
            checkBoxActivo.Location = new Point(127, 271);
            checkBoxActivo.Name = "checkBoxActivo";
            checkBoxActivo.Size = new Size(20, 20);
            checkBoxActivo.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 271);
            label1.Name = "label1";
            label1.Size = new Size(54, 20);
            label1.TabIndex = 17;
            label1.Text = "Activo:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(52, 208);
            label7.Name = "label7";
            label7.Size = new Size(45, 20);
            label7.TabIndex = 16;
            label7.Text = "Hora:";
            // 
            // dateTimePickerNacimiento
            // 
            dateTimePickerNacimiento.Format = DateTimePickerFormat.Short;
            dateTimePickerNacimiento.Location = new Point(127, 161);
            dateTimePickerNacimiento.Name = "dateTimePickerNacimiento";
            dateTimePickerNacimiento.Size = new Size(223, 27);
            dateTimePickerNacimiento.TabIndex = 15;
            // 
            // titleLabel
            // 
            titleLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleLabel.ForeColor = Color.FromArgb(3, 78, 162);
            titleLabel.Location = new Point(20, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(420, 28);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "REGISTRO DE PARTIDOS";
            // 
            // separator
            // 
            separator.BackColor = Color.FromArgb(3, 78, 162);
            separator.Location = new Point(20, 52);
            separator.Name = "separator";
            separator.Size = new Size(642, 10);
            separator.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(36, 83);
            lblId.Name = "lblId";
            lblId.Size = new Size(76, 20);
            lblId.TabIndex = 2;
            lblId.Text = "Id Partido:";
            // 
            // idBorder
            // 
            idBorder.BackColor = Color.FromArgb(3, 78, 162);
            idBorder.Controls.Add(idInner);
            idBorder.Location = new Point(130, 76);
            idBorder.Name = "idBorder";
            idBorder.Size = new Size(220, 32);
            idBorder.TabIndex = 3;
            // 
            // idInner
            // 
            idInner.BackColor = Color.White;
            idInner.Controls.Add(textBoxId);
            idInner.Location = new Point(2, 2);
            idInner.Name = "idInner";
            idInner.Size = new Size(216, 28);
            idInner.TabIndex = 0;
            // 
            // textBoxId
            // 
            textBoxId.BorderStyle = BorderStyle.None;
            textBoxId.Location = new Point(6, 5);
            textBoxId.Name = "textBoxId";
            textBoxId.Size = new Size(200, 20);
            textBoxId.TabIndex = 0;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(52, 126);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(44, 20);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Rival:";
            // 
            // nombreBorder
            // 
            nombreBorder.BackColor = Color.FromArgb(3, 78, 162);
            nombreBorder.Controls.Add(nombreInner);
            nombreBorder.Location = new Point(127, 114);
            nombreBorder.Name = "nombreBorder";
            nombreBorder.Size = new Size(223, 32);
            nombreBorder.TabIndex = 5;
            // 
            // nombreInner
            // 
            nombreInner.BackColor = Color.White;
            nombreInner.Controls.Add(textBoxNombre);
            nombreInner.Location = new Point(3, 2);
            nombreInner.Name = "nombreInner";
            nombreInner.Size = new Size(219, 28);
            nombreInner.TabIndex = 0;
            // 
            // textBoxNombre
            // 
            textBoxNombre.BorderStyle = BorderStyle.None;
            textBoxNombre.Location = new Point(0, 5);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(214, 20);
            textBoxNombre.TabIndex = 1;
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Location = new Point(52, 161);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(50, 20);
            lblPrecio.TabIndex = 6;
            lblPrecio.Text = "Fecha:";
            // 
            // imageCard
            // 
            imageCard.BackColor = Color.FromArgb(245, 246, 250);
            imageCard.Controls.Add(pictureBox);
            imageCard.Location = new Point(442, 76);
            imageCard.Name = "imageCard";
            imageCard.Size = new Size(198, 196);
            imageCard.TabIndex = 9;
            // 
            // pictureBox
            // 
            pictureBox.Image = (Image)resources.GetObject("pictureBox.Image");
            pictureBox.Location = new Point(15, 14);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(166, 161);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(95, 320);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(190, 48);
            btnGuardar.TabIndex = 11;
            btnGuardar.Text = "  Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(255, 152, 0);
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(340, 320);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(140, 48);
            btnLimpiar.TabIndex = 12;
            btnLimpiar.Text = "  Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += BtnLimpiar_Click;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.FromArgb(220, 53, 69);
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = Color.White;
            btnSalir.Location = new Point(500, 320);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(140, 48);
            btnSalir.TabIndex = 13;
            btnSalir.Text = "  Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += BtnSalir_Click;
            // 
            // dateTimePickerHora
            // 
            dateTimePickerHora.Format = DateTimePickerFormat.Time;
            dateTimePickerHora.Location = new Point(132, 204);
            dateTimePickerHora.Name = "dateTimePickerHora";
            dateTimePickerHora.ShowUpDown = true;
            dateTimePickerHora.Size = new Size(100, 27);
            dateTimePickerHora.TabIndex = 16;
            dateTimePickerHora.Value = new DateTime(2026, 6, 18, 20, 9, 39, 547);
            // 
            // btnHoraAhora
            // 
            btnHoraAhora.Location = new Point(0, 0);
            btnHoraAhora.Name = "btnHoraAhora";
            btnHoraAhora.Size = new Size(75, 23);
            btnHoraAhora.TabIndex = 0;
            // 
            // btnHora15
            // 
            btnHora15.Location = new Point(0, 0);
            btnHora15.Name = "btnHora15";
            btnHora15.Size = new Size(75, 23);
            btnHora15.TabIndex = 0;
            // 
            // btnHora20
            // 
            btnHora20.Location = new Point(0, 0);
            btnHora20.Name = "btnHora20";
            btnHora20.Size = new Size(75, 23);
            btnHora20.TabIndex = 0;
            // 
            // RegistroPartidos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(713, 401);
            Controls.Add(panelMain);
            Name = "RegistroPartidos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegistroPartidos";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            idBorder.ResumeLayout(false);
            idInner.ResumeLayout(false);
            idInner.PerformLayout();
            nombreBorder.ResumeLayout(false);
            nombreInner.ResumeLayout(false);
            nombreInner.PerformLayout();
            imageCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Label titleLabel;
        private Panel separator;
        private Label lblId;
        private Panel idBorder;
        private Panel idInner;
        private TextBox textBoxId;
        private Label lblNombre;
        private Panel nombreBorder;
        private Panel nombreInner;
        private TextBox textBoxNombre;
        private Label lblPrecio;
        private Panel imageCard;
        private PictureBox pictureBox;
        private Button btnGuardar;
        private Button btnLimpiar;
        private Button btnSalir;
        private DateTimePicker dateTimePickerNacimiento;
        private DateTimePicker dateTimePickerHora;
        private Button btnHoraAhora;
        private Button btnHora15;
        private Button btnHora20;
        private Label label7;
        private Label label1;
        private CheckBox checkBoxActivo;
        private Label labelActivoSi;
        private DateTimePicker dateTimeHora;
    }
}