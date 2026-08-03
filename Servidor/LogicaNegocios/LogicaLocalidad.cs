/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using AccesoDatos;
using Entidades;

namespace LogicaNegocios
{
    public class LogicaLocalidad
    {
        // Repositorio que gestiona el almacenamiento y recuperación de localidades.
        private RepositorioLocalidades repositorioLocalidades;

        // Constructor por defecto. Inicializa el repositorio de localidades.
        public LogicaLocalidad()
        {
            // Crea una instancia del repositorio para operar sobre las localidades.
            repositorioLocalidades = new RepositorioLocalidades();
        }

        // Valida y agrega una nueva localidad al sistema.
        public void AgregarLocalidad(Localidad localidad)
        {
            // Valida los datos de la localidad; el segundo parámetro indica que es un registro nuevo.
            ValidarLocalidad(localidad, true);

            // Si la validación pasa, delega la persistencia al repositorio.
            repositorioLocalidades.Agregar(localidad);
        }

        // Realiza todas las validaciones necesarias sobre una Localidad antes de guardar.
        // esNuevo indica si se está creando un registro nuevo (afecta validaciones de unicidad).
        private void ValidarLocalidad(Localidad localidad, bool esNuevo)
        {
            // Valida que el IdLocalidad sea un entero positivo.
            // Se convierte a string y se recorta para evitar espacios antes de intentar parsear.
            if (!int.TryParse(localidad.IdLocalidad.ToString().Trim(), out int id) || localidad.IdLocalidad <= 0)
            {
                // Lanzar excepción específica cuando el tipo de dato no es válido.
                throw new TipoDatoInvalidoException("El IdLocalidad debe ser un número entero válido.");
            }

            // Valida que el nombre no sea nulo, vacío o solo espacios en blanco.
            if (string.IsNullOrWhiteSpace(localidad.NombreLocalidad) || localidad.NombreLocalidad.Trim().Length == 0)
            {
                throw new TipoDatoInvalidoException("El nombre de la localidad no puede estar vacío.");
            }

            // Valida que el precio sea mayor que cero.
            if (localidad.Precio <= 0)
            {
                throw new TipoDatoInvalidoException("El precio debe ser un número decimal mayor que cero.");
            }

            // Si es un registro nuevo, comprueba que el id no exista ya en el repositorio.
            if (esNuevo && repositorioLocalidades.ExisteIdLocalidad(localidad.IdLocalidad))
            {
                throw new IdentificadorException("El IdLocalidad ya existe.");
            }

            // Comprueba que el repositorio aún tenga capacidad para almacenar nuevas localidades.
            if (repositorioLocalidades.limiteAlcanzado())
            {
                // Lanzar excepción estándar para indicar que no es posible realizar la operación.
                throw new InvalidOperationException("No hay espacio para registrar más localidades.");
            }
        }

        // Recupera todas las localidades almacenadas en el repositorio.
        public Localidad[] ObtenerLocalidades()
        {
            // Devuelve las copias proporcionadas por el repositorio para no exponer referencias internas.
            return repositorioLocalidades.ObtenerTodos();
        }
    }
}
