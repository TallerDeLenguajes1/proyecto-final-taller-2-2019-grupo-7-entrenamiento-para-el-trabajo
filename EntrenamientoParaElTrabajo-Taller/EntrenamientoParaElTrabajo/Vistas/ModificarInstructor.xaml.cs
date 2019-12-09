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
    /// Lógica de interacción para ModificarInstructor.xaml
    /// </summary>
    public partial class ModificarInstructor : Window
    {
        List<Instructor> Lista = new List<Instructor>();
        ConexionInstructor ConexionNueva = new ConexionInstructor();
        private Instructor TutorRegistrado;
        int i;

        public ModificarInstructor(Instructor aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();

            TutorRegistrado = aux;

            txtApellido.Text = TutorRegistrado.Apellido;
            txtNombre.Text = TutorRegistrado.Nombre;
            txtDNI.Text = TutorRegistrado.DNII.ToString();
            cbxReparticion.Items.Add("Alderetes");
            cbxReparticion.Items.Add("San Miguel de Tucuman");
            cbxReparticion.Items.Add("Yerba Buena");
            cbxReparticion.Items.Add("Banda del Rio Sali");
            cbxReparticion.SelectedIndex = 0;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Instructor InstructorNuevo = new Instructor();

            bool X = int.TryParse(txtDNI.Text, out i);

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                if (X == true)
                {
                    InstructorNuevo.Codigo = TutorRegistrado.Codigo;
                    InstructorNuevo.Nombre = txtNombre.Text;
                    InstructorNuevo.Apellido = txtApellido.Text;
                    InstructorNuevo.DNII = Convert.ToInt32(txtDNI.Text);
                    InstructorNuevo.Reparticion = cbxReparticion.SelectedItem.ToString();

                    MessageBox.Show(ConexionNueva.actualizarInstructor(InstructorNuevo));
                    this.Close();
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
            this.Close();
        }
    }
}
