using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  [Serializable]
  public class CurrentAccount:Account
  {
    readonly decimal _odLimit;
    public CurrentAccount(int accountNumber, string holdersName, decimal balance, decimal odLimit) : base(accountNumber, holdersName, odLimit)
    {
       _odLimit = odLimit; 
    }

    public CurrentAccount(int accountNumber, string holdersName, decimal balance) : this(accountNumber, holdersName, balance,0) { }
    


    public override void Withdraw(decimal amount)
    {
      if ((Balance + _odLimit)-amount < 0)
      {
        throw new InsufficientFundsException(AccountNumber, "CA-Withdraw", amount, Balance, string.Format("Insufficient Funds in Current Account - {0}", Balance-amount));

      }
      else
      {
        Balance = Balance - amount;
        //Delegate Step 3
        if (WOnBalanceChange != null)
          WOnBalanceChange(AccountNumber, "Withdraw", amount, Balance);

      }
    }

    public override void Deposit(decimal amount)
    {
      if (amount < 0)
      {
        throw new ArgumentException("Negative amount not allowed");

      }
      Balance = Balance + amount;

    }
  }
}
