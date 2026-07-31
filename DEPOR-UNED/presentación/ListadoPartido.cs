/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
using Entidades;
using LogicaNegocios;
namespace presentación
{
    public partial class ListadoPartido : Form
    {

        // Ejecuta la logica principal del metodo ListadoPartido.
        public ListadoPartido()
        {
            InitializeComponent();
        }

        // Maneja el evento Click del control btnNuevoPartido.
        private void btnNuevoPartido_Click(object sender, EventArgs e)
        {
            RegistroPartidos registroPartidos = new RegistroPartidos();
            registroPartidos.ShowDialog();
            CargarPartidos();
        }

        // Maneja la carga inicial del formulario o control ListadoPartido.
        private void ListadoPartido_Load(object? sender, EventArgs e)
        {
            CargarPartidos();
        }

        // Ejecuta la logica principal del metodo CargarPartidos.
        private void CargarPartidos()
        {
            try
            {
                DatosPartidos.Rows.Clear();
                LogicaPartido logicaPartido = new LogicaPartido();
                Partido[] lista = logicaPartido.ObtenerPartidos();

                foreach (var p in lista)
                {
                    DatosPartidos.Rows.Add(p.IdPartido, p.Rival, p.Fecha.ToShortDateString(), p.Hora, p.Activo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

