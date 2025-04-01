using System;
using System.Collections.Generic;

namespace ProximaEnergia.Entity;

public partial class AcuerdosComerciales
{
    public int IdAcuerdo { get; set; }

    public int? IdAgente { get; set; }

    public int? IdTrabajador { get; set; }

    public DateOnly? FechaAlta { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public string? Ambito { get; set; }

    public byte? DuracionMeses { get; set; }

    public bool? ProrrogaAutomatica { get; set; }

    public byte? DuracionProrrogaMeses { get; set; }

    public byte? Exclusividad { get; set; }

    public string? CodFormaPago { get; set; }

    public virtual AgentesComerciales? IdAgenteNavigation { get; set; }

    public virtual ICollection<TarifasAcuerdo> TarifasAcuerdos { get; set; } = new List<TarifasAcuerdo>();
}
