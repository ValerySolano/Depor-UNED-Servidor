/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using LogicaNegocios;
namespace presentación
{
    public partial class RegistroPartidos : Form
    {
        // Instancia de la capa de lógica de negocio para operaciones con partidos.
        private LogicaPartido logicaPartido;

        // Constructor del formulario. Inicializa componentes y crea la lógica de negocio.
        public RegistroPartidos()
        {
            // Inicializa los controles creados por el diseñador (textboxes, botones, etc.).
            InitializeComponent();

            // Crear la instancia de la lógica de negocio responsable de validar y guardar partidos.
            logicaPartido = new LogicaPartido();
        }

       
        // Manejador del evento Click para el botón Guardar.
        // Lee los valores de la UI, construye la entidad Partido y solicita su persistencia.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Variable para almacenar el Id proporcionado por el usuario.
                int id = 0;
                // Intentar convertir el texto ingresado a entero. Si falla, id queda en 0.
                int.TryParse(textBoxId.Text?.Trim(), out id);

                // Obtener el nombre/rival desde el control y normalizar espacios.
                string rival = textBoxNombre.Text?.Trim();

                // Obtener la fecha seleccionada (solo la parte de la fecha, sin hora).
                DateTime fecha = dateTimePickerNacimiento.Value.Date;

                // Leer el texto del control de hora tal como lo escribió el usuario.
                // De esta forma se preserva el formato ingresado (ej. "20:00").
                string hora = dateTimeHora.Text?.Trim();

                // Obtener el estado del checkbox que indica si el partido está activo.
                bool activo = checkBoxActivo.Checked;

                // Construir la entidad Partido con los valores leídos.
                Partido partido = new Partido(id, rival, fecha, hora, activo);

                // Delegar en la capa de lógica la validación y el agregado al repositorio.
                logicaPartido.AgregarPartido(partido);

                // Informar al usuario que la operación fue exitosa.
                MessageBox.Show("Partido registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar los campos para permitir ingresar un nuevo registro.
                LimpiarCampos();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Mostrar mensaje de validación específico si algún dato no cumple el formato requerido.
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                // Mostrar mensaje si hay problemas con el identificador (duplicado o inválido).
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Capturar cualquier otra excepción no prevista y notificar al usuario.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Manejador del evento Click para el botón Limpiar.
        // Reestablece los valores de los controles a sus valores por defecto.
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            // Reutilizar la rutina de limpieza para centralizar el comportamiento.
            LimpiarCampos();
        }

        // Manejador del evento Click para el botón Salir.
        // Cierra el formulario actual y devuelve el control al formulario padre.
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            // Cerrar la ventana de registro
            Close();
        }

        // Método que restaura todos los controles del formulario a su estado inicial.
        private void LimpiarCampos()
        {
            // Limpiar el campo de identificador para evitar reutilizar valores anteriores.
            textBoxId.Text = string.Empty;

            // Limpiar el nombre del rival.
            textBoxNombre.Text = string.Empty;

            // Establecer la fecha al día actual como valor por defecto.
            dateTimePickerNacimiento.Value = DateTime.Today;

            // Limpiar el texto de hora para que el usuario ingrese un nuevo valor.
            dateTimeHora.Text = string.Empty;

            // Desmarcar el checkbox de activo por defecto.
            checkBoxActivo.Checked = false;
        }
    }
}

