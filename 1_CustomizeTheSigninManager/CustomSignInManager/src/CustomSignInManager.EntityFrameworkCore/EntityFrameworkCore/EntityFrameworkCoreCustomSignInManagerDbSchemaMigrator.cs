using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomSignInManager.Data;
using Volo.Abp.DependencyInjection;

namespace CustomSignInManager.EntityFrameworkCore;

public class EntityFrameworkCoreCustomSignInManagerDbSchemaMigrator
    : ICustomSignInManagerDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreCustomSignInManagerDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the CustomSignInManagerDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<CustomSignInManagerDbContext>()
            .Database
            .MigrateAsync();
    }
}
