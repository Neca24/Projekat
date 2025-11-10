using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class MasaRezervoarji
{
    public DateTime? Datum { get; set; }

    public double? MasaRezervoar1 { get; set; }

    public double? MasaRezervoar2 { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
