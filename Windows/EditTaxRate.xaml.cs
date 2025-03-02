using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;
using TaxLink.Pages.Filters;
using TaxLink.Pages;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditTaxRate.xaml
    /// </summary>
    public partial class EditTaxRate : Window
    {
        private TaxRate taxRate;

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public EditTaxRate(TaxRate taxRate)
        {
            InitializeComponent();
            this.taxRate = taxRate;
            DataContext = taxRate;
        }

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            // Проверки полей

            if (string.IsNullOrWhiteSpace(tbx1.Text))
            {
                MessageBox.Show("Поле \"Процент ставки\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number;
            if (!double.TryParse(tbx1.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
            {
                MessageBox.Show("В поле \"Процент ставки\" должно быть число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx2.Text))
            {
                MessageBox.Show("Поле \"Дата начала действия\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime dateTime;
            if (!DateTime.TryParse(tbx2.Text, out dateTime))
            {
                MessageBox.Show("В поле \"Дата начала действия\" должна быть дата!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!string.IsNullOrWhiteSpace(tbx3.Text))
            {
                DateTime dateTime1;
                if (!DateTime.TryParse(tbx3.Text, out dateTime1))
                {
                    MessageBox.Show("В поле \"Дата окончания действия\" должна быть дата!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            // Создание записи о действии
            var action = new Action
            {
                Login = CurrentUser.Login,
                ActionDate = DateTime.Now,
                IdActionType = 2,
                IdWorkingTable = 3,
                IdAffectedElement = taxRate.IdTaxRate
            };

            AdminWindow.baza.Action.Add(action);
            AdminWindow.baza.SaveChanges();

            // Окно с уведомлением
            if (CurrentSettings.Notifications == true)
            {
                AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Налоговая ставка", "изменена"));
            }

            AdminWindow.baza.SaveChanges();
            this.Close();

            AdminTaxRatePage.Instance.dg.ItemsSource = null;

            // Обновление таблицы
            var items = AdminWindow.baza.TaxRate.AsEnumerable();
            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdTaxRate).Skip((currentPage - 1) * countElements).Take(countElements);
            FilterForAdminTaxRatePage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
            AdminTaxRatePage.Instance.dg.ItemsSource = itemsPage.ToList();
        }

        private void HelpBtn(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Помощь");
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            tbx1.Text = "";
            tbx2.Text = "";
            tbx3.Text = "";
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SystemDateTimeBtn(object sender, RoutedEventArgs e)
        {
            tbx3.Text = DateTime.Now.ToString("d/M/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            tbx3.Focus();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 27.3 * 10;
        }
    }
}
