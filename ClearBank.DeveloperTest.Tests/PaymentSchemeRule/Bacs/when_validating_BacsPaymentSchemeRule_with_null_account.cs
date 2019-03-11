using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Tests.Builders;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.PaymentSchemeRule.Bacs
{
    public class When_Validating_BacsPaymentSchemeRule_With_Null_Account:Specification
    {

        private readonly BacsPaymentSchemeRule _bacsPaymentSchemeRule ;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;

        public When_Validating_BacsPaymentSchemeRule_With_Null_Account()
        {
            _bacsPaymentSchemeRule = new BacsPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentDate(DateTime.Now)
                .WithPaymentScheme(PaymentScheme.Bacs)
                .Build();
        }

        protected override void Observe()
        {
            Account account = new Account();
            result = _bacsPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeFalse("Not a valid Account");
        }
    }
}
