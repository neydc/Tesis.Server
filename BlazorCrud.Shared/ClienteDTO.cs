using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre en el campo{0}")]
        public string ?Correo { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre en el campo{0}")]
        public string? Contrasenia { get; set; }
    }
}
