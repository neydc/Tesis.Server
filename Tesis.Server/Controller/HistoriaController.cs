using BlazorCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tesis.Server.Models;

namespace Tesis.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriaController : ControllerBase
    {
        private readonly TesisContext _dbcontext;

        public HistoriaController(TesisContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<HistorialDTO>>();
            var listaClientes = new List<HistorialDTO>();

            try
            {
                foreach (var item in await _dbcontext.Historial.ToListAsync())
                {
                    listaClientes.Add(new HistorialDTO
                    {
                        Id = item.Id,
                        IdCliente = item.IdMascota,
                        IdMascota = item.IdCliente,
                        Descripcion= item.Descripcion,
                        Fecha= item.Fecha
                    });
                }
                responseApi.EsCorrecto = true;
                responseApi.Valor = listaClientes;
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
    }
}
