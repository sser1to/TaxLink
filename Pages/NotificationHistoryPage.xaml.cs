using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaxLink.Windows;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotificationHistoryPage.xaml
    /// </summary>
    public partial class NotificationHistoryPage : Page
    {
        public NotificationHistoryPage()
        {
            InitializeComponent();

            // Вывод всех уведомлений
            foreach (string item in NotificationHistory.Notifications)
            {
                lbx.Items.Add(item);
            }
        }

        private void CloseBtn(object sender, MouseButtonEventArgs e)
        {
            AdminWindow.Instance.borderForFrame4.Visibility = Visibility.Hidden;
            AdminWindow.Instance.frame4.NavigationService.Navigate(null);
        }
    }
}
