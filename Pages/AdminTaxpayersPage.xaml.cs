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
using TaxLink.Pages.Filters;
using TaxLink.Windows;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для AdminTaxpayersPage.xaml
    /// </summary>
    public partial class AdminTaxpayersPage : Page
    {
        public static AdminTaxpayersPage Instance { get; private set; }

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public AdminTaxpayersPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = AdminWindow.baza.Taxpayer.ToList();
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            Taxpayer taxpayer = new Taxpayer();
            AddTaxpayer addTaxpayer = new AddTaxpayer(taxpayer);
            addTaxpayer.ShowDialog();
        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {
            var selectedItem = dg.SelectedItem as Taxpayer;
            if (selectedItem != null)
            {
                EditTaxpayer editTaxpayer = new EditTaxpayer(selectedItem);
                editTaxpayer.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var deletedItem = dg.SelectedItem as Taxpayer;
            if (deletedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
                    if (deletedItem.Tax.Any())
                    {
                        MessageBox.Show("Эта запись имеет связь(и) в другой таблице!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    // Удаление связанных записей в таблице CitizenshipTaxpayer
                    var citizenshipTaxpayers = AdminWindow.baza.CitizenshipTaxpayer.Where(t => t.IdTaxpayer == deletedItem.IdTaxpayer);
                    foreach (var citizenshipTaxpayer in citizenshipTaxpayers)
                    {
                        AdminWindow.baza.CitizenshipTaxpayer.Remove(citizenshipTaxpayer);
                    }

                    // Удаление связанных записей в таблице Property
                    var properties = AdminWindow.baza.Property.Where(t => t.IdTaxpayer == deletedItem.IdTaxpayer);
                    foreach (var property in properties)
                    {
                        AdminWindow.baza.Property.Remove(property);
                    }

                    // Воспроизведение звука
                    var player = new MediaPlayer();
                    string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                    string soundFilePath = System.IO.Path.Combine(executablePath, "Sounds", "clear.mp3");
                    player.Open(new Uri(soundFilePath));
                    player.Play();

                    // Создание записи о действии
                    var action = new Action
                    {
                        Login = CurrentUser.Login,
                        ActionDate = DateTime.Now,
                        IdActionType = 3,
                        IdWorkingTable = 1,
                        IdAffectedElement = deletedItem.IdTaxpayer
                    };

                    AdminWindow.baza.Action.Add(action);
                    AdminWindow.baza.SaveChanges();

                    // Окно с уведомлением
                    if (CurrentSettings.Notifications == true)
                    {
                        AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                        AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Налогоплательщики", "удалена"));
                    }

                    AdminWindow.baza.Taxpayer.Remove(deletedItem);
                    AdminWindow.baza.SaveChanges();
                    MessageBox.Show("Запись удалена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    dg.ItemsSource = null;

                    // Обновление таблицы
                    var items = AdminWindow.baza.Taxpayer.AsEnumerable();
                    maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
                    var itemsPage = items.OrderBy(t => t.IdTaxpayer).Skip((currentPage - 1) * countElements).Take(countElements);
                    FilterForAdminTaxpayersPage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
                    dg.ItemsSource = itemsPage.ToList();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CitizenshipCheckBtn(object sender, RoutedEventArgs e)
        {
            var selectedItem = dg.SelectedItem as Taxpayer;

            // Просмотр гражданства
            var citizenshipTaxpayers = AdminWindow.baza.CitizenshipTaxpayer.Where(t => t.IdTaxpayer == selectedItem.IdTaxpayer);
            string countries = "";
            foreach (var citizenshipTaxpayer in citizenshipTaxpayers)
            {
                countries += $"{citizenshipTaxpayer.ShortContryName} ";
            }

            if (countries == "")
            {
                countries = $"У {selectedItem.FIO} нет гражданства.";
                MessageBox.Show(countries, "Гражданство", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                countries = $"{selectedItem.FIO} имеет следующие гражданства: {countries}";
                MessageBox.Show(countries, "Гражданство" ,MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
