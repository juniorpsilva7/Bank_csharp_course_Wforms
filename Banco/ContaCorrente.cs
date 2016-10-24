using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public class ContaCorrente : Conta, ITributavel
    {
        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override void Saca(double valor)
        {
            this.Saldo -= (valor + 0.10);
        }


        public double CalculaTributos()
        {
            return this.Saldo*0.05;
        }
    }
}
