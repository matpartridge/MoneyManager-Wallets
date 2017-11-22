using MoneyManager.Wallet.Enums;
using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Classes
{
    public class WalletReceiptableTransactionComponent : WalletTransactionComponent,  IReceiptableTransactionComponent
    {
        public ObservableCollection<IReceipt> Receipts { get; set; }
        public WalletReceiptableTransactionComponent(int walletItemId, WalletItemTypeEnum walletItemType) 
            : base(walletItemId, walletItemType)
        {
            Receipts = new ObservableCollection<IReceipt>();
        }
    }
}
