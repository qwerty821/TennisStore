using System;
using System.Collections.Generic;

namespace OnlineStore.Models.RacketsModels;

public partial class Image
{
    public Guid Id { get; set; }
    
    public Guid? RefId { get; set; }

    public string ImageUrl { get; set; } = null!;
}
