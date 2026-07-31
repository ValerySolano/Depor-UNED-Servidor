/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using AccesoDatos;
using Entidades;
namespace LogicaNegocios
{
    public class LogicaVendedor
    {
        // Repositorio que gestiona el almacenamiento y recuperación de vendedores.
        private RepositorioVendedores repositorioVendedores;

        // Constructor por defecto. Inicializa el repositorio de vendedores.
        public LogicaVendedor()
        {
            // Crea la instancia del repositorio para operar sobre vendedores.
            repositorioVendedores = new RepositorioVendedores();
        }

        // Valida y agrega un nuevo vendedor al sistema.
        public void AgregarVendedor(Vendedor vendedor)
        {
            // Ejecuta las validaciones necesarias; el segundo parámetro indica que es un registro nuevo.
            ValidarVendedor(vendedor, true);

            // Comprueba que el repositorio tenga capacidad para almacenar un nuevo vendedor.
            if (repositorioVendedores.limiteAlcanzado())
            {
                // Lanza excepción estándar cuando no hay espacio disponible.
                throw new InvalidOperationException("No hay espacio para registrar más vendedores.");
            }

            // Si la validación y la capacidad son correctas, delega la persistencia al repositorio.
            repositorioVendedores.Agregar(vendedor);
        }

        // Recupera todos los vendedores registrados en el sistema.
        public Vendedor[] ObtenerVendedores()
        {
            // Devuelve las copias que proporciona el repositorio para no exponer referencias internas.
            return repositorioVendedores.ObtenerTodos();
        }

        // Realiza todas las validaciones necesarias sobre un Vendedor antes de guardarlo.
        // esNuevo indica si se trata de la creación de un nuevo registro.
        private void ValidarVendedor(Vendedor vendedor, bool esNuevo)
        {
            // Valida que el identificador del vendedor sea un entero positivo.
            if (vendedor.IdVendedor <= 0)
            {
                throw new TipoDatoInvalidoException("El IdVendedor debe ser mayor que cero.");
            }

            // Normaliza y recorta los campos de texto para validaciones posteriores.
            string identificacion = vendedor.Identificacion == null ? string.Empty : vendedor.Identificacion.Trim();
            string nombre = vendedor.Nombre == null ? string.Empty : vendedor.Nombre.Trim();
            string apellido = vendedor.Apellido == null ? string.Empty : vendedor.Apellido.Trim();

            // Identificación no puede estar vacía.
            if (identificacion == string.Empty)
            {
                throw new TipoDatoInvalidoException("La identificación es obligatoria.");
            }

            // La identificación debe ser un número entero mayor que cero.
            if (!long.TryParse(identificacion, out long idNum) || idNum <= 0)
            {
                throw new TipoDatoInvalidoException("La identificación debe ser un número mayor a cero.");
            }

            // Nombre obligatorio.
            if (nombre == string.Empty)
            {
                throw new TipoDatoInvalidoException("El nombre es obligatorio.");
            }

            // Apellido obligatorio.
            if (apellido == string.Empty)
            {
                throw new TipoDatoInvalidoException("El apellido es obligatorio.");
            }

            // Fecha de nacimiento debe ser anterior al día actual.
            if (vendedor.FechaNacimiento.Date >= DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de nacimiento debe ser menor al día actual.");
            }

            // Verificar que sea mayor de edad.
            int edad = DateTime.Today.Year - vendedor.FechaNacimiento.Year;
            if (vendedor.FechaNacimiento > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 18)
            {
                throw new TipoDatoInvalidoException("El vendedor debe ser mayor de edad.");
            }

            // La fecha de ingreso no puede ser anterior a la fecha de nacimiento.
            if (vendedor.FechaIngreso.Date < vendedor.FechaNacimiento.Date)
            {
                throw new TipoDatoInvalidoException("La fecha de ingreso no puede ser menor que la fecha de nacimiento.");
            }

            // La fecha de ingreso no puede ser futura.
            if (vendedor.FechaIngreso.Date > DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de ingreso no puede ser mayor al día actual.");
            }

            // Si es nuevo, comprobar que el id no exista ya en el repositorio.
            if (esNuevo && repositorioVendedores.ExisteIdVendedor(vendedor.IdVendedor))
            {
                throw new IdentificadorException("El IdVendedor ya existe.");
            }

            // Verificar unicidad de la identificación, excluyendo el propio id si no es nuevo.
            if (repositorioVendedores.ExisteIdentificacion(identificacion, esNuevo ? -1 : vendedor.IdVendedor))
            {
                throw new TipoDatoInvalidoException("La identificación ya existe.");
            }

            // Asigna los valores normalizados de vuelta al objeto vendedor.
            vendedor.Identificacion = identificacion;
            vendedor.Nombre = nombre;
            vendedor.Apellido = apellido;
        }
    }
}

