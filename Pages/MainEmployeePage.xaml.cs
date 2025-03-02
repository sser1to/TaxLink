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
    /// Логика взаимодействия для MainEmployeePage.xaml
    /// </summary>
    public partial class MainEmployeePage : Page
    {
        public MainEmployeePage()
        {
            InitializeComponent();
        }

        private void ClarkBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с Кларком
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.ClarkPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style2;
            EmployeeWindow.Instance.br3.Style = style2;
        }

        private void TaxpayersBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налогоплательшики
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.EmployeeTaxpayersPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForEmployeeTaxpayersPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style2;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style3;
        }

        private void PropertyBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Собственность
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.EmployeePropertyPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForEmployeePropertyPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style2;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style3;
        }

        private void TaxBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Налоги
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.EmployeeTaxPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForEmployeeTaxPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style2;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style3;
        }

        private void ArrearsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Задолженности
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.EmployeeArrearsPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForEmployeeArrearsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style2;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style3;
        }

        private void PaymentsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Платежи
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.EmployeePaymentsPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForEmployeePaymentsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style2;

            EmployeeWindow.Instance.br1.Style = style3;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style3;
        }

        private void SettingsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с настройками
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.SettingsPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style2;
            EmployeeWindow.Instance.br2.Style = style3;
            EmployeeWindow.Instance.br3.Style = style2;
        }

        private void InfographicsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с инфографикой
            EmployeeWindow.Instance.frame1.NavigationService.Navigate(new Pages.InfographicsPage());
            EmployeeWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            EmployeeWindow.Instance.btn1.Style = style1;
            EmployeeWindow.Instance.btn2.Style = style1;
            EmployeeWindow.Instance.btn3.Style = style1;
            EmployeeWindow.Instance.btn4.Style = style1;
            EmployeeWindow.Instance.btn5.Style = style1;
            EmployeeWindow.Instance.btn6.Style = style1;

            EmployeeWindow.Instance.br1.Style = style2;
            EmployeeWindow.Instance.br2.Style = style2;
            EmployeeWindow.Instance.br3.Style = style3;
        }
    }
}
