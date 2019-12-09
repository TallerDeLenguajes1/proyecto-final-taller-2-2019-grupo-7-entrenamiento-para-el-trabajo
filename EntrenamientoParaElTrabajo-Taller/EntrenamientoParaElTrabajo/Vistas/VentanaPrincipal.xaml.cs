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

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window

    {

        public VentanaPrincipal()

        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void BtnInstructores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaInstructor VTI = new VentanaInstructor();
            VTI.ShowDialog();
            this.Show();
        }

        private void BtnTutores_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaTutor VTT = new VentanaTutor();
            VTT.ShowDialog();
            this.Show();
        }

        private void BtnBeneficiarios_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaBeneficiario VTB = new VentanaBeneficiario();
            VTB.ShowDialog();
            this.Show();

        }
      

        private void BtnCursos_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaCurso VTC = new VentanaCurso();
            VTC.ShowDialog();
            this.Show();

        }

        private void BtnDictado_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaDictado VTD = new VentanaDictado();
            VTD.ShowDialog();
            this.Show();

        }

        private void BtnContrato_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            VentanaContrato VTCo = new VentanaContrato();
            VTCo.ShowDialog();
            this.Show();
        }
    }
}
