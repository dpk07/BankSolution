using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  [Serializable]
  public class SavingsAccount:Account
  {
    readonly decimal _minBalance;
    public SavingsAccount(int accountNumber, string holdersName, decimal balance) : base(accountNumber, holdersName, balance) {
       _minBalance = 500;
      if (balance < _minBalance)
        throw new OpeningBalanceException($"Opening balance cannot be less than - {_minBalance}");
    }

    public override void Withdraw(decimal amount)
    {
      if ((Balance - amount) < _minBalance)
      {
        throw new InsufficientFundsException(AccountNumber,"SA-Withdraw",amount,Balance,string.Format("Insufficient Funds in Savings Account - {0}", (Balance - amount)));
        
      }
      else
      {
        Balance = Balance - amount;
        //Delegate Step 3
        if(WOnBalanceChange!=null)
        WOnBalanceChange(AccountNumber, "Withdraw", amount, Balance);
      }
}

    
  }
}
