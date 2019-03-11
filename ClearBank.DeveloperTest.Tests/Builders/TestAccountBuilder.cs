using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Tests.Builders
{
    public class TestAccountBuilder
    {
        private string accountNumber;
        private AllowedPaymentSchemes allowedPaymentSchemes;
        private AccountStatus status;
        private decimal balance;
        public Account Build()
        {
            return new Account()
            {
                AccountNumber = accountNumber,
                AllowedPaymentSchemes = allowedPaymentSchemes,
                Status = status,
                Balance = balance
            };
        }

        public TestAccountBuilder WithAccountNumber(string withAccountNumber)
        {
            accountNumber = withAccountNumber;
            return this;
        }


        public TestAccountBuilder WithAllowedPaymentSchemes(AllowedPaymentSchemes withAllowedPaymentSchemes)
        {
            allowedPaymentSchemes = withAllowedPaymentSchemes;
            return this;
        }

        public TestAccountBuilder WithStatus(AccountStatus withAccountStatus)
        {
            status = withAccountStatus;
            return this;
        }

        public TestAccountBuilder WithBalance(decimal withBalance)
        {
            balance = withBalance;
            return this;
        }
    }
}
