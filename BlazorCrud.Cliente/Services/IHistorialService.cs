using BlazorCrud.Shared;

namespace BlazorCrud.Cliente.Services
{
    public interface IHistorialService
    {
        Task<List<HistorialDTO>> Lista();
    }
}
