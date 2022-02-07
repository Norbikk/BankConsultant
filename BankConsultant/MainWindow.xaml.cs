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
        private Page _p2;

        public MainWindow()
        {
            InitializeComponent();
            _p1 = new UserWindow();
            _p2 = new ConsultantPage();
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
            MainFrame.Content = _p2;
            Title = "Консультант";
        }
    }
}