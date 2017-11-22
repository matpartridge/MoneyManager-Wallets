using MoneyManager.Wallet.Classes;
using MoneyManager.Wallet.Enums;
using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Factories
{
    public static class WalletTransactionComponentFactory
    {
        public static IWalletTransactionComponent CreateTransactionComponent(int walletItemTypeId, WalletItemTypeEnum walletItemType)
        {
            if (walletItemType == WalletItemTypeEnum.Cash)
                return new WalletReceiptableTransactionComponent(walletItemTypeId, walletItemType);
            return new WalletTransactionComponent(walletItemTypeId, walletItemType);            
        }
    }
}
