using MoneyManager.Wallet.Classes;
using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Factories
{
    public static class WalletStateFactory
    {
        public static IWalletState CreateWalletState(int walletId, decimal cashBalance, decimal unaccountedBalance, IEnumerable<IWalletTransactionComponent> walletTransactions)
        {
            return new WalletState(walletId, cashBalance, unaccountedBalance, walletTransactions);
        }
    }
}
