using BancoUm.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoUm.Classes
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        public bool Sacar(double valorSaque)
        {
            //Validação de insuficiência de saldo
            if (Saldo - valorSaque < (Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
            }
            Saldo -= valorSaque;

            Console.WriteLine($"Saldo atual da conta é de : {0} é {1}", Nome, Saldo);

            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine($"Saldo atual da conta é de : {0} é {1}", Nome, Saldo);
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = $"Tipo de conta {TipoConta} | Nome {Nome} | Saldo {Saldo} | Crédito {Credito}";

            return retorno;

        }
    }
}