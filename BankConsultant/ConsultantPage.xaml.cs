using System;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ConsultantPage : Page
    {
        /// <summary>
        /// Основной метод страницы консультанта
        /// </summary>
        public ConsultantPage()
        {
            InitializeComponent();
            WorkWithJson.DeserializePersonJson();
            ListDbView.ItemsSource = UserWindow.Db;
        }

        /// <summary>
        /// Нажатие кнопки Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnSaveClick(object sender, RoutedEventArgs e)
        {
            UserWindow.Db[ListDbView.SelectedIndex].PhoneNumber = Convert.ToInt64(PhoneName.Text);
            WorkWithJson.DatabaseToJson();
        }

        /// <summary>
        /// Нажатие на юзера из листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickUser(object sender, RoutedEventArgs e)
        {
            ListDbView.SelectedItem = UserWindow.Db[ListDbView.SelectedIndex];
            SelectedItem();
        }

        /// <summary>
        /// Перенос выбранных данных
        /// </summary>
        private void SelectedItem()
        {
            Name.Text = UserWindow.Db[ListDbView.SelectedIndex].Name;
            Surname.Text = UserWindow.Db[ListDbView.SelectedIndex].Surname;
            SecondName.Text = UserWindow.Db[ListDbView.SelectedIndex].SecondName;
            PhoneName.Text = UserWindow.Db[ListDbView.SelectedIndex].PhoneNumber.ToString();
            PasportSeries.Text = PrivateData(UserWindow.Db[ListDbView.SelectedIndex].PassportSeries.ToString());
            PasportNumber.Text = PrivateData(UserWindow.Db[ListDbView.SelectedIndex].PassportNumber.ToString());
        }

        /// <summary>
        /// Запривачивание данных
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private string PrivateData(string where)
        {
            char[] what = null;
            if (where != null)
            {
                what = where.ToCharArray();

                for (int i = 0; i < what.Length; i++)
                {
                    what[i] = '*';
                }
            }

            var strNew = new string(what);

            return strNew;
        }
    }
}