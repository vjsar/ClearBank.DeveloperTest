using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Services
{
    public class PaymentTypeRule:IPaymentTypeRule
    {
        public IPaymentSchemeRules GetPaymentRule(PaymentScheme paymentScheme)
        {

            var paymentRule = new Dictionary<PaymentScheme, Func<IPaymentSchemeRules>>()
            {
                {PaymentScheme.Bacs, () => new BacsPaymentSchemeRule()},
                {PaymentScheme.Chaps, () => new ChapsPaymentSchemeRule()},
                {PaymentScheme.FasterPayments, () => new FasterPaymentSchemeRule()}
            };

            return paymentRule[paymentScheme]();
        }
    }
}
