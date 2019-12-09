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
    /// Lógica de interacción para VentanaLogueo.xaml
    /// </summary>
    public partial class VentanaLogueo : Window
    {
        ConexionLogueo C = new ConexionLogueo();

        public VentanaLogueo()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            C.conectar();

        }

        private void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string auxUsser = txtUsser.Text;
            string auxPassword = txtPassword.Password.ToString();          

            if (string.IsNullOrWhiteSpace(auxPassword) == true || string.IsNullOrWhiteSpace(auxUsser) == true)
            {
                MessageBox.Show("Algun campo esta vacio");
            }

            int aux = C.Validar(auxUsser, auxPassword);

            if (aux == 1)
            {         
                this.Hide();
                VentanaPrincipal VTAP = new VentanaPrincipal();
                MessageBox.Show("BIENVENIDO!!");
                VTAP.ShowDialog();
                this.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Datos ingresado incorrectos");
            }
        }

    }
}
