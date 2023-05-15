using ConsoleApp13;
using ConsoleApp13.Methods;

PmpDbContext dbContext = new PmpDbContext();

Console.WriteLine(dbContext.Городаs.ToList()[0].Город.ToString());


void menu() {

    Console.WriteLine("1. Вход");
    Console.WriteLine("2. Регистрация");
    Console.WriteLine("3. Выход");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
            Console.WriteLine("Вы выбрали Вход.");
            // Здесь может быть код для регистрации пользователя
            break;
        case "2":
            reg();
            break;
        case "3":
            Console.WriteLine("Вы выбрали Выход.");
            // Здесь может быть код для завершения программы
            break;
        default:
            Console.WriteLine("Некорректный выбор.");
            return;
    }
}


void reg()
{
    {
        Console.WriteLine("Выберите пункт меню:");
        Console.WriteLine("1. Я Администратор");
        Console.WriteLine("2. Я Покупатель");
        Console.WriteLine("3. Я Сотрудник");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.WriteLine("Вы выбрали Администраторы.");
                Reg.RegAdmin(dbContext);

                break;
            case "2":
                
                break;
            case "3":
                Console.WriteLine("Вы выбрали Сотрудники.");
                Reg.RegSotr(dbContext);
                // Здесь может быть код для сотрудников
                break;
            default:
                Console.WriteLine("Некорректный выбор.");
                break;
        }

        Console.ReadKey();
    }
}

menu(); 
Console.ReadKey();
