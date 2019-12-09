using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Clases;
using Conexiones;

namespace Vistas
{
    /// <summary>
    /// Lógica de interacción para vtaBeneficiario.xaml
    /// </summary>
    public partial class VentanaBeneficiario : Window
    {
        List<Beneficiario> BeneficiariosRegistrados = new List<Beneficiario>();
        ConexionBeneficiario ConexionNueva = new ConexionBeneficiario();
        int i, u;
        public VentanaBeneficiario()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            cbEscolaridad.Items.Add("Primaria");
            cbEscolaridad.Items.Add("Secundario");
            cbEscolaridad.Items.Add("Universitario");
            cbEscolaridad.SelectedIndex = 0;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            bool X = int.TryParse(txtDNI.Text, out i);
            bool Y = int.TryParse(txtCUIL.Text, out u);

            if (!string.IsNullOrWhiteSpace(txtNombre.Text) && !string.IsNullOrWhiteSpace(txtApellido.Text)
                && !string.IsNullOrWhiteSpace(txtDNI.Text) && !string.IsNullOrWhiteSpace(txtEmail.Text)
                && !string.IsNullOrWhiteSpace(txtCUIL.Text))
            {
                if (X == true)
                {
                    if (Y == true)
                    {
                        Beneficiario NuevoBeneficiario = new Beneficiario();
                        NuevoBeneficiario.Nombre = txtNombre.Text;
                        NuevoBeneficiario.Apellido = txtApellido.Text;
                        NuevoBeneficiario.DNI = Convert.ToInt32(txtDNI.Text);
                        NuevoBeneficiario.Email = txtEmail.Text;
                        NuevoBeneficiario.CUIL = Convert.ToInt32(txtCUIL.Text);
                        NuevoBeneficiario.Escolaridad = cbEscolaridad.SelectedItem.ToString();

                        MessageBox.Show(ConexionNueva.insertarBeneficiario(NuevoBeneficiario));
                    }
                    else
                    {
                        MessageBox.Show("CUIL incorrecto, solo se admiten numeros.");
                    }
                }
                else
                {
                    MessageBox.Show("DNI incorrecto, solo se admiten numeros.");
                }
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.");
            }

        }

        private void BtnAgregarCurso_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                AgregarCurso vtaNueva = new AgregarCurso(aux.IDBeneficiario);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnAgregarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                AgregarContrato vtaNueva = new AgregarContrato(aux.IDBeneficiario);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            BeneficiariosRegistrados = ConexionNueva.RetornarTablaBeneficiario();
            lbMostrar.ItemsSource = BeneficiariosRegistrados;
            lbMostrar.Items.Refresh();
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                ModificarBeneficiario vtaNueva = new ModificarBeneficiario(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnEliminarContrato_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarContrato(aux.IDBeneficiario));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnEliminarCursados_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                ModificarCursados vtaNueva = new ModificarCursados(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Beneficiario aux = (Beneficiario)lbMostrar.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarBeneficiario(aux.IDBeneficiario));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }
    }
}
