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
    /// Логика взаимодействия для TaxpayerPaymentsPage.xaml
    /// </summary>
    public partial class TaxpayerPaymentsPage : Page
    {
        public static TaxpayerPaymentsPage Instance { get; private set; }

        public TaxpayerPaymentsPage()
        {
            InitializeComponent();
            Instance = this;
            dg1.ItemsSource = TaxpayerWindow.baza.Payment.Where(p => p.Tax.Taxpayer.Login == CurrentUser.Login).ToList();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dg1.SelectedItem as Payment;

            // Отображение в dg2 собственности, включенной в платеж
            if (selectedItem.TypeOfPayment == true)
            {
                var taxpayerId = selectedItem.Arrears.IdTaxpayer;
                var properties = TaxpayerWindow.baza.Property.Where(p => p.IdTaxpayer == taxpayerId);
                dg2.ItemsSource = properties.ToList();     
            }
            else
            {
                var taxpayerId = selectedItem.Tax.IdTaxpayer;
                var properties = TaxpayerWindow.baza.Property.Where(p => p.IdTaxpayer == taxpayerId);
                dg2.ItemsSource = properties.ToList();
            }  
        }
    }
}
