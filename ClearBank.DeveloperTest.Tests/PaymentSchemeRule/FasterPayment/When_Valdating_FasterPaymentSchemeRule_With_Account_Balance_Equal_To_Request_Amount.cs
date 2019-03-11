using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.PaymentSchemeRule.FasterPayment
{
    public class When_Valdating_FasterPaymentSchemeRule_With_Account_Balance_Equal_To_Request_Amount : Specification
    {

        private readonly FasterPaymentSchemeRule _fasterPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;

        public When_Valdating_FasterPaymentSchemeRule_With_Account_Balance_Equal_To_Request_Amount()
        {
            _fasterPaymentSchemeRule = new FasterPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(1500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new TestAccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(1500m)
                .WithStatus(AccountStatus.Live)
                .Build();
        }

        protected override void Observe()
        {

            result = _fasterPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeTrue("A Valid Account Balance");
        }
    }
}
