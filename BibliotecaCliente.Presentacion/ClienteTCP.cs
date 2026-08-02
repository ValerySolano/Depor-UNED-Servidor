/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 1/08/2026
*/
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Entidades;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
namespace BibliotecaCliente.Presentacion
{
    public class ClienteTCP
    {
        // Variables estáticas para la conexión TCP
        private static IPAddress ipServidor;  // IP del servidor al que se conectará el cliente
        private static TcpClient cliente;  // Cliente TCP para la conexión con el servidor
        private static IPEndPoint serverEndPoint; // Punto final del servidor al que se conectará el cliente
        private static StreamWriter clienteStreamWriter; // StreamWriter para enviar datos al servidor
        private static StreamReader clienteStreamReader; // StreamReader para recibir datos del servidor
        private const int puerto = 5000; // Puerto en el que el servidor está escuchando

        // Método para enviar una respuesta al servidor
        private static bool EnviarRespuesta(string mensaje)
        {
            try
            {
                clienteStreamWriter.WriteLine(mensaje); // Escribir el mensaje en el StreamWriter
                clienteStreamWriter.Flush(); // Asegurarse de que el mensaje se envíe inmediatamente

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        // Método para conectarse y validar la identificación del cliente
       public static string ConectarYValidar(string pIdentificacionCliente)
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1"); // Dirección IP del servidor (localhost)
                cliente = new TcpClient(); // Crear una nueva instancia de TcpClient
                serverEndPoint = new IPEndPoint(ipServidor, puerto); // Crear un punto final con la IP y el puerto del servidor
                cliente.Connect(serverEndPoint); // Conectar al servidor
                clienteStreamWriter = new StreamWriter(cliente.GetStream()); // Crear un StreamWriter para enviar datos al servidor
                clienteStreamReader = new StreamReader(cliente.GetStream()); // Crear un StreamReader para recibir datos del servidor

                // Validar la identificación del cliente enviando un mensaje al servidor
                MensajeSocket<string> mensajeValidacion = new MensajeSocket<string> 
                { 
                    Metodo = "ValidarIdentificacion", 
                    Entidad = pIdentificacionCliente 
                };
                
                // Enviar el mensaje de validación y recibir la respuesta del servidor  
                string resultadoValidacion = EnviarMensaje(JsonConvert.SerializeObject(mensajeValidacion));
                
                if (resultadoValidacion == "VALIDO") // Si la validación es exitosa, enviar un mensaje de conexión al servidor
                {
                    MensajeSocket<string> mensajeConexion = new MensajeSocket<string> 
                    { 
                        Metodo = "Conectar", 
                        Entidad = pIdentificacionCliente 
                    };
                    EnviarRespuesta(JsonConvert.SerializeObject(mensajeConexion)); // Enviar el mensaje de conexión al servidor
                    return "VALIDO"; // Retornar "VALIDO" indicando que la conexión y validación fueron exitosas
                }
                else
                {
                    clienteStreamWriter?.Close(); // Cerrar el StreamWriter si no es nulo
                    clienteStreamReader?.Close(); // Cerrar el StreamReader si no es nulo
                    cliente?.Close(); // Cerrar el cliente TCP si no es nulo
                    return resultadoValidacion ?? "ERROR"; // Retornar el resultado de la validación o "ERROR" si es nulo
                }
            }
            catch (Exception)
            {
                try
                {
                    clienteStreamWriter?.Close(); // Cerrar el StreamWriter si no es nulo
                    clienteStreamReader?.Close(); // Cerrar el StreamReader si no es nulo
                    cliente?.Close(); // Cerrar el cliente TCP si no es nulo
                }
                catch { // Ignorar errores al cerrar los recursos

                }
                return "ERROR"; // Retornar "ERROR" indicando que ocurrió un error durante la conexión o validación
            }
        }
        
        // Método para desconectar al cliente del servidor
        public static void Desconectar(string pIdentificacion)
        {
            // Crear mensaje de desconexión para enviar al servidor
            MensajeSocket<string> mensajeSocket = new MensajeSocket<string> { Metodo = "Desconectar", Entidad = pIdentificacion };
            EnviarRespuesta(JsonConvert.SerializeObject(mensajeSocket));// Enviar el mensaje de desconexión al servidor
            if (cliente.Connected) // Si el cliente está conectado, cerrar los recursos
            {
                clienteStreamWriter.Close();
                clienteStreamReader.Close();
                cliente.Close();
            }
        }

