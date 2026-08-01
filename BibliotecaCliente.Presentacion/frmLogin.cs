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

            // Conectar y validar en una sola operación usando la misma conexión TCP
            this.labelConexion.Text = "Conectando al servidor...";
            this.labelConexion.Refresh(); // Asegura que el label se actualice antes de la operación de red
            this.labelConexionError.Text = " ";
            this.labelConexionError.Refresh(); // Asegura que el label se actualice antes de la operación de red
            this.btnIniciarSession.Enabled = false; // Deshabilitar el botón mientras se realiza la conexión

            string resultado = ClienteTCP.ConectarYValidar(identificacion);
            this.labelConexion.Text = " ";
            this.labelConexion.Refresh(); // Asegura que el label se actualice después de la operación de red
            this.btnIniciarSession.Enabled = true; // Rehabilitar el botón después de la operación
            if (resultado == "NOEXISTE")
            {
               this.labelConexionError.Text = "La identificación ingresada no existe en el sistema.";
                this.labelConexion.Text = " ";
                return;
            }
            else if (resultado == "INACTIVO")
            {
               this.labelConexionError.Text = "Su cuenta está inactiva. No puede iniciar sesión en este momento.\n\nPor favor, contacte al administrador del sistema.";
                this.labelConexion.Text = " ";
                this.labelConexion.Refresh(); // Asegura que el label se actualice después de la operación de red
                return;
            }
            else if (resultado == "VALIDO")
            {
                clienteConectado = true;
                FrmPanelCliente panelCliente = new FrmPanelCliente(identificacion);
                
                // Suscribirse al evento FormClosed para volver a mostrar el login cuando se cierre
                panelCliente.FormClosed += (s, args) =>
                {
                    txtIdentificacion.Clear();
                    this.Show();
                    clienteConectado = false;
                };
                
                panelCliente.Show();
                this.Hide();
                this.labelConexion.Text = "Conexión establecida con el servidor.";
                this.labelConexionError.Text = " ";
                this.labelConexion.Refresh(); // Asegura que el label se actualice después de la operación de red
                this.labelConexionError.Refresh(); // Asegura que el label se actualice después de la operación de red
            }
            else
            {
                this.labelConexionError.Text = "Error de conexión TCP con el servidor. Intente nuevamente.";
            }
        }
    }
}
