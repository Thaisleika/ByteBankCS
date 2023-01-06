using System;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace ByteBank1
{

    public class Program
    {

        static void ShowMenu()
        {
            Console.WriteLine("1 - Cadastrar novo usuário");
            Console.WriteLine("2 - Deletar usuário");
            Console.WriteLine("3 - Listar contas registradas");
            Console.WriteLine("4 - Detalhes de um usuário");
            Console.WriteLine("5 - Quantia armazenada no banco");
            Console.WriteLine("6 - Transações");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("Digite a opção desejada: ");
        }

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0); //aqui saldo começa com 0
        }

        static void DeletarUsuario(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("Conta deletada com sucesso");
        }

        static void ListarTodasAsContas(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            for (int i = 0; i < cpfs.Count; i++)
            {
                ApresentaConta(i, cpfs, titulares, saldos);
            }
        }

        static void ApresentarUsuario(List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.Write("Digite o cpf: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("Não foi possível apresentar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
            }

            ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
        }

        static void ApresentarValorAcumulado(List<double> saldos)
        {
            Console.WriteLine($"Total acumulado no banco: {saldos.Sum():F2}");
        }

        static void ApresentaConta(int index, List<string> cpfs, List<string> titulares, List<double> saldos)
        {
            Console.WriteLine($"CPF = {cpfs[index]} | Titular = {titulares[index]} | Saldo = R${saldos[index]:F2}");
        }

     

        static void Transacoes(List<string> cpfs, List<string> titulares, List<string> senhas, List<double> saldos)
        {
            Console.Write("Digite seu CPF:");
            string cpfParaLoggin = (Console.ReadLine());
            int indexParaLoggin = cpfs.FindIndex(cpf => cpf == cpfParaLoggin);// achei o index daquele cpf

            Console.Write("Digite sua senha:");
            string senhaParaLoggin = (Console.ReadLine());

            if (indexParaLoggin == -1)
            {
                Console.WriteLine("Não foi possível deletar esta Conta");
                Console.WriteLine("MOTIVO: Conta não encontrada.");
                Console.Write("Digite seu CPF novamente:");
                cpfParaLoggin = (Console.ReadLine());
            }


            else if (senhaParaLoggin != senhas[indexParaLoggin])
            {
                Console.WriteLine("Senha invalida");
                Console.Write("Digite sua senha novamente:");
                senhaParaLoggin = (Console.ReadLine());
            }
            else 
 
            Console.WriteLine("Qual opçao abaixo você deseja realizar?");

            static void ShowMenuTransacoes()
            {
                Console.WriteLine("0 - Sair/Loggout");
                Console.WriteLine("1 - Transferência");
                Console.WriteLine("2 - Saque");
                Console.WriteLine("3 - Depósito");
                Console.Write("Digite a opção desejada: ");
            }

          int option;
            do
            {
                ShowMenuTransacoes();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Voltar ao Menu inicial...");
                        break;
                    case 1:
                        RealizarTransferencia(cpfs, titulares, saldos);
                        break;
                    case 2:
                        RealizarSaque(cpfs,titulares,saldos);
                        break;
                    case 3:
                        RealizarDeposito(cpfs, titulares, saldos);
                        break;
                }
          
            static void RealizarTransferencia(List<string> cpfs, List<string> titulares, List<double> saldos)
            {
                Console.WriteLine("Valor a ser transferido");
                double valorAserTransferido = double.Parse(Console.ReadLine());
                Console.Write("Digite o cpf: ");
                string cpfParaTransferencia = Console.ReadLine();
                int indexParaTransacao = cpfs.FindIndex(cpf => cpf == cpfParaTransferencia);
                saldos[indexParaTransacao] -= valorAserTransferido;

                Console.Write("Digite o cpf para quem deseja transferir: ");
                string cpfParaTransferir = Console.ReadLine();
                int indexParaTransferir = cpfs.FindIndex(cpf => cpf == cpfParaTransferir);
                saldos[indexParaTransferir] += valorAserTransferido;

                Console.WriteLine($"Saldo Atual: {saldos[indexParaTransacao]:F2}");
            };

            static void RealizarSaque(List<string> cpfs, List<string> titulares, List<double> saldos)
            {
                    Console.WriteLine("Valor a ser sacado");
                    double valorAserSacado = double.Parse(Console.ReadLine());
                    Console.Write("Digite o cpf: ");
                    string cpfParaTransferencia = Console.ReadLine();
                    int indexParaTransacao = cpfs.FindIndex(cpf => cpf == cpfParaTransferencia);
                    saldos[indexParaTransacao] -= valorAserSacado;

                    Console.WriteLine($"Saldo Atual: {saldos[indexParaTransacao]:F2}");
            };
  
            static void RealizarDeposito(List<string> cpfs, List<string> titulares, List<double> saldos)
                {
                    Console.WriteLine("Valor a ser depositado");
                    double valorAserDepositado = double.Parse(Console.ReadLine());
                    Console.Write("Digite o cpf: ");
                    string cpfParaTransferencia = Console.ReadLine();
                    int indexParaTransacao = cpfs.FindIndex(cpf => cpf == cpfParaTransferencia);
                    saldos[indexParaTransacao] += valorAserDepositado;

                    Console.WriteLine($"Saldo Atual: {saldos[indexParaTransacao]:F2}");
                }

              Console.WriteLine("-----------------");

            } while (option != 0);
            
    }

        public static void Main(string[] args)
        {

            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            List<string> cpfs = new List<string>();
            List<string> titulares = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            int option;

            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                Console.WriteLine("-----------------");

                switch (option)
                {
                    case 0:
                        Console.WriteLine("Estou encerrando o programa...");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:
                        Transacoes(cpfs, titulares, senhas, saldos);
                        break;    
                }

                Console.WriteLine("-----------------");

            } while (option != 0);


        }

        private static void Loggin(List<string> cpfs, List<string> titulares, List<string> senhas)
        {
            throw new NotImplementedException();
        }
    }

}
