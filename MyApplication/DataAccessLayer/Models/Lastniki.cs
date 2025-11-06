using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Lastniki
{
    public int? Id { get; set; }

    public int? PoslovniPartner { get; set; }

    public string? NazivPp { get; set; }

    public string? NazivPpDod { get; set; }

    public string? NaslovPp { get; set; }

    public string? KrajPp { get; set; }

    public string? HisnaStevilka { get; set; }

    public string? Dodatek { get; set; }

    public string? DavcnaStevilka { get; set; }

    public string? StatusDdv { get; set; }

    public string? PostnaStevilka { get; set; }

    public string? Kraj { get; set; }

    public int? Drzava { get; set; }

    public string? Naziv { get; set; }

    public bool? Sinhronizirano { get; set; }

    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
