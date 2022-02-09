using System;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    public partial class ConsultantPage : Page
    {
        private Consultant Consultant { get; }

        private WorkWithJson WorkWithJson = new WorkWithJson();
        //private Consultant _consultant;

        /// <summary>
        /// Основной метод страницы консультанта
        /// </summary>
        public ConsultantPage()
        {
            Consultant = new Consultant();
            InitializeComponent();
            WorkWithJson.DeserializePersonJson();
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

            PersonDataBase.Db[ListDbView.SelectedIndex].PhoneNumber = PhoneNumber.Text;
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
            var personInfo = Consultant.GetUserById(ListDbView.SelectedIndex);
            Name.Text = personInfo.Name;
            Surname.Text = personInfo.Surname;
            SecondName.Text = personInfo.SecondName;
            PhoneNumber.Text = personInfo.PhoneNumber.ToString();
            PassportSeries.Text = personInfo.PassportSeries;
            PassportNumber.Text = personInfo.PassportNumber;
        }

        /* private void Edit()
         {
             Consultant.UpdatePerson(ListDbView.SelectedIndex, new Person(Name.Text,
                     Surname.Text,
                     SecondName.Text,
                     Convert.ToString(PassportSeries.Text),
                     Convert.ToString(PassportNumber.Text),
                     Convert.ToString(PhoneNumber.Text)));
         }
         /// <summary>
         /// Это потом в менеджера
         /// </summary>
         private void OnClickEditButton()
         {
             Edit();
             WorkWithJson.DatabaseToJson();
         }
        */
    
    }
}