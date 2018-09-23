﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BankLibrary;

namespace BankConApp
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        Account account = null;

        account = new SavingsAccount(101, "Deepak", 1000);
        //account = new CurrentAccount(101, "Deepak", 1000, 4000);
        //account = new FixedDeposit(101, "Deepak", 1000);
        //Console.WriteLine("AccountNumber:{0}, HoldersName:{1}, Balance:{2}", account.AccountNumber, account.HoldersName, account.Balance);

        //Delegate Client step 2

        account.WOnBalanceChange += new onBalanceChange(SMSAlert);
        account.DOnBalanceChange += EmailAlert;

        //Delegate Client step 2

        //account.WOnBalanceChange += new onBalanceChange(EmailAlert);

        //Console.WriteLine(account);
        account.Deposit(199);
        Console.ReadKey(true);
        account.Withdraw(500);
        Console.WriteLine($"acc[4] = {account[1]}");
        return;

      }
      catch (DepositNotSuppotedException ex)
      {
        Console.WriteLine("\n\n\n\nToString:" + ex.ToString());
      }
      catch (OpeningBalanceException ex)
      {
        Console.WriteLine("\n\n\n\nToString:" + ex.ToString());
      }
      catch (Exception ex)
      {
       Console.WriteLine("\n\n\n\nToString:" + ex.ToString());
        return;
      }
      finally
      {
        
      }
      
      }

    private static void EmailAlert(int accountNumber, string transactionType, decimal transactionAmount, decimal newBalance)
    {
      Console.WriteLine($"Email Alert... \nAccountNumber: {accountNumber},TransactionType: {transactionType}, TransactionAmount: {transactionAmount} and new Balance: {newBalance}");
    }


    //Delegate Client step 1
    static void SMSAlert(int accountNumber, string transactionType, decimal transactionAmount, decimal newBalance)
    {
      Console.WriteLine($"SMS Alert... \nAccountNumber: {accountNumber},TransactionType: {transactionType}, TransactionAmount: {transactionAmount} and new Balance: {newBalance}");
    }
    

  }
}
