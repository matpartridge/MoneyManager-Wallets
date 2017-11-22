using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.Wallet.Enums
{
    public enum WalletItemTypeEnum : byte
    {
        Cash = 1,
        BankCard,
        Passbook,
        Chequebook,
        PersonalAllowance
    }
}
