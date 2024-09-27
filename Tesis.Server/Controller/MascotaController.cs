using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesis.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;

namespace Tesis.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly TesisContext _dbcontext;

        public MascotaController(TesisContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<MascotaDTO>>();
            var listaMascotas = new List<MascotaDTO>();

            try
            {
                foreach (var item in await _dbcontext.Mascota.ToListAsync())
                {
                    listaMascotas.Add(new MascotaDTO
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Dueno = item.Dueno,
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaMascotas;
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        private async Task Eliminar(int id)
        {

        }
    }
}
