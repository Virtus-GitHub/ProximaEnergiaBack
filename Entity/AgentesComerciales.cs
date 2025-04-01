using System;
using System.Collections.Generic;

namespace ProximaEnergia.Entity;

public partial class AgentesComerciales
{
    public int IdAgente { get; set; }

    public string? Nombre { get; set; }

    public string? Estado { get; set; }

    public string? NIF { get; set; }

    public virtual ICollection<AcuerdosComerciales> AcuerdosComerciales { get; set; } = new List<AcuerdosComerciales>();
}
