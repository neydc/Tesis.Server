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

        public async  Task<MascotaDTO> Buscar(int id) {
            var result = await _http.GetFromJsonAsync<ResponseAPI<MascotaDTO>>($"api/Mascota/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(MascotaDTO mascota){
            var result = await _http.PostAsJsonAsync($"api/Mascota/Guardar", mascota);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(MascotaDTO mascota)
        {
            var result = await _http.PutAsJsonAsync($"api/Mascota/Editar/{mascota.Id}", mascota);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Mascota/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

    }
}