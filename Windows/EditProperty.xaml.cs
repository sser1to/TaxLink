using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Globalization;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditProperty.xaml
    /// </summary>
    public partial class EditProperty : Window
    {
        private Property property;

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public EditProperty(Property property)
        {
            InitializeComponent();
            this.property = property;
            DataContext = property;
            cbx1.ItemsSource = AdminWindow.baza.TypeOfProperty.ToList();

            if (property.Image != null)
            {
                tbx3.Text = "Фото загружено";
            }
        }

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            // Проверки полей

            if (cbx1.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип собственности!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx1.Text))
            {
                MessageBox.Show("Поле \"Код налогоплательщика\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx2.Text))
            {
                MessageBox.Show("Поле \"Описание\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx4.Text))
            {
                MessageBox.Show("Поле \"Дата приобретения\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx5.Text))
            {
                MessageBox.Show("Поле \"Стоимость приобретения\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime dateTime;
            if (!DateTime.TryParse(tbx4.Text, out dateTime))
            {
                MessageBox.Show("В поле \"Дата приобретения\" должна быть дата!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number;
            if (!double.TryParse(tbx5.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out number))
            {
                MessageBox.Show("В поле \"Стоимость приобретения\" должно быть число!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx2.Text.Length > 100)
            {
                MessageBox.Show("В поле \"Описание\" ограничение в 100 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (int.TryParse(tbx1.Text, out int idTaxpayer))
            {
                bool codeExists = AdminWindow.baza.Taxpayer.Any(t => t.IdTaxpayer == idTaxpayer);
                if (!codeExists)
                {
                    MessageBox.Show("Налогоплательщика с таким кодом не существует!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("В поле \"Код налогоплательщика\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание записи о действии
            var action = new Action
            {
                Login = CurrentUser.Login,
                ActionDate = DateTime.Now,
                IdActionType = 2,
                IdWorkingTable = 2,
                IdAffectedElement = property.IdProperty
            };

            string path = tbx3.Text;

            if (path != "" && path != "Фото загружено")
            {
                property.Image = ImageToByteArray(tbx3.Text);
            }

            if (string.IsNullOrEmpty(path))
            {
                property.Image = null;
            }

            AdminWindow.baza.Action.Add(action);
            AdminWindow.baza.SaveChanges();

            // Окно с уведомлением
            if (CurrentSettings.Notifications == true)
            {
                AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Собственность", "изменена"));
            }  

            AdminWindow.baza.SaveChanges();
            this.Close();

            AdminPropertyPage.Instance.dg.ItemsSource = null;

            // Обновление таблицы
            var items = AdminWindow.baza.Property.AsEnumerable();
            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdProperty).Skip((currentPage - 1) * countElements).Take(countElements);
            FilterForAdminPropertyPage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
            AdminPropertyPage.Instance.dg.ItemsSource = itemsPage.ToList();
        }

        /// <summary>
        /// Преобразование изображения в массив байтов
        /// </summary>
        /// <param name="imagePath">Путь к изображению</param>
        public byte[] ImageToByteArray(string imagePath)
        {
            byte[] imageData = null;
            FileInfo fileInfo = new FileInfo(imagePath);
            long imageFileLength = fileInfo.Length;
            FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            imageData = br.ReadBytes((int)imageFileLength);
            return imageData;
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
            tbx4.Text = "";
            tbx5.Text = "";
            cbx1.SelectedItem = null;
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 22.6 * 10;
        }

        private void ImagePathBtn(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == true)
            {
                tbx3.Text = openFileDialog.FileName;
            }
        }

        private void DeleteImagePathBtn(object sender, RoutedEventArgs e)
        {
            tbx3.Text = "";
        }
    }
}
