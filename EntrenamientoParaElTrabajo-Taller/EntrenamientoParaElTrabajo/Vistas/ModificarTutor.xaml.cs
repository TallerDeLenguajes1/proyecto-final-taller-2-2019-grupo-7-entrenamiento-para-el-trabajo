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
    /// Lógica de interacción para ModificarTutor.xaml
    /// </summary>
    public partial class ModificarTutor : Window
    {
        List<Tutor> Lista = new List<Tutor>();
        ConexionTutor ConexionNueva = new ConexionTutor();
        private Tutor TutorRegistrado;
        int i;
        public ModificarTutor(Tutor aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();

            TutorRegistrado = aux;

            txtApellido.Text = TutorRegistrado.Apellido;
            txtNombre.Text = TutorRegistrado.Nombre;
            txtDNI.Text = TutorRegistrado.DNIT.ToString();
            cbxReparticion.Items.Add("Alderetes");
            cbxReparticion.Items.Add("San Miguel de Tucuman");
            cbxReparticion.Items.Add("Yerba Buena");
            cbxReparticion.Items.Add("Banda del Rio Sali");
            cbxReparticion.SelectedIndex = 0;
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            Tutor TutorNuevo = new Tutor();

            bool X = int.TryParse(txtDNI.Text, out i);

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text) && !string.IsNullOrWhiteSpace(txtDNI.Text))
            {
                if (X == true)
                {
                    TutorNuevo.Codigo = TutorRegistrado.Codigo;
                    TutorNuevo.Nombre = txtNombre.Text;
                    TutorNuevo.Apellido = txtApellido.Text;
                    TutorNuevo.DNIT = Convert.ToInt32(txtDNI.Text);
                    TutorNuevo.Reparticion = cbxReparticion.SelectedItem.ToString();

                    MessageBox.Show(ConexionNueva.actualizarTutor(TutorNuevo));
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
