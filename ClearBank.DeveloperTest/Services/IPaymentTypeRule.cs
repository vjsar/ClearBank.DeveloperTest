using ClearBank.DeveloperTest.PaymentSchemeRules;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.Services
{
    public interface IPaymentTypeRule
    {
        IPaymentSchemeRules GetPaymentRule(PaymentScheme paymentScheme);
    }
}
