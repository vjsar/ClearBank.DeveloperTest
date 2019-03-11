using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearBank.DeveloperTest.PaymentSchemeRules
{
    public interface IPaymentSchemeRules
    {
        bool IsValid(Account account, MakePaymentRequest request);
    }
}
