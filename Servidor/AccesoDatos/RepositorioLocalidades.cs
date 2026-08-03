/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioLocalidades
    {
        // Método para agregar una nueva localidad a la base de datos
        public void Agregar(Localidad localidad)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la inserción de la localidad
            // Definir la consulta SQL para insertar una nueva localidad en la tabla Localidad
            command.CommandText = @"
INSERT INTO Localidad
    (IdLocalidad, NombreLocalidad, Precio)
VALUES
    (@IdLocalidad, @NombreLocalidad, @Precio);";

            // Agregar los parámetros del comando SQL con los valores de la localidad a insertar
            command.Parameters.AddWithValue("@IdLocalidad", localidad.IdLocalidad);
            command.Parameters.AddWithValue("@NombreLocalidad", localidad.NombreLocalidad);
            command.Parameters.AddWithValue("@Precio", localidad.Precio);

            command.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar la localidad en la base de datos
        }

        // Método para obtener una localidad por su id
        public Localidad? ObtenerPorId(int idLocalidad)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            // Crear un comando SQL para ejecutar la consulta de obtención de la localidad por su id
            using var command = connection.CreateCommand();
            // Definir la consulta SQL para obtener una localidad por su id
            command.CommandText = @"
SELECT IdLocalidad, NombreLocalidad, Precio
FROM Localidad
WHERE IdLocalidad = @IdLocalidad;";
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad); // Agregar el parámetro del comando SQL con el valor del id de la localidad a obtener

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            if (!reader.Read()) // Si no se encuentra ningún registro, devolver null
            {
                return null;
            }

            // Devolver un nuevo objeto Localidad con los datos obtenidos de la base de datos
            return new Localidad(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDecimal(2)
            );
        }

        // Método para obtener todas las localidades de la base de datos
        public Localidad[] ObtenerTodos()
        {
            var localidades = new List<Localidad>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todas las localidades
            // Definir la consulta SQL para obtener todas las localidades ordenadas por id
            command.CommandText = @"
SELECT IdLocalidad, NombreLocalidad, Precio
FROM Localidad
ORDER BY IdLocalidad;";

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de localidades
            while (reader.Read())
            {
                localidades.Add(new Localidad(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetDecimal(2)
                ));
            }

            return localidades.ToArray();
        }

        // Método para verificar si existe una localidad con el id especificado
        public bool ExisteIdLocalidad(int idLocalidad)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia de la localidad
            // Definir la consulta SQL para verificar si existe una localidad con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Localidad WHERE IdLocalidad = @IdLocalidad) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad); // Agregar el parámetro del comando SQL con el valor del id de la localidad
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de localidades
        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

