using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class DboPoslovniPartnerji
{
    public int? PoslovniPartner { get; set; }

    public int? Drzava { get; set; }

    public string? PostnaStevilka { get; set; }

    public string? VrstaOsebe { get; set; }

    public string? SifraNaselja { get; set; }

    public string? NazivPp { get; set; }

    public string? NazivPpDod { get; set; }

    public string? NaslovPp { get; set; }

    public string? KrajPp { get; set; }

    public string? HisStevilka { get; set; }

    public string? Dodatek { get; set; }

    public string? Stanovanje { get; set; }

    public string? StatusDdv { get; set; }

    public string? StatusPp { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public string? DimSez { get; set; }

    public int? DimKos { get; set; }

    public int? IdObcine { get; set; }

    public int? IdRpe { get; set; }

    public string? Oznaka { get; set; }

    public string? DdvKodaDrzave { get; set; }

    public string? DdvStevilka { get; set; }

    public string? DavcnaStevilka { get; set; }

    public int? Kategorija { get; set; }

    public string? HisnaStevilka { get; set; }
}
