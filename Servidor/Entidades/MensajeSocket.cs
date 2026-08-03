/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    // Esta clase representa un mensaje que se envía a través de un socket, con un método y una entidad genérica.
    public class MensajeSocket<T>
    {
        public string Metodo { get; set; }
        public T Entidad { get; set; }
    }
}
