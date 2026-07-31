using Microsoft.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    internal static class ConexionBD
    {
        private static readonly string ConnectionString = ObtenerCadenaConexion();

        public static SqlConnection AbrirConexion()
        {
            var conexion = new SqlConnection(ConnectionString);
            conexion.Open();
            return conexion;
        }

        private static string ObtenerCadenaConexion()
        {
            string? cadena = ConfigurationManager.ConnectionStrings["conexionDB"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(cadena))
            {
                throw new InvalidOperationException("No se encontro la cadena de conexion 'conexionDB' en App.config.");
            }

            return cadena;
        }
    }
}
