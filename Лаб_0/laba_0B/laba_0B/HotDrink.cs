using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0B
{
    public abstract class HotDrink
    {
        protected int sugar=0, milk=0;//защищен поля
        
        public virtual int Milk { get; set; }
        public virtual int Sugar { get; set; }
        public abstract string AddMilk();
        public abstract string AddSugar();
        public abstract string Drink();
    }
}
