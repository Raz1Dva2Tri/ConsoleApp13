using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class Города
{
    public int IdГорода { get; set; }

    public string Город { get; set; } = null!;

    public virtual ICollection<Покупатели> Покупателиs { get; set; } = new List<Покупатели>();
}
