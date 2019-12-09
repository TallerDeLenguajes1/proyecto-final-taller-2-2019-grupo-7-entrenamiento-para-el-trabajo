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
    /// Lógica de interacción para VentanaTutor.xaml
    /// </summary>
    public partial class VentanaTutor : Window
    {
        List<Tutor> Lista = new List<Tutor>();
        ConexionTutor ConexionNueva = new ConexionTutor();
        int i;
        public VentanaTutor()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();

            ConexionNueva.conectar();
            cbxReparticion.Items.Add("Alderetes");
            cbxReparticion.Items.Add("San Miguel de Tucuman");
            cbxReparticion.Items.Add("Yerba Buena");
            cbxReparticion.Items.Add("Banda del Rio Sali");
            cbxReparticion.SelectedIndex = 0;
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e)
        {
            Tutor TutorNuevo = new Tutor();

            bool X = int.TryParse(txtDNI.Text, out i);

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                if (X == true)
                {
                    TutorNuevo.Nombre = txtNombre.Text;
                    TutorNuevo.Apellido = txtApellido.Text;
                    TutorNuevo.DNIT = Convert.ToInt32(txtDNI.Text);
                    TutorNuevo.Reparticion = cbxReparticion.SelectedItem.ToString();

                    MessageBox.Show(ConexionNueva.insertarTutor(TutorNuevo));
                }
                else
                {
                    MessageBox.Show("DNI incorrecto, solo numeros permitidos.");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.");
            }

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListadoTutor.SelectedIndex >= 0)
            {
                Tutor aux = (Tutor)lbxListadoTutor.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarTutor(aux.Codigo));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListadoTutor.SelectedIndex >= 0)
            {
                Tutor aux = (Tutor)lbxListadoTutor.SelectedItem;
                ModificarTutor vtaNueva = new ModificarTutor(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Tutor> TutoresRegistrados = new List<Tutor>();
            TutoresRegistrados = ConexionNueva.RetornarTablaTutor();

            lbxListadoTutor.ItemsSource = TutoresRegistrados;

            lbxListadoTutor.Items.Refresh();
        }

    }
}
