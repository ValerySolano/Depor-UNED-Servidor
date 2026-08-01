using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Entidades;
using LogicaNegocios;

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
            labelUser.Text = string.IsNullOrWhiteSpace(this.identificacionCliente)
                ? "Usuario"
                : this.identificacionCliente;

            CargarVentasCliente();
        }

        private void CargarVentasCliente()
        {
            try
            {
                var logicaVenta = new LogicaVenta();
                var ventasCliente = logicaVenta.ObtenerVentas()
                    .Where(v => v.Cliente != null &&
                                string.Equals(v.Cliente.Identificacion, identificacionCliente, StringComparison.OrdinalIgnoreCase))
                    .OrderByDescending(v => v.FechaVenta)
                    .ToList();

                dataGridView1.Rows.Clear();

                foreach (var venta in ventasCliente)
                {
                    string nombreVendedor = string.Empty;
                    if (venta.Vendedor != null)
                    {
                        nombreVendedor = $"{venta.Vendedor.Nombre} {venta.Vendedor.Apellido}".Trim();
                    }

                    dataGridView1.Rows.Add(
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
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar las ventas del cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btNueva_Click(object sender, EventArgs e)
        {
            FrmRegistroVenta frmRegistroVenta = new FrmRegistroVenta();
            frmRegistroVenta.ShowDialog();
        }
    }
}
