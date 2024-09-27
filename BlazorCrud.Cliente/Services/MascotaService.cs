using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Cliente.Services
{
    public class MascotaService : IMascotaService
    {
        private readonly HttpClient _http;

        public MascotaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<MascotaDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<MascotaDTO>>>("api/Mascota/Lista");
            if (result!.EsCorrecto)
            {
                return result.Valor;
            }
            else {
                throw new Exception(result.Mensaje); 
            }
        }


    }
}