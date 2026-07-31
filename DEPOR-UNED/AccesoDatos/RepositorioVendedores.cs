/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioVendedores
    {
        public void Agregar(Vendedor vendedor)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO Vendedor
    (IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso)
VALUES
    (@IdVendedor, @Identificacion, @Nombre, @Apellido, @FechaNacimiento, @FechaIngreso);";

            command.Parameters.AddWithValue("@IdVendedor", vendedor.IdVendedor);
            command.Parameters.AddWithValue("@Identificacion", vendedor.Identificacion);
            command.Parameters.AddWithValue("@Nombre", vendedor.Nombre);
            command.Parameters.AddWithValue("@Apellido", vendedor.Apellido);
            command.Parameters.AddWithValue("@FechaNacimiento", vendedor.FechaNacimiento);
            command.Parameters.AddWithValue("@FechaIngreso", vendedor.FechaIngreso);

            command.ExecuteNonQuery();
        }

        public Vendedor? ObtenerPorId(int idVendedor)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso
FROM Vendedor
WHERE IdVendedor = @IdVendedor;";
            command.Parameters.AddWithValue("@IdVendedor", idVendedor);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new Vendedor(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetString(2),
                reader.GetString(3),
                reader.GetDateTime(4),
                reader.GetDateTime(5)
            );
        }

        public Vendedor[] ObtenerTodos()
        {
            var vendedores = new List<Vendedor>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdVendedor, Identificacion, Nombre, Apellido, FechaNacimiento, FechaIngreso
FROM Vendedor
ORDER BY IdVendedor;";

            using var reader = command.ExecuteReader();
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

        public bool ExisteIdVendedor(int idVendedor)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Vendedor WHERE IdVendedor = @IdVendedor) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdVendedor", idVendedor);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool ExisteIdentificacion(string identificacion, int idVendedorExcluir)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM Vendedor
    WHERE Identificacion = @Identificacion
      AND IdVendedor <> @IdVendedorExcluir
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";

            command.Parameters.AddWithValue("@Identificacion", identificacion);
            command.Parameters.AddWithValue("@IdVendedorExcluir", idVendedorExcluir);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

