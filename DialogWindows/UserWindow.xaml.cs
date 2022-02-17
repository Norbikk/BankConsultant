using System;
using System.Collections.ObjectModel;
using System.Net.Mime;
using System.Windows;
using System.Windows.Controls;
using Microsoft.VisualBasic;

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
            WorkWithJson.DatabaseToJson(PersonDataBase.Db, "db.json");
        }

        /// <summary>
        /// Добавление нового Person'a в List
        /// </summary>
        private void AddNewPerson()
        {
            if (IsFailed())
            {
                PersonDataBase.Db.Add(new Person()
                    {
                        Id = PersonDataBase.Db.Count + 1,
                        Name = Name.Text,
                        Surname = Surname.Text,
                        SecondName = SecondName.Text,
                        PassportSeries = PassportSeries.Text,
                        PassportNumber = PassportNumber.Text,
                        PhoneNumber = PhoneNumber.Text,
                    }
                );
            }
        }

        private bool IsFailed()
        {
            Name.Text = AddTextIsFailed(Name.Text);
            Surname.Text = AddTextIsFailed(Surname.Text);
            SecondName.Text = AddTextIsFailed(SecondName.Text);
            PassportSeries.Text = AddTextIsFailed(PassportSeries.Text);
            PassportNumber.Text = AddTextIsFailed(PassportNumber.Text);
            PhoneNumber.Text = AddTextIsFailed(PhoneNumber.Text);


            bool isNumeric = Int32.TryParse(PassportSeries.Text, out _) &&
                             Int32.TryParse(PassportNumber.Text, out _) &&
                             Int64.TryParse(PhoneNumber.Text, out _);
            PassportSeries.Text = AddTextIsNumeric(PassportSeries.Text);
            PassportNumber.Text = AddTextIsNumeric(PassportNumber.Text);
            PhoneNumber.Text = AddTextIsNumeric(PhoneNumber.Text);
            if (!isNumeric)
            {
                return false;
            }

            return true;
        }

        private string AddTextIsNumeric(string text)
        {
            if (!Int32.TryParse(text, out _) || !Int64.TryParse(text, out _))
            {
                return $"Введите цифры";
            }

            return text;
        }

        private string AddTextIsFailed(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return $"Введите корректное значение {text}";
            }

            return text;
        }
    }
}