using System;
using System.Collections.Generic;

namespace Tesis.Server.Models;

public partial class Mascota
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Dueno { get; set; }
}
