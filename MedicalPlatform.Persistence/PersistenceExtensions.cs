using MedicalPlatform.Core.Interfaces.Repositories;
using MedicalPlatform.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalPlatform.Persistence
{
    public static class PersistenceExtensions
    {
        public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<MedicalDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(MedicalDbContext)));
            });

            services.AddScoped<IUsersRepository, UsersRepository>();

            return services;
        }
    }
}
