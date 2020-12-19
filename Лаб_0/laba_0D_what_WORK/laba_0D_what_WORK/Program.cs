using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0D_what_WORK
{
    class Program
    {
        static void Main(string[] args)
        {
            int Num, sum;
            Console.Write("Введите число -> ");
            Num = int.Parse(Console.ReadLine());
            Console.Write("2147483647 + " + Num + " = ");
            try
            {
                checked //uncheked - проигнорирует и срежет
                {
                    //int.MaxValue
                    sum = 2147483647 + Num;//переполнение -> генерируется исключение
                }
                Console.Write(sum);
            }
            catch (Exception ex) { Console.WriteLine("\n"+ex); }
            Console.ReadKey();

        }
    }
}
