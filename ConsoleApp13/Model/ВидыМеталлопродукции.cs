using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class ВидыМеталлопродукции
{
    public int IdВидаМеталлопродукции { get; set; }

    public string НаименованиеВидаМеталлопродукции { get; set; } = null!;

    public virtual ICollection<Металлопродукция> Металлопродукцияs { get; set; } = new List<Металлопродукция>();
}
