using BackOffice.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BackOffice.API.Config
{
    public static class DbConfig
    {
        public static IServiceCollection ConfigDbConnection(this IServiceCollection service, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("myConnection")!;
            service.AddDbContext<BackofficeDbContext>(options => options.UseSqlServer(connectionString));

            return service;
        }

    }

}
