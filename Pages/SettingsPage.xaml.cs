using System;
using System.Collections.Generic;
using System.IO;
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

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        // Конфигурация для настроек
        int theme = CurrentSettings.Theme;
        bool notifications = CurrentSettings.Notifications;
        int fontSize = CurrentSettings.FontSize;
        int numberOfEntriesPerPage = CurrentSettings.NumberOfEntriesPerPage;

        public SettingsPage()
        {
            InitializeComponent();

            // Изменение элементво страницы в соответствии с конфигурацией

            if (CurrentSettings.Notifications == true)
            {
                cb1.IsChecked = true;
            }
            else
            {
                cb1.IsChecked = false;
            }

            switch (CurrentSettings.Theme)
            {
                case 1:
                    br1.BorderBrush = new SolidColorBrush(Colors.Blue);
                    br1.BorderThickness = new Thickness(2);
                    break;
                case 2:
                    br2.BorderBrush = new SolidColorBrush(Colors.Blue);
                    br2.BorderThickness = new Thickness(2);
                    break;
                case 3:
                    br3.BorderBrush = new SolidColorBrush(Colors.Blue);
                    br3.BorderThickness = new Thickness(2);
                    break;
                case 4:
                    br4.BorderBrush = new SolidColorBrush(Colors.Blue);
                    br4.BorderThickness = new Thickness(2);
                    break;
            }

            tbx1.Text = CurrentSettings.FontSize.ToString();

            sl1.Minimum = 14;
            sl1.Maximum = 18;

            sl1.TickFrequency = 1;

            sl1.Ticks = new DoubleCollection(new double[] { 14, 15, 16, 17, 18 });

            sl1.Value = CurrentSettings.FontSize;

            sl1.IsSnapToTickEnabled = true;

            lb1.FontSize = CurrentSettings.FontSize;

            tbx2.Text = CurrentSettings.NumberOfEntriesPerPage.ToString();

            sl2.Minimum = 5;
            sl2.Maximum = 20;

            sl2.TickFrequency = 5;

            sl2.Ticks = new DoubleCollection(new double[] { 5, 10, 15, 20 });

            sl2.Value = CurrentSettings.NumberOfEntriesPerPage;

            sl2.IsSnapToTickEnabled = true;
        }

        private void ApplyBtn(object sender, RoutedEventArgs e)
        {
            CurrentSettings.Theme = theme;
            CurrentSettings.Notifications = notifications;
            CurrentSettings.FontSize = fontSize;
            CurrentSettings.NumberOfEntriesPerPage = numberOfEntriesPerPage;

            // Путь к конфигурации
            string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string FilePath = System.IO.Path.Combine(executablePath, "config.txt");

            // Запись конфигурации
            using (StreamWriter writer = new StreamWriter(FilePath))
            {
                writer.WriteLine("theme=" + theme);
                writer.WriteLine("notifications=" + notifications);
                writer.WriteLine("fontSize=" + fontSize);
                writer.WriteLine("numberOfEntriesPerPage=" + numberOfEntriesPerPage);
            }

            MessageBox.Show("Для применения новых настроек требуется перезапустить программу!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Br1Btn(object sender, MouseButtonEventArgs e)
        {
            br1.BorderBrush = new SolidColorBrush(Colors.Blue);
            br1.BorderThickness = new Thickness(2);
            br2.BorderBrush = new SolidColorBrush(Colors.Black);
            br2.BorderThickness = new Thickness(1);
            br3.BorderBrush = new SolidColorBrush(Colors.Black);
            br3.BorderThickness = new Thickness(1);
            br4.BorderBrush = new SolidColorBrush(Colors.Black);
            br4.BorderThickness = new Thickness(1);
            theme = 1;
        }

        private void Br2Btn(object sender, MouseButtonEventArgs e)
        {
            br1.BorderBrush = new SolidColorBrush(Colors.Black);
            br1.BorderThickness = new Thickness(1);
            br2.BorderBrush = new SolidColorBrush(Colors.Blue);
            br2.BorderThickness = new Thickness(2);
            br3.BorderBrush = new SolidColorBrush(Colors.Black);
            br3.BorderThickness = new Thickness(1);
            br4.BorderBrush = new SolidColorBrush(Colors.Black);
            br4.BorderThickness = new Thickness(1);
            theme = 2;
        }

        private void Br3Btn(object sender, MouseButtonEventArgs e)
        {
            br1.BorderBrush = new SolidColorBrush(Colors.Black);
            br1.BorderThickness = new Thickness(1);
            br2.BorderBrush = new SolidColorBrush(Colors.Black);
            br2.BorderThickness = new Thickness(1);
            br3.BorderBrush = new SolidColorBrush(Colors.Blue);
            br3.BorderThickness = new Thickness(2);
            br4.BorderBrush = new SolidColorBrush(Colors.Black);
            br4.BorderThickness = new Thickness(1);
            theme = 3;
        }

        private void Br4Btn(object sender, MouseButtonEventArgs e)
        {
            br1.BorderBrush = new SolidColorBrush(Colors.Black);
            br1.BorderThickness = new Thickness(1);
            br2.BorderBrush = new SolidColorBrush(Colors.Black);
            br2.BorderThickness = new Thickness(1);
            br3.BorderBrush = new SolidColorBrush(Colors.Black);
            br3.BorderThickness = new Thickness(1);
            br4.BorderBrush = new SolidColorBrush(Colors.Blue);
            br4.BorderThickness = new Thickness(2);
            theme = 4;
        }

        private void Cb1Click(object sender, RoutedEventArgs e)
        {
            if (cb1.IsChecked == true)
            {
                notifications = true;
            }
            else
            {
                notifications = false;
            }
        }

        private void sl1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbx1.Text = sl1.Value.ToString();
            lb1.FontSize = sl1.Value;
            fontSize = (int)sl1.Value;
        }

        private void DefaultBtn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите сбросить настройки?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                br1.BorderBrush = new SolidColorBrush(Colors.Blue);
                br1.BorderThickness = new Thickness(2);
                br2.BorderBrush = new SolidColorBrush(Colors.Black);
                br2.BorderThickness = new Thickness(1);
                br3.BorderBrush = new SolidColorBrush(Colors.Black);
                br3.BorderThickness = new Thickness(1);
                br4.BorderBrush = new SolidColorBrush(Colors.Black);
                br4.BorderThickness = new Thickness(1);
                theme = 1;
                CurrentSettings.Theme = theme;

                cb1.IsChecked = true;
                notifications = true;
                CurrentSettings.Notifications = notifications;

                fontSize = 14;
                tbx1.Text = fontSize.ToString();
                sl1.Value = fontSize;

                CurrentSettings.NumberOfEntriesPerPage = numberOfEntriesPerPage;

                // Путь к конфигурации
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string FilePath = System.IO.Path.Combine(executablePath, "config.txt");
                
                // Запись конфигурации
                using (StreamWriter writer = new StreamWriter(FilePath))
                {
                    writer.WriteLine("theme=" + theme);
                    writer.WriteLine("notifications=" + notifications);
                    writer.WriteLine("fontSize=" + fontSize);
                    writer.WriteLine("numberOfEntriesPerPage=" + numberOfEntriesPerPage);
                }

                MessageBox.Show("Для применения новых настроек требуется перезапустить программу.", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void sl2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            tbx2.Text = sl2.Value.ToString();
            numberOfEntriesPerPage = (int)sl2.Value;
        }
    }
}
