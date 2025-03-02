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
    /// Логика взаимодействия для FilterForAdminTaxRatePage.xaml
    /// </summary>
    public partial class FilterForAdminTaxRatePage : Page
    {
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public static FilterForAdminTaxRatePage Instance { get; private set; }

        public FilterForAdminTaxRatePage()
        {
            InitializeComponent();
            Instance = this;
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
            string text2 = tbx2.Text;
            string text3 = tbx3.Text;

            var items = AdminWindow.baza.TaxRate.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => t.StartDate.ToString("dd.MM.yy HH:mm:ss").Contains(text1));
            }

            if (!string.IsNullOrEmpty(text2))
            {
                items = items.Where(t => t.FinishDate.HasValue && t.FinishDate.Value.ToString("dd.MM.yy HH:mm:ss").Contains(text2));
            }

            if (int.TryParse(text3, out int IdTaxRate))
            {
                items = items.Where(t => t.IdTaxRate == IdTaxRate);
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdTaxRate).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            AdminTaxRatePage.Instance.dg.ItemsSource = itemsPage.ToList();
        }

        private void tbx1_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        private void tbx2_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        private void tbx3_TextChanged(object sender, TextChangedEventArgs e)
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
            tbx2.Text = "";
            tbx3.Text = "";
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
