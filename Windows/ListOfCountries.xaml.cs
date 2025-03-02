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
using System.Windows.Shapes;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для ListOfCountries.xaml
    /// </summary>
    public partial class ListOfCountries : Window
    {
        public ListOfCountries()
        {
            InitializeComponent();
            dg.ItemsSource = AdminWindow.baza.Citizenship.ToList();
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 15.5 * 10;
        }
    }
}
