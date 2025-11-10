using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboUnpSklIzdaje
{
    public int? TocilniNalog { get; set; }

    public int? OdpremniNalog { get; set; }

    public int? Skladisce { get; set; }

    public int? Lastnik { get; set; }

    public string? NacinOdpreme { get; set; }

    public int? TipPrevoznegaSredstva { get; set; }

    public DateTime? DatumOdpreme { get; set; }

    public int? Voznik { get; set; }

    public int? Vozilo { get; set; }

    public string? Relacija { get; set; }

    public int? VrstaPlina { get; set; }

    public double? PredvidenaKolicina { get; set; }

    public int? DokumentDobavnice { get; set; }

    public DateTime? DatumOdpremeKonec { get; set; }

    public double? DejanskaKolicina { get; set; }

    public string? Operater { get; set; }

    public int? Status { get; set; }

    public int? Veljavnost { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
