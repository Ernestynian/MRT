namespace Z1_Lib
{
    public interface ICloseable
    {
        bool Open { get; }
        void Close();
    }
}