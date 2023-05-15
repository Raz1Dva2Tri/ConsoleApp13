using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class ЕдиницыИзмерения
{
    public int IdЕдиницыИзмерения { get; set; }

    public string ЕдиницыИзмерения1 { get; set; } = null!;

    public virtual ICollection<Сделки> Сделкиs { get; set; } = new List<Сделки>();
}
