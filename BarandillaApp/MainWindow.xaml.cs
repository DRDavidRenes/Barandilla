using System;
using System.Windows;
using System.Windows.Controls;

namespace BarandillaApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalcularButton_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si los valores ingresados son numéricos válidos
            if (double.TryParse(LargoTextBox.Text, out double largo) &&
                double.TryParse(SeparacionTextBox.Text, out double separacion) &&
                double.TryParse(SeccionTextBox.Text, out double seccion))
            {
                // Calcular el espacio total requerido por cada palo (incluyendo la medida de sección)
                double espacioPalo = separacion + seccion;

                // Calcular el número de palos (redondeando hacia arriba para asegurar que haya suficientes palos)
                int numeroPalos = (int)Math.Ceiling(largo / espacioPalo);
                NumeroPalosTextBlock.Text = numeroPalos.ToString();

                // Calcular la nueva separación teniendo en cuenta el espacio total requerido y el número de palos
                double nuevaSeparacion = (largo - (seccion * numeroPalos)) / (numeroPalos - 1);
                SeparacionResultTextBlock.Text = nuevaSeparacion.ToString("0.##");

                // Calcular la medida entre ejes
                double medidaEntreEjes = nuevaSeparacion + seccion;
                MedidaEntreEjesTextBlock.Text = medidaEntreEjes.ToString("0.##");
            }
            else
            {
                MessageBox.Show("Por favor, ingresa valores numéricos válidos.");
            }
        }
    }
}
