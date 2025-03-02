using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxLink
{
    /// <summary>
    /// Конфигурация настроек приложения
    /// </summary>
    public class CurrentSettings
    {
        public static int Theme { get; set; }
        public static bool Notifications { get; set; }
        public static int FontSize { get; set; }
        public static int NumberOfEntriesPerPage { get; set; }

        /// <summary>
        /// Загрузка конфигурации
        /// </summary>
        /// <param name="filePath">Путь к файлу с конфигурацией</param>
        public static void LoadSettings(string filePath)
        {
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"File {filePath} not found.");

            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var parts = line.Split('=');
                if (parts.Length != 2)
                    continue;

                var key = parts[0].Trim();
                var value = parts[1].Trim();

                switch (key)
                {
                    case "theme":
                        Theme = int.Parse(value);
                        break;
                    case "notifications":
                        Notifications = bool.Parse(value);
                        break;
                    case "fontSize":
                        FontSize = int.Parse(value);
                        break;
                    case "numberOfEntriesPerPage":
                        NumberOfEntriesPerPage = int.Parse(value);
                        break;
                }
            }
        }
    }
}
