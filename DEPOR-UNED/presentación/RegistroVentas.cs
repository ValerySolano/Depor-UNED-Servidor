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
    public partial class RegistroVentas : Form
    {
        // Instancias de las capas de lógica de negocio utilizadas por el formulario.
        private LogicaCliente logicaCliente;
        private LogicaPartido logicaPartido;
        private LogicaLocalidadPartido logicaLocalidadPartido;
        private LogicaLocalidad logicaLocalidad;
        private LogicaVendedor logicaVendedor;
        private LogicaVenta logicaVenta;

        // Constructor del formulario. Inicializa componentes y crea las instancias de la lógica de negocio.
        public RegistroVentas()
        {
            // Inicializa los controles y el diseño del formulario.
            InitializeComponent();

            // Inicializa las instancias de las lógicas que se utilizarán en los métodos del formulario.
            logicaCliente = new LogicaCliente();
            logicaPartido = new LogicaPartido();
            logicaLocalidadPartido = new LogicaLocalidadPartido();
            logicaLocalidad = new LogicaLocalidad();
            logicaVendedor = new LogicaVendedor();
            logicaVenta = new LogicaVenta();
        }

        // Maneja la carga inicial del formulario o control RegistroVentas.
        private void RegistroVentas_Load(object? sender, EventArgs e)
        {
            CargarCombos();
        }

        // Carga los datos necesarios en los ComboBox del formulario (clientes, partidos, vendedores).
        private void CargarCombos()
        {
            try
            {
                // Clientes: se crea una lista anónima con Id y Texto (Nombre Apellido) para mostrar en el ComboBox.
                var clientes = logicaCliente.ObtenerClientes();
                comboCliente.DataSource = clientes.Select(c => new { Id = c.IdCliente, Texto = c.Nombre + " " + c.Apellido }).ToList();
                comboCliente.DisplayMember = "Texto";
                comboCliente.ValueMember = "Id";
                // No seleccionar ningún elemento por defecto.
                comboCliente.SelectedIndex = -1;

                // Partidos: se enlaza directamente el arreglo de Partido para mostrar el campo Rival.
                var partidos = logicaPartido.ObtenerPartidos();
                comboPartido.DataSource = partidos;
                comboPartido.DisplayMember = "Rival";
                comboPartido.ValueMember = "IdPartido";
                comboPartido.SelectedIndex = -1;

                // Vendedores: lista anónima similar a clientes para mostrar Nombre Apellido.
                var vendedores = logicaVendedor.ObtenerVendedores();
                comboVendedor.DataSource = vendedores.Select(v => new { Id = v.IdVendedor, Texto = v.Nombre + " " + v.Apellido }).ToList();
                comboVendedor.DisplayMember = "Texto";
                comboVendedor.ValueMember = "Id";
                comboVendedor.SelectedIndex = -1;

                // Localidades se carga dinámicamente al seleccionar un partido, por eso inicialmente queda vacío.
                comboLocalidad.DataSource = null;
            }
            catch (Exception ex)
            {
                // Muestra cualquier error ocurrido durante la carga de datos.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maneja el evento SelectedIndexChanged del Combo de partidos.
        // Dispara la recarga de localidades asociadas al partido seleccionado.
        private void ComboPartido_SelectedIndexChanged(object? sender, EventArgs e)
        {
            CargarLocalidadesPorPartido();
        }

        // Carga las localidades disponibles para el partido actualmente seleccionado.
        private void CargarLocalidadesPorPartido()
        {
            try
            {
                // Limpia el origen de datos antes de poblarlo.
                comboLocalidad.DataSource = null;

                // Si no hay partido seleccionado, nada que hacer.
                if (comboPartido.SelectedItem == null) return;

                // El SelectedItem es una instancia de Partido cuando el DataSource es un arreglo de Partido.
                Partido partidoSeleccionado = comboPartido.SelectedItem as Partido;
                if (partidoSeleccionado == null) return;

                // Obtiene todos los registros LocalidadPartido y cuenta cuántos pertenecen al partido.
                LocalidadPartido[] registros = logicaLocalidadPartido.ObtenerRegistros();
                int contadorLocalidades = logicaLocalidadPartido.contarLocalidadesEnPartido(partidoSeleccionado.IdPartido);

                // Crea un arreglo del tamaño exacto y copia las entradas que coinciden con el partido.
                LocalidadPartido[] localidadesParaPartido = new LocalidadPartido[contadorLocalidades];
                int indice = 0;
                foreach (LocalidadPartido registro in registros)
                {
                    if (registro.Partido != null && registro.Partido.IdPartido == partidoSeleccionado.IdPartido)
                    {
                        localidadesParaPartido[indice] = registro;
                        indice++;
                    }
                }

                // Extrae las entidades Localidad desde LocalidadPartido para que el ComboBox tenga items del tipo Localidad.
                var localidades = localidadesParaPartido
                    .Where(lp => lp != null && lp.Localidad != null)
                    .Select(lp => lp.Localidad)
                    .ToArray();

                // Enlaza el ComboBox con las localidades disponibles para el partido.
                comboLocalidad.DataSource = localidades;
                comboLocalidad.DisplayMember = "NombreLocalidad";
                comboLocalidad.ValueMember = "IdLocalidad";
                comboLocalidad.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                // Muestra cualquier error ocurrido durante el proceso.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Calcula el monto total usando el precio de la localidad seleccionada y la cantidad ingresada.
        private void BtnCalcular_Click(object? sender, EventArgs e)
        {
            try
            {
                // Verifica que se haya seleccionado una localidad.
                if (comboLocalidad.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una localidad para calcular el monto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Intenta parsear la cantidad ingresada; debe ser un entero positivo.
                if (!int.TryParse(textBoxCantidad?.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtiene la localidad seleccionada del ComboBox.
                Localidad localidad = comboLocalidad.SelectedItem as Localidad;
                if (localidad == null)
                {
                    MessageBox.Show("Localidad inválida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcula el total y lo muestra en la etiqueta correspondiente.
                decimal precioUnitario = localidad.Precio;
                decimal total = cantidad * precioUnitario;
                labelMonto.Text = total.ToString("0.00");
            }
            catch (Exception ex)
            {
                // Muestra errores inesperados.
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Valida los datos del formulario y crea una instancia de Venta para guardarla.
        private void BtnGuardar_Click(object? sender, EventArgs e)
        {
            try
            {
                // Validar y parsear el Id de venta.
                string idText = textBoxId.Text == null ? string.Empty : textBoxId.Text.Trim();
                if (!int.TryParse(idText, out int idVenta) || idVenta <= 0)
                {
                    MessageBox.Show("Id de venta inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica que se haya seleccionado un cliente.
                if (comboCliente.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Obtiene el cliente seleccionado a partir del value del ComboBox.
                int idCliente = (int)comboCliente.SelectedValue;
                var cliente = logicaCliente.ObtenerCliente(idCliente);

                // Verifica que se haya seleccionado un partido.
                if (comboPartido.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione un partido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var partido = comboPartido.SelectedItem as Partido;

                // Verifica que se haya seleccionado una localidad.
                if (comboLocalidad.SelectedItem == null)
                {
                    MessageBox.Show("Seleccione una localidad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var localidad = comboLocalidad.SelectedItem as Localidad;

                // Valida la cantidad ingresada.
                if (!int.TryParse(textBoxCantidad?.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Verifica selección de vendedor y obtiene la instancia correspondiente.
                if (comboVendedor.SelectedValue == null)
                {
                    MessageBox.Show("Seleccione un vendedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int idVendedor = (int)comboVendedor.SelectedValue;
                var vendedor = logicaVendedor.ObtenerVendedores().FirstOrDefault(v => v.IdVendedor == idVendedor);
                if (vendedor == null)
                {
                    MessageBox.Show("Vendedor inválido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Calcula el monto total si existe la localidad seleccionada.
                decimal montoTotal = 0m;
                if (localidad != null)
                {
                    montoTotal = localidad.Precio * cantidad;
                }

                // Obtiene la fecha de venta desde el control de fecha.
                DateTime fechaVenta = dateTimePickerVenta.Value.Date;

                // Crea la entidad Venta con la información recopilada.
                Venta venta = new Venta(idVenta, cliente, partido, localidad, cantidad, vendedor, fechaVenta, montoTotal, "Boletería");

                // Llama a la lógica de negocio para validar y guardar la venta.
                logicaVenta.AgregarVenta(venta);

                // Informa al usuario y limpia el formulario.
                MessageBox.Show("Venta registrada.", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields();
            }
            catch (TipoDatoInvalidoException ex)
            {
                // Muestra mensajes de validación específicos.
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (IdentificadorException ex)
            {
                MessageBox.Show(ex.MensajePersonalizado ?? ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Maneja condiciones donde la operación no puede ejecutarse (ej. límites alcanzados).
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
            // Limpia todos los controles del formulario para una nueva entrada.
            ClearFields();
        }

        // Maneja el evento Click del control BtnSalir.
        private void BtnSalir_Click(object? sender, EventArgs e)
        {
            // Cierra el formulario actual.
            this.Close();
        }

        // Restaura los controles del formulario a sus valores por defecto.
        private void ClearFields()
        {
            // Limpia el campo de Id si existe.
            if (textBoxId != null) textBoxId.Text = string.Empty;

            // Selecciona el primer elemento de los ComboBoxes si están inicializados.
            if (comboCliente != null) comboCliente.SelectedIndex = 0;
            if (comboPartido != null) comboPartido.SelectedIndex = 0;
            if (comboLocalidad != null) comboLocalidad.SelectedIndex = 0;

            // Limpia la cantidad y resetea el vendedor seleccionado.
            if (textBoxCantidad != null) textBoxCantidad.Text = string.Empty;
            if (comboVendedor != null) comboVendedor.SelectedIndex = 0;

            // Restablece la fecha de venta a la fecha actual.
            if (dateTimePickerVenta != null) dateTimePickerVenta.Value = DateTime.Today;

            // Resetea la etiqueta de monto a cero.
            if (labelMonto != null) labelMonto.Text = "0.00";
        }
    }
}

