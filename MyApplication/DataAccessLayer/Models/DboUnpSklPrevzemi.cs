using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboUnpSklPrevzemi
{
    public int? PrevzemniNalog { get; set; }

    public int? Skladisce { get; set; }

    public int? Lastnik { get; set; }

    public string? NacinPrevzema { get; set; }

    public int? TipPrevoznegaSredstva { get; set; }

    public DateTime? DatumPrevzema { get; set; }

    public int? Voznik { get; set; }

    public int? Vozilo { get; set; }

    public int? VrstaPlina { get; set; }

    public int? Dobavitelj { get; set; }

    public string? DokumentDobavitelja { get; set; }

    public double? KolicinaPoDokumentih { get; set; }

    public DateTime? DatumPrevzemaKonec { get; set; }

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
