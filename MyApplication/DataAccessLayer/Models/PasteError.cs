using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class PasteError
{
    public string? Field0 { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
