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
    public partial class ListadoLocalidades : Form
    {

        // Ejecuta la logica principal del metodo ListadoLocalidades.
        public ListadoLocalidades()
        {
            InitializeComponent();
        }

        // Maneja el evento Click del control btnNuevoLocalidad.
        private void btnNuevoLocalidad_Click(object sender, EventArgs e)
        {
            RegistroLocalidades pantalla = new RegistroLocalidades();
            pantalla.ShowDialog();
            CargarLocalidades();
        }

        // Maneja la carga inicial del formulario o control ListadoLocalidades.
        private void ListadoLocalidades_Load(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

        // Ejecuta la logica principal del metodo CargarLocalidades.
        private void CargarLocalidades()
        {
            try
            {
                DatosLocalidades.Rows.Clear();
                LogicaLocalidad logicaLocalidad = new LogicaLocalidad();

                Localidad[] lista = logicaLocalidad.ObtenerLocalidades();

                foreach (var loc in lista)
                {
                    DatosLocalidades.Rows.Add(loc.IdLocalidad, loc.NombreLocalidad, loc.Precio);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

