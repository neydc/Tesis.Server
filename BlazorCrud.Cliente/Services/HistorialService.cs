using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Cliente.Services
{
    public class HistorialService: IHistorialService
    {
        private readonly HttpClient _http;

        public HistorialService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<HistorialDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ClienteDTO>>>("api/Historia/Lista");
            if (result!.EsCorrecto)
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
    }
}
