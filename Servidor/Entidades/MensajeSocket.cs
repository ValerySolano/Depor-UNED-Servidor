using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class MensajeSocket<T>
    {
        public string Metodo { get; set; }
        public T Entidad { get; set; }
    }
}
