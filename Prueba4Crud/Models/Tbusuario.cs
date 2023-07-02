using System;
using System.Collections.Generic;

namespace Prueba4Crud.Models;

public partial class Tbusuario
{
    public int IdUsuario { get; set; }

    public string? Clave { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public string? Fono { get; set; }

    public string? Perfil { get; set; }
}
