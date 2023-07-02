using System;
using System.Collections.Generic;

namespace Prueba4Crud.Models;

public partial class Tbpaciente
{
    public int IdPaciente { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Fono { get; set; }

    public string? Correo { get; set; }

    public int? Edad { get; set; }

    public string? Dirección { get; set; }

    public string? Previsión { get; set; }

    public virtual ICollection<Tbcita> Tbcita { get; set; } = new List<Tbcita>();
}
