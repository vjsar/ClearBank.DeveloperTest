using Autofac;
using ClearBank.DeveloperTest.Data;
using ClearBank.DeveloperTest.Services;
using ClearBank.DeveloperTest.Tests.Builders;
using ClearBank.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Extensions;

namespace ClearBank.DeveloperTest.Tests.IntegrationTest
{
    public class When_A_Valid_Payment_Requested_For_Integration_Test : Specification
    {
        private IPaymentService _paymentService;
        private readonly MakePaymentRequest _request;
        private IContainer _container;

        public When_A_Valid_Payment_Requested_For_Integration_Test()
        {
            Init();
            _request = new TestPaymentRequestBuilder().WithPaymentScheme(PaymentScheme.Bacs).WithAmount(250m).Build();

        }

        protected override void Observe()
        {
            _paymentService = _container.Resolve<IPaymentService>();
            _paymentService.MakePayment(_request);
        }

        [Observation]
        public void Should_Update_The_Dummy_Account_Balance()
        {
            var data =  _container.Resolve<IAccountDataStore>() as StubBacsAccountDataStore;
            data.Account.Balance.ShouldEqual(250);
        }

        private void Init()
        {
            var builder = new ContainerBuilder();
            
            //You can get the datastore name from the congiguration File

            builder.Register(x => new StubBacsAccountDataStore()).As<IAccountDataStore>().SingleInstance();

            builder.Register(x => new PaymentTypeRule()).As<IPaymentTypeRule>();

            builder.Register(x => new PaymentService(x.Resolve<IAccountDataStore>(), x.Resolve<IPaymentTypeRule>()))
                .As<IPaymentService>();

            _container = builder.Build();
        }

    }
}
