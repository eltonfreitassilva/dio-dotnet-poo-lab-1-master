using System;
using System.Text;

namespace DIO.Bank
{
	public class Conta
	{
		// Atributos
		private TipoConta TipoConta { get; set; }
		private double Saldo { get; set; }
		private double Credito { get; set; }
		public string Nome { get; private set; }
		public string Agencia { get; private set; }
		public string NumeroConta { get; private set; }
		public string DigitoConta { get; private set; }

		// Métodos
		public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
		{
			this.TipoConta = tipoConta;
			this.Saldo = saldo;
			this.Credito = credito;
			this.Nome = nome;
			this.Agencia = gerarAgencia();
			this.NumeroConta = gerarConta();
			this.DigitoConta = gerarDigitoConta();
		}

		public bool Sacar(double valorSaque)
		{
            // Validação de saldo suficiente
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            // https://docs.microsoft.com/pt-br/dotnet/standard/base-types/composite-formatting

            return true;
		}

		public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
		}

		public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
			retorno += "Agencia " + this.Agencia + " | ";
			retorno += "Cc " + this.NumeroConta ;
			retorno += "-" + this.DigitoConta + " | ";
			retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
			return retorno;
		}

		private string gerarConta()
		{
		    var rd= new	Random();
			var retorno = new StringBuilder();
			for (int i = 0; i < 5; i++)
			{
				retorno.Append(rd.Next(0, 9).ToString());
			}

			return retorno.ToString();
		}

		private string gerarAgencia()
		{
			var rd = new Random();
			var retorno = new StringBuilder();
			for (int i = 0; i < 5; i++)
			{
				retorno.Append(rd.Next(0, 9).ToString());
			}

			return retorno.ToString();
		}

		private string gerarDigitoConta()
		{
			int rd = new Random().Next(0, 9);
			return rd.ToString();
		}
	}
}