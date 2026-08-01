/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using AccesoDatos;
using Entidades;

namespace LogicaNegocios
{
    public class LogicaVenta
    {
        // Repositorio para almacenar y recuperar ventas.
        private RepositorioVentas repositorioVentas;
        // Repositorio para gestionar clientes.
        private RepositorioClientes repositorioClientes;
        // Repositorio para gestionar partidos.
        private RepositorioPartidos repositorioPartidos;
        // Repositorio para gestionar localidades.
        private RepositorioLocalidades repositorioLocalidades;
        // Repositorio para gestionar vendedores.
        private RepositorioVendedores repositorioVendedores;
        // Repositorio que contiene la relación Localidad-Partido y su disponibilidad.
        private RepositorioLocalidadesPartido repositorioLocalidadesPartido;

        // Constructor por defecto. Inicializa todos los repositorios necesarios.
        public LogicaVenta()
        {
            // Crea las instancias de repositorios que la lógica de ventas utilizará.
            repositorioVentas = new RepositorioVentas();
            repositorioClientes = new RepositorioClientes();
            repositorioPartidos = new RepositorioPartidos();
            repositorioLocalidades = new RepositorioLocalidades();
            repositorioVendedores = new RepositorioVendedores();
            repositorioLocalidadesPartido = new RepositorioLocalidadesPartido();
        }

        // Valida y agrega una nueva venta al sistema.
        public void AgregarVenta(Venta venta)
        {
            // Ejecuta las validaciones necesarias sobre la venta.
            ValidarVenta(venta);

            // Comprueba que el repositorio de ventas tenga capacidad disponible.
            if (repositorioVentas.limiteAlcanzado())
            {
                // Lanza excepción estándar cuando no hay espacio disponible.
                throw new InvalidOperationException("No hay espacio para registrar más ventas.");
            }

            // Si todo es correcto, delega la persistencia al repositorio.
            repositorioVentas.Agregar(venta);
        }

        // Recupera todas las ventas registradas en el sistema.
        public Venta[] ObtenerVentas()
        {
            // Devuelve las copias proporcionadas por el repositorio para no exponer referencias internas.
            return repositorioVentas.ObtenerTodos();
        }

        // Realiza todas las validaciones necesarias antes de persistir una venta.
        private void ValidarVenta(Venta venta)
        {
            // Valida que el identificador de la venta sea un número positivo.
            if (venta.IdVenta <= 0)
            {
                throw new ArgumentException("El IdVenta debe ser mayor que cero.");
            }

            // Valida existencia y registro del cliente asociado a la venta.
            if (venta.Cliente == null || repositorioClientes.ObtenerPorId(venta.Cliente.IdCliente) == null)
            {
                throw new ArgumentException("Cliente inválido o no registrado.");
            }

            // Valida existencia y registro del partido asociado.
            if (venta.Partido == null || repositorioPartidos.ObtenerPorId(venta.Partido.IdPartido) == null)
            {
                throw new ArgumentException("Partido inválido o no registrado.");
            }

            // Valida existencia y registro de la localidad asociada.
            if (venta.Localidad == null || repositorioLocalidades.ObtenerPorId(venta.Localidad.IdLocalidad) == null)
            {
                throw new ArgumentException("Localidad inválida o no registrada.");
            }

            // Valida existencia y registro del vendedor asociado solo si no es una venta en línea.
            if (venta.TipoVenta != "En Línea" && venta.TipoVenta != "En Linea")
            {
                if (venta.Vendedor == null || repositorioVendedores.ObtenerPorId(venta.Vendedor.IdVendedor) == null)
                {
                    throw new ArgumentException("Vendedor inválido o no registrado.");
                }
            }
            else
            {
                // Para ventas en línea, el vendedor debe ser null
                if (venta.Vendedor != null)
                {
                    throw new ArgumentException("Las ventas en línea no deben tener un vendedor asignado.");
                }
            }

            // La cantidad de boletos vendida debe ser mayor que cero.
            if (venta.Cantidad <= 0)
            {
                throw new ArgumentException("La cantidad debe ser mayor que cero.");
            }

            // La fecha de venta no puede ser en el futuro.
            if (venta.FechaVenta.Date > DateTime.Today)
            {
                throw new ArgumentException("La fecha de venta no puede ser mayor al día actual.");
            }

            // El monto total debe ser positivo.
            if (venta.MontoTotal <= 0)
            {
                throw new ArgumentException("El monto total debe ser mayor que cero.");
            }

            // Verifica que el id de venta no exista ya en el repositorio.
            if (repositorioVentas.ExisteIdVenta(venta.IdVenta))
            {
                throw new ArgumentException("El IdVenta ya existe.");
            }

            // Verificar que exista registro de localidad para ese partido y que haya suficiente cantidad disponible.
            var registros = repositorioLocalidadesPartido.ObtenerTodos();
            // Busca la asignación de localidad-partido correspondiente.
            var registro = registros.FirstOrDefault(r => r.Partido != null && r.Localidad != null && r.Partido.IdPartido == venta.Partido.IdPartido && r.Localidad.IdLocalidad == venta.Localidad.IdLocalidad);

            // Si no existe la asignación, no es posible vender para esa combinación.
            if (registro == null)
            {
                throw new ArgumentException("No existe asignación de esa localidad para el partido seleccionado.");
            }

            // Comprueba que la cantidad solicitada esté disponible en la asignación encontrada.
            if (venta.Cantidad > registro.CantidadDisponible)
            {
                throw new ArgumentException("No hay suficiente cantidad disponible para la localidad y partido seleccionados.");
            }
        }
    }
}
