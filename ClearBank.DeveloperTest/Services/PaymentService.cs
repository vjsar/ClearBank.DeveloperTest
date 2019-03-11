using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Types;
using System.Configuration;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentService : IPaymentService
    {
        public IAccountDataStore AccountDataStore { get;  }

        private readonly IPaymentTypeRule _paymentTypeRule;

        public PaymentService(IAccountDataStore accountDataStore, IPaymentTypeRule paymentTypeRule)
        {
            AccountDataStore = accountDataStore;
            _paymentTypeRule = paymentTypeRule;
        }
        public MakePaymentResult MakePayment(MakePaymentRequest request)
        {
            var account = AccountDataStore.GetAccount(request.DebtorAccountNumber);
            var paymentRule = _paymentTypeRule.GetPaymentRule(request.PaymentScheme);
            if (paymentRule.IsValid(account, request))
            {
                account.Balance -= request.Amount;
                AccountDataStore.UpdateAccount(account);
                return new MakePaymentResult() { Success = true };
            }
            return new MakePaymentResult();
        }
    }
}
