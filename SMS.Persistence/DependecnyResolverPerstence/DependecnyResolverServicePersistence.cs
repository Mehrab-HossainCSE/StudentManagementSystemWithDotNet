
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMS.Persistence.Contacts;
using SMS.Persistence.Data;
using SMS.Persistence.Repositories;

namespace SMS.Persistence.DependecnyResolverPerstence
{
    public static class DependecnyResolverServicePersistence
    {
        
        public static IServiceCollection Register(IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {

            services.AddDbContext<EFDataContext>(options =>
                  options.UseNpgsql(configuration.GetConnectionString("EfPostgresDb")));
            services.AddScoped<IRepositories, PostgresStudentRepository>();
            // Register DbContext based on environment
            //if (environment.IsDevelopment())
            //{
            //    // Use in-memory database for development
            //    services.AddDbContext<InMemoryDataContext>();
            //    services.AddScoped<IRepositories, InMemoryStudentRepository>();
            //}
            //else
            //{
            //    //Use PostgreSQL database for production

            //    services.AddDbContext<EFDataContext>(options =>
            //       options.UseNpgsql(configuration.GetConnectionString("EfPostgresDb")));
            //    services.AddScoped<IRepositories, PostgresStudentRepository>();
            //}

            return services;
        }
    }
}
