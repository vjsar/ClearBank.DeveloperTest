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
    public class When_Validating_ChapsPaymentSchemeRule_With_Request_AccountStatus_Set_To_InboundPaymentsOnly : Specification
    {
        private readonly ChapsPaymentSchemeRule _chapsPaymentSchemeRule;
        private readonly MakePaymentRequest makePaymentRequest;
        private bool result;
        private Account account;

        public When_Validating_ChapsPaymentSchemeRule_With_Request_AccountStatus_Set_To_InboundPaymentsOnly()
        {
            _chapsPaymentSchemeRule = new ChapsPaymentSchemeRule();
            makePaymentRequest = new TestPaymentRequestBuilder()
                .WithAmount(1000m)
                .WithCredtorAccountNumber("CredtorAccountNumber")
                .WithDebtorAccountNumber("DebtorAccountNumber")
                .WithPaymentScheme(PaymentScheme.Chaps)
                .WithPaymentDate(DateTime.Now)
                .Build();
            account = new TestAccountBuilder()
                .WithAccountNumber("AccountNumber")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.Chaps)
                .WithBalance(1500m)
                .WithStatus(AccountStatus.InboundPaymentsOnly)
                .Build();
        }

        protected override void Observe()
        {
            result = _chapsPaymentSchemeRule.IsValid(account, makePaymentRequest);
        }

        [Observation]
        public void Result()
        {
            result.ShouldBeFalse("Not A Valid Account Status");
        }
    }
}
