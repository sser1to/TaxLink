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
using word =  Microsoft.Office.Interop.Word;
using Page = System.Windows.Controls.Page;
using Microsoft.Office.Interop.Word;
using System.Runtime.Remoting.Contexts;
using System.IO;
using Path = System.IO.Path;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeeTaxPage.xaml
    /// </summary>
    public partial class EmployeeTaxPage : Page
    {
        public static EmployeeTaxPage Instance { get; private set; }

        public EmployeeTaxPage()
        {
            InitializeComponent();
            Instance = this;
            dg1.ItemsSource = EmployeeWindow.baza.Tax.ToList();
        }

        private void dg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg1.SelectedItem == null)
            {
                return;
            }

            var selectedItem = dg1.SelectedItem as Tax;

            // Отображение в dg2 собственности, включенной в налог
            var taxpayerId = selectedItem.Taxpayer.IdTaxpayer;
            var properties = EmployeeWindow.baza.Property.Where(p => p.IdTaxpayer == taxpayerId);
            dg2.ItemsSource = properties.ToList();
        }

        private void MakePayment(object sender, RoutedEventArgs e)
        {
            var selectedItem = dg1.SelectedItem as Tax;

            if (selectedItem == null)
            {
                MessageBox.Show("Вы не выбрали запись!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (selectedItem.Status == true)
            {
                MessageBox.Show("Этот налог уже был оплачен!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (selectedItem.PaymentDeadline < DateTime.Now)
            {
                MessageBox.Show("Этот налог является задолженностью!", "Внимание", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Создание платежа
            var payment = new Payment
            {
                IdTaxpayer = selectedItem.IdTaxpayer,
                IdTax = selectedItem.IdTax,
                IdEmployee = CurrentUser.Id,
                TypeOfPayment = false,
                Sum = selectedItem.Sum,
                DateOfPayment = DateTime.Now
            };

            selectedItem.Status = true;

            EmployeeWindow.baza.Payment.Add(payment);
            EmployeeWindow.baza.SaveChanges();

            dg1.SelectedItem = null;

            dg1.ItemsSource = null;
            dg1.ItemsSource = EmployeeWindow.baza.Tax.ToList();
        }

        /// <summary>
        /// Замена текста для Word
        /// </summary>
        /// <param name="f">Текст, который нужно заменить</param>
        /// <param name="r">Текст, которым нужно вставить</param>
        /// <param name="app">Word application</param>
        public void FindAndReplace(string f, string r, word.Application app)
        {
            app.Selection.Find.ClearFormatting();
            word.Range range = app.Selection.Range;

            app.Selection.Find.Replacement.ClearFormatting();

            app.Selection.Find.Replacement.Text = r;
            app.Selection.Find.Execute(f, Replace: word.WdReplace.wdReplaceOne); 

            app.Selection.WholeStory();
            app.Options.DefaultHighlightColorIndex = word.WdColorIndex.wdNoHighlight;
            app.Selection.Range.HighlightColorIndex = word.WdColorIndex.wdWhite;
        }

        /// <summary>
        /// Дублирование последних двух строк в таблице
        /// </summary>
        /// <param name="table">Таблица</param>
        public void DuplicateLastTwoRows(word.Table table)
        {
            if (table.Rows.Count >= 2)
            {
                word.Row secondLastRow = table.Rows[table.Rows.Count - 1];
                word.Row lastRow = table.Rows[table.Rows.Count];

                secondLastRow.Range.Copy();
                word.Range range = table.Range;
                range.Collapse(word.WdCollapseDirection.wdCollapseEnd);
                range.Paste();

                lastRow.Range.Copy();
                range = table.Range;
                range.Collapse(word.WdCollapseDirection.wdCollapseEnd);
                range.Paste();
            }
        }

        private void TaxNotificationBtn(object sender, RoutedEventArgs e)
        {
            var selectedItem = dg1.SelectedItem as Tax;

            if (selectedItem == null)
            {
                MessageBox.Show("Вы не выбрали запись!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (selectedItem.Status == true)
            {
                MessageBox.Show("Эта задолженность уже была оплачена!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            MessageBoxResult result = MessageBox.Show("Вы точно хотите сформировать налоговое уведомление?", "Оповещение", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // Создание налогового уведомления

                word.Application app = new word.Application();

                // Путь к шаблону
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string FilePath = System.IO.Path.Combine(executablePath, "Docs", "TaxNotificationTemplate.docx");

                // Путь для временного файла
                string tempFile = Path.GetTempFileName() + ".docx";

                File.Copy(FilePath, tempFile, true);

                word.Document document = app.Documents.Open(tempFile);

                string time = DateTime.Now.ToString("dd.MM.yyyy");

                FindAndReplace(@"ДатаНал", time, app);
                FindAndReplace(@"НомерНал", "000001", app);
                FindAndReplace(@"ФИОНал", selectedItem.Taxpayer.FIO, app);
                FindAndReplace(@"ИНННал", selectedItem.Taxpayer.INN, app);
                FindAndReplace(@"СумНал1", selectedItem.SumRub, app);
                FindAndReplace(@"СумНал2", selectedItem.SumRub, app);
                FindAndReplace(@"СумНал3", selectedItem.SumRub, app);

                var properties = EmployeeWindow.baza.Property.Where(p => p.IdTaxpayer == selectedItem.Taxpayer.IdTaxpayer);

                int count = properties.Count();
                int i = 0;

                foreach (var property in properties)
                {
                    i++;

                    if (i != count)
                    {
                        DuplicateLastTwoRows(document.Tables[2]);
                    }

                    FindAndReplace(@"НазвСобственности", property.Description, app);
                    FindAndReplace(@"ГодНал", $"{selectedItem.PaymentDeadline.Year}", app);
                    FindAndReplace(@"НалБаза", $"{property.SumRub}", app);
                    FindAndReplace(@"НалСтавка", selectedItem.TaxRate.Percent, app);

                    double sum = ((double)property.Sum - ((double)property.Sum * 0.13)) * selectedItem.TaxRate.PercentRate;
                    string fsum = sum.ToString("N2");

                    FindAndReplace(@"СумИсчНал", fsum, app);
                }

                app.Visible = true;
            }
        }
    }
}
