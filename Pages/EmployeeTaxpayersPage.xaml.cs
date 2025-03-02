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
    /// Логика взаимодействия для EmployeeTaxpayersPage.xaml
    /// </summary>
    public partial class EmployeeTaxpayersPage : Page
    {
        public static EmployeeTaxpayersPage Instance { get; private set; }

        public EmployeeTaxpayersPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = EmployeeWindow.baza.Taxpayer.ToList();
        }

        private void ExportExcelBtn(object sender, RoutedEventArgs e)
        {
            // Экспорт таблицы Налогоплательщики в Excel

            Excel.Application application = new Excel.Application();
            Excel.Workbook workbook = application.Workbooks.Add();
            Excel.Worksheet worksheet = workbook.Worksheets[1];

            var tours = EmployeeWindow.baza.Taxpayer.ToList();

            worksheet.Cells[2, 1] = "Код";
            worksheet.Cells[2, 2] = "ФИО";
            worksheet.Cells[2, 3] = "ИНН";
            worksheet.Cells[2, 4] = "Пол";
            worksheet.Cells[2, 5] = "Номер телефона";
            worksheet.Cells[2, 6] = "Место рождения";
            worksheet.Cells[2, 7] = "Серия и номер паспорта";
            worksheet.Cells[2, 8] = "Адрес проживания";

            for (int i = 0; i < tours.Count; i++)
            {
                worksheet.Cells[i + 3, 1] = tours[i].IdTaxpayer;
                worksheet.Cells[i + 3, 2] = tours[i].FIO;
                worksheet.Cells[i + 3, 3] = tours[i].INN;
                worksheet.Cells[i + 3, 4] = tours[i].GenderName;
                worksheet.Cells[i + 3, 5] = tours[i].Phone;
                worksheet.Cells[i + 3, 6] = tours[i].BirthPlace;
                worksheet.Cells[i + 3, 7] = tours[i].PassportFull;
                worksheet.Cells[i + 3, 8] = tours[i].Address;
            }

            Excel.Range rn = worksheet.Range[$"A3:H{tours.Count + 2}"];
            Excel.Range rn2 = worksheet.Range["A2:H2"];

            Excel.Range rn3 = worksheet.Range["A1:H1"];
            worksheet.Cells[1, 1] = "Налогоплательщики";
            worksheet.get_Range("A1", "H1").Merge(System.Type.Missing);
            rn3.Interior.Color = Excel.XlRgbColor.rgbLightGray;
            rn3.Font.Color = Excel.XlRgbColor.rgbBlack;
            rn3.Font.Bold = true;
            rn3.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

            rn.Interior.Color = Excel.XlRgbColor.rgbAzure;
            rn2.Interior.Color = Excel.XlRgbColor.rgbLightGray;
            rn2.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            rn2.Font.Bold = true;
            rn.EntireColumn.AutoFit();
            rn.EntireRow.AutoFit();

            rn.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rn2.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            rn3.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;

            application.Visible = true;
            application.UserControl = true;
        }
    }
}
