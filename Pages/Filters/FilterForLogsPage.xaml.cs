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
    /// Логика взаимодействия для FilterForLogsPage.xaml
    /// </summary>
    public partial class FilterForLogsPage : Page
    {
        List<string> x1 = new List<string>();
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public FilterForLogsPage()
        {
            InitializeComponent();
            if (tbxpage != null)
            {
                UpdateView();
            }

            // Заполнение cbx1
            var y1 = AdminWindow.baza.UserType.ToList();
            x1.Add("Не выбран");
            foreach (var item in y1)
            {
                x1.Add(item.Title);
            }
            cbx1.ItemsSource = x1;
            cbx1.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновление для фильтров и постраничного вывода
        /// </summary>
        private void UpdateView()
        {
            string text1 = tbx1.Text;
            string text2 = tbx2.Text;

            var items = AdminWindow.baza.Logs.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => t.LoginDate.ToString("dd.MM.yy HH:mm:ss").Contains(text1));
            }

            if (!string.IsNullOrEmpty(text2))
            {
                items = items.Where(t => t.Login.Contains(text2));
            }

            if (cbx1.SelectedIndex != 0)
            {
                if (cbx1.SelectedItem != null)
                {
                    string text3 = cbx1.SelectedItem.ToString();
                    var selectedType = AdminWindow.baza.UserType.FirstOrDefault(tp => tp.Title == text3);

                    items = items.Where(t => t.IdUserType == selectedType.IdUserType); ;
                }
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdLogin).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            LogsPage.Instance.dg.ItemsSource = itemsPage.ToList();
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
