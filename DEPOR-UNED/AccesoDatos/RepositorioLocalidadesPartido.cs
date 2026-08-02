/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioLocalidadesPartido
    {
        // Método para agregar un nuevo registro de localidad por partido a la base de datos
        public void Agregar(LocalidadPartido registro)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la inserción del registro
            // Definir la consulta SQL para insertar un nuevo registro en la tabla LocalidadPorPartido
            command.CommandText = @"
INSERT INTO LocalidadPorPartido
    (IdLocalidadPartido, IdPartido, IdLocalidad, CantidadDisponible)
VALUES
    (@IdLocalidadPartido, @IdPartido, @IdLocalidad, @CantidadDisponible);";

            // Agregar los parámetros del comando SQL con los valores del registro a insertar
            command.Parameters.AddWithValue("@IdLocalidadPartido", registro.IdLocalidadPartido);
            command.Parameters.AddWithValue("@IdPartido", registro.Partido.IdPartido);
            command.Parameters.AddWithValue("@IdLocalidad", registro.Localidad.IdLocalidad);
            command.Parameters.AddWithValue("@CantidadDisponible", registro.CantidadDisponible);

            command.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar el registro en la base de datos
        }

        // Método para obtener todos los registros de localidades por partido de la base de datos
        public LocalidadPartido[] ObtenerTodos()
        {
            var registros = new List<LocalidadPartido>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todos los registros
            // Definir la consulta SQL para obtener todos los registros con sus relaciones (Partido y Localidad)
            command.CommandText = @"
SELECT
    lp.IdLocalidadPartido,
    lp.CantidadDisponible,
    p.IdPartido,
    p.Rival,
    p.Fecha,
    p.Hora,
    p.Activo,
    l.IdLocalidad,
    l.NombreLocalidad,
    l.Precio
FROM LocalidadPorPartido lp
INNER JOIN Partido p ON p.IdPartido = lp.IdPartido
INNER JOIN Localidad l ON l.IdLocalidad = lp.IdLocalidad
ORDER BY lp.IdLocalidadPartido;";

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de registros
            while (reader.Read())
            {
                // Crear el objeto Partido con los datos obtenidos de la consulta
                var partido = new Partido(
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetString(5),
                    reader.GetBoolean(6)
                );

                // Crear el objeto Localidad con los datos obtenidos de la consulta
                var localidad = new Localidad(
                    reader.GetInt32(7),
                    reader.GetString(8),
                    reader.GetDecimal(9)
                );

                // Agregar el nuevo objeto LocalidadPartido a la lista
                registros.Add(new LocalidadPartido(
                    reader.GetInt32(0),
                    partido,
                    localidad,
                    reader.GetInt32(1)
                ));
            }

            return registros.ToArray();
        }

        // Método para verificar si existe un registro de localidad por partido con el id especificado
        public bool ExisteIdRegistro(int idLocalidadPartido)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia del registro
            // Definir la consulta SQL para verificar si existe un registro con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM LocalidadPorPartido WHERE IdLocalidadPartido = @IdLocalidadPartido) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdLocalidadPartido", idLocalidadPartido); // Agregar el parámetro del comando SQL con el valor del id del registro
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si existe una localidad específica para un partido dado
        public bool ExisteLocalidadEnPartido(int idPartido, int idLocalidad)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia de la combinación
            // Definir la consulta SQL para verificar si existe un registro con el partido y localidad especificados
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM LocalidadPorPartido
    WHERE IdPartido = @IdPartido
      AND IdLocalidad = @IdLocalidad
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdPartido", idPartido); // Agregar el parámetro del comando SQL con el valor del id del partido
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad); // Agregar el parámetro del comando SQL con el valor del id de la localidad
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de registros
        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

