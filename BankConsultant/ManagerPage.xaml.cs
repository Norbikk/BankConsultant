using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ManagerPage : Page
    {
        private Manager Manager{ get; }

        private WorkWithJson WorkWithJson = new WorkWithJson();

        /// <summary>
        /// Основной метод страницы консультанта
        /// </summary>
        public ManagerPage()
        {
            Manager = new Manager();
            InitializeComponent();
            WorkWithJson.DeserializePersonJson();
            var personsInfo = Manager.GetUsers();
            ListDbView.ItemsSource = personsInfo;

        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        private void OnClickEditButton(object sender, RoutedEventArgs e)
        {
            Edit();
            WorkWithJson.DatabaseToJson();
        }
        /// <summary>
        /// Нажатие на юзера из листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickUser(object sender, RoutedEventArgs e)
        {
            if (ListDbView.SelectedIndex > -1)
            {
                ListDbView.SelectedItem = PersonDataBase.Db[ListDbView.SelectedIndex];
                SelectionItem();
            }


        }

        /// <summary>
        /// Перенос выбранных данных
        /// </summary>
        private void SelectionItem()
        {
            var personInfo = Manager.GetUserById(ListDbView.SelectedIndex);
            Name.Text = personInfo.Name;
            Surname.Text = personInfo.Surname;
            SecondName.Text = personInfo.SecondName;
            PhoneNumber.Text = personInfo.PhoneNumber.ToString();
            PassportSeries.Text = personInfo.PassportSeries;
            PassportNumber.Text = personInfo.PassportNumber;
        }

        private void Edit()
         {
             Manager.UpdatePerson(ListDbView.SelectedIndex, new Person(Name.Text,
                     Surname.Text,
                     SecondName.Text,
                     Convert.ToString(PassportSeries.Text),
                     Convert.ToString(PassportNumber.Text),
                     Convert.ToString(PhoneNumber.Text)));
         }

        
    
    }
}