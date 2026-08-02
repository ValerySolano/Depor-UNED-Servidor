/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using System.Collections.Generic;
namespace AccesoDatos
{
    public class RepositorioClientes
    {
        // Método para agregar un nuevo cliente a la base de datos
        public void Agregar(Cliente cliente)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la inserción del cliente
            // Definir la consulta SQL para insertar un nuevo cliente en la tabla Cliente
            command.CommandText = @"
INSERT INTO Cliente
    (IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo)
VALUES
    (@IdCliente, @Identificacion, @Nombre, @Apellido, @FechaNacimiento, @FechaRegistro, @Activo);";

            // Agregar los parámetros del comando SQL con los valores del cliente a insertar
            command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaRegistro", cliente.FechaIngreso);
            command.Parameters.AddWithValue("@Activo", cliente.Activo);

            command.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar el cliente en la base de datos
        }

        // Método para obtener un cliente por su id
        public Cliente? ObtenerPorId(int idCliente)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            // Crear un comando SQL para ejecutar la consulta de obtención del cliente por su id
            using var command = connection.CreateCommand();
            // Definir la consulta SQL para obtener un cliente por su id
            command.CommandText = @"
SELECT IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo
FROM Cliente
WHERE IdCliente = @IdCliente;";
            command.Parameters.AddWithValue("@IdCliente", idCliente); // Agregar el parámetro del comando SQL con el valor del id del cliente a obtener

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            if (!reader.Read()) // Si no se encuentra ningún registro, devolver null
            {
                return null;
            }
            // Devolver un nuevo objeto Cliente con los datos obtenidos de la base de datos
            return new Cliente(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4),
                reader.GetDateTime(5),
                reader.GetBoolean(6)
            );
        }

        // Método para obtener todos los clientes de la base de datos
        public List<Cliente> ObtenerTodos()
        {
            var clientes = new List<Cliente>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todos los clientes
            // Definir la consulta SQL para obtener todos los clientes ordenados por id
            command.CommandText = @"
SELECT IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo
FROM Cliente
ORDER BY IdCliente;";

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de clientes
            while (reader.Read())
            {
                clientes.Add(new Cliente(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetDateTime(5),
                    reader.GetBoolean(6)
                ));
            }

            return clientes;
        }

        // Método para verificar si existe un cliente con el id especificado
        public bool ExisteIdCliente(int idCliente)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia del cliente
            // Definir la consulta SQL para verificar si existe un cliente con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Cliente WHERE IdCliente = @IdCliente) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdCliente", idCliente); // Agregar el parámetro del comando SQL con el valor del id del cliente
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si existe una identificación de cliente específica, excluyendo un cliente particular
        public bool ExisteIdentificacion(string identificacion, int idClienteExcluir)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia de la identificación
            // Definir la consulta SQL para verificar si existe otro cliente con la misma identificación
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM Cliente
    WHERE Identificacion = @Identificacion
      AND IdCliente <> @IdClienteExcluir
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";

            command.Parameters.AddWithValue("@Identificacion", identificacion); // Agregar el parámetro del comando SQL con el valor de la identificación a verificar
            command.Parameters.AddWithValue("@IdClienteExcluir", idClienteExcluir); // Agregar el parámetro del comando SQL con el valor del id del cliente a excluir
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de clientes
        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}
