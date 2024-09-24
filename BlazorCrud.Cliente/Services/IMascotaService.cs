using BlazorCrud.Shared;
namespace BlazorCrud.Cliente.Services
{
    public interface IMascotaService
    {
        Task<List<MascotaDTO>> Lista();
    }
}
 