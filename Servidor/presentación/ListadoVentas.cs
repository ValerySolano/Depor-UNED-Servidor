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
    public partial class ListadoVentas : Form
    {
        // Instancia de la capa de lógica de negocio para operaciones con ventas.
        private LogicaVenta logicaVenta;

        // Constructor del formulario. Inicializa componentes y crea la lógica de negocio.
        public ListadoVentas()
        {
            // Inicializa los controles y el diseño del formulario.
            InitializeComponent();

            // Crea la instancia de la lógica que proporcionará las ventas a mostrar.
            logicaVenta = new LogicaVenta();
        }

        // Maneja la carga inicial del formulario o control ListadoVentas.
        private void ListadoVentas_Load(object? sender, EventArgs e)
        {
            CargarVentas();
        }

        // Recupera las ventas desde la lógica de negocio y las muestra en el DataGridView.
        private void CargarVentas()
        {
            try
            {
                // Limpia filas previas para evitar duplicados antes de poblar con datos nuevos.
                DatosVentas.Rows.Clear();

                // Obtiene las ventas (copias) desde la capa de lógica de negocio.
                var ventas = logicaVenta.ObtenerVentas();

                // Recorre cada venta y prepara valores seguros para las columnas del grid.
                foreach (var v in ventas)
                {
                    // Preparar valores garantizando no nulos y tipos coherentes con las columnas
                    string clienteTexto = v.Cliente == null ? string.Empty : v.Cliente.Nombre + " " + v.Cliente.Apellido;
                    string rivalTexto = v.Partido == null ? string.Empty : v.Partido.Rival;

                    // Formatea la fecha del partido cuando exista, si no se muestra cadena vacía.
                    object fechaPartidoValor = v.Partido == null ? (object)string.Empty : v.Partido.Fecha.ToShortDateString();

                    // Hora del partido: puede ser null, por eso el operador null-coalescing.
                    object horaPartidoValor = v.Partido == null ? (object)string.Empty : v.Partido.Hora ?? string.Empty;

                    // Indica si el partido estaba activo en el momento del registro.
                    bool partidoActivo = v.Partido?.Activo ?? false;

                    // Identificador y texto de la localidad; usar 0 y cadena vacía cuando no exista.
                    int idLocalidad = v.Localidad?.IdLocalidad ?? 0;
                    string localidadTexto = v.Localidad?.NombreLocalidad ?? string.Empty;

                    // Texto del vendedor concatenando nombre y apellido si existe.
                    string vendedorTexto = v.Vendedor == null ? string.Empty : v.Vendedor.Nombre + " " + v.Vendedor.Apellido;

                    // Fecha de la venta: si es DateTime.MinValue se muestra vacío.
                    object fechaVentaValor = v.FechaVenta == DateTime.MinValue ? (object)string.Empty : v.FechaVenta.ToShortDateString();

                    // Monto total y tipo de venta (puede ser null en el origen).
                    decimal montoValor = v.MontoTotal;
                    string tipoVentaTexto = v.TipoVenta ?? string.Empty;

                    // Agregar fila con valores completos para todas las columnas
                    DatosVentas.Rows.Add(
                        v.IdVenta,
                        clienteTexto,
                        rivalTexto,
                        fechaPartidoValor,
                        horaPartidoValor,
                        partidoActivo,
                        idLocalidad,
                        localidadTexto,
                        vendedorTexto,
                        v.Cantidad,
                        fechaVentaValor,
                        montoValor,
                        tipoVentaTexto
                    );
                }
            }
            catch (Exception ex)
            {
                // Muestra cualquier excepción inesperada ocurrida durante la carga de ventas.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Maneja el evento Click del control Venta.
        private void Venta_Click(object sender, EventArgs e)
        {
            RegistroVentas registroVentas = new RegistroVentas();
            registroVentas.ShowDialog();
            CargarVentas();
        }
    }
}

