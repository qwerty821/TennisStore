using System;
using System.Collections.Generic;

namespace OnlineStore.Models.RacketsModels;

public partial class Brand
{
    public Guid BId { get; set; }

    public string BName { get; set; } = null!;

    public virtual ICollection<Racket> Rackets { get; set; } = new List<Racket>();
}
