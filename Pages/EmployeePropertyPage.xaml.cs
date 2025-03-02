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
using Excel = Microsoft.Office.Interop.Excel;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePropertyPage.xaml
    /// </summary>
    public partial class EmployeePropertyPage : Page
    {
        public static EmployeePropertyPage Instance { get; private set; }

        public EmployeePropertyPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = EmployeeWindow.baza.Property.ToList();
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
