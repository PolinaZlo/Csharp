using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0A
{
    class Angle
    {
                public int gr; //число градусов
        public float min; //число минут 
        public char s; //число указания направления (N, S, E  или  W).
        public Angle() //по умолчанию
        {
            gr = 0;
            min = 0;
            s = 'S';
        }
        public Angle(int gr, float min, char s) //конструктор класса, с 3 переменными
        {
            this.gr = gr;
            this.min = min;
            this.s = s;
        }
        virtual public void Show()
        {
            Console.WriteLine("Градусы = {0}, минуты = {1}, направление = {2}.", gr, min, s);
        }
    }
}