        // Método para validar la identificación del cliente sin mantener la conexión
        public static string ValidarIdentificacion(string pIdentificacionCliente)
        {
            TcpClient clienteTemp = null;
            StreamWriter writerTemp = null;
            StreamReader readerTemp = null;
            
            try
            {
                if (string.IsNullOrWhiteSpace(pIdentificacionCliente)) // Validar que la identificación no esté vacía o nula
                {
                    return "ERROR"; // Retornar "ERROR" si la identificación es inválida
                }

                // Crear conexión temporal solo para validación
                ipServidor = IPAddress.Parse("127.0.0.1");
                clienteTemp = new TcpClient(); // Crear una nueva instancia de TcpClient para la conexión temporal
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                clienteTemp.Connect(serverEndPoint);

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ValidarIdentificacion",
                    Entidad = pIdentificacionCliente.Trim()
                };

                writerTemp = new StreamWriter(clienteTemp.GetStream());
                readerTemp = new StreamReader(clienteTemp.GetStream());

                writerTemp.WriteLine(JsonConvert.SerializeObject(mensajeSocket));
                writerTemp.Flush();
                
                string respuesta = readerTemp.ReadLine();
                return respuesta ?? "ERROR";
            }
            catch (Exception)
            {
                return "ERROR";
            }
            finally
            {
                try
                {
                    writerTemp?.Close();
                    readerTemp?.Close();
                    clienteTemp?.Close();
                }
                catch
                {
                    // Ignorar errores al cerrar
                }
            }
        }
        // Método para enviar un mensaje al servidor y recibir la respuesta
        public static string EnviarMensaje(string mensaje)
        {
            if (EnviarRespuesta(mensaje)) // Si el mensaje se envió correctamente, leer la respuesta del servidor
            {
                return clienteStreamReader.ReadLine(); // Leer la respuesta del servidor
            }
            else
            {
                return "Error al enviar el mensaje."; // Retornar un mensaje de error si no se pudo enviar el mensaje
            }
        }

