using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PrevoznoSredstvo
{
    public int Id { get; set; }

    public string? Opis { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
