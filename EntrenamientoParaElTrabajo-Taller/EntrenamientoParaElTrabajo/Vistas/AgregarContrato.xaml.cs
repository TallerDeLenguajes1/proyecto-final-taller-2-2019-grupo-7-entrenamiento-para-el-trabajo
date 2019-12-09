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
    public partial class AgregarContrato : Window
    {
        ConexionBeneficiario ConexionNueva = new ConexionBeneficiario();
        ConexionContrato ConexionNueva2 = new ConexionContrato();
        int idb;
        public AgregarContrato(int aux)
        {
            InitializeComponent();
            ConexionNueva.conectar();
            ConexionNueva2.conectar();
            List<Contrato> ContratosRegistrados = new List<Contrato>();
            ContratosRegistrados = ConexionNueva2.RetornarTablaContrato();
            lbMostrarContrato.ItemsSource = ContratosRegistrados;
            idb = aux;
        }

        private void BtnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (lbMostrarContrato.SelectedIndex >= 0)
            {
                Contrato ContratoRegistrado = new Contrato();
                ContratoRegistrado = (Contrato)lbMostrarContrato.SelectedItem;
                MessageBox.Show(ConexionNueva.insertarContratoRealizado(idb, ContratoRegistrado.IDContrato));
                this.Close();
            }
            else
            {
                MessageBox.Show("Seleccione un elemento de la lista.");
            }
        }

        private void BtnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
