/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
namespace AccesoDatos
{
    public class RepositorioLocalidades
    {
        public void Agregar(Localidad localidad)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
INSERT INTO Localidad
    (IdLocalidad, NombreLocalidad, Precio)
VALUES
    (@IdLocalidad, @NombreLocalidad, @Precio);";

            command.Parameters.AddWithValue("@IdLocalidad", localidad.IdLocalidad);
            command.Parameters.AddWithValue("@NombreLocalidad", localidad.NombreLocalidad);
            command.Parameters.AddWithValue("@Precio", localidad.Precio);

            command.ExecuteNonQuery();
        }

        public Localidad? ObtenerPorId(int idLocalidad)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdLocalidad, NombreLocalidad, Precio
FROM Localidad
WHERE IdLocalidad = @IdLocalidad;";
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad);

            using var reader = command.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            return new Localidad(
                reader.GetInt32(0),
                reader.GetString(1),
                reader.GetDecimal(2)
            );
        }

        public Localidad[] ObtenerTodos()
        {
            var localidades = new List<Localidad>();

            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = @"
SELECT IdLocalidad, NombreLocalidad, Precio
FROM Localidad
ORDER BY IdLocalidad;";

            using var reader = command.ExecuteReader();
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

        public bool ExisteIdLocalidad(int idLocalidad)
        {
            using var connection = ConexionBD.AbrirConexion();
            using var command = connection.CreateCommand();
            command.CommandText = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Localidad WHERE IdLocalidad = @IdLocalidad) THEN CAST(1 AS bit) ELSE CAST(0 AS bit) END;";
            command.Parameters.AddWithValue("@IdLocalidad", idLocalidad);
            return Convert.ToBoolean(command.ExecuteScalar());
        }

        public bool limiteAlcanzado()
        {
            return false;
        }
    }
}

