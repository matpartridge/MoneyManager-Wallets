using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoneyManager.Wallet.Enums;

namespace MoneyManager.Wallet.Classes
{
    public class WalletTransactionComponent : IWalletTransactionComponent
    {
        public int WalletItemId { get; private set; }
        public decimal? Amount { get; set; }

        public WalletItemTypeEnum WalletItemType { get; private set; }

        public WalletTransactionComponent(int walletItemId,  WalletItemTypeEnum walletItemType)
        {
            WalletItemId = walletItemId;
            WalletItemType = walletItemType;
        }
    }
}
