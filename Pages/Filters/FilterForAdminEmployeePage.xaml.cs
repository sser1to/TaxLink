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
    /// Логика взаимодействия для FilterForAdminEmployeePage.xaml
    /// </summary>
    public partial class FilterForAdminEmployeePage : Page
    {
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public static FilterForAdminEmployeePage Instance { get; private set; }

        public FilterForAdminEmployeePage()
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
            bool status = cbx1.SelectedIndex == 1;

            var items = AdminWindow.baza.Employee.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => (t.LName + " " + t.FName + " " + t.Patronymic).Contains(text1));
            }

            if (int.TryParse(text2, out int IdEmployee))
            {
                items = items.Where(t => t.IdEmployee == IdEmployee);
            }

            if (!string.IsNullOrEmpty(text3))
            {
                items = items.Where(t => t.Login.Contains(text3));
            }

            if (cbx1.SelectedIndex > 0)
            {
                items = items.Where(t => t.Gender == status);
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdEmployee).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            AdminEmployeePage.Instance.dg.ItemsSource = itemsPage.ToList();
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

        private void cbx1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            cbx1.SelectedIndex = 0;
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
