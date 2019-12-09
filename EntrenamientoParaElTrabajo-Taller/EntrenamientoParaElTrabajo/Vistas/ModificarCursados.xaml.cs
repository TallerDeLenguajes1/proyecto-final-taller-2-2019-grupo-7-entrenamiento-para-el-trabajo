using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Clases;
using Conexiones;

namespace Vistas
{
    public partial class ModificarCursados : Window
    {
        ConexionCurso ConexionNueva = new ConexionCurso();
        ConexionBeneficiario ConexionNueva2 = new ConexionBeneficiario();
        List<Curso> CursosRegistrados = new List<Curso>();
        List<Cursados> CursadosRegistrados = new List<Cursados>();
        private Beneficiario BeneficiarioRegistrado;
        public ModificarCursados(Beneficiario aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            ConexionNueva2.conectar();
            BeneficiarioRegistrado = aux;

            CursadosRegistrados = ConexionNueva2.RetornarTablaCursadosID(BeneficiarioRegistrado.IDBeneficiario);

            lbMostrarCursados.ItemsSource = CursadosRegistrados;

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrarCursados.SelectedIndex >= 0)
            {
                Cursados aux = (Cursados)lbMostrarCursados.SelectedItem;
                MessageBox.Show(ConexionNueva2.eliminarCursados(aux.IDBeneficiario, aux.IDCursos));
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
