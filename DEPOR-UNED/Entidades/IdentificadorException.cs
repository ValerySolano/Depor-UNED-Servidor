/*
* UNED - Programaci�n Avanzada
* Proyecto#1 Sistema de administraci�n de partidos de f�tbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
namespace Entidades
{
    public class IdentificadorException : ApplicationException
     {
        public string MensajePersonalizado { get; set; }
        // Ejecuta la logica principal del metodo IdentificadorException.
        public IdentificadorException(string message) 
        {
            this.MensajePersonalizado = message;
        }
     
    }
}
