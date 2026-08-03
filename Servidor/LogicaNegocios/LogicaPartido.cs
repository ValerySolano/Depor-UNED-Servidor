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
    public class LogicaPartido
    {
        // Repositorio que gestiona el almacenamiento y recuperación de partidos.
        private RepositorioPartidos repositorioPartidos;

        // Constructor por defecto. Inicializa el repositorio de partidos.
        public LogicaPartido()
        {
            // Crea la instancia del repositorio para operar con partidos.
            repositorioPartidos = new RepositorioPartidos();
        }

        // Valida y agrega un nuevo partido al sistema.
        public void AgregarPartido(Partido partido)
        {
            // Ejecuta las validaciones necesarias; el segundo parámetro indica que es un registro nuevo.
            ValidarPartido(partido, true);

            // Comprueba que el repositorio tenga capacidad para almacenar un nuevo partido.
            if (repositorioPartidos.limiteAlcanzado())
            {
                // Lanza excepción estándar cuando no hay espacio disponible.
                throw new InvalidOperationException("No hay espacio para registrar más partidos.");
            }

            // Si la validación y la capacidad son correctas, delega la persistencia al repositorio.
            repositorioPartidos.Agregar(partido);
        }

        // Realiza las validaciones necesarias sobre un Partido antes de guardarlo.
        // esNuevo indica si se trata de la creación de un nuevo registro.
        private void ValidarPartido(Partido partido, bool esNuevo)
        {
            // Valida que el identificador del partido sea un número positivo.
            if (partido.IdPartido <= 0)
            {
                throw new TipoDatoInvalidoException("El IdPartido debe ser mayor que cero.");
            }

            // Normaliza el campo Rival: evita nulos y recorta espacios en los extremos.
            string rival = partido.Rival == null ? string.Empty : partido.Rival.Trim();

            // Valida que el rival no sea una cadena vacía después del recorte.
            if (rival == string.Empty)
            {
                throw new TipoDatoInvalidoException("El rival es obligatorio.");
            }

            // La fecha del partido no puede ser anterior a la fecha actual.
            if (partido.Fecha.Date < DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha del partido no puede ser anterior al día actual.");
            }

            // Si se está creando un nuevo partido, comprueba que el id no exista ya.
            if (esNuevo && repositorioPartidos.ExisteIdPartido(partido.IdPartido))
            {
                throw new IdentificadorException("El IdPartido ya existe.");
            }

            // Asigna la versión normalizada del rival al objeto Partido.
            partido.Rival = rival;
        }
        // Recupera todos los partidos registrados en el sistema.
        public Partido[] ObtenerPartidos()
        {
            // Devuelve las copias que proporciona el repositorio para no exponer referencias internas.
            return repositorioPartidos.ObtenerTodos();
        }
    }
}
