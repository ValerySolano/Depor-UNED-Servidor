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
            string identificacion = txtIdentificacion.Text;
            // Validar que el campo de identificación no esté vacío
            if (string.IsNullOrWhiteSpace(identificacion))
            {
                MessageBox.Show("Por favor, ingrese su identificación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else
            {
                // Intentar conectar al servidor
                bool conectado = ClienteTCP.Conectar(identificacion);
                if (conectado)
                {
                    MessageBox.Show("Conexión exitosa al servidor.", "Conexión establecida", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("No se pudo conectar al servidor. Por favor, intente nuevamente.", "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
