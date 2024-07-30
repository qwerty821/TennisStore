using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Models.RacketsModels;

public partial class Brand
{
    public Guid BId { get; set; }

    public string BName { get; set; } = null!;

    public string BImage { get; set; } = null!;

    public virtual ICollection<Racket> Rackets { get; set; } = new List<Racket>();
}
