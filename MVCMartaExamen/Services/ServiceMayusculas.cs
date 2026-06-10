namespace MVCMartaExamen.Services
{
    public class ServiceMayusculas
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public ServiceMayusculas(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<string> ConvertirMayusculasAsync(string texto)
        {
            var baseUrl = _config["AWS:LambdaUrl"];

            var body = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(texto),
                System.Text.Encoding.UTF8,
                "application/json"
            );

            var response = await _http.PostAsync(baseUrl, body);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
