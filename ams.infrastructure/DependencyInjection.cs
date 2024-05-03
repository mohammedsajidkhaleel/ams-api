using ams.application.Abstractions.Clock;
using ams.application.Abstractions.Data;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.Employees;
using ams.domain.ItemReceipts;
using ams.domain.Items;
using ams.domain.Licenses;
using ams.infrastructure.Clock;
using ams.infrastructure.Data;
using ams.infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ams.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            var connectionString = configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemReceiptRepository, ItemReceiptRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILicenseRepository,LicenseRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());
            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));
            return services;
        }
    }
}
