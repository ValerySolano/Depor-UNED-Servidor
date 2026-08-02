/*
* UNED - Programación Avanzada
* Proyecto#2 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 01/08/2026
*/
using Entidades;
using LogicaNegocios;

namespace presentación
{
    public partial class ListadoLocalidades : Form
    {

        public ListadoLocalidades()
        {
            InitializeComponent();
        }

        private void btnNuevoLocalidad_Click(object sender, EventArgs e)
        {
            RegistroLocalidades pantalla = new RegistroLocalidades();
            pantalla.ShowDialog();
            CargarLocalidades();
        }

        private void ListadoLocalidades_Load(object sender, EventArgs e)
        {
            CargarLocalidades();
        }

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

