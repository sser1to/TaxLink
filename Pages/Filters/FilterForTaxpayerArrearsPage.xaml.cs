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

namespace TaxLink.Pages.Filters
{
    /// <summary>
    /// Логика взаимодействия для FilterForTaxpayerArrearsPage.xaml
    /// </summary>
    public partial class FilterForTaxpayerArrearsPage : Page
    {
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public FilterForTaxpayerArrearsPage()
        {
            InitializeComponent();
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        /// <summary>
        /// Обновление для фильтров и постраничного вывода
        /// </summary>
        private void UpdateView()
        {
            string text1 = tbx1.Text;

            var items = TaxpayerWindow.baza.Arrears.Where(p => p.Tax.Taxpayer.Login == CurrentUser.Login).AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => t.StartDate.ToString("dd.MM.yy HH:mm:ss").Contains(text1));
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdArrears).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            TaxpayerArrearsPage.Instance.dg1.ItemsSource = itemsPage.ToList();
        }

        private void tbx1_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            tbx1.Text = "";
            currentPage = 1;
            UpdateView();
        }

        private void PreviosPageBtn(object sender, RoutedEventArgs e)
        {
            if (currentPage <= 1) currentPage = 1;
            else
                currentPage--;
            UpdateView();
        }

        private void NextPageBtn(object sender, RoutedEventArgs e)
        {
            if (currentPage >= maxPages) currentPage = maxPages;
            else
                currentPage++;
            UpdateView();
        }
    }
}
