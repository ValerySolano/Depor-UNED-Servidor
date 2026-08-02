/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 1/08/2026
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;

namespace BibliotecaCliente.Presentacion
{
    public partial class FrmPanelCliente : Form
    {
        private readonly string identificacionCliente;

        public FrmPanelCliente() : this(string.Empty)
        {
        }

        public FrmPanelCliente(string identificacionCliente)
        {
            InitializeComponent();
            this.identificacionCliente = identificacionCliente ?? string.Empty;
            // Metodo para cargar el nombre del cliente en el labelUser al mostrar el la pantalla del panel del cliente
            CargarNombreCliente();
            this.FormClosing += FrmPanelCliente_FormClosing;

            // Cargar las ventas del cliente al abrir el panel
            CargarVentasCliente();
        }

        private void FrmPanelCliente_FormClosing(object sender, FormClosingEventArgs e)
        {   
            // Desconectar al cliente del servidor al cerrar el formulario
            if (!string.IsNullOrWhiteSpace(identificacionCliente))
            {
                // LLamar al método Desconectar del ClienteTCP para cerrar la conexión con el servidor
                ClienteTCP.Desconectar(identificacionCliente);
            }
        }

        // Método para cargar el nombre del cliente en el labelUser
        private void CargarNombreCliente()
        {
            try
            {   
                // Validar que la identificación del cliente no esté vacía antes de intentar obtener el nombre
                if (string.IsNullOrWhiteSpace(identificacionCliente))
                {
                    labelUser.Text = "Usuario";
                    return;
                }
                
                // Llamar al método ObtenerClientePorIdentificacion del ClienteTCP para obtener la información del cliente
                var cliente = ClienteTCP.ObtenerClientePorIdentificacion(identificacionCliente);
                
                if (cliente != null)
                {
                    // Formatear el nombre completo del cliente y asignarlo al labelUser
                    labelUser.Text = $"{cliente.Nombre} {cliente.Apellido}".Trim();
                }
                else
                {
                    // Si no se encuentra el cliente, mostrar un mensaje de error y asignar un valor predeterminado al labelUser
                    labelUser.Text = identificacionCliente;
                }
            }
            catch (Exception)
            {
                labelUser.Text = identificacionCliente;
            }
        }

        // Método para cargar las ventas del cliente en el DataGridView
        private void CargarVentasCliente()
        {
            try
            {   
                // Validar que la identificación del cliente no esté vacía antes de intentar obtener las ventas
                if (string.IsNullOrWhiteSpace(identificacionCliente))
                {
                    MessageBox.Show("No hay identificación de cliente válida.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Llamar al método ObtenerVentasCliente del ClienteTCP para obtener la lista de ventas del cliente
                var ventasCliente = ClienteTCP.ObtenerVentasCliente(identificacionCliente);

                dataGridCompras.Rows.Clear(); // Limpiar las filas existentes antes de agregar nuevas ventas

                foreach (var venta in ventasCliente)
                {
                    string nombreVendedor = string.Empty;
                    if (venta.Vendedor != null) // Validar que esa venta tenga un vendedor asociado antes de intentar acceder a sus propiedades
                    {
                        nombreVendedor = $"{venta.Vendedor.Nombre} {venta.Vendedor.Apellido}".Trim();
                    }

                    // Agregar la informacion al datagridview
                    dataGridCompras.Rows.Add(
                        venta.IdVenta,
                        venta.Partido?.Rival ?? string.Empty,
                        venta.Partido?.Fecha.ToShortDateString() ?? string.Empty,
                        venta.Partido?.Hora ?? string.Empty,
                        venta.Partido != null && venta.Partido.Activo ? "Activo" : "Inactivo",
                        venta.Localidad?.IdLocalidad ?? 0,
                        venta.Localidad?.NombreLocalidad ?? string.Empty,
                        nombreVendedor,
                        venta.Cantidad,
                        venta.FechaVenta.ToShortDateString(),
                        venta.TipoVenta ?? string.Empty
                    );
                }

                // Si no se encontraron ventas para el cliente, mostrar un mensaje informativo
                if (ventasCliente.Count == 0)
                {
                    MessageBox.Show("No se encontraron ventas para este cliente.", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las ventas del cliente: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNueva_Click(object sender, EventArgs e)
        {
            FrmRegistroVenta frmRegistroVenta = new FrmRegistroVenta(identificacionCliente);
            frmRegistroVenta.ShowDialog();
            // Recargar las ventas del cliente después de cerrar el formulario de registro de venta
            CargarVentasCliente();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
