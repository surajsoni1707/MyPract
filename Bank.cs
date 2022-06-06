using System;

namespace MyPract
{ public delegate void Mydel();
    class Bank
    {
        public event Mydel balIsZero;
        public event Mydel insufficientBal;
        int bal;
        public Bank()
        {
            bal = 0;
        }
        public void credit(int n)
        {
            bal = bal + n;
        }
        public void debit(int n)
        {
            if (bal < n)
            {
                insufficientBal();
            }
            if (bal >= n)
            {
                bal = bal - n;
                if (bal == 0)
                {
                    balIsZero();
                }
            }
        }
    }
    class Bank1
    {
        static void InsufficientBalance()
        {
            Console.WriteLine("Insufficient Balance");
        }
        static void ZeroBalnce()
        {
            Console.WriteLine("Balance is zero");
        }
        static void Main(string[] args)
        {
            Bank b = new Bank();
            b.balIsZero += new Mydel(ZeroBalnce);
            b.insufficientBal += new Mydel(InsufficientBalance);
             b.credit(100);
            b.debit(100);
        }
    }
}
