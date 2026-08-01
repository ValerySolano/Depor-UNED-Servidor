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
    public partial class ListadoPartido : Form
    {

        public ListadoPartido()
        {
            InitializeComponent();
        }

        private void btnNuevoPartido_Click(object sender, EventArgs e)
        {
            RegistroPartidos registroPartidos = new RegistroPartidos();
            registroPartidos.ShowDialog();
            CargarPartidos();
        }

        private void ListadoPartido_Load(object? sender, EventArgs e)
        {
            CargarPartidos();
        }

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

