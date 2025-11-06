using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Models;

public partial class Izdaje
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
    /// Številka izdajnega naloga
    /// </summary>
    public int? TocilniNalog { get; set; }

    public int? OdpremniNalog { get; set; }

    public int? Skladisce { get; set; }

    public int? Lastnik { get; set; }

    public string? NacinOdpreme { get; set; }

    public int? TipPrevoznegaSredstva { get; set; }

    public DateTime? DatumOdpreme { get; set; }

    public int? Voznik { get; set; }
    public Vozniki? Vozniki { get; set; }

    public int? Vozilo { get; set; }
    public Vozila? Vozila { get; set; }

    public string? Relacija { get; set; }

    public int? VrstaPlina { get; set; }

    public double? PredvidenaKolicina { get; set; }

    public int? DokumentDobavnice { get; set; }

    public DateTime? DatumOdpremeKonec { get; set; }

    public double? DejanskaKolicina { get; set; }

    public string? Operater { get; set; }

    public int? Veljavnost { get; set; }

    public int? VpisUporabnik { get; set; }

    [Display(Name ="Vpis datelj")]
    public DateTime? VpisDatetime { get; set; }

    public int? SprUporabnik { get; set; }

    public DateTime? SprDatetime { get; set; }

    public byte? TocilnaPot { get; set; }

    public byte? TocilnoMesto { get; set; }

    /// <summary>
    /// Default na TRUE. Ko vnese nekdo novi RS cez SCADO se ta avtomatsko postavi na TRUE. Ko se RS prenese v PIS se postavi na FALSE.
    /// </summary>
    public bool? ScadaVnos { get; set; }

    public bool? Prikaz { get; set; }

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
