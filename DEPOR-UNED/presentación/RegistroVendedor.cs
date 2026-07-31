/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class RegistroVendedor : Form
    {
        // Instancia de la capa de lógica de negocio para operaciones con vendedores.
        private LogicaVendedor logicaVendedor;

        // Constructor del formulario. Inicializa componentes y crea la lógica de negocio.
        public RegistroVendedor()
        {
            // Inicializa los controles y el diseño del formulario.
            InitializeComponent();

            // Crea la instancia de la lógica de negocio para manejar vendedores.
            logicaVendedor = new LogicaVendedor();
        }

        // Maneja el evento Click del control BtnGuardar.
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Lee y normaliza el identificador ingresado por el usuario.
                int id = 0;
                int.TryParse(textBox1.Text?.Trim(), out id);

                // Construye la entidad Vendedor con los datos capturados desde la UI.
                Vendedor vendedor = new Vendedor(id, textBoxIdentificacion.Text?.Trim(), textBoxNombre.Text?.Trim(), textBoxApellido.Text?.Trim(), dateTimePickerNacimiento.Value.Date, dateTimePickerRegistro.Value.Date);

                // Llama a la lógica de negocio para validar y persistir el vendedor.
                logicaVendedor.AgregarVendedor(vendedor);

                // Notifica al usuario del éxito y limpia los campos para una nueva entrada.
                MessageBox.Show(vendedor.MostrarDatos() + "\n registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LimpiarCampos();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Muestra un mensaje específico cuando hay errores de tipo de dato en la validación.
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                // Muestra mensaje cuando hay conflicto de identificador (id duplicado, por ejemplo).
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Captura cualquier otra excepción y muestra un mensaje de error genérico.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el evento Click del control BtnLimpiar.
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            // Limpia todos los campos del formulario para permitir una nueva entrada.
            LimpiarCampos();
        }

        // Maneja el evento Click del control BtnSalir.
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            // Cierra el formulario actual.
            Close();
        }

        // Restaura los campos del formulario a sus valores por defecto.
        private void LimpiarCampos()
        {
            // Limpia los textboxes de entrada.
            textBox1.Text = string.Empty;
            textBoxIdentificacion.Text = string.Empty;
            textBoxNombre.Text = string.Empty;
            textBoxApellido.Text = string.Empty;

            // Establece las fechas a la fecha actual.
            dateTimePickerNacimiento.Value = DateTime.Today;
            dateTimePickerRegistro.Value = DateTime.Today;
        }
    }
}

