using LiveCharts.Wpf;
using LiveCharts;
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
using System.Data.Entity;
using TaxLink.Windows;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfographicsPage.xaml
    /// </summary>
    public partial class InfographicsPage : Page
    {
        public SeriesCollection PieChartData { get; set; }

        public InfographicsPage()
        {
            InitializeComponent();

            int count1 = 0;
            int count2 = 0;
            int count3 = 0;
            int count4 = 0;
            int totalCount = 0;

            // Подчет разной собственности
            if (CurrentUser.TypeUser == 1)
            {
                count1 = AdminWindow.baza.Property.Where(p => p.Description.StartsWith("Квартира")).Count();
                count2 = AdminWindow.baza.Property.Where(p => p.Description.StartsWith("Частный дом")).Count();
                count3 = AdminWindow.baza.Property.Where(p => p.Description.StartsWith("Гараж")).Count();
                count4 = AdminWindow.baza.Property.Where(p => p.Description.StartsWith("Земельный участок")).Count();

                totalCount = AdminWindow.baza.Property.Count();
            }
            else
            {
                count1 = EmployeeWindow.baza.Property.Where(p => p.Description.StartsWith("Квартира")).Count();
                count2 = EmployeeWindow.baza.Property.Where(p => p.Description.StartsWith("Частный дом")).Count();
                count3 = EmployeeWindow.baza.Property.Where(p => p.Description.StartsWith("Гараж")).Count();
                count4 = EmployeeWindow.baza.Property.Where(p => p.Description.StartsWith("Земельный участок")).Count();

                totalCount = EmployeeWindow.baza.Property.Count();
            }
            
            int count5 = totalCount - (count1 + count2 + count3 + count4);

            lb1.Content = $"Квартиры: {count1}";
            lb2.Content = $"Частные дома: {count2}";
            lb3.Content = $"Гаражи: {count3}";
            lb4.Content = $"Земельные участки: {count4}";
            lb5.Content = $"Транспорт: {count5}";
            lb6.Content = $"Всего: {totalCount}";

            // Данные для диаграммы
            var data = new Dictionary<string, double>
            {
                { "Квартиры", count1 },
                { "Частные дома", count2 },
                { "Гаражи", count3 },
                { "Земельные участки", count4 },
                { "Транспорт", count5 }
            };

            // Заполнение диаграммы
            PieChartData = new SeriesCollection();
            foreach (var item in data)
            {
                PieChartData.Add(new PieSeries
                {
                    Title = item.Key,
                    Values = new ChartValues<double> { item.Value },
                    DataLabels = true
                });
            }
            DataContext = this;
        }
    }
}
