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
using TaxLink.Pages;

namespace TaxLink.Windows
{
    /// <summary>
    /// Логика взаимодействия для ClarkHistoryWindow.xaml
    /// </summary>
    public partial class ClarkHistoryWindow : Window
    {
        public ClarkHistoryWindow()
        {
            InitializeComponent();

            // Вывод истории
            for (int i = 0; i < ClarkHistory.UserRequests.Count; i++)
            {
                string request = ClarkHistory.UserRequests[i]; 
                string answer = ClarkHistory.ClarkAnswers.Count > i ? ClarkHistory.ClarkAnswers[i] : "Ответ отсутствует";

                lbx.Items.Add($"Запрос: {request}\nОтвет: {answer}");
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.Height = this.Width / 15.5 * 10;
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            lbx.Items.Clear();
            ClarkHistory.ClarkAnswers.Clear();
            ClarkHistory.UserRequests.Clear();
        }
    }
}
