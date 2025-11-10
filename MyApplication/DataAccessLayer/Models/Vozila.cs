using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Models;

public partial class Vozila
{
    public int Id { get; set; }

    public int? Vozilo { get; set; }
    [Display(Name = "Opis vozila")]
    public string? Opis { get; set; }

    public string? RegistrskaOznaka { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public DateTime? ZacetekVozenj { get; set; }

    public DateTime? KonecVozenj { get; set; }

    public int? Dostopnost { get; set; }

    public int? Voznik { get; set; }

    public bool? Sinhronizirano { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
