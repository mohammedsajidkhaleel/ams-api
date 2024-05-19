using ams.application.Abstractions.Clock;
using ams.application.Abstractions.Data;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.Employees;
using ams.domain.ItemReceipts;
using ams.domain.Items;
using ams.domain.LicensedAssets;
using ams.domain.Licenses;
using ams.infrastructure.Clock;
using ams.infrastructure.Data;
using ams.infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.BearerToken;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ams.infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services
            , IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            AddPersistance(services, configuration);
            AddAuthentication(services, configuration);
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IItemReceiptRepository, ItemReceiptRepository>();
            services.AddScoped<IItemReceiptDetailRepository, ItemReceiptDetailRepository>();
            services.AddScoped<IAssetRepository, AssetRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ILicenseRepository, LicenseRepository>();
            services.AddScoped<ILicensedAssetRepository, LicensedAssetRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }

        private static void AddPersistance(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Database") ??
                            throw new ArgumentNullException(nameof(configuration));
            var identityConnectionString = configuration.GetConnectionString("IdentityDatabase") ??
                            throw new ArgumentNullException(nameof(configuration));
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });
            services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseNpgsql(identityConnectionString);
            });
            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));
        }

        private static void AddAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization();
            services.AddAuthentication()
                .AddBearerToken(IdentityConstants.BearerScheme);
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddApiEndpoints();
        }
    }
}
