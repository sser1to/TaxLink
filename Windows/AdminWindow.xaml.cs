using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml.Linq;
using Style = System.Windows.Style;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public static TaxInspectionEntities1 baza;
        public static AdminWindow Instance { get; private set; }

        public AdminWindow()
        {
            InitializeComponent();
            Instance = this;

            baza = new TaxInspectionEntities1();

            frame1.NavigationService.Navigate(new Pages.MainAdminPage());

            this.PreviewKeyDown += MainWindow_PreviewKeyDown;

            // Таймер для обновления времени
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
                btn4.Style = style1;
                btn5.Style = style1;
                btn6.Style = style1;
                btn7.Style = style1;
                btn8.Style = style1;

                br1.Style = style3;
                br2.Style = style2;
                br3.Style = style2;
                br4.Style = style2;
                br5.Style = style2;
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
            frame1.NavigationService.Navigate(new Pages.MainAdminPage());
            frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style2;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
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
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style2;
            br3.Style = style2;
            br4.Style = style2;
            br5.Style = style2;
        }

        private void LogsBtn(object sender, MouseButtonEventArgs e)
        {
            // Переход к странице с журналом логов
            frame1.NavigationService.Navigate(new Pages.LogsPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForLogsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style2;
            br2.Style = style2;
            br3.Style = style3;
            br4.Style = style2;
            br5.Style = style2;
        }

        private void ExitBtn(object sender, MouseButtonEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти из аккаунта?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                NotificationHistory.Notifications.Clear();
                AuthorizationWindow authorizationWindow = new AuthorizationWindow();
                authorizationWindow.Show();
                this.Close();
            }
        }

        private void PropertyBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Собственность
            frame1.NavigationService.Navigate(new Pages.AdminPropertyPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminPropertyPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style2;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void TaxBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налоги
            frame1.NavigationService.Navigate(new Pages.AdminTaxPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style2;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void ArrearsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Задолженности
            frame1.NavigationService.Navigate(new Pages.AdminArrearsPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminArrearsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style2;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void PaymentsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Платежи
            frame1.NavigationService.Navigate(new Pages.AdminPaymentsPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminPaymentsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style2;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void TaxRateBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налоговые ставки
            frame1.NavigationService.Navigate(new Pages.AdminTaxRatePage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxRatePage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style2;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void EmployeeBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Сотрудники
            frame1.NavigationService.Navigate(new Pages.AdminEmployeePage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminEmployeePage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style2;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
        }

        private void TaxpayersBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налогоплательшики
            frame1.NavigationService.Navigate(new Pages.AdminTaxpayersPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxpayersPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            btn1.Style = style1;
            btn2.Style = style2;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style3;
            br2.Style = style3;
            br3.Style = style3;
            br4.Style = style3;
            br5.Style = style3;
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
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style2;
            br2.Style = style2;
            br3.Style = style2;
            br4.Style = style3;
            br5.Style = style2;
        }

        private void HistoryBtn(object sender, MouseButtonEventArgs e)
        {
            // Переход к странице с историей действий
            frame1.NavigationService.Navigate(new Pages.HistoryPage());
            frame2.NavigationService.Navigate(new Pages.Filters.FilterForHistoryPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style2;
            br2.Style = style3;
            br3.Style = style2;
            br4.Style = style2;
            br5.Style = style2;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 16 * 9;
        }

        private void BellBtn(object sender, MouseButtonEventArgs e)
        {
            // Открытие/Закрытие окна с историей уведомлений
            if (borderForFrame4.Visibility == Visibility.Hidden)
            {
                borderForFrame4.Visibility = Visibility.Visible;
                frame4.NavigationService.Navigate(new Pages.NotificationHistoryPage());
            }
            else
            {
                borderForFrame4.Visibility = Visibility.Hidden;
                frame4.NavigationService.Navigate(null);
            }
        }

        private void InfoBtn(object sender, MouseButtonEventArgs e)
        {
            // Открытие окна с информацией о приложении
            InfoWindow infoWindow = new InfoWindow();
            infoWindow.ShowDialog();
        }

        private void ChartBtn(object sender, MouseButtonEventArgs e)
        {
            // Переход к странице с инфографикой
            frame1.NavigationService.Navigate(new Pages.InfographicsPage());
            frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            btn1.Style = style1;
            btn2.Style = style1;
            btn3.Style = style1;
            btn4.Style = style1;
            btn5.Style = style1;
            btn6.Style = style1;
            btn7.Style = style1;
            btn8.Style = style1;

            br1.Style = style2;
            br2.Style = style2;
            br3.Style = style2;
            br4.Style = style2;
            br5.Style = style3;
        }
    }
}