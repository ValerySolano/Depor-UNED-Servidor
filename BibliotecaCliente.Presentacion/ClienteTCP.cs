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
       public static bool Conectar(string pIdentificacionCliente)
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);
                MensajeSocket<string> mensajeSocket = new MensajeSocket<string> { Metodo = "Conectar", Entidad = pIdentificacionCliente };
                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());
                return EnviarRespuesta(JsonConvert.SerializeObject(mensajeSocket));
            }
            catch (Exception)
            {
                return false;
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
            try
            {
                if (string.IsNullOrWhiteSpace(pIdentificacionCliente))
                {
                    return "ERROR";
                }

                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ValidarIdentificacion",
                    Entidad = pIdentificacionCliente.Trim()
                };

                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

                string respuesta = EnviarMensaje(JsonConvert.SerializeObject(mensajeSocket));
                return respuesta ?? "ERROR";
            }
            catch (Exception)
            {
                return "ERROR";
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

                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerVentasCliente",
                    Entidad = identificacionCliente.Trim()
                };

                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

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
            finally
            {
                try
                {
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                }
                catch
                {
                    // Ignorar errores al cerrar
                }
            }
        }

        public static List<Partido> ObtenerPartidos()
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerPartidos",
                    Entidad = ""
                };

                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

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
            finally
            {
                try
                {
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                }
                catch
                {
                    // Ignorar errores al cerrar
                }
            }
        }

        public static List<Localidad> ObtenerLocalidades()
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);

                MensajeSocket<string> mensajeSocket = new MensajeSocket<string>
                {
                    Metodo = "ObtenerLocalidades",
                    Entidad = ""
                };

                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

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
            finally
            {
                try
                {
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                }
                catch
                {
                    // Ignorar errores al cerrar
                }
            }
        }

        public static dynamic VerificarDisponibilidad(int idPartido, int idLocalidad, int cantidad)
        {
            try
            {
                ipServidor = IPAddress.Parse("127.0.0.1");
                cliente = new TcpClient();
                serverEndPoint = new IPEndPoint(ipServidor, puerto);
                cliente.Connect(serverEndPoint);

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

                clienteStreamWriter = new StreamWriter(cliente.GetStream());
                clienteStreamReader = new StreamReader(cliente.GetStream());

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
            finally
            {
                try
                {
                    clienteStreamWriter?.Close();
                    clienteStreamReader?.Close();
                    cliente?.Close();
                }
                catch
                {
                    // Ignorar errores al cerrar
                }
            }
        }
    }
}
