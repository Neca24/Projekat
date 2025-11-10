using System;
using System.Collections.Generic;

namespace DataAccessLayer.Models;

public partial class Client
{
    public int Id { get; set; }

    public string? Ip { get; set; }

    public DateTime? DateTime { get; set; }
}
