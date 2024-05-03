using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SMS.BAL.Service;
using SMS.Persistence.Contacts;
using SMS.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.BAL.DependecnyResolverBAL
{
    public static class DependecnyResolverServiceBAL
    {
        public static IServiceCollection RegistionStudent(IServiceCollection services, IHostEnvironment environment, IConfiguration configuration)
        {
           
          return  services.AddScoped<IStudentAction, StudentAction>();

        }
    }
}
