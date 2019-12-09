using Clases;
using Conexiones;
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
    /// Lógica de interacción para VentanaDictado.xaml
    /// </summary>
    public partial class VentanaDictado : Window
    {

        ConexionDictado ConexionNueva = new ConexionDictado();
        List<Dictado> Lista = new List<Dictado>();

        ConexionInstructor CI = new ConexionInstructor();
        ConexionTutor CT = new ConexionTutor();
        ConexionCurso CC = new ConexionCurso();

        Tutor auxTutor = new Tutor();
        Instructor auxInstructor = new Instructor();
        Curso auxCurso = new Curso();

        public VentanaDictado()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            CT.conectar();
            CI.conectar();
            CC.conectar();

            //Cargamos el cbx de Tutores
            List<Tutor> ListadosDeTutores = new List<Tutor>();            
            ListadosDeTutores = CT.RetornarTablaTutor();

            cbxTutor.ItemsSource = ListadosDeTutores;

            //Cargamos el cbx de Instructor
            List<Instructor> ListadosDeInstructor = new List<Instructor>();           
            ListadosDeInstructor = CI.RetornarTablaInstructor();

            cbxInstructor.ItemsSource = ListadosDeInstructor;

            //Cargamos el cbx de Curso
            List<Curso> ListadosDeCurso = new List<Curso>();          
            ListadosDeCurso = CC.RetornarTablaCurso();

            cbxCurso.ItemsSource = ListadosDeCurso;

            cbxTutor.SelectedIndex = 0;
            cbxInstructor.SelectedIndex = 0;
            cbxCurso.SelectedIndex = 0;

        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            Dictado DictadoNuevo = new Dictado();
            auxTutor = (Tutor)cbxTutor.SelectedItem;
            auxInstructor = (Instructor)cbxInstructor.SelectedItem;
            auxCurso = (Curso)cbxCurso.SelectedItem;

            if (dpFecha.SelectedDate.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(txtObjetivo.Text))
                {
                    DictadoNuevo.Fecha = dpFecha.SelectedDate.Value;
                    DictadoNuevo.Objetivos = txtObjetivo.Text;
                    DictadoNuevo.IDCurso = auxCurso.IDCurso;
                    DictadoNuevo.IDTutor = auxTutor.Codigo;
                    DictadoNuevo.IDInstructor = auxInstructor.Codigo;

                    MessageBox.Show(ConexionNueva.insertarDictado(DictadoNuevo));
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

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListar.SelectedIndex >= 0)
            {
                Dictado aux = (Dictado)lbxListar.SelectedItem;
                ModificarDictado vtaNueva = new ModificarDictado(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            Lista = ConexionNueva.RetornarTablaDictado();
            lbxListar.ItemsSource = Lista;
            lbxListar.Items.Refresh();
        }

        private void BtnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListar.SelectedIndex >= 0)
            {
                Dictado aux = (Dictado)lbxListar.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarDictado(aux.IDDictado));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }
    }
}
