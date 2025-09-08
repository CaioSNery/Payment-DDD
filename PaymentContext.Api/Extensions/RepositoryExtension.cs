using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaymentContext.Domain.Repositories;
using PaymentContext.Infra.Repository;

namespace PaymentContext.Api.Extensions
{
    public static class RepositoryExtension
    {
        public static void AddRepositoryExtension(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
        }
    }
}