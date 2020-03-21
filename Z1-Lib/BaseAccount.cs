using System;

namespace Z1_Lib
{
    public class BaseAccount : IBaseAccount
    {
        decimal balance = 0m;
        public decimal Balance { get => balance; }

        public virtual void TransferMoneyIn(decimal amount)
        {
            if(amount < 0)
                throw new ArgumentException("Amount cannot be lower than 0");

            balance += amount;
        }

        public virtual void TransferMoneyOut(decimal amount)
        {
            if(amount < 0)
                throw new ArgumentException("Amount cannot be lower than 0");

            balance -= amount;
        }
    }
}