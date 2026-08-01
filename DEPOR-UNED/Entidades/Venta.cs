/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace Entidades
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Cliente Cliente { get; set; }
        public Partido Partido { get; set; }
        public Localidad Localidad { get; set; }
        public int Cantidad { get; set; }
        public Vendedor? Vendedor { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal MontoTotal { get; set; }
        public string TipoVenta { get; set; }
        // Ejecuta la logica principal del metodo Venta.
        public Venta(int idVenta, Cliente cliente, Partido partido, Localidad localidad, int cantidad, Vendedor? vendedor, DateTime fechaVenta, decimal montoTotal, string tipoVenta)
        {
            this.IdVenta = idVenta;
            this.Cliente = cliente;
            this.Partido = partido;
            this.Localidad = localidad;
            this.Cantidad = cantidad;
            this.Vendedor = vendedor;
            this.FechaVenta = fechaVenta;
            this.MontoTotal = montoTotal;
            this.TipoVenta = tipoVenta;
        }
    }
}

