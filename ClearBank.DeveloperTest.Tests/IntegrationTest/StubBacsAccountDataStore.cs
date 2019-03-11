using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Tests.Builders;

namespace ClearBank.DeveloperTest.Tests.IntegrationTest
{
    public class StubBacsAccountDataStore: IAccountDataStore
    {

        public Account Account { get; set; }

        public StubBacsAccountDataStore()
        {
            Account = new TestAccountBuilder()
                .WithBalance(500)
                .WithStatus(AccountStatus.Live)
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Bacs)
                .Build();
        }

        public Account GetAccount(string accountNumber)
        {
            return Account;
        }

        public void UpdateAccount(Account account)
        {
            Account.Balance = account.Balance;
        }

         
    }
}
