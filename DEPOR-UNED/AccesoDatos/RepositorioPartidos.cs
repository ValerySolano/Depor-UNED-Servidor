/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioPartidos
    {
        // Método para agregar un nuevo partido a la base de datos
        public void Agregar(Partido partido)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la inserción del partido
            // Definir la consulta SQL para insertar un nuevo partido en la tabla Partido
            command.CommandText = @"
INSERT INTO Partido
    (IdPartido, Rival, Fecha, Hora, Activo)
VALUES
    (@IdPartido, @Rival, @Fecha, @Hora, @Activo);";

            // Agregar los parámetros del comando SQL con los valores del partido a insertar
            command.Parameters.AddWithValue("@IdPartido", partido.IdPartido);
            command.Parameters.AddWithValue("@Rival", partido.Rival);
            command.Parameters.AddWithValue("@Fecha", partido.Fecha);
            command.Parameters.AddWithValue("@Hora", partido.Hora);
            command.Parameters.AddWithValue("@Activo", partido.Activo);

            command.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar el partido en la base de datos
        }

        // Método para obtener un partido por su id
        public Partido? ObtenerPorId(int idPartido)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            // Crear un comando SQL para ejecutar la consulta de obtención del partido por su id
            using var command = connection.CreateCommand();
            // Definir la consulta SQL para obtener un partido por su id
            command.CommandText = @"
SELECT IdPartido, Rival, Fecha, Hora, Activo
FROM Partido
WHERE IdPartido = @IdPartido;";
            command.Parameters.AddWithValue("@IdPartido", idPartido); // Agregar el parámetro del comando SQL con el valor del id del partido a obtener

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            if (!reader.Read()) // Si no se encuentra ningún registro, devolver null
            {
                return null;
            }

            // Devolver un nuevo objeto Partido con los datos obtenidos de la base de datos
            return new Partido(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDateTime(2),
                reader.GetString(3),
                reader.GetBoolean(4)
            );
        }

        // Método para obtener todos los partidos de la base de datos
        public Partido[] ObtenerTodos()
        {
            var partidos = new List<Partido>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todos los partidos
            // Definir la consulta SQL para obtener todos los partidos ordenados por id
            command.CommandText = @"
SELECT IdPartido, Rival, Fecha, Hora, Activo
FROM Partido
ORDER BY IdPartido;";

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de partidos
            while (reader.Read())
            {
                partidos.Add(new Partido(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetDateTime(2),
                    reader.GetString(3),
                    reader.GetBoolean(4)
                ));
            }

            return partidos.ToArray();
        }

        // Método para verificar si existe un partido con el id especificado
        public bool ExisteIdPartido(int idPartido)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia del partido
            // Definir la consulta SQL para verificar si existe un partido con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Partido WHERE IdPartido = @IdPartido) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdPartido", idPartido); // Agregar el parámetro del comando SQL con el valor del id del partido
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de partidos
        public bool limiteAlcanzado()
        {
            return false;
        }

    }
}

