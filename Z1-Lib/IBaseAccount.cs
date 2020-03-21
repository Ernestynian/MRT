namespace Z1_Lib
{
    public interface IBaseAccount
    {
        void TransferMoneyIn(decimal amount);
        void TransferMoneyOut(decimal amount);

        decimal Balance { get; }
    }
}