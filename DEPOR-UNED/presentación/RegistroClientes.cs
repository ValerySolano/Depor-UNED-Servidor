/*
* UNED - Programaci�n Avanzada
* Proyecto#1 Sistema de administraci�n de partidos de f�tbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentaci�n
{
    public partial class RegistroClientes : Form
    {
        // Instancia de la l�gica de negocio para operar con clientes
        private LogicaCliente logicaCliente;

        // Constructor: inicializa componentes de la UI y la l�gica de negocio
        public RegistroClientes()
        {
            // Inicializa los controles y el dise�o del formulario.
            InitializeComponent();

            // Crear la capa de l�gica que se encargar� de validaciones y persistencia
            logicaCliente = new LogicaCliente();
        }

        // Evento Load: preparar la UI al cargar el formulario
        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            // Limpiar campos para empezar con formulario vac�o
            ClearFields();
        }

        // Maneja el bot�n Nuevo: limpia los campos y pone el foco
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Restablecer los controles a sus valores por defecto
            ClearFields();
            // Colocar el foco en el primer campo para una nueva entrada
            textBox1.Focus();
        }

        // Maneja el bot�n Guardar: crea el objeto Cliente, valida y persiste
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Intentar obtener el Id ingresado; si falla queda en 0
                int idCliente = 0;
                int.TryParse(textBox1.Text?.Trim(), out idCliente);

                // Construir el objeto Cliente con los valores del formulario
                Cliente cliente = new Cliente(
                    idCliente,
                    textBoxIdentificacion.Text?.Trim(),
                    textBoxNombre.Text?.Trim(),
                    textBoxApellido.Text?.Trim(),
                    dateTimePickerNacimiento.Value.Date,
                    dateTimePickerRegistro.Value.Date,
                    checkBoxActivo.Checked
                );

                // Delegar a la l�gica de negocio la validaci�n y el agregado
                logicaCliente.AgregarCliente(cliente);

                // Informar al usuario y limpiar los campos para la pr�xima entrada
                MessageBox.Show(cliente.MostrarDatos() + "\n guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Mostrar mensajes de validaci�n espec�ficos cuando se detecten tipos de datos inv�lidos
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                // Mostrar mensajes cuando hay problemas con identificadores (ids duplicados o inv�lidos)
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado y mostrar al usuario
                MessageBox.Show(ex.Message, "Validaci�n", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Maneja el bot�n Limpiar: restablece los controles
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Reutilizar el m�todo que normaliza todos los controles
            ClearFields();
        }

        // Maneja el bot�n Salir: cierra el formulario actual
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana de registro y liberar recursos
            this.Close();
        }

        // M�todo auxiliar: pone todos los controles en sus valores por defecto
        private void ClearFields()
        {
            // Identificador vac�o
            textBox1.Text = string.Empty;
            // Identificaci�n del cliente vac�a
            textBoxIdentificacion.Text = string.Empty;
            // Nombre y apellido vac�os
            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;
            // Inicializar fechas al d�a de hoy
            if (dateTimePickerNacimiento != null) dateTimePickerNacimiento.Value = DateTime.Today;
            if (dateTimePickerRegistro != null) dateTimePickerRegistro.Value = DateTime.Today;
            // Marcar el cliente como activo por defecto
            if (checkBoxActivo != null) checkBoxActivo.Checked = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

