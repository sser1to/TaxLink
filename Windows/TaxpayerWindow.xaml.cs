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
using System.Windows.Threading;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для TaxpayerWindow.xaml
    /// </summary>
    public partial class TaxpayerWindow : Window
    {
        public static TaxpayerWindow Instance { get; private set; }
        public static TaxInspectionEntities1 baza;

        public TaxpayerWindow()
        {
            InitializeComponent();
            Instance = this;

            baza = new TaxInspectionEntities1();

            frame1.NavigationService.Navigate(new Pages.MainTaxpayerPage());

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            // Переход к странице с Кларком
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            // Переход к странице с Кларком
            if (e.Key == Key.F1)
            {
                frame1.NavigationService.Navigate(new Pages.ClarkPage());
                frame2.NavigationService.Navigate(null);

                Style style1 = (Style)FindResource("Btn1");
                Style style2 = (Style)FindResource("Bord3");
                Style style3 = (Style)FindResource("Bord4");

                btn1.Style = style1;
                btn2.Style = style1;
                btn3.Style = style1;

                br1.Style = style3;
                br2.Style = style2;
            }
        }

        /// <summary>
        /// Обновление времени
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            lb1.Content = DateTime.Now.ToString("HH:mm dd.MM.yyyy");
        }

        private void MainBtn(object sender, RoutedEventArgs e)
        {
            // Переход к главной странице
            frame1.NavigationService.Navigate(new Pages.MainTaxpayerPage());
            frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style2;
            btn2.Style = style1;
            btn3.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
        }

        private void ClarkBtn(object sender, MouseButtonEventArgs e)
        {
            // Переход к странице с Кларком
            frame1.NavigationService.Navigate(new Pages.ClarkPage());
            frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;

            br1.Style = style3;
            br2.Style = style2;
        }

        private void ExitBtn(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }

        private void PaymentsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Платежи
            frame1.NavigationService.Navigate(new Pages.TaxpayerPaymentsPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForTaxpayerPaymentsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style2;
            btn3.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
        }

        private void ArrearsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Задолженности
            frame1.NavigationService.Navigate(new Pages.TaxpayerArrearsPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForTaxpayerArrearsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style2;

            br1.Style = style3;
            br2.Style = style3;
        }

        private void SettingsBtn(object sender, MouseButtonEventArgs e)
        {
            // Переход к странице с настройками
            frame1.NavigationService.Navigate(new Pages.SettingsPage());
            frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;

            br1.Style = style2;
            br2.Style = style3;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 16 * 9;
        }

        private void InfoBtn(object sender, MouseButtonEventArgs e)
        {
            // Открытие окна с информацией о приложении
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.ShowDialog();
        }
    }
}
