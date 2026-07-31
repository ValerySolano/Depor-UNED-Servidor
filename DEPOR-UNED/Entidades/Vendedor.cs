/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace Entidades
{
    public class Vendedor: Persona
    {
        public int IdVendedor{ get; set; }
        // Ejecuta la logica principal del metodo Vendedor.
        public Vendedor(int idVendedor, string identificacion, string nombre, string apellido, DateTime fechaNacimiento, DateTime fechaIngreso)
        {
            this.IdVendedor = idVendedor;
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaIngreso = fechaIngreso;
        }
        // Ejecuta la logica principal del metodo MostrarDatos.
        public override string MostrarDatos()
        {
            return "Vendedor: " + Nombre;
        }
    }
}

