/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace Entidades
{
     public class Partido
    {
        public int IdPartido { get; set; }
        public string Rival { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public bool Activo { get; set; }
        // Ejecuta la logica principal del metodo Partido.
        public Partido(int idPartido, string rival, DateTime fecha, string hora, bool activo)
        {
            this.IdPartido = idPartido;
            this.Rival = rival;
            this.Fecha = fecha;
            this.Hora = hora;
            this.Activo = activo;
        }
    }
}

