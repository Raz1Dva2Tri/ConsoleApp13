using System;
using System.Collections.Generic;

namespace ConsoleApp13.Model;

public partial class АдминистраторыБдМониторинг
{
    public string Пользователь { get; set; } = null!;

    public string Компьютер { get; set; } = null!;

    public string Операция { get; set; } = null!;

    public string? ПрежнееЗначение { get; set; }

    public string? НовоеЗначение { get; set; }

    public DateTime ВремяМодификации { get; set; }
}
