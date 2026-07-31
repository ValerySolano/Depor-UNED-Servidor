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
    public partial class ListadoLocalidadesPartido : Form
    {
        private LogicaLocalidadPartido logicaLocalidadPartido;

        // Ejecuta la logica principal del metodo ListadoLocalidadesPartido.
        public ListadoLocalidadesPartido()
        {
            InitializeComponent();
            logicaLocalidadPartido = new LogicaLocalidadPartido();
            
        }

        // Maneja la carga inicial del formulario o control ListadoLocalidadesPartido.
        private void ListadoLocalidadesPartido_Load(object sender, EventArgs e)
        {
            CargarRegistros();
        }

        // Maneja el evento Click del control btnNuevo.
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LocalidadesPartido localidadesPartido = new LocalidadesPartido();
            localidadesPartido.ShowDialog();
            CargarRegistros();
        }

        // Ejecuta la logica principal del metodo CargarRegistros.
        private void CargarRegistros()
        {
            try
            {
                DatosLoalidadesPartido.Rows.Clear();
                LocalidadPartido[] registros = logicaLocalidadPartido.ObtenerRegistros();

                foreach (var r in registros)
                {
                    string partidoTexto = r.Partido == null ? string.Empty : r.Partido.Rival + " (ID:" + r.Partido.IdPartido + ")";
                    string localidadTexto = r.Localidad == null ? string.Empty : r.Localidad.NombreLocalidad + " (ID:" + r.Localidad.IdLocalidad + ")";
                    bool activo = r.Partido?.Activo ?? false;
                    int idLocalidad = r.Localidad?.IdLocalidad ?? 0;
                    decimal precio = r.Localidad?.Precio ?? 0m;

                    // Asegurar que se agregan valores para todas las columnas definidas en el DataGridView
                    DatosLoalidadesPartido.Rows.Add(
                        r.IdLocalidadPartido,
                        partidoTexto,
                        r.Partido?.Fecha.ToShortDateString(),
                        r.Partido?.Hora,
                        activo,
                        idLocalidad,
                        r.Localidad?.NombreLocalidad ?? string.Empty,
                        precio,
                        r.CantidadDisponible);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

