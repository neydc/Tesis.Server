using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tesis.Server.Models;
using BlazorCrud.Shared;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        [HttpGet]
        [Route("Buscar/{id}")]
        public async Task<IActionResult> Buscar(int id)
        {
            var responseApi = new ResponseAPI<MascotaDTO>();
            var mascotaBuscada = new MascotaDTO();

            try
            {
                var dbEmpleado = await _dbcontext.Mascota.FirstOrDefaultAsync(x => x.Id == id);
                if (dbEmpleado != null)
                {
                    mascotaBuscada.Id = dbEmpleado.Id;
                    mascotaBuscada.Nombre = dbEmpleado.Nombre;
                    mascotaBuscada.Descripcion = dbEmpleado.Descripcion;
                    mascotaBuscada.Dueno = dbEmpleado.Dueno;

                    responseApi.EsCorrecto = true;
                    responseApi.Valor = mascotaBuscada;
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
        public async Task<IActionResult> Guardar(MascotaDTO mascota)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbMascota = new Mascota() { 
                Id = mascota.Id,  
                Nombre = mascota.Nombre,
                Dueno = mascota.Dueno,
                Descripcion = mascota.Descripcion,
                };

                _dbcontext.Mascota.Add(dbMascota);
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
        public async Task<IActionResult> Editar(MascotaDTO mascota,int id)
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
