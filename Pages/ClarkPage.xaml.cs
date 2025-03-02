using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
using System.Windows.Threading;
using TaxLink.Windows;
using System.Net.Http;
using System.Net.Http.Json;

namespace TaxLink.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClarkPage.xaml
    /// </summary>
    public partial class ClarkPage : Page
    {
        public static ClarkPage Instance { get; private set; }

        private ModelClient _modelClient;

        string item1 = "Привет, я Кларк - твой личный путеводитель по этой программе. Можешь задавать мне любые вопросы," +
            " связанные с этой программой или предметной областью налоговая инспекция. Буду рад тебе помочь!"; // Начальное сообщение

        public ClarkPage()
        {
            InitializeComponent();
            Instance = this;

            _modelClient = new ModelClient();

            tbx1.Focus();
        }

        private void EnterBtn(object sender, RoutedEventArgs e)
        {          
            if (tbx1.Text == "")
            {
                MessageBox.Show("Вы не ввели запрос!", "Оповещение", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            tbc0.Text = item1;

            br2.Visibility = Visibility.Hidden;
            img2.Visibility = Visibility.Hidden;

            string request = tbx1.Text;

            tbc1.Text = request;

            Random random = new Random();

            try
            {
                string answer = _modelClient.GetAnswerSync(request);

                tbc2.Text = answer;

                tbx1.Text = "";

                br1.Visibility = Visibility.Visible;
                img1.Visibility = Visibility.Visible;

                item1 = tbc2.Text;

                // Создание таймера для ответа от Кларка
                DispatcherTimer timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(2);
                timer.Tick += Timer_Tick;
                timer.Start();

                ClarkHistory.UserRequests.Add(request);
                ClarkHistory.ClarkAnswers.Add(answer);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при подключении к клиенту: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }   
        }

        /// <summary>
        /// Отображение ответа от Кларка
        /// </summary>
        private void Timer_Tick(object sender, EventArgs e)
        {
            br2.Visibility = Visibility.Visible;
            img2.Visibility = Visibility.Visible;
        }

        private void HistoryBtn(object sender, RoutedEventArgs e)
        {
            ClarkHistoryWindow clarkHistoryWindow = new ClarkHistoryWindow();
            clarkHistoryWindow.ShowDialog();
        }

        private void tbx1_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Счетчик символов
            string text = tbx1.Text;
            int count = text.Length;
            lb1.Content = count + "/100";
        }
    }
}
