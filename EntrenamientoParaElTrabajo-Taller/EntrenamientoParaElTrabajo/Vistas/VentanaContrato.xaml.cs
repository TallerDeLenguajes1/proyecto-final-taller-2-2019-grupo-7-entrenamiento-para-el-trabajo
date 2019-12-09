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
    /// Lógica de interacción para vtaContrato.xaml
    /// </summary>
    public partial class VentanaContrato : Window
    {
        ConexionContrato ConexionNueva = new ConexionContrato();
        public VentanaContrato()
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (dateFechaI.SelectedDate.HasValue && dateFechaF.SelectedDate.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(txtCargo.Text) && !string.IsNullOrWhiteSpace(txtEmpresa.Text))
                {
                    Contrato ContratoNuevo = new Contrato();
                    ContratoNuevo.Fecha_Inicio = dateFechaI.SelectedDate.Value;
                    ContratoNuevo.Fecha_Fin = dateFechaF.SelectedDate.Value;
                    ContratoNuevo.Cargo = txtCargo.Text;
                    ContratoNuevo.Empresa = txtEmpresa.Text;

                    MessageBox.Show(ConexionNueva.insertarContrato(ContratoNuevo));
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos.");
                }
            }
            else
            {
                MessageBox.Show("Fecha ingresada no valida.");
            }
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Contrato aux = (Contrato)lbMostrar.SelectedItem;
                ModificarContrato vtaNueva = new ModificarContrato(aux);
                vtaNueva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            List<Contrato> ContratosRegistrados = new List<Contrato>();
            ContratosRegistrados = ConexionNueva.RetornarTablaContrato();

            lbMostrar.ItemsSource = ContratosRegistrados;

            lbMostrar.Items.Refresh();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrar.SelectedIndex >= 0)
            {
                Contrato aux = (Contrato)lbMostrar.SelectedItem;
                MessageBox.Show(ConexionNueva.eliminarContrato(aux.IDContrato));
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }
    }
}