using System.Net.Http.Json;
using System.Text.Json;
using WebEmpresa.Models;

namespace WebEmpresa.Services
{
    public class ClienteService
    {
        private readonly HttpClient _http;
        private const string ApiEndpoint = "api/Clientes"; // Coincide con la ruta /api/Clientes de tu Swagger

        // Opciones para desensibilizar mayúsculas/minúsculas en el JSON
        private readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            try
            {
                var result = await _http.GetFromJsonAsync<List<Cliente>>(ApiEndpoint, _jsonOptions);
                return result ?? new List<Cliente>();
            }
            catch
            {
                return new List<Cliente>();
            }
        }

        public async Task<bool> CreateClienteAsync(Cliente cliente)
        {
            var response = await _http.PostAsJsonAsync(ApiEndpoint, cliente);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateClienteAsync(Cliente cliente)
        {
            var response = await _http.PutAsJsonAsync($"{ApiEndpoint}/{cliente.Id_cliente}", cliente);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteClienteAsync(int id)
        {
            var response = await _http.DeleteAsync($"{ApiEndpoint}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}