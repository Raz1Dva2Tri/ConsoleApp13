using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class Металлопродукция
{
    public int IdМеталлопродукции { get; set; }

    public string НаименованиеМеталлопродукции { get; set; } = null!;

    public int IdВидаМеталлопродукции { get; set; }

    public virtual ВидыМеталлопродукции IdВидаМеталлопродукцииNavigation { get; set; } = null!;

    public virtual ICollection<Сделки> Сделкиs { get; set; } = new List<Сделки>();
}
