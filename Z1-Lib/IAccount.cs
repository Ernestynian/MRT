namespace Z1_Lib
{
    public interface IAccount
    {
        void TransferMoneyIn(decimal amount);
        void TransferMoneyOut(decimal amount);

        decimal Balance { get; }
    }
}