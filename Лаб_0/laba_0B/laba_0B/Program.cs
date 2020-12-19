using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0B
{
    class Program
    {
        static void ProcessCup(HotDrink cup)
        {
            int tmp,again;//значения добавок, повтор чашки
            double capacity;
            ICup c = (ICup)cup;
            if (cup is Cup_of_Cofee)
            {
                Console.ResetColor();
                Cup_of_Cofee drink = (Cup_of_Cofee)cup;
                Console.Write("Тип зёрен: арабика или робуста (по умолч. арабика): ");
                Console.ForegroundColor = ConsoleColor.Red;
                drink.BeanType = Console.ReadLine();
                Console.ResetColor();
                Console.Write("Сахар: 0...5 (по умолч. 0): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (int.TryParse(Console.ReadLine(), out tmp)) drink.Sugar = tmp;
                Console.ResetColor();
                Console.Write("Молоко: 0...10 (по умолч. 0): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (int.TryParse(Console.ReadLine(), out tmp)) drink.Milk = tmp;
                Console.ResetColor();
                Console.Write("Тип стакана: пластик или стекло (по умолч. пластик): ");
                Console.ForegroundColor = ConsoleColor.Red;
                drink.Type = Console.ReadLine();
                Console.ResetColor();
                Console.Write("Объем: 0,2 или 0,3 (по умолч. 0,2): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (double.TryParse(Console.ReadLine(), out capacity)) drink.Capacity = capacity;
                Console.ResetColor();
                Console.WriteLine("----------------------------");
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(drink.AddSugar());
                    Console.WriteLine(drink.AddMilk());
                    Console.WriteLine(drink.Drink());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(drink.Wash());
                    Console.Write(drink.Refill());
                    Console.ForegroundColor = ConsoleColor.Red;
                    again = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (again != 1)
                    {
                        Console.Write("\tСпасибо что выпили кофе!");
                        break;
                    }
                    Console.WriteLine(drink.Refill());
                }
            }
            else if (cup is Cup_of_Tea)
            {
                Console.ResetColor();
                Cup_of_Tea drink = (Cup_of_Tea)cup;
                Console.Write("Тип чая: черный или зелёный (по умолч. черный): ");
                Console.ForegroundColor = ConsoleColor.Red;
                drink.LeafType = Console.ReadLine();
                Console.ResetColor();
                Console.Write("Сахар: 0...5 (по умолч. 0): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (int.TryParse(Console.ReadLine(), out tmp)) drink.Sugar = tmp;
                Console.ResetColor();
                Console.Write("Молоко: 0...10 (по умолч. 0): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (int.TryParse(Console.ReadLine(), out tmp)) drink.Milk = tmp;
                Console.ResetColor();
                Console.Write("Тип стакана: пластик или стекло (по умолч. стекло): ");
                Console.ForegroundColor = ConsoleColor.Red;
                drink.Type = Console.ReadLine();
                Console.ResetColor();
                Console.Write("Объем: 0,2 или 0,3 (по умолч. 0,2): ");
                Console.ForegroundColor = ConsoleColor.Red;
                if (double.TryParse(Console.ReadLine(), out capacity)) drink.Capacity = capacity;
                Console.ResetColor();
                Console.WriteLine("----------------------------");
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(drink.AddSugar());
                    Console.WriteLine(drink.AddMilk());
                    Console.WriteLine(drink.Drink());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(drink.Wash());
                    Console.Write(drink.Refill());
                    Console.ForegroundColor = ConsoleColor.Red;
                    again = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();
                    if (again != 1)
                    {
                        Console.Write("\tСпасибо что выпили чай!");
                        break;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int Ch;//выбор кофе или чай
            try
            {
                Console.Write("Выберите напиток: кофе[1] или чай[2] -> "); Console.ForegroundColor = ConsoleColor.Red;
                Ch = Convert.ToInt32(Console.ReadLine());
                if (Ch == 1)
                {
                    Cup_of_Cofee cup1 = new Cup_of_Cofee();
                    ProcessCup(cup1);
                }
                if(Ch==2)
                {
                    Cup_of_Tea cup2 = new Cup_of_Tea();
                    ProcessCup(cup2);
                }
            }
            catch {
                Console.ResetColor();
                Console.WriteLine("Некорректный ввод");
            }
            Console.ReadKey();
        }
    }
}
