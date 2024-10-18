using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrud.Shared
{
    public class MascotaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre en el campo{0}")]
        public string? Nombre { get; set; } = null;
        [Required(ErrorMessage = "Ingrese una descripción en el campo{0}")]
        public string? Descripcion { get; set; }
        [Required(ErrorMessage = "Ingrese el nombre del dueño en el campo{0}")]
        public string? Dueno { get; set; }
    }
}
