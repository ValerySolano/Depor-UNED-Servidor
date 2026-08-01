/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class RegistroLocalidades : Form
    {
        // Instancia de la capa de lógica de negocio para operaciones con localidades.
        private LogicaLocalidad logicaLocalidad;

        // Constructor del formulario.
        // Inicializa los componentes visuales y la lógica necesaria para el formulario.
        public RegistroLocalidades()
        {
            // Inicializa los controles creados por el diseñador (textboxes, botones, etc.).
            InitializeComponent();

            // Crear la instancia de la lógica de negocio que maneja las localidades.
            logicaLocalidad = new LogicaLocalidad();

            // Vincular los eventos Click de los botones a sus métodos manejadores.
            btnGuardar.Click += BtnGuardar_Click;
            btnLimpiar.Click += BtnLimpiar_Click;
            btnSalir.Click += BtnSalir_Click;
        }

        // Manejador del evento Click para el botón Guardar.
        // Lee los valores del formulario, construye la entidad y la guarda mediante la lógica.
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Leer el texto del campo Id y del nombre
                string idText = textBoxId.Text;
                string nombre = textBoxNombre.Text;

                // Leer el valor numérico del control para el precio
                decimal precio = numericPrecio.Value;

                // Parsear el identificador a entero; usar 0 si no se puede convertir
                int id = 0;
                if (!int.TryParse(idText?.Trim(), out id))
                {
                    // Si el parse falla, id queda en 0 (valor por defecto)
                    id = 0;
                }

                // Crear la entidad Localidad con los valores obtenidos del formulario
                Localidad localidad = new Localidad(id, nombre, precio);

                // Delegar a la lógica de negocio la validación y el almacenamiento
                logicaLocalidad.AgregarLocalidad(localidad);

                // Informar al usuario del éxito de la operación
                MessageBox.Show("Localidad registrada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos para una nueva entrada
                LimpiarCampos();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Mostrar mensaje específico cuando hay datos con formato o tipo inválido
                MessageBox.Show(ex.MensajePersonalizado ?? "Tipo de dato inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IdentificadorException ex)
            {
                // Mostrar mensaje cuando el identificador está duplicado o es inválido
                MessageBox.Show(ex.MensajePersonalizado ?? "Error de identificador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException ex)
            {
                // Tratar excepciones por operaciones inválidas (por ejemplo, límite de almacenamiento)
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Capturar y mostrar cualquier otra excepción inesperada
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejador del evento Click para el botón Limpiar.
        // Reutiliza el método que restablece los controles a sus valores por defecto.
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            LimpiarCampos();
        }

        // Manejador del evento Click para el botón Salir.
        // Cierra el formulario actual.
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            Close();
        }

        // Restablece los campos del formulario a valores iniciales o vacíos.
        private void LimpiarCampos()
        {
            // Vaciar el campo de identificador
            textBoxId.Text = string.Empty;

            // Vaciar el campo de nombre
            textBoxNombre.Text = string.Empty;

            // Poner el precio en cero
            numericPrecio.Value = 0;
        }
    }
}

