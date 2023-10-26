using System;
using System.Diagnostics.Eventing.Reader;

namespace Laboratory_work
{
    public enum BankAccountType
    {
        Savings_account = 1,
        Current_account
    }
    class BankAccount
    {
        private ulong account_number;
        private double account_balance;
        private BankAccountType bank_account_type;
        private static ulong number_of_bank_accounts = 0;

        public ulong AccountNumber
        {
            get
            {
                return account_number;
            }
            set
            {
                account_number = value;
            }
        }
        public double AccountBalance
        {
            get
            {
                return account_balance;
            }
            set
            {
                account_balance = Math.Round(value, 2);
            }
        }
        public BankAccountType AccountType
        {
            get
            {
                return bank_account_type;
            }
            set
            {
                bank_account_type = value;
            }
        }
        public void GenerateAnAccountNumber()
        {
            number_of_bank_accounts++;
        }
        public bool WithdrawMoneyFromAccount(double withdrawal_amount)
        {
            if (account_balance - withdrawal_amount > 0)
            {
                account_balance -= withdrawal_amount;
                return true;
            }

            return false;
        }

        public void PutMoneyIntoAccount(double deposited_amount)
        {
            account_balance += deposited_amount;
        }
        public void TransferFromAnotherAccount(BankAccount bank_account_debit, double transfer_amount)
        {
            if (bank_account_debit.WithdrawMoneyFromAccount(transfer_amount))
            {
                PutMoneyIntoAccount(transfer_amount);
            }
            else
            {
                Console.WriteLine("Недостаточно средств на выбранном счету");
            }
        }

        public BankAccount(double account_balance, BankAccountType bank_account_type)
        {
            GenerateAnAccountNumber();
            account_number = number_of_bank_accounts;
            this.account_balance = account_balance;
            this.bank_account_type = bank_account_type;
        }
        public BankAccount(ulong account_number, double account_balance, BankAccountType bank_account_type)
        {
            this.account_number = account_number;
            this.account_balance = account_balance;
            this.bank_account_type = bank_account_type;
        }
    }
}