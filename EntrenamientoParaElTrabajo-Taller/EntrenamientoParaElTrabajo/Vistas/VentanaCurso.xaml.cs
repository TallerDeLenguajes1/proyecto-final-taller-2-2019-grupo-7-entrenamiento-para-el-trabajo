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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Clases;
using Conexiones;

namespace Vistas
{
    public partial class VentanaCurso : Window
    {
        ConexionCurso ConexionNueva = new ConexionCurso();

        public VentanaCurso()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtTematica.Text))
            {
                Curso CursoNuevo = new Curso();
                CursoNuevo.Nombre = txtNombre.Text;
                CursoNuevo.Tematica = txtTematica.Text;
                MessageBox.Show(ConexionNueva.insertarCurso(CursoNuevo));
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Curso> CursosRegistrados = new List<Curso>();
            CursosRegistrados = ConexionNueva.RetornarTablaCurso();

            lbMostrar.ItemsSource = CursosRegistrados;

            lbMostrar.Items.Refresh();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            if (lbMostrar.SelectedIndex >= 0)
            {
                Curso aux = (Curso)lbMostrar.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarCurso(aux.IDCurso));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Curso aux = (Curso)lbMostrar.SelectedItem;
                ModificarCurso vtaNueva = new ModificarCurso(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }
    }
}