using System;

namespace Z1_Lib
{
    public class Account : BaseAccount, IFreezable, ICloseable, IVerifable
    {
        public override void TransferMoneyIn(decimal amount)
        {
            if(Open == false)
            {
                throw new InvalidOperationException("This account is closed.");
            }

            if(amount > 0)
            {
                Frozen = false;
            }

            base.TransferMoneyIn(amount);
        }

        public override void TransferMoneyOut(decimal amount)
        {
            if(Open == false)
            {
                throw new InvalidOperationException("This account is closed.");
            }

            if(Verified == false)
            {
                throw new InvalidOperationException("Can't extract money when the account is not verified.");
            }

            if(amount > 0)
            {
                Frozen = false;
            }

            base.TransferMoneyOut(amount);
        }

        bool verified = false;
        public bool Verified
        {
            get => verified;
            set
            {
                if(open != true)
                    throw new InvalidOperationException("This account is closed.");
                else
                    verified = value;
            }
        }

        bool open = true;
        public bool Open { get => open; }

        bool frozen = false;
        public bool Frozen
        {
            get => frozen;
            set
            {
                if(open != true)
                    throw new InvalidOperationException("This account is closed.");
                else
                    frozen = value;
            }
        }

        public void Close()
        {
            open = false;
        }
    }
}