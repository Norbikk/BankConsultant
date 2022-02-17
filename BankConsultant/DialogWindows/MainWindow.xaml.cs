using System.Windows;
using System.Windows.Controls;

namespace BankConsultant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Page _p1;

        public MainWindow()
        {
            InitializeComponent();
            PersonDataBase.Db = WorkWithJson.DeserializePersonJson("db.json");
            PersonDataBase.LastChangesDb = WorkWithJson.DeserializePersonJson("lastChanges.json");
            _p1 = new UserWindow();
        }

        /// <summary>
        /// Выбор страницы пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPage1Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = _p1;
            Title = "Пользователь";
        }

        /// <summary>
        /// Выбор страницы консультанта
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPage2Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ConsultantPage();
            Title = "Консультант";
        }

        private void BtnPage3Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new ManagerPage();
            Title = "Менеджер";
        }
    }
}