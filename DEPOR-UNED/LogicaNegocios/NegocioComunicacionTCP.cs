using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
namespace LogicaNegocios
{
    public class NegocioComunicacionTCP
    {
        // Variable tcp listener
        private TcpListener tcpListener;
        private bool servidorActivo;
        private const int puerto = 5000;
        // event handler para recibir mensajes
        public event EventHandler<(string mensaje, StreamWriter streamWriter)>? MensajeRecibido;
        public NegocioComunicacionTCP()
        {
            var local= System.Net.IPAddress.Parse("127.0.0.1");
            tcpListener = new TcpListener(local, puerto);
            servidorActivo = false;
        }

        //Metodo iniciar servidor
        public void IniciarServidor()
        {
            servidorActivo = true;
            tcpListener.Start();
           // Iniciar un hilo para aceptar conexiones entrantes
            var subprocesoEscuchaClientes = new Thread(AceptarConexiones);
            subprocesoEscuchaClientes.IsBackground = true;
            subprocesoEscuchaClientes.Start();
        }
         
         // Metodo detener servidor
        public void DetenerServidor()
        {
            servidorActivo = false;
            tcpListener.Stop();
        }

        // Metodo aceptar conexiones
        private void AceptarConexiones()
        {
            while (servidorActivo)
            {
                try
                {
                    // Aceptar una conexión entrante
                    var cliente = tcpListener.AcceptTcpClient();
                    // Iniciar un hilo para manejar la comunicación con el cliente
                    var subprocesoCliente = new Thread(ComunicacionCliente);
                    subprocesoCliente.Start(cliente);
                }
                catch (SocketException ex)
                {
                    // Manejar la excepción si el servidor se detiene mientras espera conexiones
                    if (servidorActivo)
                    {
                        Console.WriteLine($"Error al aceptar conexión: {ex.Message}");
                    }
                }
            }
        }

        // Metodo comunicacion con el cliente
        private void ComunicacionCliente(object cliente)
        {
            var tcpClient = (TcpClient)cliente;
            var reader = new StreamReader(tcpClient.GetStream());
            var writer = new StreamWriter(tcpClient.GetStream());

            while (servidorActivo)
            {
                try
                {
                    // Leer mensaje del cliente
                    var mensaje = reader.ReadLine();
                    
                    // Validar que el mensaje no sea null antes de invocar el evento
                    if (!string.IsNullOrWhiteSpace(mensaje))
                    {
                        // Utilizamos invoke para disparar el evento
                        MensajeRecibido?.Invoke(this, (mensaje, writer));
                    }
                    else
                    {
                        // Si el mensaje es null o vacío, el cliente probablemente se desconectó
                        break;
                    }
                }
                catch (IOException)
                {
                    break; // Cliente desconectado
                }
            }
        }
    }
}
