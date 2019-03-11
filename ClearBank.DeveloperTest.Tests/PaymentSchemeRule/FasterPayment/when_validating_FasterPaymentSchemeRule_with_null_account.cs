using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClearBank.DeveloperTest.Tests.Builders;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.PaymentSchemeRule.FasterPayment
{
    public class When_Validating_FasterPaymentSchemeRule_With_Null_Account:Specification
    {

        private readonly FasterPaymentSchemeRule _fasterPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;

        public When_Validating_FasterPaymentSchemeRule_With_Null_Account()
        {
            _fasterPaymentSchemeRule = new FasterPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentDate(DateTime.Now)
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .Build();
        }

        protected override void Observe()
        {
            Account account = new Account();
            result = _fasterPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeFalse("Not a valid Account");
        }
    }
}
