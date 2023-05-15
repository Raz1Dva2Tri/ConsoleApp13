using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class Покупатели
{
    public int IdПокупателя { get; set; }

    public string НаименованиеПокупателя { get; set; } = null!;

    public string? АббревиатураПокупателя { get; set; }

    public decimal НомерТелефона { get; set; }

    public int IdГорода { get; set; }

    public string АдресРегистрации { get; set; } = null!;

    public virtual Города IdГородаNavigation { get; set; } = null!;

    public virtual ICollection<Сделки> Сделкиs { get; set; } = new List<Сделки>();
}
