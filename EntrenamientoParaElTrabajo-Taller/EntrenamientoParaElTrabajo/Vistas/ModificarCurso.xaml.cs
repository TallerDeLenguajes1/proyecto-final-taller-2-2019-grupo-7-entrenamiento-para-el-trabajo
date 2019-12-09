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
    /// Lógica de interacción para ModificarCurso.xaml
    /// </summary>
    public partial class ModificarCurso : Window
    {
        ConexionCurso ConexionNueva2 = new ConexionCurso();
        private Curso CursoRegistrado;
        public ModificarCurso(Curso aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva2.conectar();
            CursoRegistrado = aux;
            txtNombre.Text = CursoRegistrado.Nombre;
            txtTematica.Text = CursoRegistrado.Tematica;
        }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtTematica.Text))
            {
                Curso CursoNuevo = new Curso();
                CursoNuevo.IDCurso = CursoRegistrado.IDCurso;
                CursoNuevo.Nombre = txtNombre.Text;
                CursoNuevo.Tematica = txtTematica.Text;

                MessageBox.Show(ConexionNueva2.actualizarCurso(CursoNuevo));
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.");
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}