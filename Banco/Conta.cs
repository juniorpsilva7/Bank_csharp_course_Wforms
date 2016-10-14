using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banco
{
    public abstract class Conta
    {
        //ATRIBUTOS
        public int Numero { get; set; }
        public double Saldo { get; set; }
        public Cliente Titular { get; set; }


        //METODOS ABSTRATOS
        public abstract void Deposita(double valor)
        {
            //this.Saldo += valor;
        }

        public abstract void Saca(double valor)
        {
            //this.Saldo -= valor;
        }
    }
}
