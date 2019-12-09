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
using Conexiones;
using Clases;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para ModificarDictado.xaml
    /// </summary>
    public partial class ModificarDictado : Window
    {
        ConexionDictado ConexionNueva = new ConexionDictado();
        ConexionTutor CT = new ConexionTutor();
        ConexionInstructor CI = new ConexionInstructor();
        ConexionCurso CC = new ConexionCurso();

        Tutor auxTutor = new Tutor();
        Instructor auxInstructor = new Instructor();
        Curso auxCurso = new Curso();

        private Dictado DictadoRegistrado;
        public ModificarDictado(Dictado aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            CT.conectar();
            CI.conectar();
            CC.conectar();

            DictadoRegistrado = aux;

            dpFecha.SelectedDate = DictadoRegistrado.Fecha;
            txtObjetivo.Text = DictadoRegistrado.Objetivos;

            List<Tutor> TutorRegistrado = new List<Tutor>();
            TutorRegistrado = CT.RetornarTablaTutor();
            cbxTutor.ItemsSource = TutorRegistrado;
            cbxTutor.SelectedIndex = 0;

            List<Instructor> InstructorRegistrado = new List<Instructor>();
            InstructorRegistrado = CI.RetornarTablaInstructor();
            cbxInstructor.ItemsSource = InstructorRegistrado;
            cbxInstructor.SelectedIndex = 0;

            List<Curso> CursoRegistrado = new List<Curso>();
            CursoRegistrado = CC.RetornarTablaCurso();
            cbxCurso.ItemsSource = CursoRegistrado;
            cbxCurso.SelectedIndex = 0;

        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Dictado DictadoNuevo = new Dictado();
            auxTutor = (Tutor)cbxTutor.SelectedItem;
            auxInstructor = (Instructor)cbxInstructor.SelectedItem;
            auxCurso = (Curso)cbxCurso.SelectedItem;

            if (dpFecha.SelectedDate.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(txtObjetivo.Text))
                {
                    DictadoNuevo.IDDictado = DictadoRegistrado.IDDictado;
                    DictadoNuevo.Fecha = dpFecha.SelectedDate.Value;
                    DictadoNuevo.Objetivos = txtObjetivo.Text;
                    DictadoNuevo.IDCurso = auxCurso.IDCurso;
                    DictadoNuevo.IDTutor = auxTutor.Codigo;
                    DictadoNuevo.IDInstructor = auxInstructor.Codigo;

                    MessageBox.Show(ConexionNueva.actualizarDictado(DictadoNuevo));

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Campo Objetivos vacio, ingrese nuevamente.");
                }
            }
            else
            {
                MessageBox.Show("Campo FECHA vacio, ingrese nuevamente.");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
