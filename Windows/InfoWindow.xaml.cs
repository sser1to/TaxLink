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
using System.Windows.Shapes;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для InfoWindow.xaml
    /// </summary>
    public partial class InfoWindow : Window
    {
        public InfoWindow()
        {
            InitializeComponent();

            string user = "";

            // Вывод текущего пользователя
            switch (CurrentUser.TypeUser)
            {
                case 1:
                    user = "Администратор";
                    break;
                case 2:
                    user = "Налоговый инспектор";
                    break;
                case 3:
                    user = "Налогоплательщик";
                    break;
            }
            lb1.Content = $"Пользователь: {user}";
        }

        private void DeveloperClick(object sender, RoutedEventArgs e)
        {
            string url = "https://t.me/n1krus54";

            // Открытие ссылки в браузере
            try
            {
                System.Diagnostics.Process.Start(url);
            }
            catch
            {
                MessageBox.Show("Не удалось открыть браузер!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 11.3 * 10;
        }
    }
}
