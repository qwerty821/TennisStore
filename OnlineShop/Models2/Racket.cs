using System;
using System.Collections.Generic;

namespace OnlineStore.Models2;

public partial class Racket
{
    public Guid RId { get; set; }

    public string RName { get; set; } = null!;

    public Guid? RBrand { get; set; }

    public decimal RPrice { get; set; }

    public string RImageUrl { get; set; } = null!;

    public virtual Brand? RBrandNavigation { get; set; }
}
