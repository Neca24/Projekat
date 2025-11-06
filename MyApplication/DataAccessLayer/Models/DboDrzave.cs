using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboDrzave
{
    public int? Drzava { get; set; }

    public string? SimbolA2 { get; set; }

    public string? SimbolA3 { get; set; }

    public string? Naziv { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }
}
