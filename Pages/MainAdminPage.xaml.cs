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
    /// Логика взаимодействия для MainAdminPage.xaml
    /// </summary>
    public partial class MainAdminPage : Page
    {
        public MainAdminPage()
        {
            InitializeComponent();
        }

        private void ClarkBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с Кларком
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.ClarkPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style2;
            AdminWindow.Instance.br3.Style = style2;
            AdminWindow.Instance.br4.Style = style2;
            AdminWindow.Instance.br5.Style = style2;
        }

        private void TaxpayersBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налогоплательшики
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminTaxpayersPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxpayersPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style2;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void PropertyBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Собственность
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminPropertyPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminPropertyPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style2;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void TaxBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налоги
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminTaxPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style2;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void ArrearsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Задолженности
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminArrearsPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminArrearsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style2;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void PaymentsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Платежи
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminPaymentsPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminPaymentsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style2;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void TaxRateBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налоговые ставки
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminTaxRatePage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminTaxRatePage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style2;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void EmployeeBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Сотрудники
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.AdminEmployeePage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForAdminEmployeePage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style2;

            AdminWindow.Instance.br1.Style = style3;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style3;
        }

        private void LogsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с журналом логов
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.LogsPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForLogsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style2;
            AdminWindow.Instance.br2.Style = style2;
            AdminWindow.Instance.br3.Style = style3;
            AdminWindow.Instance.br4.Style = style2;
            AdminWindow.Instance.br5.Style = style2;
        }

        private void HistoryBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с историей действий
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.HistoryPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForHistoryPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style2;
            AdminWindow.Instance.br2.Style = style3;
            AdminWindow.Instance.br3.Style = style2;
            AdminWindow.Instance.br4.Style = style2;
            AdminWindow.Instance.br5.Style = style2;
        }

        private void SettingsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с настройками
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.SettingsPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style2;
            AdminWindow.Instance.br2.Style = style2;
            AdminWindow.Instance.br3.Style = style2;
            AdminWindow.Instance.br4.Style = style3;
            AdminWindow.Instance.br5.Style = style2;
        }

        private void InfographicsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с инфографикой
            AdminWindow.Instance.frame1.NavigationService.Navigate(new Pages.InfographicsPage());
            AdminWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            AdminWindow.Instance.btn1.Style = style1;
            AdminWindow.Instance.btn2.Style = style1;
            AdminWindow.Instance.btn3.Style = style1;
            AdminWindow.Instance.btn4.Style = style1;
            AdminWindow.Instance.btn5.Style = style1;
            AdminWindow.Instance.btn6.Style = style1;
            AdminWindow.Instance.btn7.Style = style1;
            AdminWindow.Instance.btn8.Style = style1;

            AdminWindow.Instance.br1.Style = style2;
            AdminWindow.Instance.br2.Style = style2;
            AdminWindow.Instance.br3.Style = style2;
            AdminWindow.Instance.br4.Style = style2;
            AdminWindow.Instance.br5.Style = style3;
        }
    }
}
