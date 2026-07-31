/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using AccesoDatos;
using Entidades;
using System.Collections.Generic;

namespace LogicaNegocios
{
    public class LogicaCliente
    {
        // Acceso a datos de clientes (capa de persistencia / almacenamiento)
        private RepositorioClientes accesoDatosClientes;

        // Constructor: crea la instancia de la capa de acceso a datos
        public LogicaCliente()
        {
            // Instanciar el objeto que maneja el almacenamiento de clientes
            accesoDatosClientes = new RepositorioClientes();
        }

        // Agrega un cliente al sistema
        public void AgregarCliente(Cliente cliente)
        {
            // Validar los datos del cliente antes de intentar guardarlo
            ValidarCliente(cliente, true);

            // Si la validación es correcta, delegar la inserción a la capa de datos
            accesoDatosClientes.Agregar(cliente);
        }

        // Obtiene un cliente por su identificador
        public Cliente ObtenerCliente(int idCliente)
        {
            // Pedir a la capa de datos la entidad correspondiente
            Cliente? cliente = accesoDatosClientes.ObtenerPorId(idCliente);

            // Si la capa de datos no devolvió nada, informar con excepción
            if (cliente == null)
            {
                throw new InvalidOperationException("No existe un cliente con el Id indicado.");
            }

            // Devolver el objeto cliente recuperado
            return cliente;
        }

        // Devuelve todos los clientes registrados
        public List<Cliente> ObtenerClientes()
        {
            // Recuperar el conjunto completo desde la capa de datos
            return accesoDatosClientes.ObtenerTodos();
        }

        // Valida los datos de un cliente antes de crear o actualizar
        private void ValidarCliente(Cliente cliente, bool esNuevo)
        {
            // Verificar que el Id sea positivo
            if (cliente.IdCliente <= 0 )
            {
                throw new IdentificadorException("El IdCliente debe ser mayor que cero.");
            }

            // Validar que no sean nulos
            string identificacion = cliente.Identificacion == null ? string.Empty : cliente.Identificacion.Trim();
            string nombre = cliente.Nombre == null ? string.Empty : cliente.Nombre.Trim();
            string apellido = cliente.Apellido == null ? string.Empty : cliente.Apellido.Trim();
           
            // La identificación es obligatoria
            if (identificacion == string.Empty)
            {
                throw new IdentificadorException("La identificación es obligatoria.");
            }

            // El nombre es obligatorio
            if (nombre == string.Empty)
            {
                throw new TipoDatoInvalidoException("El nombre es obligatorio.");
            }

            // El apellido es obligatorio
            if (apellido == string.Empty)
            {
                throw new TipoDatoInvalidoException("El apellido es obligatorio.");
            }

            // La fecha de nacimiento debe ser anterior al día actual
            if (cliente.FechaNacimiento.Date >= DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de nacimiento debe ser menor al día actual.");
            }

            // La fecha de ingreso no puede ser futura
            if (cliente.FechaIngreso.Date > DateTime.Today)
            {
                throw new TipoDatoInvalidoException("La fecha de registro no puede ser mayor al día actual.");
            }
            // Si es un cliente nuevo y ya existe un cliente con ese Id, lanzar excepción
            if (esNuevo && accesoDatosClientes.ExisteIdCliente(cliente.IdCliente))
            {
                throw new IdentificadorException("El IdCliente ya existe.");
            }

            // Sino es un cliente nuevo y  no existe un cliente con ese Id, lanzar excepción
            if (!esNuevo && !accesoDatosClientes.ExisteIdCliente(cliente.IdCliente))
            {
                throw new IdentificadorException("No existe un cliente con el Id indicado.");
            }

            // Existe la identificación en otro cliente (distinto al que se está editando), lanzar excepción
            if (accesoDatosClientes.ExisteIdentificacion(identificacion, esNuevo ? -1 : cliente.IdCliente))
            {
                throw new IdentificadorException("La identificación ya existe.");
            }

            // Asignar los valores
            cliente.Identificacion = identificacion;
            cliente.Nombre = nombre;
            cliente.Apellido = apellido;
        }
    }
}

