/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace Entidades
{
    public class LocalidadPartido
    {
        public int IdLocalidadPartido { get; set; }
        public Partido Partido { get; set; }
        public Localidad Localidad { get; set; }
        public int CantidadDisponible { get; set; }
        // Ejecuta la logica principal del metodo LocalidadPartido.
        public LocalidadPartido(int idLocalidadPartido, Partido partido, Localidad localidad, int cantidadDisponible)
        {
            this.IdLocalidadPartido = idLocalidadPartido;
            this.Partido = partido;
            this.Localidad = localidad;
            this.CantidadDisponible = cantidadDisponible;
        }
    }
}

