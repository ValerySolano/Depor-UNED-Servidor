/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioVentas
    {
        public void Agregar(Venta venta)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var transaction = connection.BeginTransaction();

            using var updateInventory = connection.CreateCommand();
            updateInventory.Transaction = transaction;
            updateInventory.CommandText = @"
UPDATE LocalidadPorPartido
SET CantidadDisponible = CantidadDisponible - @Cantidad
WHERE IdPartido = @IdPartido
  AND IdLocalidad = @IdLocalidad
  AND CantidadDisponible >= @Cantidad;";

            updateInventory.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
            updateInventory.Parameters.AddWithValue("@IdPartido", venta.Partido.IdPartido);
            updateInventory.Parameters.AddWithValue("@IdLocalidad", venta.Localidad.IdLocalidad);

            int filasActualizadas = updateInventory.ExecuteNonQuery();
            if (filasActualizadas == 0)
            {
                transaction.Rollback();
                throw new InvalidOperationException("No hay inventario suficiente para completar la venta.");
            }

            using var insertVenta = connection.CreateCommand();
            insertVenta.Transaction = transaction;
            insertVenta.CommandText = @"
SET IDENTITY_INSERT Venta ON;
INSERT INTO Venta
    (IdVenta, IdCliente, IdPartido, IdLocalidad, Cantidad, IdVendedor, FechaVenta, MontoTotal, TipoVenta)
VALUES
    (@IdVenta, @IdCliente, @IdPartido, @IdLocalidad, @Cantidad, @IdVendedor, @FechaVenta, @MontoTotal, @TipoVenta);
SET IDENTITY_INSERT Venta OFF;";

            insertVenta.Parameters.AddWithValue("@IdVenta", venta.IdVenta);
            insertVenta.Parameters.AddWithValue("@IdCliente", venta.Cliente.IdCliente);
            insertVenta.Parameters.AddWithValue("@IdPartido", venta.Partido.IdPartido);
            insertVenta.Parameters.AddWithValue("@IdLocalidad", venta.Localidad.IdLocalidad);
            insertVenta.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
            insertVenta.Parameters.AddWithValue("@IdVendedor", (object?)venta.Vendedor?.IdVendedor ?? DBNull.Value);
            insertVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
            insertVenta.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
            insertVenta.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);

            insertVenta.ExecuteNonQuery();
            transaction.Commit();
        }

        public Venta[] ObtenerTodos()
        {
            var ventas = new List<Venta>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT
    v.IdVenta,
    v.Cantidad,
    v.FechaVenta,
    v.MontoTotal,
    v.TipoVenta,
    c.IdCliente,
    c.Identificacion,
    c.Nombre,
    c.Apellido,
    c.FechaNacimiento,
    c.FechaRegistro,
    c.Activo,
    p.IdPartido,
    p.Rival,
    p.Fecha,
    p.Hora,
    p.Activo,
    l.IdLocalidad,
    l.NombreLocalidad,
    l.Precio,
    vd.IdVendedor,
    vd.Identificacion,
    vd.Nombre,
    vd.Apellido,
    vd.FechaNacimiento,
    vd.FechaIngreso
FROM Venta v
INNER JOIN Cliente c ON c.IdCliente = v.IdCliente
INNER JOIN Partido p ON p.IdPartido = v.IdPartido
INNER JOIN Localidad l ON l.IdLocalidad = v.IdLocalidad
LEFT JOIN Vendedor vd ON vd.IdVendedor = v.IdVendedor
ORDER BY v.IdVenta;";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var cliente = new Cliente(
                    reader.GetInt32(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetDateTime(9),
                    reader.GetDateTime(10),
                    reader.GetBoolean(11)
                );

                var partido = new Partido(
                    reader.GetInt32(12),
                    reader.GetString(13),
                    reader.GetDateTime(14),
                    reader.GetString(15),
                    reader.GetBoolean(16)
                );

                var localidad = new Localidad(
                    reader.GetInt32(17),
                    reader.GetString(18),
                    reader.GetDecimal(19)
                );

                // Vendedor puede ser null para ventas en línea
                Vendedor? vendedor = null;
                if (!reader.IsDBNull(20))
                {
                    vendedor = new Vendedor(
                        reader.GetInt32(20),
                        reader.GetString(21),
                        reader.GetString(22),
                        reader.GetString(23),
                        reader.GetDateTime(24),
                        reader.GetDateTime(25)
                    );
                }

                ventas.Add(new Venta(
                    reader.GetInt32(0),
                    cliente,
                    partido,
                    localidad,
                    reader.GetInt32(1),
                    vendedor,
                    reader.GetDateTime(2),
                    reader.GetDecimal(3),
                    reader.GetString(4)
                ));
            }

            return ventas.ToArray();
        }

        public bool ExisteIdVenta(int idVenta)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Venta WHERE IdVenta = @IdVenta) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdVenta", idVenta);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}
