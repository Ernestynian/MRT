using System;

namespace Z1_Lib
{
    public class Account
    {
        decimal balance = 0m;
        public decimal Balance
        {
            get => balance;
            set
            {
                if(open == false)
                {
                    throw new InvalidOperationException("This account is closed.");
                }

                if(value < balance && Verified == false)
                {
                    throw new InvalidOperationException("Can't extract money when the account is not verified.");
                }

                if(value != balance)
                {
                    Frozen = false;
                }

                balance = value;
            }
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