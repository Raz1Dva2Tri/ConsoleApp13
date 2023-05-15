using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class Сотрудники
{
    public int IdСотрудника { get; set; }

    public string Фамилия { get; set; } = null!;

    public string Имя { get; set; } = null!;

    public string? Отчество { get; set; }

    public decimal НомерТелефона { get; set; }

    public DateTime ДатаРождения { get; set; }

    public int? ВозрастЛет { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Сделки> Сделкиs { get; set; } = new List<Сделки>();
}
