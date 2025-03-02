using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Timers;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для NotificationPage.xaml
    /// </summary>
    public partial class NotificationPage : Page
    {
        private System.Timers.Timer timer;

        public NotificationPage(string table, string action)
        {
            InitializeComponent();
            
            // Вывод уведомления
            tbc1.Text = $"Запись в таблице \"{table}\" успешно {action}!";
            string time = DateTime.Now.ToString("HH:mm:ss");

            NotificationHistory.Notifications.Add($"{tbc1.Text}\n({time})");
            
            // Таймер для закрытия окна с уведомлением
            timer = new System.Timers.Timer(5000);
            timer.Elapsed += OnTimedEvent;
            timer.Enabled = true;
        }

        private void CloseBtn(object sender, MouseButtonEventArgs e)
        {
            AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Hidden;
            AdminWindow.Instance.frame3.NavigationService.Navigate(null);
        }

        /// <summary>
        /// Закрытие окна с уведомлением
        /// </summary>
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Hidden;
                AdminWindow.Instance.frame3.NavigationService.Navigate(null);
            });
        }
    }
}
