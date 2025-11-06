using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Vozniki
{
    public int Id { get; set; }

    public int? Voznik { get; set; }
    [Display(Name ="Opis voznika")]
    public string? Opis { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public bool? Sinhronizirano { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
