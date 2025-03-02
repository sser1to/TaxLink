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
    /// Логика взаимодействия для FilterForEmployeePropertyPage.xaml
    /// </summary>
    public partial class FilterForEmployeePropertyPage : Page
    {
        List<string> x = new List<string>();
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public FilterForEmployeePropertyPage()
        {
            InitializeComponent();
            if (tbxpage != null)
            {
                UpdateView();
            }

            // Заполнение cbx1
            var y = EmployeeWindow.baza.TypeOfProperty.ToList();
            x.Add("Не выбран");
            foreach (var item in y)
            {
                x.Add(item.Ttile);
            }
            cbx1.ItemsSource = x;
            cbx1.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновление для фильтров и постраничного вывода
        /// </summary>
        private void UpdateView()
        {
            string text1 = tbx1.Text;
            string text2 = tbx2.Text;

            var items = EmployeeWindow.baza.Property.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => (t.Taxpayer.LName + " " + t.Taxpayer.FName + " " + t.Taxpayer.Patronymic).Contains(text1));
            }

            if (int.TryParse(text2, out int IdProperty))
            {
                items = items.Where(t => t.IdProperty == IdProperty);
            }

            if (cbx1.SelectedIndex != 0)
            {
                if (cbx1.SelectedItem != null)
                {
                    string text3 = cbx1.SelectedItem.ToString();
                    var selectedType = EmployeeWindow.baza.TypeOfProperty.FirstOrDefault(tp => tp.Ttile == text3);

                    items = items.Where(t => t.IdTypeOfProperty == selectedType.IdTypeOfProperty);
                }
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdProperty).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            EmployeePropertyPage.Instance.dg.ItemsSource = itemsPage.ToList();
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
