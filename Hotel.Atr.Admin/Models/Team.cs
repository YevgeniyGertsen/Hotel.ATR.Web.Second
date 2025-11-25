using System;
using System.Collections.Generic;

namespace Hotel.Atr.Admin.Models;

public partial class Team
{
    public int Id { get; set; }

    public DateTime CreateDate { get; set; }

    public string FullName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ImagePath { get; set; } = null!;

    public int PositionId { get; set; }

    public virtual Position Position { get; set; } = null!;
}
