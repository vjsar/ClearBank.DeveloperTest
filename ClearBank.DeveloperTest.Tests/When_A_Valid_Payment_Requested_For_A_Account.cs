using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Types;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests
{
    public class When_A_Valid_Payment_Requested_For_A_Account:Specification
    {
        private readonly string accountNumber = "AccountNumber";
        private IPaymentService _paymentService;
        private Mock<IPaymentTypeRule> _paymentTypeRule;
        private MakePaymentResult _makePaymentResult;
        private Mock<IAccountDataStore> _accountDataStore;
        private Account _account;
        private PaymentScheme _paymentScheme;

        public When_A_Valid_Payment_Requested_For_A_Account()
        {
            _accountDataStore = new Mock<IAccountDataStore>();

            _account = new TestAccountBuilder()
                .WithAccountNumber("Acct123456")
                .WithAllowedPaymentSchemes(AllowedPaymentSchemes.FasterPayments)
                .WithBalance(500m)
                .WithStatus(AccountStatus.Live)
                .Build();

            _accountDataStore.Setup(x => x.GetAccount(accountNumber)).Returns(_account);
            _paymentTypeRule = new Mock<IPaymentTypeRule>();


            var paymentRule = new Dictionary<PaymentScheme, Func<IPaymentSchemeRules>>()
            {
                {PaymentScheme.Bacs, () => new BacsPaymentSchemeRule()},
                {PaymentScheme.Chaps, () => new ChapsPaymentSchemeRule()},
                {PaymentScheme.FasterPayments, () => new FasterPaymentSchemeRule()}
            };
            _paymentScheme = PaymentScheme.FasterPayments;
            _paymentTypeRule.Setup(x => x.GetPaymentRule(_paymentScheme)).Returns(paymentRule[_paymentScheme]);
            _paymentService = new PaymentService(_accountDataStore.Object, _paymentTypeRule.Object);
        }
        protected override void Observe()
        {
            var paymentRequestBuilder = new TestPaymentRequestBuilder()
                .WithDebtorAccountNumber(accountNumber)
                .WithAmount(200m)
                .WithPaymentDate(DateTime.Now)
                .WithPaymentScheme(PaymentScheme.FasterPayments)
                .Build();

            _makePaymentResult = _paymentService.MakePayment(paymentRequestBuilder);
        }

        [Observation]
        public void Result()
        {
            _makePaymentResult.Success.ShouldBeTrue("A Valid Payment Requested For an Account");
        }
    }
}
