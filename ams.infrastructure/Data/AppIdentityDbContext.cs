using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ams.infrastructure.Data
{
    public class AppIdentityDbContext : IdentityDbContext
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Property(i => i.Name).HasMaxLength(250);
            builder.HasDefaultSchema("identity");
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured) {
        //        optionsBuilder
        //            .UseNpgsql("Host=localhost;Port=5432;Database=saliniams;Username=postgres;Password=postgres;")
        //            .ReplaceService<IHistoryRepository, MyHistoryContext>();
        //    }
        //}        
    }

    //public class AppIdentityDbContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    //{
    //    public static Action<NpgsqlDbContextOptionsBuilder> GetNpgsqlOptionsBuilder()
    //    {
    //        return options =>
    //        {
    //            options.MigrationsHistoryTable("__EFMigrationsHistory");
    //        };
    //    }
    //    public AppIdentityDbContext CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<AppIdentityDbContext>();
    //        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=saliniams-;Username=postgres;Password=postgres;");
    //        return new AppIdentityDbContext(optionsBuilder.Options);
    //    }
    //}
    //public class MyHistoryContext : NpgsqlHistoryRepository
    //{
    //    public MyHistoryContext(HistoryRepositoryDependencies dependencies) : base(dependencies)
    //    {
    //    }

    //    protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
    //    {
    //        base.ConfigureTable(history);

    //        history.Property(h => h.MigrationId).HasColumnName("migration_id");
    //        history.Property(h => h.ProductVersion).HasColumnName("product_version");
    //    }
    //}


}
