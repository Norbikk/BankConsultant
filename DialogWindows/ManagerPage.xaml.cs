using System;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ManagerPage : Page
    {
        private Manager Manager { get; }


        private WorkWithJson WorkWithJson { get;} = new();

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
                WorkWithJson.DatabaseToJson(PersonDataBase.LastChangesDb, "lastChanges.json");
                Edit();
                WorkWithJson.DatabaseToJson(PersonDataBase.Db, "db.json");
            }
        }

        /// <summary>
        /// Нажатие на юзера из листа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickUser(object sender, RoutedEventArgs e)
        {
            if (ListDbView.SelectedIndex == -1)
            {
                return;
            }

            ListDbView.SelectedItem = PersonDataBase.Db[ListDbView.SelectedIndex];
            SelectionItem();
            Check.Text = Manager.CheckChanges(ListDbView.SelectedIndex);
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

        /// <summary>
        /// Редактирует данные Person[listDbView.SelectedIndex]
        /// </summary>
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

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            PersonDataBase.SortingBase();
            ListDbView.ItemsSource = PersonDataBase.Db;
            WorkWithJson.DatabaseToJson(PersonDataBase.Db, "db.json");
        }

        private void DeleteButton_OnClick(object sender, RoutedEventArgs e)
        {
            PersonDataBase.Remove(ListDbView.SelectedIndex);
            ListDbView.ItemsSource = PersonDataBase.Db;
            WorkWithJson.DatabaseToJson(PersonDataBase.LastChangesDb, "lastChanges.json");
            WorkWithJson.DatabaseToJson(PersonDataBase.Db, "db.json");
        }
    }
}