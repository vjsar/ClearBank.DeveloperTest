using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.PaymentSchemeRule.Bacs
{
    public class When_Valdating_BacsPaymentSchemeRule_With_Account_Balance_More_Than_To_Request_Amount : Specification
    {

        private readonly BacsPaymentSchemeRule _bacsPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;

        public When_Valdating_BacsPaymentSchemeRule_With_Account_Balance_More_Than_To_Request_Amount()
        {
            _bacsPaymentSchemeRule = new BacsPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(1000m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.Bacs)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new TestAccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Bacs)
                .WithBalance(1500m)
                .WithStatus(AccountStatus.Live)
                .Build();
        }

        protected override void Observe()
        {

            result = _bacsPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeTrue("A Valid Account Balance");
        }
    }
}
