using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class VrstePlina
{
    public int Id { get; set; }

    public int? VrstaPlina { get; set; }

    public string? Opis { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public bool? Sinhronizirano { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
