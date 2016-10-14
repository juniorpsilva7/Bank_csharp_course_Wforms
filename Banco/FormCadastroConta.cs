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
    public partial class FormCadastroConta : Form
    {
        public Form1 formPrincipal;

        public FormCadastroConta(Form1 formPrincipal)
        {
            this.formPrincipal = formPrincipal;
            InitializeComponent();

            //tentar carregar o combobox de tipo de conta
            comboTipoConta.Items.Add("Corrente"); // índice 0 do combobox
            comboTipoConta.Items.Add("Poupança"); // índice 1 do combobox
        }


        private void botaoCadastro_Click(object sender, EventArgs e)
        {
            
            Cliente titular = new Cliente(textoTitular.Text);
            int numero = Convert.ToInt32(textoNumero.Text);
            //codigo para escolher o tipo de conta
            int tipoDeConta = comboTipoConta.SelectedIndex; // indice 0 é Corrente e indice 1 é Poupança

            //envia os dados par ao metodo para adicionar conta no Form1
            this.formPrincipal.AdicionaConta(titular, numero, tipoDeConta);
            this.Close();

        }

        
    }
}
