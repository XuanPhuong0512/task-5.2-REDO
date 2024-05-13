using System;

namespace Task5._2
{

    internal class WithdrawTransaction
    {
        Account _account;
        decimal _amount;
        bool _executed;
        bool _success;
        bool _reversed;

        public bool Executed
        {
            get { return _executed; }
        }

        public bool Success
        {
            get { return _success; }
        }

        public bool Reversed
        {
            get { return _reversed; }
        }

        public WithdrawTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;

        }

        public void Print()
        {
            Console.WriteLine("Executed: " + _executed);
            Console.WriteLine("Success: " + _success);
            Console.WriteLine("Reversed: " + _reversed);

        }

       

        public void Execute()
        {
            if (!_executed)
            {
                _executed = true;
                _success = _account.Withdrawal(_amount);
                if (!_success)
                {
                    Console.WriteLine("Withdrawal failed");
                }
            }
            else
            {
                Console.WriteLine("Withdrawal already executed");
            }
        }

        public void RollBack()
        {
            if (_executed && _success && !_reversed)
            {
                _reversed = _account.Deposit(_amount); // This should be Deposit instead of Withdrawal
                if (!_reversed)
                {
                    Console.WriteLine("Rollback of withdrawal transaction failed");
                }
            }
            else if (!_executed)
            {
                Console.WriteLine("Cannot rollback withdrawal transaction, it has not been executed");
            }
            else if (!_success)
            {
                Console.WriteLine("Cannot rollback withdrawal transaction, it was not successful");
            }
            else if (_reversed)
            {
                Console.WriteLine("Withdrawal transaction has already been reversed");
            }
        }
    }
}
   
