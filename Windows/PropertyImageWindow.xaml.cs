using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для PropertyImageWindow.xaml
    /// </summary>
    public partial class PropertyImageWindow : Window
    {
        byte[] image;

        /// <summary>
        /// Вывод изображения
        /// </summary>
        /// <param name="image">Массив байтов</param>
        public PropertyImageWindow(byte[] image)
        {
            InitializeComponent();
            this.image = image;

            if (image == null)
            {
                string executablePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string soundFilePath = System.IO.Path.Combine(executablePath, "Images", "null image.png");
                img1.Source = new BitmapImage(new Uri(soundFilePath));
            }
            else
            {
                var bitmapImage = new BitmapImage();
                using (var mem = new MemoryStream(image))
                {
                    mem.Position = 0;
                    bitmapImage.BeginInit();
                    bitmapImage.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = null;
                    bitmapImage.StreamSource = mem;
                    bitmapImage.EndInit();
                }
                bitmapImage.Freeze();

                img1.Source = bitmapImage;
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
    }
}
