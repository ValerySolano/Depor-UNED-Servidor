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
            
            CargarNombreCliente();
            this.FormClosing += FrmPanelCliente_FormClosing;

            CargarVentasCliente();
        }

        private void FrmPanelCliente_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(identificacionCliente))
            {
                ClienteTCP.Desconectar(identificacionCliente);
            }
        }

        private void CargarNombreCliente()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificacionCliente))
                {
                    labelUser.Text = "Usuario";
                    return;
                }

                var cliente = ClienteTCP.ObtenerClientePorIdentificacion(identificacionCliente);
                
                if (cliente != null)
                {
                    labelUser.Text = $"{cliente.Nombre} {cliente.Apellido}".Trim();
                }
                else
                {
                    labelUser.Text = identificacionCliente;
                }
            }
            catch (Exception)
            {
                labelUser.Text = identificacionCliente;
            }
        }

        private void CargarVentasCliente()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(identificacionCliente))
                {
                    MessageBox.Show("No hay identificación de cliente válida.", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var ventasCliente = ClienteTCP.ObtenerVentasCliente(identificacionCliente);

                dataGridCompras.Rows.Clear();

                foreach (var venta in ventasCliente)
                {
                    string nombreVendedor = string.Empty;
                    if (venta.Vendedor != null)
                    {
                        nombreVendedor = $"{venta.Vendedor.Nombre} {venta.Vendedor.Apellido}".Trim();
                    }

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
            
            CargarVentasCliente();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
