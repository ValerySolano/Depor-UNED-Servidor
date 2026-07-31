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
    public partial class ListadoVendedores : Form
    {
        // Instancia de la capa de lógica de negocio para operaciones con vendedores.
        private LogicaVendedor logicaVendedor;

        // Constructor del formulario. Inicializa componentes y crea la lógica de negocio.
        public ListadoVendedores()
        {
            // Inicializa los controles del formulario.
            InitializeComponent();

            // Crea la instancia de la lógica de negocio para obtener y gestionar vendedores.
            logicaVendedor = new LogicaVendedor();
        }

        // Maneja el evento Click del control btnNuevoPartido.
        private void btnNuevoPartido_Click(object sender, EventArgs e)
        {
            // Abre el formulario de registro de vendedor como diálogo modal.
            RegistroVendedor registroVendedor = new RegistroVendedor();
            registroVendedor.ShowDialog();

            // Tras cerrar el diálogo, recarga la lista de vendedores para reflejar cambios.
            CargarVendedores();
        }

        // Maneja la carga inicial del formulario o control ListadoVendedores.
        private void ListadoVendedores_Load(object? sender, EventArgs e)
        {
            // Carga los datos al iniciar el formulario.
            CargarVendedores();
        }

        // Recupera la lista de vendedores desde la lógica de negocio y la muestra en el DataGridView.
        private void CargarVendedores()
        {
            try
            {
                // Limpia las filas existentes antes de poblar con los datos actualizados.
                DatosPartidos.Rows.Clear();

                // Obtiene el arreglo de vendedores (copias) desde la lógica de negocio.
                Vendedor[] lista = logicaVendedor.ObtenerVendedores();

                // Agrega cada vendedor como una nueva fila en el control de datos.
                foreach (var v in lista)
                {
                    DatosPartidos.Rows.Add(v.IdVendedor, v.Identificacion, v.Nombre, v.Apellido, v.FechaNacimiento.ToShortDateString(), v.FechaIngreso.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                // Muestra cualquier error inesperado ocurrido durante la carga.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

