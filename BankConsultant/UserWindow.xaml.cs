using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class UserWindow : Page
    {
        public static ObservableCollection<Person> Db { get; set; } = new ObservableCollection<Person>();

        /// <summary>
        /// Оснвной метод страницы Юзера
        /// </summary>
        public UserWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку генерации Person'a
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGenerateClick(object sender, RoutedEventArgs e)
        {
            AddNewPerson();

            Pew.Text = $"db Count = {Db.Count}";
            WorkWithJson.DatabaseToJson();
        }

        /// <summary>
        /// Добавление нового Person'a в List
        /// </summary>
        private void AddNewPerson()
        {
            Db.Add(new Person(Name.Text,
                Surname.Text,
                SecondName.Text,
                Convert.ToInt32(PassportSeries.Text),
                Convert.ToInt32(PassportNumber.Text),
                Convert.ToInt64(PhoneNumber.Text))
            );
        }
    }
}