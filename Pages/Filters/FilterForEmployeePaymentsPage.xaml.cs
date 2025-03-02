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
    /// Логика взаимодействия для FilterForEmployeePaymentsPage.xaml
    /// </summary>
    public partial class FilterForEmployeePaymentsPage : Page
    {
        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public FilterForEmployeePaymentsPage()
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
            string text2 = tbx2.Text;
            string text3 = tbx3.Text;
            string text4 = tbx4.Text;
            string text5 = tbx5.Text;
            string text6 = tbx6.Text;
            bool status = cbx1.SelectedIndex == 1;

            var items = EmployeeWindow.baza.Payment.AsEnumerable();

            if (!string.IsNullOrEmpty(text1))
            {
                items = items.Where(t =>
                    (t.TypeOfPayment ?
                    (t.Arrears.Tax.Taxpayer.LName + " " + t.Arrears.Tax.Taxpayer.FName + " " + t.Arrears.Tax.Taxpayer.Patronymic) :
                    (t.Tax.Taxpayer.LName + " " + t.Tax.Taxpayer.FName + " " + t.Tax.Taxpayer.Patronymic)).Contains(text1));
            }

            if (int.TryParse(text2, out int IdArrears))
            {
                items = items.Where(t => t.IdArrears == IdArrears);
            }

            if (int.TryParse(text3, out int IdTax))
            {
                items = items.Where(t => t.IdTax == IdTax);
            }

            if (!string.IsNullOrEmpty(text4))
            {
                items = items.Where(t => (t.Employee.LName + " " + t.Employee.FName + " " + t.Employee.Patronymic).Contains(text4));
            }

            if (!string.IsNullOrEmpty(text5))
            {
                items = items.Where(t => t.DateOfPayment.ToString("dd.MM.yy HH:mm:ss").Contains(text5));
            }

            if (int.TryParse(text6, out int IdPayment))
            {
                items = items.Where(t => t.IdPayment == IdPayment);
            }

            if (cbx1.SelectedIndex > 0)
            {
                items = items.Where(t => t.TypeOfPayment == status);
            }

            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdPayment).Skip((currentPage - 1) * countElements).Take(countElements);
            tbxpage.Text = $"{currentPage}/{maxPages}";

            EmployeePaymentsPage.Instance.dg.ItemsSource = itemsPage.ToList();
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
            tbx4.Text = "";
            tbx5.Text = "";
            tbx6.Text = "";
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

        private void tbx4_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        private void tbx5_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }

        private void tbx6_TextChanged(object sender, TextChangedEventArgs e)
        {
            currentPage = 1;
            if (tbxpage != null)
            {
                UpdateView();
            }
        }
    }
}
