using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Prevzemi
{
    /// <summary>
    /// ID tabele
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 1=odprt, 2=začetek, 3=točenje, 4=zaključevanje, 5=obdelan, 6=prekinjen
    /// </summary>
    public int? Status { get; set; }

    public bool? Sinhronizirano { get; set; }

    /// <summary>
    /// ID od poslovnega sistema
    /// </summary>
    public int? IdPis { get; set; }

    /// <summary>
    /// Številka prevzemnega naloga
    /// </summary>
    public int? PrevzemniNalog { get; set; }

    public int? Skladisce { get; set; }

    public string? NacinPrevzema { get; set; }

    /// <summary>
    /// 1=rezervoar, 2=žel. cist, 3=avto cist.
    /// </summary>
    public int? TipPrevoznegaSredstva { get; set; }

    public DateTime? DatumPrevzema { get; set; }

    public int? Voznik { get; set; }

    public int Vozilo { get; set; }

    public bool? CelotnaCisterna { get; set; }

    public int? VrstaPlina { get; set; }

    public int? Dobavitelj { get; set; }

    public string? DokumentDobavitelja { get; set; }

    public double? KolicinaPoDokumentih { get; set; }

    public DateTime? DatumPrevzemaKonec { get; set; }

    public double? DejanskaKolicina { get; set; }

    public string? Operater { get; set; }

    public int? Veljavnost { get; set; }

    public int? VpisUporabnik { get; set; }

    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public byte? TocilnaPot { get; set; }

    public byte? TocilnoMesto { get; set; }

    public int? Lastnik { get; set; }

    /// <summary>
    /// Default na TRUE. Ko vnese nekdo novi RS cez SCADO se ta avtomatsko postavi na TRUE. Ko se RS prenese v PIS se postavi na FALSE.
    /// </summary>
    public bool? ScadaVnos { get; set; }

    public bool? Prikaz { get; set; }

    public float? VsebnostC3 { get; set; }

    public float? MejaVsebnostC3 { get; set; }

    public float? VsebnostDieni { get; set; }

    public float? MejaVsebnostDieni { get; set; }

    public float? VsebnostOlje { get; set; }

    public float? MejaVsebnostOlje { get; set; }

    public float? VsebnostZveplo { get; set; }

    public float? MejaVsebnostZveplo { get; set; }

    public float? VsebnostPp { get; set; }

    public float? MejaVsebnostPp { get; set; }

    public float? VsebnostC2c4 { get; set; }

    public float? MejaVsebnostC2c4 { get; set; }

    public byte? MmStevilka { get; set; }

    public float? MmTemp { get; set; }

    public string? MmSn { get; set; }

    public int? MmZacetek { get; set; }

    public int? MmKonec { get; set; }

    public int? MmRazlika { get; set; }

    public float? MmKonstanta { get; set; }

    public string? RazlogPrekinitve { get; set; }

    /// <summary>
    /// 0=mala, 1=velika
    /// </summary>
    public byte? VrstaCisterne { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
