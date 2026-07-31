/*
* UNED - Programación Avanzada
* Proyecto#1 Sistema de administración de partidos de fútbol
* Autor: Valery Fonseca Solano
* Fecha: 21/06/2026
*/
namespace presentación
{
    public partial class PantallaPrincipal : Form
    {
        // Ejecuta la logica principal del metodo PantallaPrincipal.
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        // Maneja el evento Click del control button5.
        private void button5_Click(object sender, EventArgs e)
        {
            ListadoVendedores listadoVendedores = new ListadoVendedores();
            listadoVendedores.Show();
        }

        // Maneja el evento Click del control btnSalir.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Maneja el evento Click del control btnClientes.
        private void btnClientes_Click(object sender, EventArgs e)
        {
            ListadoClientes listadoClientes = new ListadoClientes();
            listadoClientes.Show();
        }

        // Maneja el evento Click del control btnPartidos.
        private void btnPartidos_Click(object sender, EventArgs e)
        {
            ListadoPartido listadoPartidos = new ListadoPartido();
            listadoPartidos.Show();
        }

        // Maneja el evento Click del control btnLocalidades.
        private void btnLocalidades_Click(object sender, EventArgs e)
        {
            ListadoLocalidades Localidades = new ListadoLocalidades();
            Localidades.Show();
        }

        // Maneja el evento Click del control btnLocalidadesPartido.
        private void btnLocalidadesPartido_Click(object sender, EventArgs e)
        {
            ListadoLocalidadesPartido listadoLocalidadesPartido = new ListadoLocalidadesPartido();
            listadoLocalidadesPartido.Show();
        }

        // Maneja el evento Click del control btnVentas.
        private void btnVentas_Click(object sender, EventArgs e)
        {
            ListadoVentas listadoVentas = new ListadoVentas();
            listadoVentas.Show();
        }
    }
}

