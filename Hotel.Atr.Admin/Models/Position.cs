using System;
using System.Collections.Generic;

namespace Hotel.Atr.Admin.Models;

public partial class Position
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
