namespace BibliotecaCliente.Presentacion
{
    public partial class frmLogin : Form
    {
        bool clienteConectado = false;
        public frmLogin()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIniciarSession_Click(object sender, EventArgs e)
        {
            string identificacion = txtIdentificacion.Text?.Trim();

            if (string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show("Por favor, ingrese su identificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string resultadoValidacion = ClienteTCP.ValidarIdentificacion(identificacion);
            
            if (resultadoValidacion == "NOEXISTE")
            {
                MessageBox.Show("La identificación ingresada no existe en el sistema.", "Identificación inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (resultadoValidacion == "INACTIVO")
            {
                MessageBox.Show("Su cuenta está inactiva. No puede iniciar sesión en este momento.\n\nPor favor, contacte al administrador del sistema.", "Usuario inactivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (resultadoValidacion != "VALIDO")
            {
                MessageBox.Show("Error al validar la identificación. Por favor, intente nuevamente.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool conectado = ClienteTCP.Conectar(identificacion);
            if (conectado)
            {
                clienteConectado = true;
                MessageBox.Show("Conexión exitosa al servidor.", "Conexión establecida", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FrmPanelCliente panelCliente = new FrmPanelCliente(identificacion);
                panelCliente.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se pudo conectar al servidor. Por favor, intente nuevamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
