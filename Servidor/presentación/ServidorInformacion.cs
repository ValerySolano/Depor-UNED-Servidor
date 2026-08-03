/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using LogicaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using Entidades;
using Newtonsoft.Json;
using System.Xml.Serialization;

namespace presentación
{
    public partial class ServidorInformacion : Form
    {
        // Variable para la comunicación TCP
        private readonly NegocioComunicacionTCP comunicacionTCP = new NegocioComunicacionTCP();
       // Variables de lógica de negocio
        private readonly LogicaCliente logicaCliente = new LogicaCliente();
        private readonly LogicaVenta logicaVenta = new LogicaVenta();
        private readonly LogicaPartido logicaPartido = new LogicaPartido();
        private readonly LogicaLocalidad logicaLocalidad = new LogicaLocalidad();
        private readonly LogicaLocalidadPartido logicaLocalidadPartido = new LogicaLocalidadPartido();

        // Delegados para actualizar la interfaz de usuario desde hilos diferentes
        private delegate void EscribirEnTextBoxDelegate(string texto);
        // Delegado para modificar el ListBox de clientes conectados
        private delegate void ModificarListBoxDelegate(string texto, bool agregar);

        EscribirEnTextBoxDelegate modificarTextotxtBitacora;
        ModificarListBoxDelegate modificarListBoxClientes;

