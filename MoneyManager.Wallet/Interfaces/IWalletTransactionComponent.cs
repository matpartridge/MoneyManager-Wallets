using MoneyManager.Wallet.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Interfaces
{
    public interface IWalletTransactionComponent
    {
        int WalletItemId { get; }
        WalletItemTypeEnum WalletItemType { get; }
        decimal? Amount { get; set; }
    }
}
