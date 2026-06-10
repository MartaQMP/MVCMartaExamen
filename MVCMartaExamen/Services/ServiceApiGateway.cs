using MVCMartaExamen.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Serialization;

namespace MVCMartaExamen.Services
{
    public class ServiceApiGateway
    {
        private HttpClient client;
        private string UrlApiGateway;

        public ServiceApiGateway(IConfiguration configuration)
        {
            this.client = new HttpClient();
            this.UrlApiGateway = configuration.GetValue<string>("ApiGatewayUrl");
            this.client.DefaultRequestHeaders.Accept.Clear();
            this.client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Categoria>> GetCategoriasAsync()
        {
            string request = this.UrlApiGateway + "/api/evento/categorias";
            HttpResponseMessage response = await this.client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Categoria>>(json);
            }
            return null;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = this.UrlApiGateway + "/api/evento/eventos";
            HttpResponseMessage response = await this.client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Evento>>(json);
            }
            return null;
        }

        public async Task<List<Evento>> GetEventosCategoriaAsync(int idCategoria)
        {
            string request = this.UrlApiGateway + $"/api/evento/eventoscategoria/{idCategoria}";
            HttpResponseMessage response = await this.client.GetAsync(request);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Evento>>(json);
            }
            return null;
        }
    }
}
