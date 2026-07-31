/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioLocalidadesPartido
    {
        public void Agregar(LocalidadPartido registro)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO LocalidadPorPartido
    (IdLocalidadPartido, IdPartido, IdLocalidad, CantidadDisponible)
VALUES
    (@IdLocalidadPartido, @IdPartido, @IdLocalidad, @CantidadDisponible);";

            command.Parameters.AddWithValue("@IdLocalidadPartido", registro.IdLocalidadPartido);
            command.Parameters.AddWithValue("@IdPartido", registro.Partido.IdPartido);
            command.Parameters.AddWithValue("@IdLocalidad", registro.Localidad.IdLocalidad);
            command.Parameters.AddWithValue("@CantidadDisponible", registro.CantidadDisponible);

            command.ExecuteNonQuery();
        }

        public LocalidadPartido[] ObtenerTodos()
        {
            var registros = new List<LocalidadPartido>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
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

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var partido = new Partido(
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetDateTime(4),
                    reader.GetString(5),
                    reader.GetBoolean(6)
                );

                var localidad = new Localidad(
                    reader.GetInt32(7),
                    reader.GetString(8),
                    reader.GetDecimal(9)
                );

                registros.Add(new LocalidadPartido(
                    reader.GetInt32(0),
                    partido,
                    localidad,
                    reader.GetInt32(1)
                ));
            }

            return registros.ToArray();
        }

        public bool ExisteIdRegistro(int idLocalidadPartido)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM LocalidadPorPartido WHERE IdLocalidadPartido = @IdLocalidadPartido) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdLocalidadPartido", idLocalidadPartido);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool ExisteLocalidadEnPartido(int idPartido, int idLocalidad)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT CASE WHEN EXISTS(
    SELECT 1
    FROM LocalidadPorPartido
    WHERE IdPartido = @IdPartido
      AND IdLocalidad = @IdLocalidad
) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdPartido", idPartido);
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

