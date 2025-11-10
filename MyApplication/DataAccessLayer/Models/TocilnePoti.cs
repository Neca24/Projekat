using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class TocilnePoti
{
    /// <summary>
    /// ID točilne poti
    /// </summary>
    public byte? Id { get; set; }

    /// <summary>
    /// Opis točilne poti
    /// </summary>
    public string? Opis { get; set; }

    /// <summary>
    /// ID prevoznega sredstva
    /// </summary>
    public byte? IdPrevoznoSredstvo { get; set; }

    /// <summary>
    /// ID vrsta plina
    /// </summary>
    public short? VrstaPlina { get; set; }

    /// <summary>
    /// Se gorivo prevzema
    /// </summary>
    public bool? Prevzem { get; set; }

    /// <summary>
    /// Se gorivo izdaja?
    /// </summary>
    public bool? Izdaja { get; set; }

    /// <summary>
    /// Točilno mesto avto pretakališča
    /// </summary>
    public string? TmAp { get; set; }

    /// <summary>
    /// Točilno mesto železniškega pretakališča
    /// </summary>
    public string? TmZp { get; set; }

    /// <summary>
    /// GUI prikaz
    /// </summary>
    public bool? Prikaz { get; set; }

    public byte[] SsmaTimeStamp { get; set; } = null!;
}
