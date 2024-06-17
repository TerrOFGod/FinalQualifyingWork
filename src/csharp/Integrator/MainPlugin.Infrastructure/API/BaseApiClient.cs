using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTTextGenerator.Infrastructure.API
{
    public class BaseApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseApiUrl;
        private readonly string _apiKey;
        private readonly string _model;

        public BaseApiClient(string apiKey, string baseApiUrl, string model)
        {
            _apiKey = apiKey;
            _baseApiUrl = baseApiUrl;
            _model = model;
            _httpClient = new HttpClient();
        }

        public async Task<string> SendRequest(string prompt)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

                List<dynamic> messages = new List<dynamic>();
                messages.Add(new { role = "user", content = prompt });

                var requestBody = new
                {
                    model = _model,
                    messages = messages,
                    temperature = 0.7,
                    n = 1,
                    max_tokens = Convert.ToInt32(prompt.Length * 1.5),
                    extra_headers = new { X_Title = "My App" } // опционально - передача информации об источнике API-вызова
                };

                var jsonRequest = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseApiUrl + "chat/completions", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    dynamic responseData = JsonConvert.DeserializeObject(jsonResponse);
                    return responseData.choices[0].message.content;
                }
                else
                {
                    return "Error: " + response.ReasonPhrase;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
