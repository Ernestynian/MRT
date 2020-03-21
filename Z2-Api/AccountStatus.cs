namespace Z2_Api
{
    public class AccountStatus
    {
        public decimal Balance { get; set; }

        public bool Verified { get; set; }

        public bool Open { get; set; }

        public bool Frozen { get; set; }
    }
}