        // Método para obtener las ventas de un cliente específico
        public static List<Venta> ObtenerVentasCliente(string identificacionCliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificacionCliente)) // Validar que la identificación del cliente no esté vacía o nula
                {
                    return new List<Venta>(); // Retornar una lista vacía si la identificación es inválida
                }

                if (cliente == null || !cliente.Connected) // Validar que el cliente esté conectado al servidor
                {
                    return new List<Venta>(); // Retornar una lista vacía si el cliente no está conectado
                }

                // Crear un mensaje para solicitar las ventas del cliente al servidor
                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerVentasCliente",
                    Entidad = identificacionCliente.Trim()
                };
                // Enviar el mensaje al servidor y recibir la respuesta
                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));
                
                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]") // Validar que la respuesta no esté vacía o sea una lista vacía
                {
                    return new List<Venta>(); // Retornar una lista vacía si no hay ventas para el cliente
                }
                
                // Deserializar la respuesta JSON en una lista de ventas
                var ventas = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
                return ventas ?? new List<Venta>(); // Retornar la lista de ventas o una lista vacía si la deserialización falla
            }
            catch (Exception)
            {
                return new List<Venta>(); // Retornar una lista vacía si ocurre un error durante el proceso
            }
        }

        // Método para obtener un cliente por su identificación
        public static Cliente ObtenerClientePorIdentificacion(string identificacionCliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificacionCliente)) // Validar que la identificación del cliente no esté vacía o nula
                {
                    return null; // Retornar null si la identificación es inválida
                }

                if (cliente == null || !cliente.Connected) // Validar que el cliente esté conectado al servidor
                {
                    return null;
                }
                // Crear un mensaje para solicitar el cliente al servidor
                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerClientePorIdentificacion",
                    Entidad = identificacionCliente.Trim()
                };

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket)); // Enviar el mensaje al servidor y recibir la respuesta
                
                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "null") // Validar que la respuesta no esté vacía o sea "null"
                {
                    return null;
                }
                // Deserializar la respuesta JSON en un objeto Cliente
                var clienteObj = JsonConvert.DeserializeObject<Cliente>(respuesta);
                return clienteObj;
            }
            catch (Exception)
            {
                return null;
            }
        }
        // Método para obtener la lista de partidos disponibles
        public static List<Partido> ObtenerPartidos()
        {
            try
            {   
                // Validar que el cliente esté conectado al servidor antes de enviar la solicitud
                if (cliente == null || !cliente.Connected)
                {
                    return new List<Partido>(); // Retornar una lista vacía si el cliente no está conectado
                }
                // Crear un mensaje para solicitar la lista de partidos al servidor
                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerPartidos",
                    Entidad = ""
                };
                
                // Enviar el mensaje al servidor y recibir la respuesta
                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));
                
                // Validar que la respuesta no esté vacía o sea una lista vacía
                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]")
                {
                    return new List<Partido>();
                }
                // Deserializar la respuesta JSON en una lista de partidos
                var partidos = JsonConvert.DeserializeObject<List<Partido>>(respuesta);
                return partidos ?? new List<Partido>();
            }
            catch (Exception)
            {
                return new List<Partido>();
            }
        }

        // Método para obtener la lista de localidades disponibles
        public static List<Localidad> ObtenerLocalidades()
        {
            try
            {
                if (cliente == null || !cliente.Connected) // Validar que el cliente esté conectado al servidor antes de enviar la solicitud
                {
                    return new List<Localidad>(); // Retornar una lista vacía si el cliente no está conectado
                }
                // Crear un mensaje para solicitar la lista de localidades al servidor
                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerLocalidades",
                    Entidad = ""
                };
                
                // Enviar el mensaje al servidor y recibir la respuesta
                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]") // Validar que la respuesta no esté vacía o sea una lista vacía
                {
                    return new List<Localidad>();
                }

                // Deserializar la respuesta JSON en una lista de localidades
                var localidades = JsonConvert.DeserializeObject<List<Localidad>>(respuesta);
                // Retornar la lista de localidades o una lista vacía si la deserialización falla
                return localidades ?? new List<Localidad>();
            }
            catch (Exception)
            {
                return new List<Localidad>();
            }
        }

        // Método para verificar la disponibilidad de boletos para un partido específico
        public static dynamic VerificarDisponibilidad(int idPartido, int idLocalidad, int cantidad)
        {
            try
            {   
                // Validar que el cliente esté conectado al servidor antes de enviar la solicitud
                if (cliente == null || !cliente.Connected)
                {
                    // Retornar un objeto indicando que no hay disponibilidad si el cliente no está conectado
                    return new { disponible = false, cantidadDisponible = 0, precio = 0m };
                }

                // Crear un objeto de datos de verificación con la información del partido, localidad y cantidad solicitada
                var datosVerificacion = new DatosVerificacionDisponibilidad
                {
                    IdPartido = idPartido,
                    IdLocalidad = idLocalidad,
                    Cantidad = cantidad
                };

                // Crear un mensaje para solicitar la verificación de disponibilidad al servidor
                MensajeSocket<DatosVerificacionDisponibilidad> mensajeSocket = new MensajeSocket<DatosVerificacionDisponibilidad>
                {
                    Metodo = "VerificarDisponibilidad",
                    Entidad = datosVerificacion
                };
                
                // Enviar el mensaje al servidor y recibir la respuesta
                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (string.IsNullOrWhiteSpace(respuesta))
                {
                    return new { disponible = false, cantidadDisponible = 0, precio = 0m };
                }
                // Deserializar la respuesta JSON en un objeto dinámico para obtener la información de disponibilidad
                var resultado = JsonConvert.DeserializeObject<dynamic>(respuesta);
                return resultado;
            }
            catch (Exception)
            {
                return new { disponible = false, cantidadDisponible = 0, precio = 0m };
            }
        }

        // Método para agregar una venta al servidor
        public static bool AgregarVenta(Venta venta)
        {
            try
            {   
                // Validar que el cliente esté conectado al servidor antes de enviar la solicitud
                if (cliente == null || !cliente.Connected)
                {
                    throw new Exception("No hay conexión con el servidor");
                }

                // Crear un mensaje para solicitar la adición de una venta al servidor
                MensajeSocket<Venta> mensajeSocket = new MensajeSocket<Venta>
                {
                    Metodo = "AgregarVenta",
                    Entidad = venta
                };
                
                // Enviar el mensaje al servidor y recibir la respuesta
                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (respuesta.StartsWith("ERROR:"))
                {
                    throw new Exception(respuesta.Replace("ERROR: ", ""));
                }

                return respuesta == "OK";
            }
            catch (Exception)
            {
                throw; // Re-lanzar la excepción para que sea capturada en el formulario
            }
        }
    }
}
