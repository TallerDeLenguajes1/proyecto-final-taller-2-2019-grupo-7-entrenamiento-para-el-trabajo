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
 
    public partial class VentanaInstructor : Window
    {
        List<Instructor> Lista = new List<Instructor>(); 
        ConexionInstructor ConexionNueva = new ConexionInstructor();
        int i;

        public VentanaInstructor()
        {
            ///WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            cbxReparticion.Items.Add("Alderetes"); // Cargamos el comboBox
            cbxReparticion.Items.Add("San Miguel de Tucuman");
            cbxReparticion.Items.Add("Yerba Buena");
            cbxReparticion.Items.Add("Banda del Rio Sali");
            cbxReparticion.SelectedIndex = 0;
        }

        private void BtnInsertar_Click(object sender, RoutedEventArgs e) //Creamos el evento Insertar.
        {
            Instructor InstructorNuevo = new Instructor();

            bool X = int.TryParse(txtDNI.Text, out i);

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                if (X == true)
                {
                    InstructorNuevo.Nombre = txtNombre.Text;
                    InstructorNuevo.Apellido = txtApellido.Text;
                    InstructorNuevo.DNII = Convert.ToInt32(txtDNI.Text);
                    InstructorNuevo.Reparticion = cbxReparticion.SelectedItem.ToString();

                    MessageBox.Show(ConexionNueva.insertarInstructor(InstructorNuevo));
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

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListadoInstructor.SelectedIndex >= 0)
            {
                Instructor aux = (Instructor)lbxListadoInstructor.SelectedItem;
                ModificarInstructor vtaNueva = new ModificarInstructor(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }

        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (lbxListadoInstructor.SelectedIndex >= 0)
            {
                Instructor aux = (Instructor)lbxListadoInstructor.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarInstructor(aux.Codigo));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Instructor> InstructoresRegistrados = new List<Instructor>();
            InstructoresRegistrados = ConexionNueva.RetornarTablaInstructor();

            lbxListadoInstructor.ItemsSource = InstructoresRegistrados;

            lbxListadoInstructor.Items.Refresh();
        }
    }
}
