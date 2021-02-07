using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Dolgnost.xaml
    /// </summary>
    public partial class Dolgnost : Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Dolgnost()
        {
            InitializeComponent();
        }

        private void BtDolgnostInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.gucDolgnost_insert(tbName_Dolgnost.Text.ToString(), Convert.ToInt32(tbSalary.Text.ToString()));
            dtFill(QR);
        }

        private void BtDolgnostUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dtWorkerPosition.SelectedItems[0];
            procedures.gucDolgnost_update(Convert.ToInt32(ID["ID_Position"]), tbName_Dolgnost.Text.ToString(), Convert.ToInt32(tbSalary.Text.ToString()));
            dtFill(QR);
        }

        private void BtDolgnostDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dtWorkerPosition.SelectedItems[0];
            procedures.gucDolgnost_delete(Convert.ToInt32(ID["ID_Position"]));
            dtFill(QR);
        }

        private void dtWorkerPosition_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Position"):
                    e.Column.Header = "Название должности";
                    break;
                case ("Salary"):
                    e.Column.Header = "Зарплата";
                    break;
            }
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + " where [Position] like '%" + tbSearch.Text + "%' or " +
                "[Salary] like '%" + tbSearch.Text + "%'";
                    dtFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dtWorkerPosition.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text)
                        {
                            dtWorkerPosition.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Perexod Perexod = new Perexod();
            Perexod.Show();
            Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrWorkerPosition;
            dtFill(QR);
        }

        private void dtFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrWorkerPosition = qr;
            connection.PositionFill();
            dtWorkerPosition.ItemsSource = connection.dtWorkerPosition.DefaultView;
            dtWorkerPosition.Columns[0].Visibility = Visibility.Collapsed;            
        }

        private void BtChbCLick(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    btSearch.Content = "Фильтрация";
                    break;
                case (false):
                    btSearch.Content = "Поиск";
                    dtFill(QR);
                    break;
            }
        }
    }
}
