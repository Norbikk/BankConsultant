using System;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ManagerPage : Page
    {
        private Manager Manager{ get; }
        public WorkWithJson WorkWithJson1 { get => WorkWithJson; set => WorkWithJson = value; }

        private WorkWithJson WorkWithJson = new();

        /// <summary>
        /// Основной метод страницы консультанта
        /// </summary>
        public ManagerPage()
        {
            Manager = new Manager();
            InitializeComponent();
            var personsInfo = Manager.GetUsers();
            ListDbView.ItemsSource = personsInfo;
            

        }

        /// <summary>
        /// Сохранение данных
        /// </summary>
        private void OnClickEditButton(object sender, RoutedEventArgs e)
        {
            if (ListDbView.SelectedIndex > -1)
            {
                Manager.SaveLastChanges(ListDbView.SelectedIndex);
                WorkWithJson1.DatabaseToJson(PersonDataBase.LastChangesDb, "lastChanges.json");
                Edit();
                WorkWithJson1.DatabaseToJson(PersonDataBase.Db, "db.json"); 
            }

            
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
                Check.Text = Manager.CheckChanges(ListDbView.SelectedIndex);
                
            }
        }

      
            
        /// <summary>
        /// Перенос выбранных данных
        /// </summary>
        private void SelectionItem()
        {
            var personInfo = Manager.GetUserById(ListDbView.SelectedIndex);
            WhoChanged.Text = personInfo.WhoChanging;
            Name.Text = personInfo.Name;
            Surname.Text = personInfo.Surname;
            SecondName.Text = personInfo.SecondName;
            PhoneNumber.Text = personInfo.PhoneNumber.ToString();
            PassportSeries.Text = personInfo.PassportSeries;
            PassportNumber.Text = personInfo.PassportNumber;
            if (personInfo.DateOfChanging != default)
            {
                WhenChanged.Text = personInfo.DateOfChanging.ToString();
            }
            else
            {
                WhenChanged.Text = String.Empty;
            }
        }

        private void Edit()
         {
             Manager.UpdatePerson(ListDbView.SelectedIndex, new Person()
             {
                 Id = PersonDataBase.Db[ListDbView.SelectedIndex].Id,
                 Name = Name.Text,
                 Surname = Surname.Text,
                 SecondName = SecondName.Text,
                 PassportSeries = Convert.ToString(PassportSeries.Text),
                 PassportNumber = Convert.ToString(PassportNumber.Text),
                 PhoneNumber = Convert.ToString(PhoneNumber.Text)
             });
         }

    }
}