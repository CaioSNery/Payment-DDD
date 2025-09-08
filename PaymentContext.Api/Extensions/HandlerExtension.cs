using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Command;
using PaymentContext.Domain.Handlers;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Api.Extension
{
    public static class HandlerExtensions
    {
        public static void AddHandlerExtension(this IServiceCollection services)
        {
            services.AddScoped<SubscriptionHandler>();

            services.AddScoped<IHandler<CreateBoletoSubscriptionCommand>, SubscriptionHandler>();

            services.AddScoped<IHandler<CreatePaypalSubscriptionCommand>, SubscriptionHandler>();

            services.AddScoped<IHandler<CreateCreditCardSubscriptionCommand>, SubscriptionHandler>();
        }
    }
}