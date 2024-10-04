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
    public class LoginController : ControllerBase
    {
        private readonly TesisContext _dbcontext;

        public LoginController(TesisContext dbContext)
        {
            _dbcontext = dbContext;
        }

       

    }
}

