using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Bank_Experiment
{
    class Program
    {

        static List<Account> accountList = new List<Account>();
        static void Main(string[] args)
        {
            while (true) {
                string userOption = GetUserOption();

                Console.WriteLine("\n\n");
                switch (userOption)
                {
                    case "1":
                        Console.WriteLine("Exibir as contas cadastradas no sistema\n");
                        ShowAccounts();
                        break;
                    case "2":
                        Console.WriteLine("Adicionar nova conta\n");
                        CreateAccount();
                        break;
                    case "3":
                        Console.WriteLine("Realizar uma transferência\n");
                        Transfer();
                        break;
                    case "4":
                        Console.WriteLine("Realizar um saque\n");
                        Withdraw();
                        break;
                    case "5":
                        Console.WriteLine("Realizar um depósito\n");
                        Deposit();
                        break;
                    case "C":
                        Console.WriteLine("C.Limpar a tela\n");
                        Console.Clear();
                        break;
                    case "X":
                        Console.WriteLine("Até Logo!\n");
                        Task.Delay(3000).Wait();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Perdão, a opção desejada não está disponível. Selecione dentre as opções listada\n");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar.");
                Console.ReadLine();
            }
        }

        private static void ShowAccounts()
        {
            if (accountList.Count == 0) {
                Console.WriteLine("Ainda não há nenhuma conta cadastrada!");
            }
            else {
                foreach (Account account in accountList) {
                    Console.WriteLine(account.ToString());
                }
            }
        }
        private static void CreateAccount()
        {
            Console.WriteLine("Ficamos felizes com a sua iniciativa! Para adicionar uma conta, é muito simples! É só inserir os dados a seguir:");

            Console.WriteLine("A conta a ser adicionada é para uma pessoa física ou jurídica?\n\n 1. Pessoa Física\n 2. Pessoa Jurídica");
            int typeOfAccount = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual é o nome do proprietário da conta?");
            string name = Console.ReadLine();

            Console.WriteLine("Qual é o valor inicial de abertura da conta?");
            double balance = double.Parse(Console.ReadLine());

            Console.WriteLine("Qual é o limite de crédito que você deseja definir para a sua conta?");
            double credit = double.Parse(Console.ReadLine());

            Account createdAccount = 
            new Account(name: name, balance: balance, credit: credit, typeOfAccount: (TypeOfAccount)typeOfAccount);

            accountList.Add(createdAccount);

            Console.WriteLine("Sua conta foi criada com êxito!");
        }
        private static void Transfer()
        {
            Console.WriteLine("Claro! Qual é o nome do proprietário da conta?");
            string targetName = Console.ReadLine();

            Account targetAccount = accountList.Find(acc => acc.Name.Equals(targetName));

            if (targetAccount != null)
            {
                Console.WriteLine("Bem-vindo de volta, {0}! Qual é o nome do proprietário da conta de destino?", targetAccount.Name);
                string destinationName = Console.ReadLine();

                Account destinationAccount = accountList.Find(acc => acc.Name.Equals(destinationName));

                if (destinationAccount != null)
                {
                    Console.WriteLine("Qual valor você deseja transferir para a conta de {0}?", destinationAccount.Name);
                    double transferValue = double.Parse(Console.ReadLine());
                    targetAccount.Transfer(transferValue, destinationAccount);
                }
                else
                {
                    Console.WriteLine("Não foi encontrada nenhuma conta registrada nesse nome. Verifique se a ortografia está correta ou se a conta existe.");
                }

            }
            else
            {
                Console.WriteLine("Não foi encontrada nenhuma conta registrada nesse nome. Verifique se a ortografia está correta ou se a conta existe.");
            }
        }
        private static void Withdraw()
        {
            Console.WriteLine("Claro! Qual é o nome do proprietário da conta?");
            string withdrawName = Console.ReadLine();

            Account withdrawAccount = accountList.Find(acc => acc.Name.Equals(withdrawName));

            if (withdrawAccount != null) {
                Console.WriteLine("Bem-vindo de volta, {0}! Qual é o valor que você deseja sacar?", withdrawAccount.Name);
                double withdrawValue = double.Parse(Console.ReadLine());
                withdrawAccount.Withdraw(withdrawValue);
            }
            else {
                Console.WriteLine("Não foi encontrada nenhuma conta registrada nesse nome. Verifique se a ortografia está correta ou se a conta existe.");
            }
        }
        private static void Deposit()
        {
            Console.WriteLine("Claro! Qual é o nome do proprietário da conta a qual se destina o depósito?");
            string depositName = Console.ReadLine();

            Account depositAccount = accountList.Find(acc => acc.Name.Equals(depositName));

            if (depositAccount != null)
            {
                Console.WriteLine("Qual é que você deseja depositar na conta de {0}?", depositAccount.Name);
                double depositValue = double.Parse(Console.ReadLine());
                depositAccount.Deposit(depositValue);
            }
            else
            {
                Console.WriteLine("Não foi encontrada nenhuma conta registrada nesse nome. Verifique se a ortografia está correta ou se a conta existe.");
            }
        }


        private static string GetUserOption() {
            Console.WriteLine("Bom dia, em que podemos ajudar?");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1. Exibir as contas cadastradas no sistema");
            Console.WriteLine("2. Adicionar nova conta");
            Console.WriteLine("3. Realizar uma transferência");
            Console.WriteLine("4. Realizar um saque");
            Console.WriteLine("5. Realizar um depósito");
            Console.WriteLine("\n\n------------------------------------------");
            Console.WriteLine("C. Limpar a tela");
            Console.WriteLine("X. Sair do Programa");

            string userOption = Console.ReadLine().ToUpper();
            return userOption;
        }
    }
}
