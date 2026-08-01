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
        private readonly NegocioComunicacionTCP comunicacionTCP = new NegocioComunicacionTCP();
        private readonly LogicaCliente logicaCliente = new LogicaCliente();
        private readonly LogicaVenta logicaVenta = new LogicaVenta();
        private readonly LogicaPartido logicaPartido = new LogicaPartido();
        private readonly LogicaLocalidad logicaLocalidad = new LogicaLocalidad();
        private readonly LogicaLocalidadPartido logicaLocalidadPartido = new LogicaLocalidadPartido();

        private delegate void EscribirEnTextBoxDelegate(string texto);
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
        private void ComunicacionTCP_MensajeRecibido(object sender, (string mensaje, StreamWriter streamWriter) e) {
            // Maneja el mensaje recibido 
            try
            {
                var mensajeRecibido = JsonConvert.DeserializeObject<MensajeSocket<object>>(e.mensaje);
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
                case "Conectar":
                    Conectar((string) entidad);
                    break;
                case "ConsultarCliente":
                    var entidadCliente = JsonConvert.DeserializeObject<Cliente>(JsonConvert.SerializeObject(entidad));
                    logicaCliente.AgregarCliente(entidadCliente);
                    break;
                case "ValidarIdentificacion":
                    var identificacionCliente = (string)entidad;
                    var clienteEncontrado = logicaCliente.ObtenerClientes()
                        .FirstOrDefault(cliente => cliente.Identificacion == identificacionCliente);
                    
                    if (clienteEncontrado == null)
                    {
                        EnviarRespuesta("NOEXISTE", ref servidorStreamWriter);
                    }
                    else if (!clienteEncontrado.Activo)
                    {
                        EnviarRespuesta("INACTIVO", ref servidorStreamWriter);
                    }
                    else
                    {
                        EnviarRespuesta("VALIDO", ref servidorStreamWriter);
                    }
                    break;

                case "ObtenerVentasCliente":
                    var identificacionVentas = (string)entidad;
                    ObtenerVentasCliente(identificacionVentas, ref servidorStreamWriter);
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
                List<Cliente> clientes = new List<Cliente>();
                clientes = logicaCliente.ObtenerClientes();
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
        private void Conectar(string pIdentificadorCliente)
       { 
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] { pIdentificadorCliente + "se ha conectado..." });
            LstClientesConectados.Invoke(modificarListBoxClientes, new object[] { pIdentificadorCliente, true });
        }
        private void Desconectar(string pIdentificadorCliente)
        {
            txtBitacora.Invoke(modificarTextotxtBitacora, new object[] { pIdentificadorCliente + "se ha desconectado..." });
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
