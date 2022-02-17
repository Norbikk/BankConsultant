using System;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ConsultantPage : Page
    {
        private Consultant Consultant { get; }


        private WorkWithJson WorkWithJson { get; } = new();

        /// <summary>
        /// Основной метод страницы консультанта
        /// </summary>
        public ConsultantPage()
        {
            Consultant = new Consultant();
            InitializeComponent();
            var personsInfo = Consultant.GetUsers();
            ListDbView.ItemsSource = personsInfo;
        }

        /// <summary>
        /// Нажатие кнопки Save
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBtnSaveClick(object sender, RoutedEventArgs e)
        {
            if (ListDbView.SelectedIndex > -1)
            {
                Consultant.SaveLastChanges(ListDbView.SelectedIndex);
                WorkWithJson.DatabaseToJson(PersonDataBase.LastChangesDb, "lastChanges.json");
                PersonDataBase.Db[ListDbView.SelectedIndex].DateOfChanging = DateTime.Now;
                PersonDataBase.Db[ListDbView.SelectedIndex].WhoChanging = "Консультант";
                PersonDataBase.Db[ListDbView.SelectedIndex].PhoneNumber = PhoneNumber.Text;
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
            Check.Text = Consultant.CheckChanges(ListDbView.SelectedIndex);
        }


        /// <summary>
        /// Перенос выбранных данных
        /// </summary>
        private void SelectionItem()
        {
            var personInfo = Consultant.GetUserById(ListDbView.SelectedIndex);
            WhoChanged.Text = personInfo.WhoChanging;
            Name.Text = personInfo.Name;
            Surname.Text = personInfo.Surname;
            SecondName.Text = personInfo.SecondName;
            PhoneNumber.Text = personInfo.PhoneNumber.ToString();
            PassportSeries.Text = personInfo.PassportSeries;
            PassportNumber.Text = personInfo.PassportNumber;


            WhenChanged.Text = personInfo.DateOfChanging != default
                ? personInfo.DateOfChanging.ToString()
                : String.Empty;
        }
    }
}