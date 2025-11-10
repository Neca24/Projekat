using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboBisVozilaUnp
{
    public int? Vozilo { get; set; }

    public string? Opis { get; set; }

    public string? RegistrskaOznaka { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public DateTime? ZacetekVozenj { get; set; }

    public DateTime? KonecVozenj { get; set; }

    public int? Dostopnost { get; set; }

    public int? Voznik { get; set; }
}
