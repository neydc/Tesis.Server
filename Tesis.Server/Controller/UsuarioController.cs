using BlazorCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tesis.Server.Models;

namespace Tesis.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly TesisContext _dbcontext;

        public UsuarioController(TesisContext dbContext)
        {
            _dbcontext = dbContext;
        }

        [HttpPost()]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            var dbEmpleado = await _dbcontext.Cliente.FirstOrDefaultAsync(x => x.Correo == login.Correo && x.Contrasenia ==login.Contrasenia );

            if (dbEmpleado!=null)
            {
               // sesionDTO.Nombre = dbEmpleado.Nombres; 
                sesionDTO.Nombre = dbEmpleado.Nombres;
                sesionDTO.Correo = dbEmpleado.Correo;
                sesionDTO.Rol = dbEmpleado.RolUser;
                return StatusCode(StatusCodes.Status200OK, sesionDTO);
            }
            else
            {
                // Si el usuario no existe o las credenciales son incorrectas, retornar 401 (Unauthorized)
                return StatusCode(StatusCodes.Status401Unauthorized, "Correo o contraseña incorrectos.");

            }
        }

        [HttpPost]
        [Route("Registrarse")]
        public async Task<IActionResult> Registrarse(Cliente cliente)
        {
            var responseApi = new ResponseAPI<int>();
            try
            {
                var dbMascota = new Cliente
                {
                    Correo = cliente.Correo,
                    Contrasenia = cliente.Contrasenia,
                    Nombres = cliente.Nombres,
                    RolUser = cliente.RolUser,
                    Celular = cliente.Celular,
                    Direccion = cliente.Direccion
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
    }
}
