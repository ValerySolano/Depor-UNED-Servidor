/*
* UNED - Programaci�n Avanzada
* Proyecto#1 Sistema de administraci�n de partidos de f�tbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using AccesoDatos;
using Entidades;
using System.Collections.Generic;

namespace LogicaNegocios
{
    public class LogicaCliente
    {
        private RepositorioClientes accesoDatosClientes;

        public LogicaCliente()
        {
            accesoDatosClientes = new RepositorioClientes();
        }

        public void AgregarCliente(Cliente cliente)
        {
            ValidarCliente(cliente, true);
            accesoDatosClientes.Agregar(cliente);
        }

        public Cliente ObtenerCliente(int idCliente)
        {
            Cliente? cliente = accesoDatosClientes.ObtenerPorId(idCliente);

            if (cliente == null)
            {
                throw new InvalidOperationException("No existe un cliente con el Id indicado.");
            }

            return cliente;
        }

        public List<Cliente> ObtenerClientes()
        {
            return accesoDatosClientes.ObtenerTodos();
        }

        private void ValidarCliente(Cliente cliente, bool esNuevo)
        {
            if (cliente.IdCliente <= 0 )
            {
                throw new IdentificadorException("El IdCliente debe ser mayor que cero.");
            }

            string identificacion = cliente.Identificacion == null ? string.Empty : cliente.Identificacion.Trim();
            string nombre = cliente.Nombre == null ? string.Empty : cliente.Nombre.Trim();
            string apellido = cliente.Apellido == null ? string.Empty : cliente.Apellido.Trim();
           

            if (identificacion == string.Empty)
            {
                throw new IdentificadorException("La identificaci�n es obligatoria.");
            }


            if (nombre == string.Empty)
            {
                throw new TipoDatoInvalidoException("El nombre es obligatorio.");
            }

            if (apellido == string.Empty)
            {
                throw new TipoDatoInvalidoException("El apellido es obligatorio.");
            }


            if (cliente.FechaNacimiento.Date >= DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de nacimiento debe ser menor al d�a actual.");
            }


            if (cliente.FechaIngreso.Date > DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de registro no puede ser mayor al d�a actual.");
            }
            // Si es un cliente nuevo y ya existe un cliente con ese Id, lanzar excepci�n
            if (esNuevo && accesoDatosClientes.ExisteIdCliente(cliente.IdCliente))
            {
                throw new IdentificadorException("El IdCliente ya existe.");
            }

            // Sino es un cliente nuevo y  no existe un cliente con ese Id, lanzar excepci�n
            if (!esNuevo && !accesoDatosClientes.ExisteIdCliente(cliente.IdCliente))
            {
                throw new IdentificadorException("No existe un cliente con el Id indicado.");
            }

            // Existe la identificaci�n en otro cliente (distinto al que se est� editando), lanzar excepci�n
            if (accesoDatosClientes.ExisteIdentificacion(identificacion, esNuevo ? -1 : cliente.IdCliente))
            {
                throw new IdentificadorException("La identificaci�n ya existe.");
            }

            // Asignar los valores
            cliente.Identificacion = identificacion;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
        }
    }
}

