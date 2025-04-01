using System;
using System.Collections.Generic;

namespace ProximaEnergia.Entity;

public partial class TarifasConsumo
{
    public int IdTarifa { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime InicioVigencia { get; set; }

    public DateTime? FinVigencia { get; set; }

    public string CodTarifaAcceso { get; set; } = null!;

    public int? IdProductoComercial { get; set; }

    public bool AñadirComisionAPrecios { get; set; }

    public int? IdComisionComercialTipo { get; set; }

    public int? IdComisionComercialAjustada { get; set; }

    public string? CodCanal { get; set; }

    public int? IdModeloFactura { get; set; }

    public virtual ICollection<TarifasAcuerdo> TarifasAcuerdos { get; set; } = new List<TarifasAcuerdo>();
}
