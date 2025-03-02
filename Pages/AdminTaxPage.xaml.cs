using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для AdminTaxPage.xaml
    /// </summary>
    public partial class AdminTaxPage : Page
    {
        public static AdminTaxPage Instance { get; private set; }

        public AdminTaxPage()
        {
            InitializeComponent();
            Instance = this;
            dg1.ItemsSource = AdminWindow.baza.Tax.ToList();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = dg1.SelectedItem as Tax;

            if (selectedItem == null)
            {
                dg2.ItemsSource = null;
                return;
            }

            // Отображение в dg2 собственности, включенной в налог
            var taxpayerId = selectedItem.Taxpayer.IdTaxpayer;
            var properties = AdminWindow.baza.Property.Where(p => p.IdTaxpayer == taxpayerId);
            dg2.ItemsSource = properties.ToList();
        }
    }
}
