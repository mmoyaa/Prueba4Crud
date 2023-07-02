using System;
using System.Collections.Generic;

namespace Prueba4Crud.Models;

public partial class Tbcita
{
    public int IdCita { get; set; }

    public DateTime? Fecha { get; set; }

    public TimeSpan? Hora { get; set; }

    public string? Previsión { get; set; }

    public string? ModoCita { get; set; }

    public int? IdDoctor { get; set; }

    public int? IdPaciente { get; set; }

    public virtual Tbdoctor? IdDoctorNavigation { get; set; }

    public virtual Tbpaciente? IdPacienteNavigation { get; set; }
}
