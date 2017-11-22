using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Interfaces
{
    public interface IWalletState
    {
        int WalletId { get;}
        decimal CashBalance { get;}
        decimal UnaccountedBalance { get;}
        IEnumerable<IWalletTransactionComponent> WalletTransactions { get;}
        decimal BankWithdrawals { get; }
        decimal CashWithdrawals { get; }
        decimal CashDiscrepancy { get; }
        decimal ReceiptTotal { get; }
    }
}
