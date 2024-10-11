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
                sesionDTO.Nombre = dbEmpleado.Nombres;
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";
                return StatusCode(StatusCodes.Status200OK, sesionDTO);
            }
            else
            {
                // Si el usuario no existe o las credenciales son incorrectas, retornar 401 (Unauthorized)
                return StatusCode(StatusCodes.Status401Unauthorized, "Correo o contraseña incorrectos.");

            }
        }
    }
}
