using System;
using System.Collections.Generic;

namespace ProximaEnergia.Entity;

public partial class TarifasAcuerdo
{
    public int IdTarifaAcuerdo { get; set; }

    public int IdAcuerdo { get; set; }

    public int? IdTarifa { get; set; }

    public int PorcRenovacion { get; set; }

    public DateOnly FechaVigor { get; set; }

    public virtual AcuerdosComerciales IdAcuerdoNavigation { get; set; } = null!;

    public virtual TarifasConsumo? IdTarifaNavigation { get; set; }
}
