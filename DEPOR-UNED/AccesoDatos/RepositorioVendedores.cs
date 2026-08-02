/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioVendedores
    {
        // Método para agregar un nuevo vendedor a la base de datos
        public void Agregar(Vendedor vendedor)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la inserción del vendedor
            // Definir la consulta SQL para insertar un nuevo vendedor en la tabla Vendedor
            command.CommandText = @"
INSERT INTO Vendedor
    (IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso)
VALUES
    (@IdVendedor, @Identificacion, @Nombre, @Apellido, @FechaNacimiento, @FechaIngreso);";

            // Agregar los parámetros del comando SQL con los valores del vendedor a insertar
            command.Parameters.AddWithValue("@IdVendedor", vendedor.IdVendedor);
            command.Parameters.AddWithValue("@Identificacion", vendedor.Identificacion);
            command.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
            command.Parameters.AddWithValue("@Apellido", vendedor.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", vendedor.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaIngreso", vendedor.FechaIngreso);

            command.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar el vendedor en la base de datos
        }

        // Método para obtener un vendedor por su id
        public Vendedor? ObtenerPorId(int idVendedor)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            // Crear un comando SQL para ejecutar la consulta de obtención del vendedor por su id
            using var command = connection.CreateCommand();
            // Definir la consulta SQL para obtener un vendedor por su id
            command.CommandText = @"
SELECT IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso
FROM Vendedor
WHERE IdVendedor = @IdVendedor;";
            command.Parameters.AddWithValue("@IdVendedor", idVendedor); // Agregar el parámetro del comando SQL con el valor del id del vendedor a obtener

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            if (!reader.Read()) // Si no se encuentra ningún registro, devolver null
            {
                return null;
            }

            // Devolver un nuevo objeto Vendedor con los datos obtenidos de la base de datos
            return new Vendedor(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4),
                reader.GetDateTime(5)
            );
        }

        // Método para obtener todos los vendedores de la base de datos
        public Vendedor[] ObtenerTodos()
        {
            var vendedores = new List<Vendedor>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todos los vendedores
            // Definir la consulta SQL para obtener todos los vendedores ordenados por id
            command.CommandText = @"
SELECT IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso
FROM Vendedor
ORDER BY IdVendedor;";

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de vendedores
            while (reader.Read())
            {
                vendedores.Add(new Vendedor(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetDateTime(5)
                ));
            }

            return vendedores.ToArray();
        }

        // Método para verificar si existe un vendedor con el id especificado
        public bool ExisteIdVendedor(int idVendedor)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia del vendedor
            // Definir la consulta SQL para verificar si existe un vendedor con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Vendedor WHERE IdVendedor = @IdVendedor) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdVendedor", idVendedor); // Agregar el parámetro del comando SQL con el valor del id del vendedor
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si existe una identificación de vendedor específica, excluyendo un vendedor particular
        public bool ExisteIdentificacion(string identificacion, int idVendedorExcluir)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia de la identificación
            // Definir la consulta SQL para verificar si existe otro vendedor con la misma identificación
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM Vendedor
    WHERE Identificacion = @Identificacion
      AND IdVendedor <> @IdVendedorExcluir
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";

            command.Parameters.AddWithValue("@Identificacion", identificacion); // Agregar el parámetro del comando SQL con el valor de la identificación a verificar
            command.Parameters.AddWithValue("@IdVendedorExcluir", idVendedorExcluir); // Agregar el parámetro del comando SQL con el valor del id del vendedor a excluir
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de vendedores
        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

