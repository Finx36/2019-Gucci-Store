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

namespace GucciWPF
{
    /// <summary>
    /// Логика взаимодействия для Perexod.xaml
    /// </summary>
    public partial class Perexod : Window
    {
        public Perexod()
        {
            InitializeComponent();
        }

        private void btOtdel_Click(object sender, RoutedEventArgs e)
        {
            Dolgnost dolgnost = new Dolgnost();
            dolgnost.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            Sotrudniki sotrudniki = new Sotrudniki();
            sotrudniki.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btZakaz_Click(object sender, RoutedEventArgs e)
        {
            Sales_Rezult sales_Rezult = new Sales_Rezult();
            sales_Rezult.Show();
            Visibility = Visibility.Collapsed;
        }

        private void btTovary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btKachestvo_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
