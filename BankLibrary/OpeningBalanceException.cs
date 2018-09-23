using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
  public class OpeningBalanceException:ApplicationException
  {
    public OpeningBalanceException(string message) : base(message) { }

  }
}
