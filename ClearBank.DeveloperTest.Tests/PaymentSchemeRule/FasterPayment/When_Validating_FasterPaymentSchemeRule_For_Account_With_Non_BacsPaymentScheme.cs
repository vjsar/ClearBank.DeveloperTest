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
    public class When_Validating_FasterPaymentSchemeRule_For_Account_With_Non_FasterPaymentScheme:Specification
    {
        private readonly FasterPaymentSchemeRule _fasterPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;

        public When_Validating_FasterPaymentSchemeRule_For_Account_With_Non_FasterPaymentScheme()
        {
            _fasterPaymentSchemeRule = new FasterPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new TestAccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Chaps)
                .WithBalance(1000m)
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
            result.ShouldBeFalse("Payment Scheme is Not valid with this Account");
        }

    }
}
