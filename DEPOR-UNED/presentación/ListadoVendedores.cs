/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class ListadoVendedores : Form
    {
        private LogicaVendedor logicaVendedor;

        public ListadoVendedores()
        {
            InitializeComponent();
            logicaVendedor = new LogicaVendedor();
        }

        private void btnNuevoPartido_Click(object sender, EventArgs e)
        {
            RegistroVendedor registroVendedor = new RegistroVendedor();
            registroVendedor.ShowDialog();
            CargarVendedores();
        }

        private void ListadoVendedores_Load(object? sender, EventArgs e)
        {
            CargarVendedores();
        }

        private void CargarVendedores()
        {
            try
            {
                DatosPartidos.Rows.Clear();
                Vendedor[] lista = logicaVendedor.ObtenerVendedores();
                foreach (var v in lista)
                {
                    DatosPartidos.Rows.Add(v.IdVendedor, v.Identificacion, v.Nombre, v.Apellido, v.FechaNacimiento.ToShortDateString(), v.FechaIngreso.ToShortDateString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

