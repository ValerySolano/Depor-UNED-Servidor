/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class ListadoClientes : Form
    {
        private LogicaCliente logicaCliente;

        public ListadoClientes()
        {
            InitializeComponent();
            logicaCliente = new LogicaCliente();
        }

        private void ListadoClientes_Load(object? sender, EventArgs e)
        {
            CargarClientes();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            RegistroClientes registroClientes = new RegistroClientes();
            registroClientes.ShowDialog();
            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                List<Cliente> clientes = logicaCliente.ObtenerClientes();
                dataGridClientes.Rows.Clear();

                int indice = 0;
                while (indice < clientes.Count)
                {
                    Cliente cliente = clientes[indice];

                    dataGridClientes.Rows.Add(
                        cliente.IdCliente,
                        cliente.Identificacion,
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.FechaNacimiento.ToShortDateString(),
                        cliente.FechaIngreso.ToShortDateString(),
                        cliente.Activo);

                    indice++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

