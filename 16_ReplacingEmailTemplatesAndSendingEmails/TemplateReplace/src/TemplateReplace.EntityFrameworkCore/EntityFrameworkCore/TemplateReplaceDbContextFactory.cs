using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TemplateReplace.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class TemplateReplaceDbContextFactory : IDesignTimeDbContextFactory<TemplateReplaceDbContext>
{
    public TemplateReplaceDbContext CreateDbContext(string[] args)
    {
        TemplateReplaceEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<TemplateReplaceDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new TemplateReplaceDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../TemplateReplace.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
