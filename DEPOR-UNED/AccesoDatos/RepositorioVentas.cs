/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioVentas
    {
        // Método para agregar una nueva venta a la base de datos con transacción para actualizar el inventario
        public void Agregar(Venta venta)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var transaction = connection.BeginTransaction(); // Iniciar una transacción para garantizar la consistencia de los datos

            // Crear comando para actualizar el inventario de localidades disponibles
            using var updateInventory = connection.CreateCommand();
            updateInventory.Transaction = transaction; // Asociar el comando a la transacción
            // Definir la consulta SQL para decrementar la cantidad disponible de localidades para el partido
            updateInventory.CommandText = @"
UPDATE LocalidadPorPartido
SET CantidadDisponible = CantidadDisponible - @Cantidad
WHERE IdPartido = @IdPartido
  AND IdLocalidad = @IdLocalidad
  AND CantidadDisponible >= @Cantidad;";

            // Agregar los parámetros del comando SQL para la actualización del inventario
            updateInventory.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
            updateInventory.Parameters.AddWithValue("@IdPartido", venta.Partido.IdPartido);
            updateInventory.Parameters.AddWithValue("@IdLocalidad", venta.Localidad.IdLocalidad);

            int filasActualizadas = updateInventory.ExecuteNonQuery(); // Ejecutar la actualización y obtener el número de filas afectadas
            // Si no se actualizó ninguna fila, significa que no hay suficiente inventario disponible
            if (filasActualizadas == 0)
            {
                transaction.Rollback(); // Revertir la transacción si no hay inventario suficiente
                throw new InvalidOperationException("No hay inventario suficiente para completar la venta.");
            }

            // Crear comando para insertar el registro de la venta en la base de datos
            using var insertVenta = connection.CreateCommand();
            insertVenta.Transaction = transaction; // Asociar el comando a la transacción
            // Definir la consulta SQL para insertar una nueva venta en la tabla Venta
            insertVenta.CommandText = @"
SET IDENTITY_INSERT Venta ON;
INSERT INTO Venta
    (IdVenta, IdCliente, IdPartido, IdLocalidad, Cantidad, IdVendedor, FechaVenta, MontoTotal, TipoVenta)
VALUES
    (@IdVenta, @IdCliente, @IdPartido, @IdLocalidad, @Cantidad, @IdVendedor, @FechaVenta, @MontoTotal, @TipoVenta);
SET IDENTITY_INSERT Venta OFF;";

            // Agregar los parámetros del comando SQL con los valores de la venta a insertar
            insertVenta.Parameters.AddWithValue("@IdVenta", venta.IdVenta);
            insertVenta.Parameters.AddWithValue("@IdCliente", venta.Cliente.IdCliente);
            insertVenta.Parameters.AddWithValue("@IdPartido", venta.Partido.IdPartido);
            insertVenta.Parameters.AddWithValue("@IdLocalidad", venta.Localidad.IdLocalidad);
            insertVenta.Parameters.AddWithValue("@Cantidad", venta.Cantidad);
            insertVenta.Parameters.AddWithValue("@IdVendedor", (object?)venta.Vendedor?.IdVendedor ?? DBNull.Value); // Vendedor puede ser null para ventas en línea
            insertVenta.Parameters.AddWithValue("@FechaVenta", venta.FechaVenta);
            insertVenta.Parameters.AddWithValue("@MontoTotal", venta.MontoTotal);
            insertVenta.Parameters.AddWithValue("@TipoVenta", venta.TipoVenta);

            insertVenta.ExecuteNonQuery(); // Ejecutar el comando SQL para insertar la venta
            transaction.Commit(); // Confirmar la transacción si todo fue exitoso
        }

        // Método para obtener todas las ventas de la base de datos con sus relaciones
        public Venta[] ObtenerTodos()
        {
            var ventas = new List<Venta>();

            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para ejecutar la consulta de obtención de todas las ventas
            // Definir la consulta SQL para obtener todas las ventas con sus relaciones (Cliente, Partido, Localidad y Vendedor)
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

            using var reader = command.ExecuteReader(); // Ejecutar el comando SQL y obtener un lector de datos para leer los resultados de la consulta
            // Leer cada registro y agregarlo a la lista de ventas
            while (reader.Read())
            {
                // Crear el objeto Cliente con los datos obtenidos de la consulta
                var cliente = new Cliente(
                    reader.GetInt32(5),
                    reader.GetString(6),
                    reader.GetString(7),
                    reader.GetString(8),
                    reader.GetDateTime(9),
                    reader.GetDateTime(10),
                    reader.GetBoolean(11)
                );

                // Crear el objeto Partido con los datos obtenidos de la consulta
                var partido = new Partido(
                    reader.GetInt32(12),
                    reader.GetString(13),
                    reader.GetDateTime(14),
                    reader.GetString(15),
                    reader.GetBoolean(16)
                );

                // Crear el objeto Localidad con los datos obtenidos de la consulta
                var localidad = new Localidad(
                    reader.GetInt32(17),
                    reader.GetString(18),
                    reader.GetDecimal(19)
                );

                // Vendedor puede ser null para ventas en línea, verificar si el campo no es nulo
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

                // Agregar el nuevo objeto Venta a la lista
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

        // Método para verificar si existe una venta con el id especificado
        public bool ExisteIdVenta(int idVenta)
        {
            // Abrir la conexión a la base de datos usando la clase ConexionBD
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand(); // Crear un comando SQL para verificar la existencia de la venta
            // Definir la consulta SQL para verificar si existe una venta con el id especificado
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Venta WHERE IdVenta = @IdVenta) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdVenta", idVenta); // Agregar el parámetro del comando SQL con el valor del id de la venta
            return Convert.ToBoolean(command.ExecuteScalar()); // Ejecutar el comando SQL y devolver el resultado como booleano
        }

        // Método para verificar si se alcanzó el límite de ventas
        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}
