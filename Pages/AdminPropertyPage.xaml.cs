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
    /// Логика взаимодействия для AdminPropertyPage.xaml
    /// </summary>
    public partial class AdminPropertyPage : Page
    {
        public static AdminPropertyPage Instance { get; private set; }

        private int currentPage = 1;
        private int countElements = CurrentSettings.NumberOfEntriesPerPage;
        private int maxPages;

        public AdminPropertyPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = AdminWindow.baza.Property.ToList();
        }

        private void AddBtn(object sender, RoutedEventArgs e)
        {
            Property property = new Property();
            AddProperty addProperty = new AddProperty(property);
            addProperty.ShowDialog();
        }

        private void EditBtn(object sender, RoutedEventArgs e)
        {
            var editButton = sender as Button;
            var selectedItem = dg.SelectedItem as Property;
            if (selectedItem != null)
            {
                EditProperty editProperty = new EditProperty(selectedItem);
                editProperty.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteBtn(object sender, RoutedEventArgs e)
        {
            var deletedItem = dg.SelectedItem as Property;
            if (deletedItem != null)
            {
                MessageBoxResult result = MessageBox.Show("Вы точно хотите удалить запись?", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (result == MessageBoxResult.Yes)
                {
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
                        IdWorkingTable = 2,
                        IdAffectedElement = deletedItem.IdProperty
                    };

                    AdminWindow.baza.Action.Add(action);
                    AdminWindow.baza.SaveChanges();

                    // Окно с уведомлением
                    if (CurrentSettings.Notifications == true)
                    {
                        AdminWindow.Instance.borderForFrame3.Visibility = Visibility.Visible;
                        AdminWindow.Instance.frame3.NavigationService.Navigate(new Pages.NotificationPage("Собственность", "удалена"));
                    }

                    AdminWindow.baza.Property.Remove(deletedItem);
                    AdminWindow.baza.SaveChanges();
                    MessageBox.Show("Запись удалена!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    dg.ItemsSource = null;

                    // Обновление таблицы
                    var items = AdminWindow.baza.Property.AsEnumerable();
                    maxPages = (int)Math.Ceiling(items.Count() * 1.0 / countElements);
                    var itemsPage = items.OrderBy(t => t.IdProperty).Skip((currentPage - 1) * countElements).Take(countElements);
                    FilterForAdminPropertyPage.Instance.tbxpage.Text = $"{currentPage}/{maxPages}";
                    dg.ItemsSource = itemsPage.ToList();
                }
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ImageBtn(object sender, RoutedEventArgs e)
        {
            var selectedItem = dg.SelectedItem as Property;
            if (selectedItem != null)
            {
                // Окно с изображением
                PropertyImageWindow propertyImageWindow = new PropertyImageWindow(selectedItem.Image);
                propertyImageWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Вы не выбрали запись!", "Внимание!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
