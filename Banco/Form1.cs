using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banco
{
    public partial class Form1 : Form
    {
        private Conta[] contas;
        private int numeroDeContas;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.contas = new Conta[1];
            
            //Cliente titular1 = new Cliente("victor");
            //int numero1 = 1;
            //this.AdicionaConta(titular1, numero1, 1);

            
            //Cliente titular2 = new Cliente("mauricio");
            //int numero2 = 2;
            //this.AdicionaConta(titular2, numero2, 1);

            //Cliente titular3 = new Cliente("osni");
            //int numero3 = 3;
            //this.AdicionaConta(titular3, numero3, 0);

            //Carregar o Combobox
            //foreach (Conta c in contas)
            //{
            //    comboContas.Items.Add(c.Titular.Nome);
            //}

            //Carregar o Combobox da transferencia
            foreach (Conta c in contas)
            {
                comboDestinoTransferencia.Items.Add(c.Titular.Nome);
            }

        }

        private void botaoDeposito_Click(object sender, EventArgs e)
        {
            //string valorDigitado = textoValor.Text;
            //double valorOperacao = Convert.ToDouble(valorDigitado);
            //this.contas.Deposita(valorOperacao);
            //textoSaldo.Text = Convert.ToString(this.contas.Saldo);
            //MessageBox.Show("Sucesso!");

            // primeiro precisamos recuperar o índice da conta selecionada
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboContas.SelectedIndex;
            // e depois precisamos ler a posição correta do array
            Conta selecionada = this.contas[indice];
            
            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Deposita(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);

        }

        private void botaoSaque_Click(object sender, EventArgs e)
        {
            //string valorDigitado = textoValor.Text;
            //double valorOperacao = Convert.ToDouble(valorDigitado);
            //this.contas.Saca(valorOperacao);
            //textoSaldo.Text = Convert.ToString(this.contas.Saldo);
            //MessageBox.Show("Sucesso!");

            // primeiro precisamos recuperar o índice da conta selecionada
            //int indice = Convert.ToInt32(textoIndice.Text);
            int indice = comboContas.SelectedIndex;
            // e depois precisamos ler a posição correta do array
            Conta selecionada = this.contas[indice];

            double valor = Convert.ToDouble(textoValor.Text);
            selecionada.Saca(valor);
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);

        }

        //private void botaoBusca_Click(object sender, EventArgs e)
        //{
        //    int indice = Convert.ToInt32(textoIndice.Text);
        //    Conta selecionada = this.contas[indice];
        //    textoNumero.Text = Convert.ToString(selecionada.Numero);
        //    textoTitular.Text = selecionada.Titular.Nome;
        //    textoSaldo.Text = Convert.ToString(selecionada.Saldo);
        //}

        private void comboContas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = comboContas.SelectedIndex;
            Conta selecionada = contas[indice];
            textoTitular.Text = selecionada.Titular.Nome;
            textoSaldo.Text = Convert.ToString(selecionada.Saldo);
            textoNumero.Text = Convert.ToString(selecionada.Numero);

        }

        private void botaoTransfere_Click(object sender, EventArgs e)
        {
            int indiceContaDestino = comboDestinoTransferencia.SelectedIndex;
            int indiceContaOrigem = comboContas.SelectedIndex;
            Conta origemTransferencia = contas[indiceContaOrigem];
            Conta destinoTransferencia = contas[indiceContaDestino];

            double valorTransferencia = Convert.ToDouble(textoValor.Text);
            origemTransferencia.Saca(valorTransferencia);
            destinoTransferencia.Deposita(valorTransferencia);

            textoSaldo.Text = Convert.ToString(origemTransferencia.Saldo);

        }

        public void AdicionaConta(Cliente titular, int numero, int tipoConta) // se tipo for 0 é Corrente e se for 1 é Poupança
        {

            if (tipoConta == 0) // se for pra criar conta Corrente
            {
                Conta c1 = new ContaCorrente();
                c1.Titular = titular;
                c1.Numero = numero;
                this.contas[this.numeroDeContas] = c1;
                comboContas.Items.Add("titular: " + c1.Titular.Nome + this.numeroDeContas);
                comboDestinoTransferencia.Items.Add(c1.Titular.Nome);
                //Aumenta o tamanho do vetor
                Array.Resize(ref  contas, contas.Length + 1);
            }
            else // se for pra criar conta Poupança
            {
                Conta c2 = new ContaPoupanca();
                c2.Titular = titular;
                c2.Numero = numero;
                this.contas[this.numeroDeContas] = c2;
                comboContas.Items.Add("titular: " + c2.Titular.Nome + this.numeroDeContas);
                comboDestinoTransferencia.Items.Add(c2.Titular.Nome);
                //Aumenta o tamanho do vetor
                Array.Resize(ref  contas, contas.Length + 1);
            }
            this.numeroDeContas++;
            
        }

        private void botaoNovaConta_Click(object sender, EventArgs e)
        {
            // this representa a instância de Form1 que está sendo utilizada pelo
            // Windows Form
            FormCadastroConta formularioDeCadastro = new FormCadastroConta(this);
            formularioDeCadastro.ShowDialog();
        }

        private void botaoImpostos_Click(object sender, EventArgs e)
        {
            ContaCorrente contaCC = new ContaCorrente();
            contaCC.Deposita(200.0);

            MessageBox.Show("imposto da conta corrente = " + contaCC.CalculaTributos());
            ITributavel t = contaCC;

            MessageBox.Show("imposto da conta pela interface = " + t.CalculaTributos());

            SeguroDeVida sv = new SeguroDeVida();
            MessageBox.Show("imposto do seguro = " + sv.CalculaTributos());

            t = sv;
            MessageBox.Show("imposto do seguro pela interface" + t.CalculaTributos());
        }

    }
}
