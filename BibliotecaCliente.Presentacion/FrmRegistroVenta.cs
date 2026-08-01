using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Entidades;

namespace BibliotecaCliente.Presentacion
{
    public partial class FrmRegistroVenta : Form
    {
        private List<Partido> partidos;
        private List<Localidad> localidades;
        private string identificacionCliente;

        public FrmRegistroVenta()
        {
            InitializeComponent();
            this.Load += FrmRegistroVenta_Load;
        }

        public FrmRegistroVenta(string pIdentificacionCliente) : this()
        {
            identificacionCliente = pIdentificacionCliente;
        }

        private void FrmRegistroVenta_Load(object sender, EventArgs e)
        {
            CargarPartidos();
            CargarLocalidades();
            OcultarResumen();
        }

        private void CargarPartidos()
        {
            try
            {
                partidos = ClienteTCP.ObtenerPartidos();
                comboPartido.Items.Clear();
                comboPartido.Items.Add("Seleccione partido");
                
                if (partidos != null && partidos.Count > 0)
                {
                    foreach (var partido in partidos)
                    {
                        comboPartido.Items.Add($"{partido.Rival} - {partido.Fecha:dd/MM/yyyy} {partido.Hora}");
                    }
                }
                comboPartido.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los partidos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarLocalidades()
        {
            try
            {
                localidades = ClienteTCP.ObtenerLocalidades();
                comboLocalidad.Items.Clear();
                comboLocalidad.Items.Add("Seleccione localidad");
                
                if (localidades != null && localidades.Count > 0)
                {
                    foreach (var localidad in localidades)
                    {
                        comboLocalidad.Items.Add(localidad.NombreLocalidad);
                    }
                }
                comboLocalidad.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las localidades: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OcultarResumen()
        {
            panel3.Visible = false;
        }

        private void MostrarResumen()
        {
            panel3.Visible = true;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar selecciones
                if (comboPartido.SelectedIndex <= 0)
                {
                    MessageBox.Show("Por favor seleccione un partido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (comboLocalidad.SelectedIndex <= 0)
                {
                    MessageBox.Show("Por favor seleccione una localidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show("Por favor ingrese la cantidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    MessageBox.Show("Por favor ingrese una cantidad válida mayor a 0.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Obtener partido y localidad seleccionados
                var partidoSeleccionado = partidos[comboPartido.SelectedIndex - 1];
                var localidadSeleccionada = localidades[comboLocalidad.SelectedIndex - 1];

                // Verificar disponibilidad
                var resultado = ClienteTCP.VerificarDisponibilidad(
                    partidoSeleccionado.IdPartido,
                    localidadSeleccionada.IdLocalidad,
                    cantidad);

                bool disponible = resultado.disponible;
                int cantidadDisponible = resultado.cantidadDisponible;
                decimal precio = resultado.precio;

                if (!disponible)
                {
                    MessageBox.Show($"No hay suficientes localidades disponibles. Cantidad disponible: {cantidadDisponible}", 
                        "Disponibilidad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calcular total
                decimal total = precio * cantidad;

                // Mostrar resumen
                labelCantidad.Text = cantidad.ToString();
                labelPrecio.Text = $"₡{precio:N2}";
                labelTotal.Text = $"₡{total:N2}";
                MostrarResumen();

                MessageBox.Show("Cálculo realizado correctamente. Revise el resumen y presione Guardar para confirmar.", 
                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!panel3.Visible)
                {
                    MessageBox.Show("Por favor primero calcule la venta presionando el botón Calcular.", 
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Aquí iría la lógica para guardar la venta
                MessageBox.Show("La funcionalidad de guardar será implementada cuando se configure el método TCP en el servidor.", 
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            comboPartido.SelectedIndex = 0;
            comboLocalidad.SelectedIndex = 0;
            txtCantidad.Clear();
            labelCantidad.Text = "";
            labelPrecio.Text = "";
            labelTotal.Text = "";
            OcultarResumen();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
