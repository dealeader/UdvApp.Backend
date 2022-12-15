using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using UdvApp.Application.Interfaces;

namespace UdvApp.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<UdvAppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IUdvAppDbContext>(provider => provider.GetService<UdvAppDbContext>());

            return services;
        }
    }
}
