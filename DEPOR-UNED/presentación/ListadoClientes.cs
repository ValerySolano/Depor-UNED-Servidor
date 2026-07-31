/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class ListadoClientes : Form
    {
        // Instancia de la lógica de negocio para operaciones con clientes
        private LogicaCliente logicaCliente;

        // Constructor: inicializa componentes y crea la capa de lógica de negocio
        public ListadoClientes()
        {
            InitializeComponent();
            // Crear la instancia responsable de validar y obtener clientes
            logicaCliente = new LogicaCliente();
        }

        // Evento Load del formulario: cargar la lista al abrir la ventana
        private void ListadoClientes_Load(object? sender, EventArgs e)
        {
            // Cargar los clientes desde la capa de negocio y mostrarlos en el DataGridView
            CargarClientes();
        }

        // Manejador del botón Nuevo Cliente: abre el formulario de registro
        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            // Crear la ventana de registro de clientes
            RegistroClientes registroClientes = new RegistroClientes();

            // Mostrarla de forma modal para esperar a que el usuario termine
            registroClientes.ShowDialog();

            // Tras cerrar el formulario de registro, recargar los clientes para reflejar cambios
            CargarClientes();
        }

        // Carga los clientes desde la lógica y llena el DataGridView
        private void CargarClientes()
        {
            try
            {
                // Obtener todos los clientes disponibles en la capa de negocio
                List<Cliente> clientes = logicaCliente.ObtenerClientes();

                // Limpiar filas existentes en la tabla antes de agregar las actuales
                dataGridClientes.Rows.Clear();

                // Recorrer el arreglo para agregar cada cliente como una fila
                int indice = 0;
                while (indice < clientes.Count)
                {
                    // Obtener la entidad cliente en la posición actual
                    Cliente cliente = clientes[indice];

                    // Agregar una fila al DataGridView con los campos relevantes
                    dataGridClientes.Rows.Add(
                        cliente.IdCliente,
                        cliente.Identificacion,
                        cliente.Nombre,
                        cliente.Apellido,
                        // Formatear fechas para mostrar solo la parte de la fecha
                        cliente.FechaNacimiento.ToShortDateString(),
                        cliente.FechaIngreso.ToShortDateString(),
                        cliente.Activo);

                    // Avanzar al siguiente índice
                    indice++;
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error si algo falla al cargar los datos
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

