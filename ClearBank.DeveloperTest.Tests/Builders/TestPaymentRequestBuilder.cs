using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Tests.Builders
{
    public class TestPaymentRequestBuilder
    {
        private decimal requestAmount;
        private PaymentScheme requestPaymentSchemes;
        private string requestCredtorAccountNumber;
        private string requestDebtorAccountNumber;
        private DateTime requestPaymentDate;

        public MakePaymentRequest Build()
        {
            return new MakePaymentRequest()
            {
                Amount = requestAmount,
                PaymentScheme = requestPaymentSchemes,
                DebtorAccountNumber = requestDebtorAccountNumber,
                CreditorAccountNumber = requestCredtorAccountNumber,
                PaymentDate = requestPaymentDate
            };
        }

        public TestPaymentRequestBuilder WithPaymentScheme(PaymentScheme paymentScheme)
        {
            requestPaymentSchemes = paymentScheme;
            return this;
        }

        public TestPaymentRequestBuilder WithAmount(decimal amount)
        {
            requestAmount = amount;
            return this;
        }

        public TestPaymentRequestBuilder WithCredtorAccountNumber(string credtorAccountNumber)
        {
            requestCredtorAccountNumber = credtorAccountNumber;
            return this;
        }

        public TestPaymentRequestBuilder WithDebtorAccountNumber(string debtorAccountNumber)
        {
            requestDebtorAccountNumber = debtorAccountNumber;
            return this;
        }

        public TestPaymentRequestBuilder WithPaymentDate(DateTime paymentDate)
        {
            requestPaymentDate = paymentDate;
            return this;
        }


    }
}
