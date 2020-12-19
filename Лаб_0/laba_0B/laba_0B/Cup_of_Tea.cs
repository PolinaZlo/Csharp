using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0B
{
    public class Cup_of_Tea:HotDrink,ICup
    {
        private string leaftype = "черный";//тип чая
        private double capacity = 0.2;//емкость чашки
        private string type = "стекло";//

        public string LeafType
        {
            get { return leaftype; }
            set
            {
                if (value == "черный" || value == "зеленый") leaftype = value;
            }
        }

        public double Capacity
        {
            get { return capacity; }
            set
            {
                if (value == 0.2 || value == 0.3) capacity = value;
            }
        }

        public override int Milk
        {
            get { return milk; }
            set
            {
                if (value >= 0 && value <= 10) milk = value;
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

        public string Type
        {
            get { return type; }
            set
            {
                if (value == "пластик" || value == "стекло") type = value;
            }
        }

        public override string AddMilk()
        { return "В чай добавлено молоко: " + milk; }

        public override string AddSugar()
        { return "В чай добавлен сахар: " + sugar; }

        public override string Drink()
        { return "Получите "+ leaftype +" чай"; }

        public string Refill()
        { return "Повторить чай объемом " + capacity + " мл. Да[1], Нет[2] -> "; }

        public string Wash()
        { return "Вымыть " + type + " чашку с чаем"; }
    }
}
