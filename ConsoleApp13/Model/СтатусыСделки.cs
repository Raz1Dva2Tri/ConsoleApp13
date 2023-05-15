using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class СтатусыСделки
{
    public int IdСтатусаСделки { get; set; }

    public string СтатусСделки { get; set; } = null!;

    public virtual ICollection<Сделки> Сделкиs { get; set; } = new List<Сделки>();
}
