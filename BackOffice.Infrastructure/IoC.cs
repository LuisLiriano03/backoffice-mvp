using BackOffice.Domain.Interfaces;
using BackOffice.Infrastructure.Repositorys;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Infrastructure
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection service)
        {
            return service
                .AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        }

    }
}
