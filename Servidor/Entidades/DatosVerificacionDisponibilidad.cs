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
    public class DatosVerificacionDisponibilidad
    {
        public int IdPartido { get; set; }
        public int IdLocalidad { get; set; }
        public int Cantidad { get; set; }
    }
}