        public ServidorInformacion()
        {
            InitializeComponent();
            comunicacionTCP.MensajeRecibido += ComunicacionTCP_MensajeRecibido;
            modificarTextotxtBitacora = new EscribirEnTextBoxDelegate(EcribirEnTextBox);
            modificarListBoxClientes = new ModificarListBoxDelegate(ModificarListBox);
        }
        // Manejo de eventos para recibir mensajes del cliente
        private void ComunicacionTCP_MensajeRecibido(object sender, (string mensaje, StreamWriter streamWriter) e) {
            try
            {
                if (string.IsNullOrWhiteSpace(e.mensaje))
                {
                    // 
                    txtBitacora.Invoke(modificarTextotxtBitacora, 
                        new object[] { "Se recibió un mensaje vacío o null. Ignorando..." });
                    return;
                }
                // Deserializar el mensaje recibido en un objeto MensajeSocket
                var mensajeRecibido = JsonConvert.DeserializeObject<MensajeSocket<object>>(e.mensaje);
                
                if (mensajeRecibido == null)
                {
                    // Manejar el caso en que la deserialización falle
                    txtBitacora.Invoke(modificarTextotxtBitacora, 
                        new object[] { "No se pudo deserializar el mensaje. Ignorando..." });
                    return;
                }
                // Llamar al método correspondiente según el valor de "Metodo"
                SeleccionarMetodo(mensajeRecibido.Metodo, mensajeRecibido.Entidad, ref e.streamWriter);
            }
            catch (System.Text.Json.JsonException ex)
            {
                MessageBox.Show($"No fue posible convertir el objeto: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar mensaje: {ex.Message}\n\nDetalles: {ex.StackTrace}");
            }
        }
        public void SeleccionarMetodo(string pMetodo, object entidad, ref StreamWriter servidorStreamWriter)
        {
            switch (pMetodo)
            {
                // Llama al metodo conectar para agregar el cliente a la lista de clientes conectados
                case "Conectar":
                    Conectar((string) entidad);
                    break;
                // Llama al metodo para consultar un cliente
                case "ConsultarCliente":
                    // Deserializar la entidad del cliente
                    var entidadCliente = JsonConvert.DeserializeObject<Cliente>(JsonConvert.SerializeObject(entidad));
                    // Agregar el cliente a la lista de clientes
                    logicaCliente.AgregarCliente(entidadCliente);
                    break;
                // Llama al metodo para consultar un cliente
                case "ValidarIdentificacion":
                    var identificacionCliente = (string)entidad;
                    // Buscar el cliente en la lista de clientes
                    var clienteEncontrado = logicaCliente.ObtenerClientes()
                        .FirstOrDefault(cliente => cliente.Identificacion == identificacionCliente);
                    
                    if (clienteEncontrado == null)
                    {   
                        // Si no se encuentra el cliente, enviar respuesta "NOEXISTE"
                        EnviarRespuesta("NOEXISTE", ref servidorStreamWriter);
                    }
                    else if (!clienteEncontrado.Activo)
                    {
                        // Si el cliente está inactivo, enviar respuesta "INACTIVO"
                        EnviarRespuesta("INACTIVO", ref servidorStreamWriter);
                    }
                    else
                    {
                        // Si el cliente es válido, enviar respuesta "VALIDO"
                        EnviarRespuesta("VALIDO", ref servidorStreamWriter);
                    }
                    break;

                case "ObtenerVentasCliente":
                    var identificacionVentas = (string)entidad;
                    ObtenerVentasCliente(identificacionVentas, ref servidorStreamWriter);
                    break;

                case "ObtenerClientePorIdentificacion":
                    var identificacionBuscar = (string)entidad;
                    ObtenerClientePorIdentificacion(identificacionBuscar, ref servidorStreamWriter);
                    break;

                case "ObtenerPartidos":
                    ObtenerPartidos(ref servidorStreamWriter);
                    break;

                case "ObtenerLocalidades":
                    ObtenerLocalidades(ref servidorStreamWriter);
                    break;

                case "VerificarDisponibilidad":
                    try
                    {
                        var jsonString = JsonConvert.SerializeObject(entidad);
                        var datosVerificacion = JsonConvert.DeserializeObject<DatosVerificacionDisponibilidad>(jsonString);
                        VerificarDisponibilidad(datosVerificacion.IdPartido, datosVerificacion.IdLocalidad, datosVerificacion.Cantidad, ref servidorStreamWriter);
                    }
                    catch (Exception ex)
                    {
                        var resultado = new { disponible = false, cantidadDisponible = 0, precio = 0 };
                        EnviarRespuesta(JsonConvert.SerializeObject(resultado), ref servidorStreamWriter);
                        txtBitacora.Invoke(modificarTextotxtBitacora, 
                            new object[] { $"Error al verificar disponibilidad: {ex.Message}" });
                    }
                    break;

                case "AgregarVenta":
                    try
                    {
                        var jsonVenta = JsonConvert.SerializeObject(entidad);
                        var venta = JsonConvert.DeserializeObject<Venta>(jsonVenta);
                        AgregarVenta(venta, ref servidorStreamWriter);
                    }
                    catch (Exception ex)
                    {
                        EnviarRespuesta($"ERROR: {ex.Message}", ref servidorStreamWriter);
                        txtBitacora.Invoke(modificarTextotxtBitacora, 
                            new object[] { $"Error al agregar venta: {ex.Message}" });
                    }
                    break;

                case "Desconectar":
                    Desconectar((string)entidad);
                    // var entidadAutor= JsonConvert.DeserializeObject<Autor>(JsonConvert.SerializeObject(entidad));
                    break;
                default:
                    //Manejar el método desconocido si es necesario
                    break;
            }
        }
        private void ObtenerCliente(ref StreamWriter servidorStreamWriter)
        {
            try
            {
                // Obtener la lista de clientes desde la lógica de negocio
                List<Cliente> clientes = new List<Cliente>();
                clientes = logicaCliente.ObtenerClientes();
                // Serializar la lista de clientes a JSON y enviarla al cliente
                EnviarRespuesta(JsonConvert.SerializeObject(cliente), ref servidorStreamWriter);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible obtener los datos correctamente.", ex.Message);
            }
        }
        private void EnviarRespuesta(string respuesta, ref StreamWriter servidorStreamWriter)
        {
            try
            {
                
                servidorStreamWriter.WriteLine(respuesta);
                servidorStreamWriter.Flush();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible enviar los datos correctamente.", ex.Message);
            }
        }

