namespace CompanyApp
{
    public class BankAccount
    {
        private static int TotalAccounts;
        private decimal Balance;

        public BankAccount() { TotalAccounts += 1; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public int GetTotalAccounts()
        {
            return TotalAccounts;
        }
    }
}
