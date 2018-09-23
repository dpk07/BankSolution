using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{

  public class FixedDeposit : Account
  {
    readonly decimal _openingBalance;
    public FixedDeposit(int accountNumber, string holdersName, decimal balance) : base(accountNumber, holdersName, balance)
    {
      _openingBalance = 4000;
      if (balance < _openingBalance)
      {
        throw new OpeningBalanceException($"Opening balance cannot be less than {_openingBalance}");
      }
    }

    public override void Deposit(decimal amount)
    {
      throw new DepositNotSuppotedException("Deposit not allowed");
    }

    public override void Withdraw(decimal amount)
    {
      throw new WithdrawNotSupportedException("Withdraw not allowed");
    }


  }
}
  

