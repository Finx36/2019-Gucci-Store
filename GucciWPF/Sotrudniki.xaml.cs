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
    /// Логика взаимодействия для Sotrudniki.xaml
    /// </summary>
    public partial class Sotrudniki : Window
    {
        DBProcedures procedures = new DBProcedures();
        private string QR = "";

        public Sotrudniki()
        {
            InitializeComponent();
        }

        private void SotrudnikiWPF_Loaded(object sender, RoutedEventArgs e)
        {
            QR = DBConnection.qrSotrudniki;
            dtFill(QR);
            cbFill();

        }

        private void dtFill(string qr)
        {
            DBConnection connection = new DBConnection();
            DBConnection.qrSotrudniki = qr;
            connection.SotrudnikFill();
            dtSotrudniki.ItemsSource = connection.dtSotrudniki.DefaultView;
            dtSotrudniki.Columns[0].Visibility = Visibility.Collapsed;
            dtSotrudniki.Columns[8].Visibility = Visibility.Collapsed;
            dtSotrudniki.Columns[9].Visibility = Visibility.Collapsed;
            dtSotrudniki.Columns[11].Visibility = Visibility.Collapsed;
        }

        private void cbFill()
        {
            DBConnection connection = new DBConnection();
            connection.PositionFill();
            cbOtdel.ItemsSource = connection.dtWorkerPosition.DefaultView;
            cbOtdel.SelectedValuePath = "ID_Position";
            cbOtdel.DisplayMemberPath = "Position";
        }

        private void dtSotrudniki_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch (e.Column.Header)
            {
                case ("Surname"):
                    e.Column.Header = "Фамилия сотрудники";
                    break;
                case ("Name"):
                    e.Column.Header = "Имя сотрудники";
                    break;
                case ("Middle_Name"):
                    e.Column.Header = "Отчество сотрудники";
                    break;
                case ("Date_Of_Birth"):
                    e.Column.Header = "Дата рождения";
                    break;
                case ("Passport_Number"):
                    e.Column.Header = "Серия паспорта";
                    break;
                case ("Passport_Series"):
                    e.Column.Header = "Номер паспорта";
                    break;
                case ("User_Name"):
                    e.Column.Header = "Логин сотрудника";
                    break;
                case ("Password"):
                    e.Column.Header = "Пароль сотрудника";
                    break;
                case ("Position"):
                    e.Column.Header = "Название отдела";
                    break;
            }
        }

        private void BtSotrudnikInsertType_Click(object sender, RoutedEventArgs e)
        {
            procedures.gucSotrudniki_insert(tbName_Sotrudnika.Text.ToString(), tbMidlle_Name_Sotrudnika.Text.ToString(), tbLast_Name_Sotrudnika.Text.ToString(),
               tbDate_Sotrudnika.Text.ToString(), Convert.ToInt32(tbSeries_Sotrudnika.Text.ToString()), Convert.ToInt32(tbNumber_Sotrudnika.Text.ToString()), tbLogin_Sotrudnika.Text.ToString(),
               tbPassword_Sotrudnika.Text.ToString(), Convert.ToInt32(cbOtdel.SelectedValue.ToString()));

            dtFill(QR);
            cbFill();
        }

        private void BtSotrudnikUpdateType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dtSotrudniki.SelectedItems[0];
            procedures.gucSotrudniki_update(Convert.ToInt32(ID["ID_Sotrudnik"]), tbName_Sotrudnika.Text.ToString(), tbMidlle_Name_Sotrudnika.Text.ToString(), tbLast_Name_Sotrudnika.Text.ToString(),
               tbDate_Sotrudnika.Text.ToString(), Convert.ToInt32(tbSeries_Sotrudnika.Text.ToString()), Convert.ToInt32(tbNumber_Sotrudnika.Text.ToString()), tbLogin_Sotrudnika.Text.ToString(),
               tbPassword_Sotrudnika.Text.ToString(), Convert.ToInt32(cbOtdel.SelectedValue.ToString()));

            dtFill(QR);
            cbFill();
        }

        private void BtSotrudnikDeleteType_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ID = (DataRowView)dtSotrudniki.SelectedItems[0];
            procedures.gucSotrudniki_delete(Convert.ToInt32(ID["ID_Sotrudnik"]));

            dtFill(QR);
            cbFill();
        }

        private void BtClose_Click(object sender, RoutedEventArgs e)
        {
            Perexod perexod = new Perexod();
            perexod.Show();
            Visibility = Visibility.Collapsed;
        }

        private void BtSearch_Click(object sender, RoutedEventArgs e)
        {
            switch (chbFilter.IsChecked)
            {
                case (true):
                    string newQR = QR + "where [Surname] like '%" + tbSearch.Text + "%' or " +
                "[Name] like '%" + tbSearch.Text + "%' or " +
                "[Middle_Name] like '%" + tbSearch.Text + "%' or " +
                "[Date_Of_Birth] like '%" + tbSearch.Text + "%' or " +
                "[Passport_Number] like '%" + tbSearch.Text + "%' or " +
                "[Passport_Series] like '%" + tbSearch.Text + "%' or " +
                "[User_Name] like '%" + tbSearch.Text + "%' or " +
                "[Password] like '%" + tbSearch.Text + "%' or " +
                "[Position] like '%" + tbSearch.Text + "%'";
                    dtFill(newQR);
                    break;
                case (false):
                    foreach (DataRowView dataRow in (DataView)dtSotrudniki.ItemsSource)
                    {
                        if (dataRow.Row.ItemArray[1].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[2].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[3].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[4].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[5].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[7].ToString() == tbSearch.Text ||
                            dataRow.Row.ItemArray[10].ToString() == tbSearch.Text)
                        {
                            dtSotrudniki.SelectedItem = dataRow;
                        }
                    }
                    break;
            }
        }

        private void ChbFilter_Click(object sender, RoutedEventArgs e)
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
