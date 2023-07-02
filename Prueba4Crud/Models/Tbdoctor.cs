using System;
using System.Collections.Generic;

namespace Prueba4Crud.Models;

public partial class Tbdoctor
{
    public int IdDoctor { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Fono { get; set; }

    public string? Correo { get; set; }

    public string? Especialidad { get; set; }

    public string? Convenio { get; set; }

    public string? TipoCita { get; set; }

    public virtual ICollection<Tbcita> Tbcita { get; set; } = new List<Tbcita>();
}
