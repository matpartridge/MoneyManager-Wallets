using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Interfaces
{
    public interface IReceipt
    {
        decimal Amount { get; set; }
    }
}
