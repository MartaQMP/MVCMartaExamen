namespace MVCMartaExamen.Services
{
    public class ServiceIA
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public ServiceIA(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string> AskAsync(string question)
        {
            var baseUrl = _config["AWS:LambdaUrl"];

            var body = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(new { Pregunta = question }),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync(baseUrl, body);
            return await response.Content.ReadAsStringAsync();
        }

    }
}
