/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
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
        private LogicaLocalidadPartido logicaLocalidadPartido;
        private LogicaPartido logicaPartido;
        private LogicaLocalidad logicaLocalidad;

        public LocalidadesPartido()
        {
            InitializeComponent();
            logicaLocalidadPartido = new LogicaLocalidadPartido();
            logicaPartido = new LogicaPartido();
            logicaLocalidad = new LogicaLocalidad();
        }

        private void BtnNuevo_Click(object? sender, EventArgs e)
        {
            ClearFields();
            textBoxIdRegistro.Focus();
        }

        private void LocalidadesPartido_Load(object? sender, EventArgs e)
        {
            CargarCombos();
        }

        private void CargarCombos()
        {
            try
            {
                comboPartido.DataSource = null;
                Partido[] partidos = logicaPartido.ObtenerPartidos();
                comboPartido.DisplayMember = "Rival";
                comboPartido.ValueMember = "IdPartido";
                comboPartido.DataSource = partidos;
                comboPartido.SelectedIndex = -1;

                comboLocalidad.DataSource = null;
                Localidad[] localidades = logicaLocalidad.ObtenerLocalidades();
                comboLocalidad.DisplayMember = "NombreLocalidad";
                comboLocalidad.ValueMember = "IdLocalidad";
                comboLocalidad.DataSource = localidades;
                comboLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                int id = 0;
                int.TryParse(textBoxIdRegistro.Text?.Trim(), out id);

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

                int cantidad = 0;
                int.TryParse(textBoxCantidad.Text?.Trim(), out cantidad);

                Partido partidoSeleccionado = (Partido)comboPartido.SelectedItem;
                Localidad localidadSeleccionada = (Localidad)comboLocalidad.SelectedItem;

                LocalidadPartido registro = new LocalidadPartido(id, partidoSeleccionado, localidadSeleccionada, cantidad);

                logicaLocalidadPartido.AgregarLocalidadPartido(registro);

                MessageBox.Show("Localidad asignada al partido guardada.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (TipoDatoInvalidoException ex)
            {
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Operación inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnLimpiar_Click(object? sender, EventArgs e)
        {
            ClearFields();
        }

        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void ClearFields()
        {
            if (textBoxIdRegistro != null) textBoxIdRegistro.Text = string.Empty;
            if (comboPartido != null) comboPartido.SelectedIndex = 0;
            if (dateTimePickerFecha != null) dateTimePickerFecha.Value = DateTime.Today;
            if (dateTimePickerHora != null) dateTimePickerHora.Value = DateTime.Now;
            if (comboLocalidad != null) comboLocalidad.SelectedIndex = 0;
            if (textBoxCantidad != null) textBoxCantidad.Text = string.Empty;
        }

        private void comboPartido_SelectedValueChanged(object sender, EventArgs e)
        {
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

