﻿using ams.application.Abstractions.Clock;
using ams.application.Abstractions.Data;
using ams.domain.Abstractions;
using ams.domain.Assets;
using ams.domain.EmployeeAccessories;
using ams.domain.Employees;
using ams.domain.ItemReceipts;
using ams.domain.Items;
using ams.domain.LicensedAssets;
using ams.domain.LicensedEmployees;
using ams.domain.Licenses;
using ams.domain.PurchaseOrders;
using ams.domain.Sims;
using ams.infrastructure.Clock;
using ams.infrastructure.Data;
using ams.infrastructure.Repositories;
using Microsoft.AspNetCore.Identity;
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
            services.AddScoped<ILicensedEmployeeRepository, LicensedEmployeeRepository>();
            services.AddScoped<ISimRepository, SimRepository>();
            services.AddScoped<IEmployeeAccessoryRepository, EmployeeAccessoryRepository>();
            services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            return services;
        }

        private static void AddPersistance(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = //Environment.GetEnvironmentVariable("AMS_CONNECTION_STRING");
            configuration.GetConnectionString("Database") ?? throw new ArgumentNullException(nameof(configuration));
            var identityConnectionString = //Environment.GetEnvironmentVariable("IDENTITY_CONNTECTION_STRING");
            configuration.GetConnectionString("IdentityDatabase") ?? throw new ArgumentNullException(nameof(configuration));
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
