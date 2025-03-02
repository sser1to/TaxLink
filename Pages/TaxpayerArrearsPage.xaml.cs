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
    /// Логика взаимодействия для TaxpayerArrearsPage.xaml
    /// </summary>
    public partial class TaxpayerArrearsPage : Page
    {
        public static TaxpayerArrearsPage Instance { get; private set; }

        public TaxpayerArrearsPage()
        {
            InitializeComponent();
            Instance = this;
            dg1.ItemsSource = TaxpayerWindow.baza.Arrears.Where(arrear => arrear.Tax.Taxpayer.Login == CurrentUser.Login).ToList();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dg1.SelectedItem as Arrears;

            // Отображение в dg2 собственности, включенной в задолженность
            var taxpayerId = selectedItem.Tax.IdTaxpayer;
            var properties = TaxpayerWindow.baza.Property.Where(p => p.IdTaxpayer == taxpayerId);

            dg2.ItemsSource = properties.ToList();
        }
    }
}
