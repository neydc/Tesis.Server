using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tesis.Server.Models;

public partial class Mascota
{
    [Key]
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Dueno { get; set; }
}
