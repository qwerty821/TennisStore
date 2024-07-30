using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace OnlineStore.Models2;

public partial class Brand
{
    public Guid BId { get; set; }
    public string BName { get; set; } = null!;

    public string BImage { get; set; } = null!;
    public virtual ICollection<Racket> Rackets { get; set; } = new List<Racket>();
}
