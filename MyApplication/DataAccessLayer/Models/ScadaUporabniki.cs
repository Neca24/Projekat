using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class ScadaUporabniki
{
    /// <summary>
    /// Identifikacijska stev. uporabnika
    /// </summary>
    public short Id { get; set; }

    /// <summary>
    /// Uporabnik SCADA sistem
    /// </summary>
    public string? Uporabnik { get; set; }
}
