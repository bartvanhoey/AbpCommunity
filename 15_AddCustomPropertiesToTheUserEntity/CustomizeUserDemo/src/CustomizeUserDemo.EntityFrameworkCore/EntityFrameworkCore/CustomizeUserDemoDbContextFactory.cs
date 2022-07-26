using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace CustomizeUserDemo.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class CustomizeUserDemoDbContextFactory : IDesignTimeDbContextFactory<CustomizeUserDemoDbContext>
{
    public CustomizeUserDemoDbContext CreateDbContext(string[] args)
    {
        CustomizeUserDemoEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<CustomizeUserDemoDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new CustomizeUserDemoDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CustomizeUserDemo.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
