using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Database;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var envConn = Environment.GetEnvironmentVariable("");

        if (!string.IsNullOrWhiteSpace(envConn))
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            builder.UseSqlServer(envConn);
            return new ApplicationDbContext(builder.Options);
        }

        var basePath = Path.GetFullPath(
            Path.Combine(Directory.GetCurrentDirectory(), "..", "")
        );

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", optional: true)
            .AddJsonFile("appsettings.Development.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var connectionString = config.GetConnectionString("DefaultConnection");

        var dbOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString);

        return new ApplicationDbContext(dbOptions.Options);
    }
}
