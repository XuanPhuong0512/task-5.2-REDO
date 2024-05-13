using System;

namespace Task5._2
{
    /// <summary>
    /// Prototype for a deposit transaction
    /// </summary>
    internal class DepositeTransaction
    {
        Account _account;
        decimal _amount;
        bool _executed;
        public bool _success;
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

        public DepositeTransaction(Account account, decimal amount)
        {
            this._account = account;
            this._amount = amount;
        }

        public void Print()
        {
            Console.WriteLine("Amount: " + _amount);
            Console.WriteLine("Executed: " + _executed);
            Console.WriteLine("Success: " + _success);
            Console.WriteLine("Reversed: " + _reversed);

        }

        public void Execute()
        {
            if (!_executed)
            {
                _executed = true;
                _success = _account.Deposit(_amount);
                if (!_success)
                {
                    Console.WriteLine("Deposit failed");
                }
            }
            else
            {
                Console.WriteLine("Deposit transaction already executed");
            }
        }

        public void RollBack()
        {
            if (_executed && _success && !_reversed)
            {
                _reversed = _account.Withdrawal(_amount);
                if (!_reversed)
                {
                    Console.WriteLine("Rollback of deposit transaction failed");
                }
            }
            else if (!_executed)
            {
                Console.WriteLine("Cannot rollback deposit transaction, it has not been executed");
            }
            else if (!_success)
            {
                Console.WriteLine("Cannot rollback deposit transaction, it was not successful");
            }
            else if (_reversed)
            {
                Console.WriteLine("Deposit transaction has already been reversed");
            }
        }

    }
}
