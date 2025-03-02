using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для LogsPage.xaml
    /// </summary>
    public partial class LogsPage : Page
    {
        public static LogsPage Instance { get; private set; }

        public LogsPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = AdminWindow.baza.Logs.ToList();
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите очистить весь журнал логов?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                // Воспроизведение звука
                var player = new MediaPlayer();
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string soundFilePath = System.IO.Path.Combine(executablePath, "Sounds", "clear.mp3");
                player.Open(new Uri(soundFilePath));
                player.Play();

                AdminWindow.baza.Logs.RemoveRange(AdminWindow.baza.Logs);
                AdminWindow.baza.SaveChanges();

                dg.ItemsSource = null;
                dg.ItemsSource = AdminWindow.baza.Logs.ToList();
            }
        }
    }
}
