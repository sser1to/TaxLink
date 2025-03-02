using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TaxLink
{
    /// <summary>
    /// Работа с обученной моделью (Кларк)
    /// </summary>
    public class ModelClient
    {
        private readonly HttpClient _client;

        public ModelClient()
        {
            // Подключение к клиенту
            _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:5000/");
        }

        /// <summary>
        /// Отправка запроса и получение ответа от клиента
        /// </summary>
        /// <param name="question">Запрос пользователя</param>
        public string GetAnswerSync(string question)
        {
            try
            {
                // Отправляем запрос
                var response = _client.PostAsync("predict", new StringContent($"{{\"question\": \"{question}\"}}")).Result;
                response.EnsureSuccessStatusCode();
                var jsonString = response.Content.ReadAsStringAsync().Result;

                // Парсим JSON строку
                dynamic jsonResponse = JsonConvert.DeserializeObject(jsonString);

                // Извлекаем текст ответа
                string answer = jsonResponse.response;

                return answer;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
