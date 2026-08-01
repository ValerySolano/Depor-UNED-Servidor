/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioPartidos
    {
        public void Agregar(Partido partido)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO Partido
    (IdPartido, Rival, Fecha, Hora, Activo)
VALUES
    (@IdPartido, @Rival, @Fecha, @Hora, @Activo);";

            command.Parameters.AddWithValue("@IdPartido", partido.IdPartido);
            command.Parameters.AddWithValue("@Rival", partido.Rival);
            command.Parameters.AddWithValue("@Fecha", partido.Fecha);
            command.Parameters.AddWithValue("@Hora", partido.Hora);
            command.Parameters.AddWithValue("@Activo", partido.Activo);

            command.ExecuteNonQuery();
        }

        public Partido? ObtenerPorId(int idPartido)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdPartido, Rival, Fecha, Hora, Activo
FROM Partido
WHERE IdPartido = @IdPartido;";
            command.Parameters.AddWithValue("@IdPartido", idPartido);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new Partido(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDateTime(2),
                reader.GetString(3),
                reader.GetBoolean(4)
            );
        }

        public Partido[] ObtenerTodos()
        {
            var partidos = new List<Partido>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdPartido, Rival, Fecha, Hora, Activo
FROM Partido
ORDER BY IdPartido;";

            using var reader = command.ExecuteReader();
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

        public bool ExisteIdPartido(int idPartido)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Partido WHERE IdPartido = @IdPartido) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdPartido", idPartido);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool limiteAlcanzado()
        {
            return false;
        }

    }
}

