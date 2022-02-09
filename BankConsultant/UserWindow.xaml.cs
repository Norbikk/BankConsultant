using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class UserWindow : Page
    {
        
        private WorkWithJson WorkWithJson = new WorkWithJson();
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

            Pew.Text = $"db Count = {PersonDataBase.Db.Count}";
            WorkWithJson.DatabaseToJson();
  
        }

        /// <summary>
        /// Добавление нового Person'a в List
        /// </summary>
        private void AddNewPerson()
        {
            
            if (IsFailed())
            {
                PersonDataBase.Db.Add(new Person(Name.Text,
                    Surname.Text,
                    SecondName.Text,
                    PassportSeries.Text,
                    PassportNumber.Text,
                    PhoneNumber.Text)
                );
            }
            else
            {
                Name.Text = "Введите корректное имя";
                Surname.Text = "Введите корректную фамилию";
                SecondName.Text = "Введите корректное отчество";
                PassportSeries.Text = "Введите числа";
                PassportNumber.Text = "Введите числа";
                PhoneNumber.Text = "Введите числа";
            }

            
        }

        private bool IsFailed()
        {
            if (String.IsNullOrEmpty(Name.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(Surname.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(SecondName.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(PassportSeries.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(PassportNumber.Text))
            {
                return false;
            }

            if (String.IsNullOrEmpty(PhoneNumber.Text))
            {
                return false;
            }
            int number;
            long longNumber;
            bool isNumeric = Int32.TryParse(PassportSeries.Text, out number) && Int32.TryParse(PassportNumber.Text, out number ) && Int64.TryParse(PhoneNumber.Text, out longNumber);
            if (!isNumeric)
            {
                return false;
            }

            return true;
        }
    }
}