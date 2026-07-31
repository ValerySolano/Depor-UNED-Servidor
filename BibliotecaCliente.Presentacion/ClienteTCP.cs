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

        public static bool ValidarIdentificacion(string pIdentificacionCliente)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(pIdentificacionCliente))
                {
                    return false;
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
                return bool.TryParse(respuesta, out bool existe) && existe;
            }
            catch (Exception)
            {
                return false;
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
    }
}
