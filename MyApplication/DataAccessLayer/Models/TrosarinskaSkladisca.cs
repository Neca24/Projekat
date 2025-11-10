using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class TrosarinskaSkladisca
{
    /// <summary>
    /// Stevilka skladisca
    /// </summary>
    public int? Id { get; set; }

    /// <summary>
    /// Naziv skladisca
    /// </summary>
    public string? Opis { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
