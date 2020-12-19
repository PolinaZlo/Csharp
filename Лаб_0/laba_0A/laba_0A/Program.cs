using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0A
{
    class Program
    {
        static void Main(string[] args)
        {
            int a; float b; char c;
            Angle ang = new Angle();
            Console.Write("Введите градусы -> ");
            //try { ang.gr = Convert.ToInt32(Console.ReadLine()); }//не вариант
           // catch { }
            string s = Console.ReadLine();
            if (int.TryParse(s, out a)) { ang.gr = int.Parse(s); }
            Console.Write("Введите минуты -> "); s = Console.ReadLine();
            if (float.TryParse(s, out b)) { ang.min = float.Parse(s); }
            Console.Write("Введите буквой направление (N, S, E  или  W) -> "); s = Console.ReadLine();
            if (char.TryParse(s, out c) && (s == "N" || s == "E" || s == "W" || s == "S")) { ang.s = char.Parse(s); }
            //min = Convert.ToDouble(Console.ReadLine());trypasre
            ang.Show();
            Console.ReadKey();
        }
    }
}
