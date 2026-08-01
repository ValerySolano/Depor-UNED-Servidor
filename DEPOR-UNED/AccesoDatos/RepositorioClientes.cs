/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using System.Collections.Generic;
namespace AccesoDatos
{
    public class RepositorioClientes
    {
        public void Agregar(Cliente cliente)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO Cliente
    (IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo)
VALUES
    (@IdCliente, @Identificacion, @Nombre, @Apellido, @FechaNacimiento, @FechaRegistro, @Activo);";

            command.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
            command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
            command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
            command.Parameters.AddWithValue("@Apellido", cliente.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaRegistro", cliente.FechaIngreso);
            command.Parameters.AddWithValue("@Activo", cliente.Activo);

            command.ExecuteNonQuery();
        }

        public Cliente? ObtenerPorId(int idCliente)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo
FROM Cliente
WHERE IdCliente = @IdCliente;";
            command.Parameters.AddWithValue("@IdCliente", idCliente);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

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

        public List<Cliente> ObtenerTodos()
        {
            var clientes = new List<Cliente>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdCliente, Identificacion, Nombre, Apellido, FechaNacimiento, FechaRegistro, Activo
FROM Cliente
ORDER BY IdCliente;";

            using var reader = command.ExecuteReader();
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

        public bool ExisteIdCliente(int idCliente)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Cliente WHERE IdCliente = @IdCliente) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdCliente", idCliente);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool ExisteIdentificacion(string identificacion, int idClienteExcluir)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM Cliente
    WHERE Identificacion = @Identificacion
      AND IdCliente <> @IdClienteExcluir
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";

            command.Parameters.AddWithValue("@Identificacion", identificacion);
            command.Parameters.AddWithValue("@IdClienteExcluir", idClienteExcluir);
            return Convert.ToBoolean(command.ExecuteScalar());
        }
    }
}
