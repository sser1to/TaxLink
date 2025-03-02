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
    /// Логика взаимодействия для FilterForHistoryPage.xaml
    /// </summary>
    public partial class FilterForHistoryPage : Page
    {
        List<string> x1 = new List<string>();
        List<string> x2 = new List<string>();
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public FilterForHistoryPage()
        {
            InitializeComponent();
            if (tbxpage != null)
            {
                UpdateView();
            }

            // Заполнение cbx1
            var y1 = AdminWindow.baza.ActionType.ToList();
            x1.Add("Не выбрано");
            foreach (var item in y1)
            {
                x1.Add(item.Title);
            }
            cbx1.ItemsSource = x1;
            cbx1.SelectedIndex = 0;

            // Заполнение cbx2
            var y2 = AdminWindow.baza.WorkingTable.ToList();
            x2.Add("Не выбрана");
            foreach (var item in y2)
            {
                x2.Add(item.Title);
            }
            cbx2.ItemsSource = x2;
            cbx2.SelectedIndex = 0;
        }

        /// <summary>
        /// Обновление для фильтров и постраничного вывода
        /// </summary>
        private void UpdateView()
        {
            string text1 = tbx1.Text;
            string text2 = tbx2.Text;

            var items = AdminWindow.baza.Action.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t => t.Login.Contains(text1));
            }

            if (!string.IsNullOrEmpty(text2))
            {
                items = items.Where(t => t.ActionDate.ToString("dd.MM.yy HH:mm:ss").Contains(text2));
            }

            if (cbx1.SelectedIndex != 0)
            {
                if (cbx1.SelectedItem != null)
                {
                    string text3 = cbx1.SelectedItem.ToString();
                    var selectedType = AdminWindow.baza.ActionType.FirstOrDefault(tp => tp.Title == text3);

                    items = items.Where(t => t.IdActionType == selectedType.IdActionType); ;
                }
            }

            if (cbx2.SelectedIndex != 0)
            {
                if (cbx2.SelectedItem != null)
                {
                    string text4 = cbx2.SelectedItem.ToString();
                    var selectedType = AdminWindow.baza.WorkingTable.FirstOrDefault(tp => tp.Title == text4);

                    items = items.Where(t => t.IdWorkingTable == selectedType.IdWorkingTable); ;
                }
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdAction).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            HistoryPage.Instance.dg.ItemsSource = itemsPage.ToList();
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

        private void cbx2_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
            cbx2.SelectedIndex = 0;
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
