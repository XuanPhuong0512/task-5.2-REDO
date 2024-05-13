using System;

namespace Task5._2
{
    internal class TransferTransaction
    {
        private Account _fromAccount;
        private Account _toAccount;
        private decimal _amount;
        private DepositeTransaction _deposit;
        private WithdrawTransaction _withdraw;
        private bool _reverse = false;
        private bool _executed = false;
        private bool _success = false;

        public bool Executed => _executed;

        public bool Reversed => _reverse;

        public bool Success => _success;

        public TransferTransaction(Account fromAccount, Account toAccount, decimal amount)
        {
            _fromAccount = fromAccount;
            _toAccount = toAccount;
            _amount = amount;

            _withdraw = new WithdrawTransaction(_fromAccount, _amount);
            _deposit = new DepositeTransaction(_toAccount, _amount);
        }

        public void Execute()
        {
            if (!_executed)
            {
                _executed = true;
                _withdraw.Execute();
                if (_withdraw.Success)
                {
                    _deposit.Execute();
                    _success = _deposit.Success;
                    if (!_success)
                    {
                        Console.WriteLine("Transfer failed during deposit");
                    }
                    else
                    {
                        Console.WriteLine("Transfer Completed Successfully");
                    }
                }
                else
                {
                    Console.WriteLine("Inadequate funds, cannot transfer");
                }
            }
            else
            {
                Console.WriteLine("Transfer has already been executed");
            }
        }

        public void RollBack()
        {
            if (_executed && _success && !_reverse)
            {
                _deposit.RollBack();
                _withdraw.RollBack();
                _reverse = true;
                Console.WriteLine("Transaction reversed");
            }
            else if (!_executed)
            {
                Console.WriteLine("Cannot reverse, transfer has not been executed");
            }
            else if (!_success)
            {
                Console.WriteLine("Cannot reverse, transfer was not successful");
            }
            else if (_reverse)
            {
                Console.WriteLine("Transfer has already been reversed");
            }
        }
    }

}
