/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace Entidades
{
    public class Cliente: Persona
    {
        public int IdCliente { get; set; }
        public bool Activo { get; set; }
        // Ejecuta la logica principal del metodo Cliente.
        public Cliente(int idCliente, string identificacion, string nombre, string apellido, DateTime fechaNacimiento, DateTime fechaIngreso, bool activo)
        {
            this.IdCliente = idCliente;
            this.Identificacion = identificacion;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaNacimiento = fechaNacimiento;
            this.FechaIngreso = fechaIngreso;
            this.Activo = activo;
        }
        // Ejecuta la logica principal del metodo MostrarDatos.
        public override string MostrarDatos()
        {
            return "Cliente: " + Nombre;
        }
    }

}

