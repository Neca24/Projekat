using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboBisVoznikiUnp
{
    public int? Voznik { get; set; }

    public string? Opis { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }
}
