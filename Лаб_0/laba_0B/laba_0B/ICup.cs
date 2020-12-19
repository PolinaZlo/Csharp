using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_0B
{
    public interface ICup
    {
        string Type { get; set; }

        double Capacity { get; set; }

        string Refill();

        string Wash();
    }
}
