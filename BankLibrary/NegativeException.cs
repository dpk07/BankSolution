using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLibrary
{
    public class NegativeException:ApplicationException
    {
    public NegativeException(string message) : base(message) { }
    

    }
}
