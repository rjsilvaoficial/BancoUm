using BancoUm.Classes;
using BancoUm.Enum;
using System;
using System.Collections.Generic;

namespace BancoUm
{

    class Program
    {
        static List<Conta> listContas = new List<Conta>();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterUsuario();

            while (opcaoUsuario != "x")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "L":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterUsuario();
            }

            Console.WriteLine("Obrigado por utilizar nossos serviços!");
            Console.ReadLine(); // teste
        }

        private static void Depositar()
        {
            Console.WriteLine("Insira o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do depósito");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indiceConta].Depositar(valorSaque);
        }

        private static void Sacar()
        {
            Console.WriteLine("Insira o número da conta");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor do saque");
            double valorSaque = double.Parse(Console.ReadLine());
            listContas[indiceConta].Sacar(valorSaque);
        }

        private static void Transferir()
        {
            Console.WriteLine("Insira o número da conta de origem");
            int indiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferência");
            double valorTransferido = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o número da conta de destino");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferido, listContas[indiceContaDestino]);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas!");
            if (listContas.Count == 0)
            {
                Console.WriteLine("Não há contas cadastradas!");
                return;
            }
            else
            {
                foreach (Conta conta in listContas)
                {
                    Console.WriteLine(conta);
                }
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para pessoa física e 2 para jurídica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o saldo inicial");
            double entradaSaldoInicial = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito");
            double entradaCredito = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do titular");
            string entradaNome = Console.ReadLine();

            Conta novaConta = new Conta((TipoConta)entradaTipoConta, entradaSaldoInicial, entradaCredito, entradaNome);
            listContas.Add(novaConta);



        }

        private static string ObterUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("OneBank a seu dispor!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta!");
            Console.WriteLine("3 - Transferir!");
            Console.WriteLine("4 - Sacar!");
            Console.WriteLine("5 - Depositar!");
            Console.WriteLine("L - Limpar tela!");
            Console.WriteLine("X - Sair!");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;


        }
    }
}

