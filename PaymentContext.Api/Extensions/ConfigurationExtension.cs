using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PaymentContext.Infra.Data;

namespace PaymentContext.Api.Extensions
{
    public static class ConfigurationExtension
    {
        public static void AddConfigurationExtension(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

        }
    }
}