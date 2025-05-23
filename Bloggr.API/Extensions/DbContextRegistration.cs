using System.Reflection;
using Bloggr.Database;
using Microsoft.EntityFrameworkCore;

namespace Bloggr.API.Extensions;

public static class DbContextRegistration
{
    public static void AddDbContexts(this IServiceCollection collection, ConfigurationManager config)
    {
        var dbConnectionString = config.GetSection("SqliteConnection")["ConnectionString"];

        collection.AddDbContext<BloggrDbContext>(options =>
        {
            options.UseSqlite(dbConnectionString,
                option => { option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName); });
            options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });
    }
}