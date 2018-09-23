using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class DepositNotSuppotedException:ApplicationException
    {
    public DepositNotSuppotedException(string message):base(message){}
    }
}
