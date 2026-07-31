/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/

namespace Entidades
{
    public class TipoDatoInvalidoException : ApplicationException
     {
        public string MensajePersonalizado { get; set; }
        // Ejecuta la logica principal del metodo TipoDatoInvalidoException.
        public TipoDatoInvalidoException(string message) 
        {
            this.MensajePersonalizado = message;
        }
     
    }
}
