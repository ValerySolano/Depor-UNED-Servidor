/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace AccesoDatos
{
    internal static class ConexionBD
    {
        // Cadena de conexión obtenida del archivo App.config
        private static readonly string ConnectionString = ObtenerCadenaConexion();

        // Método para abrir la conexión a la base de datos, de tipo SqlConnection, y devolver la conexión abierta
        public static SqlConnection AbrirConexion()
        {
            // Crear una nueva instancia de SqlConnection con la cadena de conexión obtenida
            var conexion = new SqlConnection(ConnectionString);
            conexion.Open(); // Abrir la conexión a la base de datos
            return conexion;
        }

        // Método para cerrar la conexión a la base de datos, de tipo SqlConnection
        private static string ObtenerCadenaConexion()
        {   
            // Se obtiene la cadena de conexión desde el archivo App.config usando ConfigurationManager
            string? cadena = ConfigurationManager.ConnectionStrings["conexionDB"]?.ConnectionString;

            if (string.IsNullOrWhiteSpace(cadena)) // Si la cadena es nula o vacía, se lanza una excepción indicando que no se encontró la cadena de conexión
            {
                throw new InvalidOperationException("No se encontro la cadena de conexion 'conexionDB' en App.config.");
            }

            return cadena;
        }
    }
}
