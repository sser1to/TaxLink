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
    /// Логика взаимодействия для HistoryPage.xaml
    /// </summary>
    public partial class HistoryPage : Page
    {
        public static HistoryPage Instance { get; private set; }

        public HistoryPage()
        {
            InitializeComponent();
            Instance = this;
            dg.ItemsSource = AdminWindow.baza.Action.ToList();
        }

        private void ClearBtn(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите очистить всю историю?", "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Error);
            if (result == MessageBoxResult.Yes)
            {
                // Воспроизведение звука
                var player = new MediaPlayer();
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string soundFilePath = System.IO.Path.Combine(executablePath, "Sounds", "clear.mp3");
                player.Open(new Uri(soundFilePath));
                player.Play();

                AdminWindow.baza.Action.RemoveRange(AdminWindow.baza.Action);
                AdminWindow.baza.SaveChanges();

                dg.ItemsSource = null;
                dg.ItemsSource = AdminWindow.baza.Action.ToList();
            }
        }
    }
}
