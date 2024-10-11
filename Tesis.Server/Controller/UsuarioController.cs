using BlazorCrud.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Tesis.Server.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost()]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            SesionDTO sesionDTO = new SesionDTO();
            if (login.Correo == "admin" && login.Contrasenia == "admin")
            {
                sesionDTO.Nombre = "Administrador";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Administrador";

            }
            else
            {
                sesionDTO.Nombre = "Empleado";
                sesionDTO.Correo = login.Correo;
                sesionDTO.Rol = "Empleado";
            }
            return StatusCode(StatusCodes.Status200OK, sesionDTO);
        }
    }
}
