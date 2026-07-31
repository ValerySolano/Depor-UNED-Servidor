/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace presentación
{
    public partial class LocalidadesPartido : Form
    {
        // Repositorios/servicios de lógica de negocio utilizados por el formulario.
        private LogicaLocalidadPartido logicaLocalidadPartido;
        private LogicaPartido logicaPartido;
        private LogicaLocalidad logicaLocalidad;

        // Constructor del formulario. Inicializa componentes y crea instancias de las lógicas.
        public LocalidadesPartido()
        {
            // Inicializa los controles generados por el diseñador.
            InitializeComponent();

            // Crea las instancias de las clases de lógica que se usarán en los métodos del formulario.
            logicaLocalidadPartido = new LogicaLocalidadPartido();
            logicaPartido = new LogicaPartido();
            logicaLocalidad = new LogicaLocalidad();
        }

        // Maneja el evento Click del control BtnNuevo.
        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            // Limpia los campos para ingresar un nuevo registro y posiciona el foco en el Id.
            ClearFields();
            textBoxIdRegistro.Focus();
        }

        // Maneja la carga inicial del formulario o control LocalidadesPartido.
        private void LocalidadesPartido_Load(object? sender, EventArgs e)
        {
            // Carga los ComboBoxes con los datos necesarios al iniciar el formulario.
            CargarCombos();
        }

        // Carga los datos en los ComboBox: partidos y localidades.
        private void CargarCombos()
        {
            try
            {
                // Cargar partidos: limpiar origen de datos y enlazar arreglo de partidos.
                comboPartido.DataSource = null;
                Partido[] partidos = logicaPartido.ObtenerPartidos();
                comboPartido.DisplayMember = "Rival";
                comboPartido.ValueMember = "IdPartido";
                comboPartido.DataSource = partidos;
                // No seleccionar ningún elemento por defecto.
                comboPartido.SelectedIndex = -1;

                // Cargar localidades: limpiar origen y enlazar arreglo de localidades.
                comboLocalidad.DataSource = null;
                Localidad[] localidades = logicaLocalidad.ObtenerLocalidades();
                comboLocalidad.DisplayMember = "NombreLocalidad";
                comboLocalidad.ValueMember = "IdLocalidad";
                comboLocalidad.DataSource = localidades;
                comboLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Muestra cualquier error ocurrido al cargar los datos.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Valida los campos del formulario y guarda la asociación Localidad-Partido.
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Parsear el Id del registro; si falla queda en 0.
                int id = 0;
                int.TryParse(textBoxIdRegistro.Text?.Trim(), out id);

                // Validaciones básicas de selección de partido y localidad.
                if (comboPartido.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un partido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (comboLocalidad.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Parsear la cantidad disponible; valor por defecto 0 si falla.
                int cantidad = 0;
                int.TryParse(textBoxCantidad.Text?.Trim(), out cantidad);

                // Obtener las instancias seleccionadas de Partido y Localidad.
                Partido partidoSeleccionado = (Partido)comboPartido.SelectedItem;
                Localidad localidadSeleccionada = (Localidad)comboLocalidad.SelectedItem;

                // Construir el objeto LocalidadPartido con los valores recogidos.
                LocalidadPartido registro = new LocalidadPartido(id, partidoSeleccionado, localidadSeleccionada, cantidad);

                // Delegar la validación y el guardado a la lógica de negocio.
                logicaLocalidadPartido.AgregarLocalidadPartido(registro);

                // Notificar al usuario y limpiar campos.
                MessageBox.Show("Localidad asignada al partido guardada.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Mensajes de validación específicos devueltos por la lógica.
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Operaciones no permitidas por la lógica (ej. límite alcanzado).
                MessageBox.Show(ex.Message, "Operación inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Captura cualquier otro error inesperado.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el evento Click del control BtnLimpiar.
        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            // Restaura los controles a sus valores iniciales.
            ClearFields();
        }

        // Maneja el evento Click del control BtnSalir.
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            // Cierra el formulario actual.
            this.Close();
        }

        // Restaura los controles del formulario a valores por defecto para una nueva entrada.
        private void ClearFields()
        {
            // Limpia el campo de Id si está inicializado.
            if (textBoxIdRegistro != null) textBoxIdRegistro.Text = string.Empty;

            // Selecciona el primer elemento de comboboxes para evitar valores residuales.
            if (comboPartido != null) comboPartido.SelectedIndex = 0;

            // Restablece los selectores de fecha y hora a valores actuales.
            if (dateTimePickerFecha != null) dateTimePickerFecha.Value = DateTime.Today;
            if (dateTimePickerHora != null) dateTimePickerHora.Value = DateTime.Now;

            // Reinicia la selección de localidad y la cantidad.
            if (comboLocalidad != null) comboLocalidad.SelectedIndex = 0;
            if (textBoxCantidad != null) textBoxCantidad.Text = string.Empty;
        }

        private void comboPartido_SelectedValueChanged(object sender, EventArgs e)
        {

            // Opción 2: Obtener el valor directo (ideal si el ComboBox tiene ValueMember configurado)
            if (comboPartido.SelectedValue != null && comboPartido.SelectedIndex != -1)
            {
                Partido partidoSeleccionado = (Partido)comboPartido.SelectedItem;
                if(partidoSeleccionado != null)
                {
                    dateTimePickerFecha.Value = partidoSeleccionado.Fecha;
                    dateTimePickerHora.Value = DateTime.Parse(partidoSeleccionado.Hora);
                }
            }
           
        }
    }
}

