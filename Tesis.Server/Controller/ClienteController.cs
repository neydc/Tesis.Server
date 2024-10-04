using BlazorCrud.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tesis.Server.Models;
namespace Tesis.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly TesisContext _dbcontext;

        public ClienteController(TesisContext dbContext)
        {
            _dbcontext = dbContext;
        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var responseApi = new ResponseAPI<List<ClienteDTO>>();
            var listaClientes = new List<ClienteDTO>();

            try
            {
                foreach (var item in await _dbcontext.Cliente.ToListAsync())
                {
                    listaClientes.Add(new ClienteDTO
                    {
                        Id = item.Id,
                        Correo = item.Correo,
                        Contrasenia= item.Contrasenia 
                    
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
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<ClienteDTO>();
            var ClienteBuscado = new ClienteDTO();

            try
            {
                var dbEmpleado = await _dbcontext.Cliente.FirstOrDefaultAsync(x => x.Id == id);
                if (dbEmpleado != null)
                {
                    ClienteBuscado.Id = dbEmpleado.Id;
                    ClienteBuscado.Correo = dbEmpleado.Correo;
                    ClienteBuscado.Contrasenia = dbEmpleado.Contrasenia;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = ClienteBuscado;
                }
            }
            catch (Exception ex)
            {

                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar(Cliente cliente)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbMascota = new Cliente
                {
                    Correo = cliente.Correo,
                    Contrasenia = cliente.Contrasenia,
                };

                _dbcontext.Cliente.Add(dbMascota);
                await _dbcontext.SaveChangesAsync();

                if (dbMascota.Id != 0)
                {
                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbMascota.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = " No Guardado";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }
            return Ok(responseApi);
        }

        [HttpPut]
        [Route("Editar/{id}")]
        public async Task<IActionResult> Editar(MascotaDTO mascota, int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbMascota = await _dbcontext.Mascota.FirstOrDefaultAsync(x => x.Id == id);

                if (dbMascota != null)
                {
                    dbMascota.Nombre = mascota.Nombre;
                    dbMascota.Descripcion = mascota.Descripcion;
                    dbMascota.Dueno = mascota.Dueno;

                    _dbcontext.Mascota.Update(dbMascota);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbMascota.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = " Mascota no encontrada";
                }
            }
            catch (Exception ex)
            {
                responseApi.EsCorrecto = false;
                responseApi.Mensaje = ex.Message;
            }

            return Ok(responseApi);
        }
        [HttpDelete]
        [Route("Eliminar/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbMascota = await _dbcontext.Mascota.FirstOrDefaultAsync(x => x.Id == id);

                if (dbMascota != null)
                {
                    _dbcontext.Mascota.Remove(dbMascota);
                    await _dbcontext.SaveChangesAsync();

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = dbMascota.Id;
                }
                else
                {
                    responseApi.EsCorrecto = false;
                    responseApi.Mensaje = " Mascota no encontrada";
                }
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
