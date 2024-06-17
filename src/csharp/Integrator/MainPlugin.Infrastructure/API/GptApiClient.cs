using System.Text;
using GPTTextGenerator.Entities.Models.Interactions;
using GPTTextGenerator.Entities.Models.Interactors;
using RestSharp;
using Newtonsoft.Json;
using System.Net;

namespace GPTTextGenerator.Infrastructure.API
{
    public class RootResponse
    {
        public List<Choice> choices { get; set; }
    }

    public class Choice
    {
        public Message message { get; set; }
    }

    public class Message
    {
        public string content { get; set; }
    }

    public class GptApiClient
    {
        private readonly RestClient _restClient;
        private readonly string _baseApiUrl;
        private readonly string _apiKey;
        private readonly string _model;

        public GptApiClient(string apiKey, string baseApiUrl, string model)
        {
            _apiKey = apiKey;
            _baseApiUrl = baseApiUrl;
            _model = model;
            _restClient = new RestClient(_baseApiUrl);
        }

        public async Task<string> SendRequest(string prompt)
        {
            try
            {
                var request = new RestRequest("chat/completions", Method.Post);
                request.AddHeader("Authorization", $"Bearer {_apiKey}");
                request.AddJsonBody(new
                {
                    model = _model,
                    messages = new List<dynamic> { new { role = "user", content = prompt } },
                    temperature = 0.7,
                    n = 1,
                    max_tokens = Convert.ToInt32(prompt.Length * 1.5),
                    extra_headers = new { X_Title = "My App" } // опционально - передача информации об источнике API-вызова
                });

                var response = await _restClient.ExecuteAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseData = JsonConvert.DeserializeObject<RootResponse>(response.Content);
                    return responseData.choices[0].message.content;
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
