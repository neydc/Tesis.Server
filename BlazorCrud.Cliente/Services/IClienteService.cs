using BlazorCrud.Shared;

namespace BlazorCrud.Cliente.Services
{
    public interface IClienteService
    {
    
    Task<List<ClienteDTO>> Lista();
    Task<ClienteDTO> Buscar(int id);

    Task<int> Guardar(ClienteDTO cliente);
    Task<int> Editar(ClienteDTO cliente);
    Task<bool> Eliminar(int id);
    }
}