        private void ObtenerVentasCliente(string identificacionCliente, ref StreamWriter servidorStreamWriter)
        {
            try
            {
                var todasLasVentas = logicaVenta.ObtenerVentas();
                var ventasCliente = todasLasVentas
                    .Where(v => v.Cliente != null && 
                                string.Equals(v.Cliente.Identificacion, identificacionCliente, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(v => v.FechaVenta)
                    .ToList();

                var respuesta = JsonConvert.SerializeObject(ventasCliente);
                EnviarRespuesta(respuesta, ref servidorStreamWriter);
                
                txtBitacora.Invoke(modificarTextotxtBitacora, 
                    new object[] { $"Enviadas {ventasCliente.Count} ventas del cliente {identificacionCliente}" });
            }
            catch (Exception ex)
            {
                EnviarRespuesta("[]", ref servidorStreamWriter);
                MessageBox.Show($"Error al obtener ventas del cliente: {ex.Message}", "Error");
            }
        }

        private void ObtenerClientePorIdentificacion(string identificacion, ref StreamWriter servidorStreamWriter)
        {
            try
            {
                var clientes = logicaCliente.ObtenerClientes();
                var cliente = clientes.FirstOrDefault(c => 
                    string.Equals(c.Identificacion, identificacion, StringComparison.OrdinalIgnoreCase));

                if (cliente != null)
                {
                    var respuesta = JsonConvert.SerializeObject(cliente);
                    EnviarRespuesta(respuesta, ref servidorStreamWriter);
                    txtBitacora.Invoke(modificarTextotxtBitacora, 
                        new object[] { $"Cliente encontrado: {cliente.Nombre} {cliente.Apellido}" });
                }
                else
                {
                    EnviarRespuesta("null", ref servidorStreamWriter);
                    txtBitacora.Invoke(modificarTextotxtBitacora, 
                        new object[] { $"Cliente no encontrado: {identificacion}" });
                }
            }
            catch (Exception ex)
            {
                EnviarRespuesta("null", ref servidorStreamWriter);
                MessageBox.Show($"Error al obtener cliente: {ex.Message}", "Error");
            }
        }

        private void ObtenerPartidos(ref StreamWriter servidorStreamWriter)
        {
            try
            {
                var partidos = logicaPartido.ObtenerPartidos()
                    .Where(p => p.Activo)
                    .ToList();
                var respuesta = JsonConvert.SerializeObject(partidos);
                EnviarRespuesta(respuesta, ref servidorStreamWriter);
                txtBitacora.Invoke(modificarTextotxtBitacora, 
                    new object[] { $"Enviados {partidos.Count} partidos activos" });
            }
            catch (Exception ex)
            {
                EnviarRespuesta("[]", ref servidorStreamWriter);
                MessageBox.Show($"Error al obtener partidos: {ex.Message}", "Error");
            }
        }

        private void ObtenerLocalidades(ref StreamWriter servidorStreamWriter)
        {
            try
            {
                var localidades = logicaLocalidad.ObtenerLocalidades().ToList();
                var respuesta = JsonConvert.SerializeObject(localidades);
                EnviarRespuesta(respuesta, ref servidorStreamWriter);
                txtBitacora.Invoke(modificarTextotxtBitacora, 
                    new object[] { $"Enviadas {localidades.Count} localidades" });
            }
            catch (Exception ex)
            {
                EnviarRespuesta("[]", ref servidorStreamWriter);
                MessageBox.Show($"Error al obtener localidades: {ex.Message}", "Error");
            }
        }

        private void VerificarDisponibilidad(int idPartido, int idLocalidad, int cantidad, ref StreamWriter servidorStreamWriter)
        {
            try
            {
                var localidadesPartido = logicaLocalidadPartido.ObtenerRegistros();
                var localidadPartido = localidadesPartido.FirstOrDefault(lp => 
                    lp.Partido.IdPartido == idPartido && lp.Localidad.IdLocalidad == idLocalidad);

                if (localidadPartido != null && localidadPartido.CantidadDisponible >= cantidad)
                {
                    var resultado = new
                    {
                        disponible = true,
                        cantidadDisponible = localidadPartido.CantidadDisponible,
                        precio = localidadPartido.Localidad.Precio
                    };
                    EnviarRespuesta(JsonConvert.SerializeObject(resultado), ref servidorStreamWriter);
                }
                else
                {
                    var resultado = new
                    {
                        disponible = false,
                        cantidadDisponible = localidadPartido?.CantidadDisponible ?? 0,
                        precio = localidadPartido?.Localidad.Precio ?? 0
                    };
                    EnviarRespuesta(JsonConvert.SerializeObject(resultado), ref servidorStreamWriter);
                }
            }
            catch (Exception ex)
            {
                var resultado = new { disponible = false, cantidadDisponible = 0, precio = 0 };
                EnviarRespuesta(JsonConvert.SerializeObject(resultado), ref servidorStreamWriter);
                MessageBox.Show($"Error al verificar disponibilidad: {ex.Message}", "Error");
            }
        }

        private void AgregarVenta(Venta venta, ref StreamWriter servidorStreamWriter)
        {
            try
            {
                // Buscar el cliente real por su identificación
                var clientes = logicaCliente.ObtenerClientes();
                var clienteReal = clientes.FirstOrDefault(c => 
                    string.Equals(c.Identificacion, venta.Cliente.Identificacion, StringComparison.OrdinalIgnoreCase));

                if (clienteReal == null)
                {
                    EnviarRespuesta("ERROR: Cliente no encontrado", ref servidorStreamWriter);
                    return;
                }

                // Buscar el partido real
                var partidos = logicaPartido.ObtenerPartidos();
                var partidoReal = partidos.FirstOrDefault(p => p.IdPartido == venta.Partido.IdPartido);

                if (partidoReal == null)
                {
                    EnviarRespuesta("ERROR: Partido no encontrado", ref servidorStreamWriter);
                    return;
                }

                // Buscar la localidad real
                var localidades = logicaLocalidad.ObtenerLocalidades();
                var localidadReal = localidades.FirstOrDefault(l => l.IdLocalidad == venta.Localidad.IdLocalidad);

                if (localidadReal == null)
                {
                    EnviarRespuesta("ERROR: Localidad no encontrada", ref servidorStreamWriter);
                    return;
                }

                // Obtener el siguiente ID de venta (auto-incremental)
                var ventasExistentes = logicaVenta.ObtenerVentas();
                int nuevoIdVenta = ventasExistentes.Length > 0 ? ventasExistentes.Max(v => v.IdVenta) + 1 : 1;

                // Crear la venta con los datos completos
                var ventaCompleta = new Venta(
                    nuevoIdVenta,
                    clienteReal,
                    partidoReal,
                    localidadReal,
                    venta.Cantidad,
                    null, // Sin vendedor para ventas en línea
                    venta.FechaVenta,
                    venta.MontoTotal,
                    venta.TipoVenta
                );

                // Validar y agregar la venta usando la lógica de negocio
                logicaVenta.AgregarVenta(ventaCompleta);
                
                EnviarRespuesta("OK", ref servidorStreamWriter);
                txtBitacora.Invoke(modificarTextotxtBitacora, 
                    new object[] { $"Venta agregada exitosamente: Cliente {clienteReal.Identificacion}, Partido {partidoReal.Rival}, Monto: ₡{venta.MontoTotal:N2}" });
            }
            catch (Exception ex)
            {
                EnviarRespuesta($"ERROR: {ex.Message}", ref servidorStreamWriter);
                txtBitacora.Invoke(modificarTextotxtBitacora, 
                    new object[] { $"Error al agregar venta: {ex.Message}" });
            }
        }

        private void Conectar(string pIdentificadorCliente)
       { 
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] { pIdentificadorCliente + " se ha conectado..." });
            LstClientesConectados.Invoke(modificarListBoxClientes, new object[] { pIdentificadorCliente, true });
        }
        private void Desconectar(string pIdentificadorCliente)
        {
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] { pIdentificadorCliente + " se ha desconectado..." });
            LstClientesConectados.Invoke(modificarListBoxClientes, new object[] { pIdentificadorCliente, false });
        }


        private void ModificarListBox (string texto, bool agregar)
        {
            if (agregar)
               LstClientesConectados.Items.Add(texto); 
           
            else
               LstClientesConectados.Items.Remove(texto);

        }
        private void EcribirEnTextBox(string texto)
        {
           txtBitacora.AppendText(DateTime.Now.ToString() + " - " + texto);
           txtBitacora.AppendText(Environment.NewLine);
        }


        private void BtnAdministracion_Click(object sender, EventArgs e)
        {
            PantallaPrincipal pantallaPrincipal = new PantallaPrincipal();
            pantallaPrincipal.Show();
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            comunicacionTCP.IniciarServidor();
            LabelEstado.Text = "Servidor iniciado";
            LabelEstado.ForeColor = Color.Green;
            btnDetener.Enabled = true;
            btnIniciar.Enabled = false;
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            comunicacionTCP.DetenerServidor();
            LabelEstado.Text = "Servidor detenido";
            LabelEstado.ForeColor = Color.Red;
            btnIniciar.Enabled = true;
            btnDetener.Enabled = false;
        }
    }
}
