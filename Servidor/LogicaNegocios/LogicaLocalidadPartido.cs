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
    public class LogicaLocalidadPartido
    {
        // Repositorio que gestiona asociaciones Localidad-Partido.
        private RepositorioLocalidadesPartido repositorioLocalidadesPartido;
        // Repositorio para acceder a partidos registrados.
        private RepositorioPartidos repositorioPartidos;
        // Repositorio para acceder a localidades registradas.
        private RepositorioLocalidades repositorioLocalidades;

        // Constructor por defecto. Inicializa los repositorios necesarios para las operaciones.
        public LogicaLocalidadPartido()
        {
            // Crea instancias de los repositorios utilizados por la lógica de negocio.
            repositorioLocalidadesPartido = new RepositorioLocalidadesPartido();
            repositorioPartidos = new RepositorioPartidos();
            repositorioLocalidades = new RepositorioLocalidades();
        }

        // Valida y agrega una nueva asociación Localidad-Partido al sistema.
        public void AgregarLocalidadPartido(LocalidadPartido registro)
        {
            // Ejecuta todas las validaciones necesarias sobre el registro.
            ValidarRegistro(registro);

            // Comprueba que el repositorio aún tenga capacidad para nuevos registros.
            if (repositorioLocalidadesPartido.limiteAlcanzado())
            {
                // Lanza una excepción estándar si no es posible almacenar más registros.
                throw new InvalidOperationException("Se alcanzó la capacidad máxima de 200 registros.");
            }

            // Si todo es válido, delega la persistencia al repositorio.
            repositorioLocalidadesPartido.Agregar(registro);
        }

        // Recupera todas las asociaciones Localidad-Partido almacenadas.
        public LocalidadPartido[] ObtenerRegistros()
        {
            // Devuelve las copias provistas por el repositorio para no exponer referencias internas.
            return repositorioLocalidadesPartido.ObtenerTodos();
        }
        // Cuenta cuántas localidades están asociadas a un partido específico.
        public int contarLocalidadesEnPartido(int idPartido)
        {
            // Inicializa el contador y obtiene una copia de los registros disponibles.
            int contador = 0;
            LocalidadPartido[] registros = repositorioLocalidadesPartido.ObtenerTodos();

            int indice = 0;

            // Recorre todos los registros y cuenta aquellos cuyo partido coincide con el id indicado.
            while (indice < registros.Length)
            {
                if (registros[indice].Partido != null && registros[indice].Partido.IdPartido == idPartido)
                {
                    contador++;
                }
                // Avanza al siguiente registro.
                indice++;
            }

            // Devuelve la cantidad encontrada.
            return contador;
        }

        // Realiza todas las validaciones necesarias antes de persistir un registro LocalidadPartido.
        private void ValidarRegistro(LocalidadPartido registro)
        {
            // Valida que el identificador sea positivo.
            if (registro.IdLocalidadPartido <= 0)
            {
                throw new IdentificadorException("El IdLocalidadPartido debe ser mayor que cero.");
            }

            // Valida que se haya seleccionado un partido.
            if (registro.Partido == null)
            {
                throw new ArgumentException("Debe seleccionar un partido.");
            }

            // Valida que se haya seleccionado una localidad.
            if (registro.Localidad == null)
            {
                throw new ArgumentException("Debe seleccionar una localidad.");
            }

            // Valida que la cantidad disponible sea mayor que cero.
            if (registro.CantidadDisponible <= 0)
            {
                throw new ArgumentException("La CantidadDisponible debe ser mayor a cero.");
            }

            // Verifica que el id del registro no exista ya en el repositorio.
            if (repositorioLocalidadesPartido.ExisteIdRegistro(registro.IdLocalidadPartido))
            {
                throw new IdentificadorException("El IdLocalidadPartido ya existe.");
            }

            // Obtiene el partido registrado por su id para validar existencia y estado.
            Partido? partidoRegistrado = repositorioPartidos.ObtenerPorId(registro.Partido.IdPartido);

            if (partidoRegistrado == null)
            {
                throw new ArgumentException("El partido debe estar previamente registrado.");
            }

            // Obtiene la localidad registrada por su id para validar existencia.
            Localidad? localidadRegistrada = repositorioLocalidades.ObtenerPorId(registro.Localidad.IdLocalidad);

            if (localidadRegistrada == null)
            {
                throw new ArgumentException("La localidad debe estar previamente registrada.");
            }

            // No se permiten asociar localidades a partidos inactivos.
            if (!partidoRegistrado.Activo)
            {
                throw new ArgumentException("No se pueden registrar localidades para partidos inactivos.");
            }

            // Evita duplicar la misma localidad en el mismo partido.
            if (repositorioLocalidadesPartido.ExisteLocalidadEnPartido(partidoRegistrado.IdPartido, localidadRegistrada.IdLocalidad))
            {
                throw new ArgumentException("No se puede registrar la misma localidad para el mismo partido más de una vez.");
            }

            // Sustituye las referencias del registro por las instancias registradas (copias del repositorio).
            registro.Partido = partidoRegistrado;
            registro.Localidad = localidadRegistrada;
        }
    }
}
