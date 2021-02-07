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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GucciWPF
{
    /// <summary>
    /// Логика взаимодействия для Authorization.xaml
    /// </summary>
    public partial class Authorization : Window
    {
        public Authorization()
        {
            InitializeComponent();
        }

        private void BtEnter_Click(object sender, RoutedEventArgs e)
        {
            DBConnection connection = new DBConnection();
            Perexod Perexod = new Perexod();
            connection.dbEnter(tbEnterLogin.Password, tbEnterPassword.Password);
            switch (DBConnection.IDUser)
            {
                case (0):
                    MessageBox.Show("Введён неверный логин или пароль!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Warning);
                    tbEnterLogin.Password = "";
                    tbEnterPassword.Password = "";
                    break;
                default:
                    Perexod.Show();
                    Visibility = Visibility.Collapsed;
                    break;
            }
        }

        private void BtLeave_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
