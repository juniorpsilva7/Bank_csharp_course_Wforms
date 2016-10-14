using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class ContaPoupanca : Conta
    {

        public override void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        public override void Saca(double valor)
        {
            this.Saldo -= valor;
        }


    }
}
