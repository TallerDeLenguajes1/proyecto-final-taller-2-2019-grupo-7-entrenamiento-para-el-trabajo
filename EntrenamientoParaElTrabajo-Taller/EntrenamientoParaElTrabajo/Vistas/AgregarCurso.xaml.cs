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
    /// <summary>
    /// Lógica de interacción para AgregarCurso.xaml
    /// </summary>
    public partial class AgregarCurso : Window
    {
        ConexionBeneficiario ConexionNueva = new ConexionBeneficiario();
        ConexionCurso ConexionNueva2 = new ConexionCurso();
        int idb;
        public AgregarCurso(int aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            ConexionNueva2.conectar();
            List<Curso> CursosRegistrados = new List<Curso>();
            CursosRegistrados = ConexionNueva2.RetornarTablaCurso();
            lbMostrarCursos.ItemsSource = CursosRegistrados;
            idb = aux;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrarCursos.SelectedIndex >= 0)
            {
                Curso CursoRegistrado = new Curso();
                CursoRegistrado = (Curso)lbMostrarCursos.SelectedItem;
                MessageBox.Show(ConexionNueva.insertarCursoAsistido(idb, CursoRegistrado.IDCurso));
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
