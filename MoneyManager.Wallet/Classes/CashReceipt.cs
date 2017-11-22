using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Classes
{
    public class CashReceipt : IReceipt
    {
        public decimal Amount { get ; set ; }
        public CashReceipt(decimal amount)
        {
            Amount = amount;
        }
    }
}
