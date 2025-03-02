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
    /// Логика взаимодействия для MainTaxpayerPage.xaml
    /// </summary>
    public partial class MainTaxpayerPage : Page
    {
        public MainTaxpayerPage()
        {
            InitializeComponent();
        }

        private void ClarkBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с Кларком
            TaxpayerWindow.Instance.frame1.NavigationService.Navigate(new Pages.ClarkPage());
            TaxpayerWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            TaxpayerWindow.Instance.btn1.Style = style1;
            TaxpayerWindow.Instance.btn2.Style = style1;
            TaxpayerWindow.Instance.btn3.Style = style1;

            TaxpayerWindow.Instance.br1.Style = style3;
            TaxpayerWindow.Instance.br2.Style = style2;
        }

        private void PaymentsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Платежи
            TaxpayerWindow.Instance.frame1.NavigationService.Navigate(new Pages.TaxpayerPaymentsPage());
            TaxpayerWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForTaxpayerPaymentsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            TaxpayerWindow.Instance.btn1.Style = style1;
            TaxpayerWindow.Instance.btn2.Style = style2;
            TaxpayerWindow.Instance.btn3.Style = style1;

            TaxpayerWindow.Instance.br1.Style = style3;
            TaxpayerWindow.Instance.br2.Style = style3;
        }

        private void ArrearsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с таблицей Задолженности
            TaxpayerWindow.Instance.frame1.NavigationService.Navigate(new Pages.TaxpayerArrearsPage());
            TaxpayerWindow.Instance.frame2.NavigationService.Navigate(new Pages.Filters.FilterForTaxpayerArrearsPage());

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Btn2");
            Style style3 = (Style)FindResource("Bord3");

            TaxpayerWindow.Instance.btn1.Style = style1;
            TaxpayerWindow.Instance.btn2.Style = style1;
            TaxpayerWindow.Instance.btn3.Style = style2;

            TaxpayerWindow.Instance.br1.Style = style3;
            TaxpayerWindow.Instance.br2.Style = style3;
        }

        private void SettingsBtn(object sender, RoutedEventArgs e)
        {
            // Переход к странице с настройками
            TaxpayerWindow.Instance.frame1.NavigationService.Navigate(new Pages.SettingsPage());
            TaxpayerWindow.Instance.frame2.NavigationService.Navigate(null);

            Style style1 = (Style)FindResource("Btn1");
            Style style2 = (Style)FindResource("Bord3");
            Style style3 = (Style)FindResource("Bord4");

            TaxpayerWindow.Instance.btn1.Style = style1;
            TaxpayerWindow.Instance.btn2.Style = style1;
            TaxpayerWindow.Instance.btn3.Style = style1;

            TaxpayerWindow.Instance.br1.Style = style2;
            TaxpayerWindow.Instance.br2.Style = style3;
        }
    }
}
