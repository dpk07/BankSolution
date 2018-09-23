using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  //Delegate step 1
  public delegate void onBalanceChange(int accountNumber, string transactionType, decimal transactionAmount, decimal newBalance);
  

  public abstract class Account
  {
    int _accountNumber;
    string _holdersName;
    decimal _balance;

    //Delegate step 2
    public onBalanceChange WOnBalanceChange;
    public event onBalanceChange DOnBalanceChange;
    public Account(int accountNumber, string holdersName, decimal balance)
    {
      _accountNumber = accountNumber;
      _holdersName = holdersName;
      _balance = balance;

    }

    public object this[int position]
    {
      get
      {
        if (position == 0)
        {
          return _accountNumber;
        }
        else if (position == 1)
        {
          return _holdersName;

        }
        else if (position == 2)
        {
          return _balance;
        }
        throw new ArgumentException("Invalid index, Index out of range");
      }
    }

    public Account()
    {
    }

    public int AccountNumber
    {
      get { return _accountNumber; }

    }
    public string HoldersName
    {
      get { return _holdersName; }
      set { _holdersName = value; }
    }
    public decimal Balance
    {
      get { return _balance; }
      set { _balance = value; }
    }



    public virtual void Deposit(decimal amount) {
      Balance = Balance + amount;
      if (DOnBalanceChange != null)
      {
        DOnBalanceChange(_accountNumber, "Deposit", amount, _balance);
      }
    }
    

    public abstract void Withdraw(decimal amount);

    public override string ToString()
    {
      return $"AccountNumber: { AccountNumber}, HoldersName: {HoldersName} and Balance={Balance}";
    }

  }
}
