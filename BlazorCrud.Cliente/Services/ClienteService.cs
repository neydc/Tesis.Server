using BlazorCrud.Shared;
using System.Net.Http.Json;

namespace BlazorCrud.Cliente.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ClienteDTO>> Lista()
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<List<ClienteDTO>>>("api/Cliente/Lista");
            if (result!.EsCorrecto)
            {
                return result.Valor;
            }
            else
            {
                throw new Exception(result.Mensaje);
            }
        }
        public async Task<ClienteDTO> Buscar(int id)
        {
            var result = await _http.GetFromJsonAsync<ResponseAPI<ClienteDTO>>($"api/Cliente/Buscar/{id}");
            if (result!.EsCorrecto)
                return result.Valor!;
            else
                throw new Exception(result.Mensaje);
        }
        public async Task<int> Guardar(ClienteDTO cliente)
        {
            var result = await _http.PostAsJsonAsync($"api/Cliente/Guardar", cliente);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<int> Editar(ClienteDTO cliente)
        {
            var result = await _http.PutAsJsonAsync($"api/Cliente/Editar/{cliente.Id}", cliente);
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.Valor!;
            else
                throw new Exception(response.Mensaje);
        }

        public async Task<bool> Eliminar(int id)
        {
            var result = await _http.DeleteAsync($"api/Cliente/Eliminar/{id}");
            var response = await result.Content.ReadFromJsonAsync<ResponseAPI<int>>();

            if (response!.EsCorrecto)
                return response.EsCorrecto!;
            else
                throw new Exception(response.Mensaje);
        }

    }
}