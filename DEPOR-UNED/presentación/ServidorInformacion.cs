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
            catch (System.Text.Json.JsonException)
            {
                MessageBox.Show("No fue posible convertit el objeto.");
                // Manejar el error de deserialización JSON si es necesario
            }
            catch (Exception ex)
            {
                MessageBox.Show("No fue posible guardar los datos correctamente.", ex.Message);
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
