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
    /// Lógica de interacción para ModificarBeneficiario.xaml
    /// </summary>
    public partial class ModificarBeneficiario : Window
    {
        ConexionBeneficiario ConexionNueva = new ConexionBeneficiario();
        Beneficiario BeneficiarioRegistrado = new Beneficiario();
        int i, u;
        public ModificarBeneficiario(Beneficiario aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            cbEscolaridad.Items.Add("Primaria");
            cbEscolaridad.Items.Add("Secundario");
            cbEscolaridad.Items.Add("Universitario");
            cbEscolaridad.SelectedIndex = 0;

            BeneficiarioRegistrado = aux;

            txtApellido.Text = BeneficiarioRegistrado.Apellido;
            txtNombre.Text = BeneficiarioRegistrado.Nombre;
            txtDNI.Text = BeneficiarioRegistrado.DNI.ToString();
            txtEmail.Text = BeneficiarioRegistrado.Email;
            txtCUIL.Text = BeneficiarioRegistrado.CUIL.ToString();

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
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
                        NuevoBeneficiario.IDBeneficiario = BeneficiarioRegistrado.IDBeneficiario;
                        NuevoBeneficiario.Nombre = txtNombre.Text;
                        NuevoBeneficiario.Apellido = txtApellido.Text;
                        NuevoBeneficiario.DNI = Convert.ToInt32(txtDNI.Text);
                        NuevoBeneficiario.Email = txtEmail.Text;
                        NuevoBeneficiario.CUIL = Convert.ToInt32(txtCUIL.Text);
                        NuevoBeneficiario.Escolaridad = cbEscolaridad.SelectedItem.ToString();

                        MessageBox.Show(ConexionNueva.actualizarBeneficiario(NuevoBeneficiario));
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
