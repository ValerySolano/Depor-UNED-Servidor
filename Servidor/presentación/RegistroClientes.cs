/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class RegistroClientes : Form
    {
        // Instancia de la lógica de negocio para operar con clientes
        private LogicaCliente logicaCliente;

        // Constructor: inicializa componentes de la UI y la lógica de negocio
        public RegistroClientes()
        {
            // Inicializa los controles y el diseño del formulario.
            InitializeComponent();

            // Crear la capa de lógica que se encargará de validaciones y persistencia
            logicaCliente = new LogicaCliente();
        }

        // Evento Load: preparar la UI al cargar el formulario
        private void RegistroClientes_Load(object sender, EventArgs e)
        {
            // Limpiar campos para empezar con formulario vacío
            ClearFields();
        }

        // Maneja el botón Nuevo: limpia los campos y pone el foco
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            // Restablecer los controles a sus valores por defecto
            ClearFields();
            // Colocar el foco en el primer campo para una nueva entrada
            textBox1.Focus();
        }

        // Maneja el botón Guardar: crea el objeto Cliente, valida y persiste
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

                // Delegar a la lógica de negocio la validación y el agregado
                logicaCliente.AgregarCliente(cliente);

                // Informar al usuario y limpiar los campos para la próxima entrada
                MessageBox.Show(cliente.MostrarDatos() + "\n guardado correctamente.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Mostrar mensajes de validación específicos cuando se detecten tipos de datos inválidos
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                // Mostrar mensajes cuando hay problemas con identificadores (ids duplicados o inválidos)
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Capturar cualquier otro error inesperado y mostrar al usuario
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Maneja el botón Limpiar: restablece los controles
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Reutilizar el método que normaliza todos los controles
            ClearFields();
        }

        // Maneja el botón Salir: cierra el formulario actual
        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Cerrar la ventana de registro y liberar recursos
            this.Close();
        }

        // Método auxiliar: pone todos los controles en sus valores por defecto
        private void ClearFields()
        {
            // Identificador vacío
            textBox1.Text = string.Empty;
            // Identificación del cliente vacía
            textBoxIdentificacion.Text = string.Empty;
            // Nombre y apellido vacíos
            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;
            // Inicializar fechas al día de hoy
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

