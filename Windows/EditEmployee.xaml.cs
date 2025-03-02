﻿using System;
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
using System.Windows.Shapes;
using TaxLink.Pages.Filters;
using TaxLink.Pages;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для EditEmployee.xaml
    /// </summary>
    public partial class EditEmployee : Window
    {
        private Employee employee;

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public EditEmployee(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            DataContext = employee;

            if (employee.Gender == true)
            {
                cbx1.SelectedIndex = 0;
            }
            else
            {
                cbx1.SelectedIndex = 1;
            }
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

        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            if (cbx1.SelectedIndex == 0)
            {
                employee.Gender = true;
            }
            else
            {
                employee.Gender = false;
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
                MessageBox.Show("Поле \"Дата начала работы\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx6.Text))
            {
                MessageBox.Show("Поле \"Логин\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(tbx7.Text))
            {
                MessageBox.Show("Поле \"Пароль\" не может быть пустым!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime dateTime;
            if (!DateTime.TryParse(tbx5.Text, out dateTime))
            {
                MessageBox.Show("В поле \"Дата начала работы\" должна быть дата!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double number;
            if (!double.TryParse(tbx4.Text, out number))
            {
                MessageBox.Show("В поле \"Номер телефона\" должны быть только цифры!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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

            if (tbx4.Text.Length > 9)
            {
                MessageBox.Show("В поле \"Номер телефона\" ограничение в 10 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx6.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Логин\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (tbx7.Text.Length > 50)
            {
                MessageBox.Show("В поле \"Пароль\" ограничение в 50 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание записи о действии
            var action = new Action
            {
                Login = CurrentUser.Login,
                ActionDate = DateTime.Now,
                IdActionType = 2,
                IdWorkingTable = 4,
                IdAffectedElement = employee.IdEmployee
            };

            AdminWindow.baza.Action.Add(action);
            AdminWindow.baza.SaveChanges();

            // Окно с уведомлением
            if (CurrentSettings.Notifications == true)
            {
                AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Сотрудники", "изменена"));
            }

            AdminWindow.baza.SaveChanges();
            this.Close();

            AdminEmployeePage.Instance.dg.ItemsSource = null;

            // Обновление таблицы
            var items = AdminWindow.baza.Employee.AsEnumerable();
            maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
            var itemsPage = items.OrderBy(t => t.IdEmployee).Skip((currentPage - 1) * countElements).Take(countElements);
            FilterForAdminEmployeePage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
            AdminEmployeePage.Instance.dg.ItemsSource = itemsPage.ToList();
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
            cbx1.SelectedIndex = 0;
        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 18.2 * 10;
        }
    }
}
