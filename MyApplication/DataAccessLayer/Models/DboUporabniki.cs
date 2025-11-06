using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboUporabniki
{
    public short? Uporabnik { get; set; }

    public string? ImeInPriimek { get; set; }

    public string? Userid { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public int? GroupId { get; set; }

    public int? Delavec { get; set; }

    public string? Status { get; set; }

    public string? Password { get; set; }
}
