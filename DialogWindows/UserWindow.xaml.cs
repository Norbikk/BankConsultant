using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class UserWindow : Page
    {
        private WorkWithJson _workWithJson { get; set; } = new WorkWithJson();
        private List<TextBox> _textBoxes { get; set; } = new();


        /// <summary>
        /// Оснвной метод страницы Юзера
        /// </summary>
        public UserWindow()
        {
            InitializeComponent();
            AddInList();
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
            _workWithJson.DatabaseToJson(PersonDataBase.Db, "db.json");
        }

        /// <summary>
        /// Добавление нового Person'a в List
        /// </summary>
        private void AddNewPerson()
        {
            if (IsEmpty() || IsString())
            {
                MessageBox.Show("Все поля должны быть заполнены!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!IsNumeric())
            {
                MessageBox.Show("В паспортных данных и номере телефона должны быть числа!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


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

        /// <summary>
        /// Добавляет все текстбоксы в лист
        /// </summary>
        private void AddInList()
        {
            _textBoxes.Add(Name);
            _textBoxes.Add(Surname);
            _textBoxes.Add(SecondName);
            _textBoxes.Add(PassportSeries);
            _textBoxes.Add(PassportNumber);
            _textBoxes.Add(PhoneNumber);
        }

        /// <summary>
        /// Проверяет введены ли в строки цифры
        /// </summary>
        /// <returns>Возвращает true</returns>
        private bool IsNumeric()
        {
            bool isNumeric = Int32.TryParse(PassportSeries.Text, out _) &&
                             Int32.TryParse(PassportNumber.Text, out _) &&
                             Int64.TryParse(PhoneNumber.Text, out _);
            
            
                

            return isNumeric;
        }


        private string AddTextIsNotNumeric(string text)
        {
            if (Int32.TryParse(text, out _) || Int64.TryParse(text, out _))
            {
                return "Введите число";
            }
            return text;
        }
        /// <summary>
        /// Проверяет пустые ли строки
        /// </summary>
        /// <returns>возвращает False</returns>
        private bool IsEmpty()
        {
            var str = "Введите корректное значение";
            for (int i = 0; i < _textBoxes.Count; i++)
            {
                if (_textBoxes[i].Text.Length <= 0)
                {
                    _textBoxes[i].Text = str;
                    
                    if (i == _textBoxes.Count)
                    {
                        
                        return true;
                        
                    }
                    
                }
            }
            return false;
        }

        /// <summary>
        /// Проверяет на дефолтную фразу
        /// </summary>
        /// <returns>возвращает false</returns>
        private bool IsString()
        {
            var str = "Введите корректное значение";
            for (int i = 0; i < _textBoxes.Count; i++)
            {
                if (_textBoxes[i].Text == str)
                {
                        return true;
                }
            }
            return false;
        }


    }
}