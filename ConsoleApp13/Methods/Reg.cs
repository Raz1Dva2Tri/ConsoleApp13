using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp13.Methods
{
    internal class Reg
    {

        public static void  RegAdmin(PmpDbContext dbcontex)
        {
            dbcontex.АдминистраторыБдs.Add(new() { IdСотрудника = 234, Пароль = "РазДваТри"} );
            dbcontex.SaveChanges();
            return; 

        }
        public static void RegSotr(PmpDbContext dbcontex)
        {
            Console.WriteLine("Введите фамилию:");
            string name_f = Console.ReadLine();

            Console.WriteLine("Введите имя:");
            string name = Console.ReadLine();

            Console.WriteLine("Введите отчество:");
            string name_o = Console.ReadLine();

            Console.WriteLine("Введите номер телефона:");
            decimal numb = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Введите дату рождения:");
            DateTime dt = DateTime.Parse(Console.ReadLine());

            int age = 222222;
            Console.WriteLine("Введите Email:");
            string Email_ = Console.ReadLine();


            dbcontex.Сотрудникиs.Add(new()
            {
                Фамилия = name_f,
                Имя = name,
                Отчество = name_o,
                НомерТелефона = numb,
                ДатаРождения = dt,
                ВозрастЛет = age,
                Email = Email_
            }) ;
            dbcontex.SaveChanges();
            return;

        }
    }
}
