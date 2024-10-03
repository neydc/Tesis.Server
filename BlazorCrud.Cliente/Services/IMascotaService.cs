using BlazorCrud.Shared;
namespace BlazorCrud.Cliente.Services
{
    public interface IMascotaService
    {
        Task<List<MascotaDTO>> Lista();
        Task<MascotaDTO> Buscar(int id );

        Task<int> Guardar(MascotaDTO mascota);
        Task<int> Editar(MascotaDTO mascota);
        Task<bool> Eliminar( int id );
    }
}
 