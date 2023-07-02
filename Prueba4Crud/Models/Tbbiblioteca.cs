using System;
using System.Collections.Generic;

namespace Prueba4Crud.Models;

public partial class Tbbiblioteca
{
    public int IdLibro { get; set; }

    public string? Nombre { get; set; }

    public int? Año { get; set; }

    public string? Especialidad { get; set; }

    public string? Autor { get; set; }
}
