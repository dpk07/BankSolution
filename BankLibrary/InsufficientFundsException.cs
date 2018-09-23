using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BankLibrary
{
    public class InsufficientFundsException : ApplicationException
    {
    public int AccountNumber;
    public string TransactionType;
    public decimal TransactionAmount;
    public decimal CurrentBalance;

    public InsufficientFundsException(int accountNumber,string transactionType, decimal transactionAmount, decimal currentBalance, string message):base(message)
    {
      AccountNumber = accountNumber;
      TransactionType = transactionType;
      TransactionAmount = transactionAmount;
      CurrentBalance = currentBalance;
      StreamWriter sWriter = new StreamWriter("../../AccInsufficientFunds.txt",true);
      string strMessage=$"{AccountNumber}|{TransactionType}|{TransactionAmount}|{CurrentBalance}|{DateTime.Now}";
      sWriter.WriteLine(strMessage);
      sWriter.Flush();
      sWriter.Close();

    }
    }
}
