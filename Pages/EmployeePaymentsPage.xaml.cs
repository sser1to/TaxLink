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

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeePaymentsPage.xaml
    /// </summary>
    public partial class EmployeePaymentsPage : Page
    {
        public static EmployeePaymentsPage Instance { get; private set; }

        public EmployeePaymentsPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = EmployeeWindow.baza.Payment.ToList();
        }
    }
}
