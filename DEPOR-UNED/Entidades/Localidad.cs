/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace Entidades
{
    public class Localidad
    {
        public int IdLocalidad { get; set; }
        public string NombreLocalidad { get; set; }
        public decimal Precio { get; set; }
        // Ejecuta la logica principal del metodo Localidad.
        public Localidad(int idLocalidad, string nombreLocalidad, decimal precio)
        {
            this.IdLocalidad = idLocalidad;
            this.NombreLocalidad = nombreLocalidad;
            this.Precio = precio;
        }
    }
}

