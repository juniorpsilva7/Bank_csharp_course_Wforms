using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class SeguroDeVida : ITributavel
    {
        public double CalculaTributos()
        {
            double taxa = 42.00;
            return taxa;
        }
    }
}
