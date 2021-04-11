using System;

namespace Bank_Experiment
{
    public class Account
    {
        public string Name { get; }
        public double Balance { get; set; }
        private double Credit { get; set; }
        private TypeOfAccount TypeOfAccount { get; set; }

        public Account(string name, double balance, double credit, TypeOfAccount typeOfAccount)
        {
            this.Name = name;
            this.Balance = balance;
            this.Credit = credit;
            this.TypeOfAccount = typeOfAccount;
            Console.WriteLine("É um prazer ter você conosco, {0}!", this.Name);
        }

        public bool Withdraw(double withdrawValue)
        {
            if (this.Balance - withdrawValue < (-this.Credit))
            {
                Console.WriteLine("Seu Saldo é insuficiente para sacar esse valor.");
                return false;
            }
            this.Balance -= withdrawValue;
            Console.WriteLine("O saque foi realizado com êxito. O Saldo da conta de {0} é {1}.", this.Name, this.Balance);
            return true;
        }
        public void Deposit(double depositValue)
        {
            this.Balance += depositValue;
            Console.WriteLine("O depósito foi realizado com êxito. O Saldo da conta de {0} é {1}.", this.Name, this.Balance);
        }
        public void Transfer(double transferValue, Account destinationAccount)
        {
            Console.WriteLine("\n");
            if (this.Withdraw(transferValue))
            {
                Console.WriteLine("↓");
                destinationAccount.Deposit(transferValue);

                Console.WriteLine("A transferência foi realizada com êxito.");
            }
            else
            {
                Console.WriteLine("A transferência não pôde ser realizada.");
            }
        }



        public override string ToString()
        {
            string returnString =
                $"Conta: \n\nNome: {this.Name}\nSaldo: {this.Balance.ToString()}\nCrédito: {this.Credit.ToString()}\nTipo da Conta: {this.TypeOfAccount.ToString()}\n\n"; ;

            return returnString;
        }
    }
}