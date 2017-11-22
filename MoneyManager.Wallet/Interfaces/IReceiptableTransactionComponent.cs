using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MoneyManager.Wallet.Interfaces
{
    public interface IReceiptableTransactionComponent
    {
        ObservableCollection<IReceipt> Receipts { get; set; }
    }
}
