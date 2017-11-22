using MoneyManager.Wallet.Enums;
using MoneyManager.Wallet.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Classes
{
    public class WalletState : IWalletState
    {
        public int WalletId { get; private set; }
        public decimal CashBalance { get; private set; }
        public decimal UnaccountedBalance { get; private set; }
        public IEnumerable<IWalletTransactionComponent> WalletTransactions { get; private set; }

        public decimal BankWithdrawals => WalletTransactions
            .Where(wt=>wt.WalletItemType == WalletItemTypeEnum.BankCard || wt.WalletItemType == WalletItemTypeEnum.Chequebook || wt.WalletItemType == WalletItemTypeEnum.Passbook)
            .Sum(wt=> wt?.Amount ?? 0);
        public decimal CashWithdrawals => WalletTransactions
            .Where(wt => wt.WalletItemType == WalletItemTypeEnum.Cash)
            .Sum(wt => wt?.Amount ?? 0);
        public decimal CashDiscrepancy => UnaccountedBalance + BankWithdrawals - ReceiptTotal;
        public decimal ReceiptTotal => ((WalletReceiptableTransactionComponent)WalletTransactions
            .Where(wt => wt.WalletItemType == WalletItemTypeEnum.Cash)
            .Single())
            .Receipts.Sum(r => r.Amount);
        public WalletState(int walletId, decimal cashBalance, decimal unaccountedBalance, IEnumerable<IWalletTransactionComponent> walletTransactions)
        {
            WalletId = walletId;
            CashBalance = cashBalance;
            UnaccountedBalance = unaccountedBalance;
            WalletTransactions = walletTransactions;
        }
    }
}
