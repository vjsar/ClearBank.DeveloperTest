using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.PaymentSchemeRule.Chaps
{
    public class When_Validating_ChapsPaymentSchemeRule_For_Account_With_Non_ChapsPaymentScheme:Specification
    {
        private readonly ChapsPaymentSchemeRule _chapsPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;

        public When_Validating_ChapsPaymentSchemeRule_For_Account_With_Non_ChapsPaymentScheme()
        {
            _chapsPaymentSchemeRule = new ChapsPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(500m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.Chaps)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new TestAccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(1000m)
                .WithStatus(AccountStatus.Live)
                .Build();

        }

        protected override void Observe()
        {

            result = _chapsPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeFalse("Payment Scheme is Not valid with this Account");
        }

    }
}
