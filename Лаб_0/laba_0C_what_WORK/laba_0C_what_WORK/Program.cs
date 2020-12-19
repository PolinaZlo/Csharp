using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0C_what_WORK
{
    class Program
    {
        struct orders
        {
            public string itemname;  //наименование
            public int unitCount;       //число единиц
            public double unitCost; //стоимость одной единицы
            public double Sum()
            {
                return unitCount * unitCost;
            }
        }

        static void Main(string[] args)
        {
            orders NewOrder = new orders();
            Console.Write("Что вы покупаете? -> ");
            string s = Console.ReadLine();
            NewOrder.itemname = s;
            Console.Write("Сколько вы покупаете? -> ");
            s = Console.ReadLine();
            NewOrder.unitCount = int.Parse(s);
            Console.Write("Стоимость одной единицы? -> ");
            s = Console.ReadLine();
            NewOrder.unitCost = double.Parse(s);
            Console.Write("\tСуммарная стоимость = " + NewOrder.Sum());
            Console.ReadKey();

        }
    }
}
