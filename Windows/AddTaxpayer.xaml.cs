using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TaxLink.Pages;
using TaxLink.Pages.Filters;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddTaxpayer.xaml
    /// </summary>
    public partial class AddTaxpayer : Window
    {
        private Taxpayer taxpayer;

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public AddTaxpayer(Taxpayer taxpayer)
        {
            InitializeComponent();
            this.taxpayer = taxpayer;
            DataContext = taxpayer;
        }

        /// <summary>
        /// Проверка на наличие только букв в строке
        /// </summary>
        /// <param name="text">Текст для проверки</param>
        private bool ContainsOnlyLetters(string text)
        {
            foreach (char c in text)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        private void RandomLoginBtn(object sender, MouseButtonEventArgs e)
        {
            tbx10.Text = GenerateUniqueLogin();
            tbx10.Focus();
        }

        private void RandomPasswordBtn(object sender, MouseButtonEventArgs e)
        {
            tbx11.Text = GenerateRandomPassword();
            tbx11.Focus();
        }

        Random random = new Random();

        /// <summary>
        /// Генерация лоигна
        /// </summary>
        public string GenerateRandomLogin()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";         
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Генерация пароля
        /// </summary>
        public string GenerateRandomPassword()
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Генерация уникального логина
        /// </summary>
        public string GenerateUniqueLogin()
        {
            string generatedLogin;
            bool loginExists1;
            bool loginExists2;
            bool loginExists3;

            do
            {
                generatedLogin = GenerateRandomLogin();

                loginExists1 = AdminWindow.baza.Taxpayer.Any(t => t.Login == generatedLogin);
                loginExists2 = AdminWindow.baza.Action.Any(t => t.Login == generatedLogin);
                loginExists3 = AdminWindow.baza.Action.Any(t => t.Login == generatedLogin);

            } while (loginExists1 && loginExists2 && loginExists3);

            return generatedLogin;
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            if (cbx1.SelectedIndex == 0)
            {
                taxpayer.Gender = true;
            }
            else
            {
                taxpayer.Gender = false;
            }

            // Проверки полей

            if (string.IsNullOrWhiteSpace(tbx1.Text))
            {
                MessageBox.Show("Поле \"Фамилия\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx2.Text))
            {
                MessageBox.Show("Поле \"Имя\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx4.Text))
            {
                MessageBox.Show("Поле \"Номер телефона\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx5.Text))
            {
                MessageBox.Show("Поле \"ИНН\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx6.Text))
            {
                MessageBox.Show("Поле \"Место рождения\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx7.Text))
            {
                MessageBox.Show("Поле \"Адрес проживания\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx8.Text))
            {
                MessageBox.Show("Поле \"Серия паспорта\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx9.Text))
            {
                MessageBox.Show("Поле \"Номер паспорта\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx10.Text))
            {
                MessageBox.Show("Поле \"Логин\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx11.Text))
            {
                MessageBox.Show("Поле \"Пароль\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ContainsOnlyLetters(tbx1.Text))
            {
                MessageBox.Show("В поле \"Фамилия\" должны быть только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!ContainsOnlyLetters(tbx2.Text))
            {
                MessageBox.Show("В поле \"Имя\" должны быть только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx3.Text != "")
            {
                if (!ContainsOnlyLetters(tbx3.Text))
                {
                    MessageBox.Show("В поле \"Отчество\" должны быть только буквы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            double number;
            if (!double.TryParse(tbx4.Text, out number))
            {
                MessageBox.Show("В поле \"Номер телефона\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number1;
            if (!double.TryParse(tbx5.Text, out number1))
            {
                MessageBox.Show("В поле \"ИНН\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number2;
            if (!double.TryParse(tbx8.Text, out number2))
            {
                MessageBox.Show("В поле \"Серия паспорта\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number3;
            if (!double.TryParse(tbx9.Text, out number3))
            {
                MessageBox.Show("В поле \"Номер паспорта\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx1.Text.Length > 30)
            {
                MessageBox.Show("В поле \"Фамилия\" ограничение в 30 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx2.Text.Length > 30)
            {
                MessageBox.Show("В поле \"Имя\" ограничение в 30 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx3.Text.Length > 30)
            {
                MessageBox.Show("В поле \"Отчество\" ограничение в 30 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx5.Text.Length > 15)
            {
                MessageBox.Show("В поле \"ИНН\" ограничение в 15 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx4.Text.Length > 10)
            {
                MessageBox.Show("В поле \"Номер телефона\" ограничение в 10 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx6.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Место рождения\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx7.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Адрес проживания\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx8.Text.Length != 4)
            {
                MessageBox.Show("В поле \"Серия паспорта\" должно быть 4 символа!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx9.Text.Length != 6)
            {
                MessageBox.Show("В поле \"Номер паспорта\" должно быть 6 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx10.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Логин\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx11.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Пароль\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание записи о действии
            var action = new Action
            {
                Login = CurrentUser.Login,
                ActionDate = DateTime.Now,
                IdActionType = 1,
                IdWorkingTable = 1,
                IdAffectedElement = taxpayer.IdTaxpayer
            };

            AdminWindow.baza.Action.Add(action);
            AdminWindow.baza.SaveChanges();

            // Окно с уведомлением
            if (CurrentSettings.Notifications == true)
            {
                AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Налогоплательщики", "добавлена"));
            }

            AdminWindow.baza.Taxpayer.Add(taxpayer);
            AdminWindow.baza.SaveChanges();

            string countries = tbx12.Text;

            if (countries != "")
            {
                foreach (var country in countries.Split(' '))
                {
                    // Проверка на длину названия страны
                    if (country.Length != 2)
                    {
                        MessageBox.Show("Неправильный формат записи!\nФормат записи: краткое название стран через пробел (например, RU KZ UZ)", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Проверка на существование страны
                    var countryEntity = AdminWindow.baza.Citizenship.FirstOrDefault(c => c.ShortContryName == country.ToUpper());
                    if (countryEntity == null)
                    {
                        MessageBox.Show($"Страна с кратким названием {country.ToUpper()} не найдена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    var taxpayerCountry = new CitizenshipTaxpayer
                    {
                        IdTaxpayer = taxpayer.IdTaxpayer,
                        ShortContryName = country.ToUpper()
                    };
                    AdminWindow.baza.CitizenshipTaxpayer.Add(taxpayerCountry);
                }
            }
            AdminWindow.baza.SaveChanges();

            this.Close();

            AdminTaxpayersPage.Instance.dg.ItemsSource = null;

            // Обновление таблицы
            var items = AdminWindow.baza.Taxpayer.AsEnumerable();
            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdTaxpayer).Skip((currentPage - 1) * countElements).Take(countElements);
            FilterForAdminTaxpayersPage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
            AdminTaxpayersPage.Instance.dg.ItemsSource = itemsPage.ToList();
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
            tbx6.Text = "";
            tbx7.Text = "";
            tbx8.Text = "";
            tbx9.Text = "";
            tbx10.Text = "";
            tbx11.Text = "";
            cbx1.SelectedIndex = 0;
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void CountriesBtn(object sender, RoutedEventArgs e)
        {
            ListOfCountries listOfCountries = new ListOfCountries();
            listOfCountries.ShowDialog();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 11.7 * 10;
        }
    }
}
