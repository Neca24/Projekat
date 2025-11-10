using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboPostum
{
    public string? PostnaStevilka { get; set; }

    public string? Kraj { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public string? Naziv { get; set; }

    public string? Opis { get; set; }
}
