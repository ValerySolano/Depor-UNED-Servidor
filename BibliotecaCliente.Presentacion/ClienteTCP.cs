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
        private static IPAddress ipServidor;
        private static TcpClient cliente;
        private static IPEndPoint serverEndPoint;
        private static StreamWriter clienteStreamWriter;
        private static StreamReader clienteStreamReader;
        private const int puerto = 5000;
        private static bool EnviarRespuesta(string mensaje)
        {
            try
            {
                clienteStreamWriter.WriteLine(mensaje);
                clienteStreamWriter.Flush();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       public static string ConectarYValidar(string pIdentificacionCliente)
        {
            try
            {
                // Establecer la conexión TCP persistente
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);
                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

                // Validar usando la conexión establecida
                MensajeSocket<string> mensajeValidacion = new MensajeSocket<string> 
                { 
                    Metodo = "ValidarIdentificacion", 
                    Entidad = pIdentificacionCliente 
                };
                
                string resultadoValidacion = EnviarMensaje(JsonConvert.SerializeObject(mensajeValidacion));
                
                // Si la validación es exitosa, enviar mensaje de conexión
                if (resultadoValidacion == "VALIDO")
                {
                    MensajeSocket<string> mensajeConexion = new MensajeSocket<string> 
                    { 
                        Metodo = "Conectar", 
                        Entidad = pIdentificacionCliente 
                    };
                    EnviarRespuesta(JsonConvert.SerializeObject(mensajeConexion));
                    return "VALIDO";
                }
                else
                {
                    // Si la validación falla, cerrar la conexión
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                    return resultadoValidacion ?? "ERROR";
                }
            }
            catch (Exception)
            {
                // En caso de error, cerrar la conexión si existe
                try
                {
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                }
                catch { }
                return "ERROR";
            }
        }
        public static void Desconectar(string pIdentificacion)
        {
            MensajeSocket<string> mensajeSocket = new MensajeSocket<string> { Metodo = "Desconectar", Entidad = pIdentificacion };
            EnviarRespuesta(JsonConvert.SerializeObject(mensajeSocket));
            if (cliente.Connected)
            {
                clienteStreamWriter.Close();
                clienteStreamReader.Close();
                cliente.Close();
            }
        }

        public static string ValidarIdentificacion(string pIdentificacionCliente)
        {
            TcpClient clienteTemp = null;
            StreamWriter writerTemp = null;
            StreamReader readerTemp = null;
            
            try
            {
                if (string.IsNullOrWhiteSpace(pIdentificacionCliente))
                {
                    return "ERROR";
                }

                // Crear conexión temporal solo para validación
                ipServidor = IPAddress.Parse("127.0.0.1");
                clienteTemp = new TcpClient();
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

        public static string EnviarMensaje(string mensaje)
        {
            if (EnviarRespuesta(mensaje))
            {
                return clienteStreamReader.ReadLine();
            }
            else
            {
                return "Error al enviar el mensaje.";
            }
        }

        public static List<Venta> ObtenerVentasCliente(string identificacionCliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificacionCliente))
                {
                    return new List<Venta>();
                }

                if (cliente == null || !cliente.Connected)
                {
                    return new List<Venta>();
                }

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerVentasCliente",
                    Entidad = identificacionCliente.Trim()
                };

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));
                
                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]")
                {
                    return new List<Venta>();
                }

                var ventas = JsonConvert.DeserializeObject<List<Venta>>(respuesta);
                return ventas ?? new List<Venta>();
            }
            catch (Exception)
            {
                return new List<Venta>();
            }
        }

        public static List<Partido> ObtenerPartidos()
        {
            try
            {
                if (cliente == null || !cliente.Connected)
                {
                    return new List<Partido>();
                }

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerPartidos",
                    Entidad = ""
                };

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]")
                {
                    return new List<Partido>();
                }

                var partidos = JsonConvert.DeserializeObject<List<Partido>>(respuesta);
                return partidos ?? new List<Partido>();
            }
            catch (Exception)
            {
                return new List<Partido>();
            }
        }

        public static List<Localidad> ObtenerLocalidades()
        {
            try
            {
                if (cliente == null || !cliente.Connected)
                {
                    return new List<Localidad>();
                }

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerLocalidades",
                    Entidad = ""
                };

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (string.IsNullOrWhiteSpace(respuesta) || respuesta == "[]")
                {
                    return new List<Localidad>();
                }

                var localidades = JsonConvert.DeserializeObject<List<Localidad>>(respuesta);
                return localidades ?? new List<Localidad>();
            }
            catch (Exception)
            {
                return new List<Localidad>();
            }
        }

        public static dynamic VerificarDisponibilidad(int idPartido, int idLocalidad, int cantidad)
        {
            try
            {
                if (cliente == null || !cliente.Connected)
                {
                    return new { disponible = false, cantidadDisponible = 0, precio = 0m };
                }

                var datosVerificacion = new DatosVerificacionDisponibilidad
                {
                    IdPartido = idPartido,
                    IdLocalidad = idLocalidad,
                    Cantidad = cantidad
                };

                MensajeSocket<DatosVerificacionDisponibilidad> mensajeSocket = new MensajeSocket<DatosVerificacionDisponibilidad>
                {
                    Metodo = "VerificarDisponibilidad",
                    Entidad = datosVerificacion
                };

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));

                if (string.IsNullOrWhiteSpace(respuesta))
                {
                    return new { disponible = false, cantidadDisponible = 0, precio = 0m };
                }

                var resultado = JsonConvert.DeserializeObject<dynamic>(respuesta);
                return resultado;
            }
            catch (Exception)
            {
                return new { disponible = false, cantidadDisponible = 0, precio = 0m };
            }
        }

        public static bool AgregarVenta(Venta venta)
        {
            try
            {
                if (cliente == null || !cliente.Connected)
                {
                    throw new Exception("No hay conexión con el servidor");
                }

                MensajeSocket<Venta> mensajeSocket = new MensajeSocket<Venta>
                {
                    Metodo = "AgregarVenta",
                    Entidad = venta
                };

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
