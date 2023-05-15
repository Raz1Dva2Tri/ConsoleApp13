using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class Сделки
{
    public int IdПокупателя { get; set; }

    public int IdМеталлопродукции { get; set; }

    public DateTime ДатаЗаказа { get; set; }

    public int КоличествоЕд { get; set; }

    public int IdЕдиницыИзмерения { get; set; }

    public int КоэффициентЦены { get; set; }

    public int СтоимостьРуб { get; set; }

    public DateTime ДатаПоставкиПлан { get; set; }

    public DateTime? ДатаПоставкиФакт { get; set; }

    public int ПродолжительностьПоставкиДниПлан { get; set; }

    public int? ПродолжительностьПоставкиДниФакт { get; set; }

    public int IdСотрудника { get; set; }

    public int IdСтатусаСделки { get; set; }

    public virtual ЕдиницыИзмерения IdЕдиницыИзмеренияNavigation { get; set; } = null!;

    public virtual Металлопродукция IdМеталлопродукцииNavigation { get; set; } = null!;

    public virtual Покупатели IdПокупателяNavigation { get; set; } = null!;

    public virtual Сотрудники IdСотрудникаNavigation { get; set; } = null!;

    public virtual СтатусыСделки IdСтатусаСделкиNavigation { get; set; } = null!;
}
