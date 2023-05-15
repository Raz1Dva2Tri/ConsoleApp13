using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp13.Model;

public partial class АдминистраторыБд
{
    [Key]
    public int IdСотрудника { get; set; }

    public string Пароль { get; set; } = null!;

    public virtual Сотрудники IdСотрудникаNavigation { get; set; } = null!;
}
