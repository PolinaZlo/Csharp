using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0B
{
    public class Cup_of_Cofee:HotDrink,ICup
    {
        private string beantype = "арабика";
        private double capacity = 0.2;
        private string type = "пластик";
        public double Capacity
        {
            get { return capacity; }
            set
            {
                if (value == 0.2 || value == 0.3) capacity = value;
            }
        }
        public string Type
        {
            get { return type; }
            set
            {
                if (value == "пластик" || value == "стекло") type = value;
            }
        }
        public override int Milk
        {
            get { return milk; }
            set
            {
                if (value >= 0  && value <= 10) milk = value;
            }
        }

        public override int Sugar
        {
            get { return sugar; }
            set
            {
                if (value >= 0 && value <= 5) sugar = value;
            }
        }
        public string BeanType
        {
            get { return beantype; }
            set
            {
                if (value == "арабика" || value == "робуста") beantype = value;
            }
        }
        public string Refill()
        {return "Повторить кофе объемом " + capacity + " мл. Да[1], Нет[2] -> ";}

        public string Wash()
        { return "Вымыть " + type + " чашку с кофе"; }

        public override string AddMilk()
        { return "В кофе добавлено молоко: " + milk; }

        public override string AddSugar()
        { return "В кофе добавлен сахар: " + sugar;}

        public override string Drink()
        { return "Получите кофе: " + beantype; }
    }
}
