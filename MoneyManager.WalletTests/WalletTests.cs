using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyManager.Wallet.Interfaces;
using System.Collections.Generic;
using MoneyManager.Wallet.Factories;
using MoneyManager.Wallet.Classes;
using System.Linq;
using MoneyManager.Wallet.Enums;

namespace MoneyManager.WalletTests
{
    [TestClass]
    public class WalletTests
    {
        [TestMethod]
        public void CreateWalletState()
        {
            //Arrange
            IWalletState x;
            //Act
            x = WalletStateFactory.CreateWalletState(1, 100, 100, new List<IWalletTransactionComponent>());
            //Assert
            Assert.IsInstanceOfType(x, typeof(WalletState));
            Assert.AreEqual(1, x.WalletId);
            Assert.AreEqual(100m, x.CashBalance);
            Assert.AreEqual(100m, x.UnaccountedBalance);
            Assert.AreEqual(0, x.WalletTransactions.Count());
        }
        [TestMethod]
        public void CreateWalletTransactionComponent()
        {
            //Arrange
            IWalletTransactionComponent expected;
            //Act
            expected = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.Cash);
            //Assert
            Assert.IsInstanceOfType(expected, typeof(WalletTransactionComponent));
            Assert.AreEqual(expected.WalletItemId, 1);
            Assert.AreEqual(expected.WalletItemType, WalletItemTypeEnum.Cash);
        }
        [TestMethod]
        public void ConfirmBankWithdrawalTotal()
        {
            //Arrange
            IWalletTransactionComponent bankCard = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.BankCard);
            IWalletTransactionComponent passbook = WalletTransactionComponentFactory.CreateTransactionComponent(2, WalletItemTypeEnum.Passbook);
            IWalletTransactionComponent chequebook = WalletTransactionComponentFactory.CreateTransactionComponent(3, WalletItemTypeEnum.Chequebook);
            IWalletTransactionComponent cash = WalletTransactionComponentFactory.CreateTransactionComponent(4, WalletItemTypeEnum.Cash);
            
            IWalletState actual = WalletStateFactory.CreateWalletState(1,100,100,new List<IWalletTransactionComponent>() {bankCard, passbook, chequebook, cash });
            //Act
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.BankCard).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Passbook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Chequebook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Cash).SingleOrDefault().Amount = 100;
            //Assert
            Assert.AreEqual(actual.BankWithdrawals, 300m);
        }
        [TestMethod]
        public void ConfirmCashWithdrawalTotal()
        {
            //Arrange
            IWalletTransactionComponent bankCard = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.BankCard);
            IWalletTransactionComponent passbook = WalletTransactionComponentFactory.CreateTransactionComponent(2, WalletItemTypeEnum.Passbook);
            IWalletTransactionComponent chequebook = WalletTransactionComponentFactory.CreateTransactionComponent(3, WalletItemTypeEnum.Chequebook);
            IWalletTransactionComponent cash = WalletTransactionComponentFactory.CreateTransactionComponent(4, WalletItemTypeEnum.Cash);

            IWalletState actual = WalletStateFactory.CreateWalletState(1, 100, 100, new List<IWalletTransactionComponent>() { bankCard, passbook, chequebook, cash });
            //Act
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.BankCard).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Passbook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Chequebook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Cash).SingleOrDefault().Amount = 100;
            //Assert
            Assert.AreEqual(actual.CashWithdrawals, 100m);
        }
        [TestMethod]
        public void ConfirmCashIsTypeOfReceiptableTransactionComponent()
        {
            //Arrange
            IWalletTransactionComponent cash;
            //Act
            cash = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.Cash);
            //Assert
            Assert.IsInstanceOfType(cash, typeof(WalletReceiptableTransactionComponent));

        }
        [TestMethod]
        public void ConfirmReceiptTotal()
        {
            //Arrange
            IWalletState wallet;
            IWalletTransactionComponent cash;
            IEnumerable<IWalletTransactionComponent> transactions;
            //Act
            cash = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.Cash);
            ((WalletReceiptableTransactionComponent)cash).Receipts.Add(new CashReceipt(50));
            transactions = new List<IWalletTransactionComponent>() {cash};
            wallet = WalletStateFactory.CreateWalletState(1,100,50,transactions);
            
            //Assert
            Assert.AreEqual(wallet.ReceiptTotal, 50);
        }
        
        [TestMethod]
        public void ConfirmCashOver()
        {
            //Arrange
            IWalletTransactionComponent bankCard = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.BankCard);
            IWalletTransactionComponent passbook = WalletTransactionComponentFactory.CreateTransactionComponent(2, WalletItemTypeEnum.Passbook);
            IWalletTransactionComponent chequebook = WalletTransactionComponentFactory.CreateTransactionComponent(3, WalletItemTypeEnum.Chequebook);
            IWalletTransactionComponent cash = WalletTransactionComponentFactory.CreateTransactionComponent(4, WalletItemTypeEnum.Cash);

            IWalletState actual = WalletStateFactory.CreateWalletState(1, 100, 100, new List<IWalletTransactionComponent>() { bankCard, passbook, chequebook, cash });
            //Act
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.BankCard).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Passbook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Chequebook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Cash).SingleOrDefault().Amount = 100;
            //Assert
            Assert.AreEqual(actual.CashDiscrepancy, 400m);
        }

        [TestMethod]
        public void ConfirmCashUnder()
        {
            //Arrange
            IWalletTransactionComponent bankCard = WalletTransactionComponentFactory.CreateTransactionComponent(1, WalletItemTypeEnum.BankCard);
            IWalletTransactionComponent passbook = WalletTransactionComponentFactory.CreateTransactionComponent(2, WalletItemTypeEnum.Passbook);
            IWalletTransactionComponent chequebook = WalletTransactionComponentFactory.CreateTransactionComponent(3, WalletItemTypeEnum.Chequebook);
            IWalletTransactionComponent cash = WalletTransactionComponentFactory.CreateTransactionComponent(4, WalletItemTypeEnum.Cash);
            ((WalletReceiptableTransactionComponent)cash).Receipts.Add(new CashReceipt(500));

            IWalletState actual = WalletStateFactory.CreateWalletState(1, 100, 100, new List<IWalletTransactionComponent>() { bankCard, passbook, chequebook, cash });
            //Act
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.BankCard).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Passbook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Chequebook).SingleOrDefault().Amount = 100;
            actual.WalletTransactions.Where(o => o.WalletItemType == WalletItemTypeEnum.Cash).SingleOrDefault().Amount = 100;
            //Assert
            Assert.AreEqual(actual.CashDiscrepancy, -100m);
        }
    }
}
