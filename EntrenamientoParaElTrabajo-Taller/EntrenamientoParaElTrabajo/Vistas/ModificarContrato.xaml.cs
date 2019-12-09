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
    /// Lógica de interacción para ModificarContrato.xaml
    /// </summary>
    public partial class ModificarContrato : Window
    {
        ConexionContrato ConexionNueva = new ConexionContrato();
        private Contrato ContratoRegistrado;
        public ModificarContrato(Contrato aux)
        {
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            InitializeComponent();
            ConexionNueva.conectar();
            ContratoRegistrado = aux;
            dateFechaI.SelectedDate = ContratoRegistrado.Fecha_Inicio;
            dateFechaF.SelectedDate = ContratoRegistrado.Fecha_Fin;
            txtCargo.Text = ContratoRegistrado.Cargo;
            txtEmpresa.Text = ContratoRegistrado.Empresa;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            if (dateFechaI.SelectedDate.HasValue && dateFechaF.SelectedDate.HasValue)
            {
                if (!string.IsNullOrWhiteSpace(txtCargo.Text) && !string.IsNullOrWhiteSpace(txtEmpresa.Text))
                {
                    Contrato ContratoNuevo = new Contrato();
                    ContratoNuevo.IDContrato = ContratoRegistrado.IDContrato;
                    ContratoNuevo.Fecha_Inicio = dateFechaI.SelectedDate.Value;
                    ContratoNuevo.Fecha_Fin = dateFechaF.SelectedDate.Value;
                    ContratoNuevo.Cargo = txtCargo.Text;
                    ContratoNuevo.Empresa = txtEmpresa.Text;

                    MessageBox.Show(ConexionNueva.actualizarContrato(ContratoNuevo));
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
