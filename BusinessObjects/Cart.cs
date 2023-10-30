using System;
using System.Collections.Generic;

namespace BusinessObjects;

public partial class Cart
{
    public int CartdId { get; set; }

    public int? ProductId { get; set; }

    public int? UserId { get; set; }

    public virtual Product? Product { get; set; }

    public virtual User? User { get; set; }
}
