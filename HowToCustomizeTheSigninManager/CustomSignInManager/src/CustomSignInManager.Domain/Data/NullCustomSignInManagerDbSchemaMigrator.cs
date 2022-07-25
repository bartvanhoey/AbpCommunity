using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace CustomSignInManager.Data;

/* This is used if database provider does't define
 * ICustomSignInManagerDbSchemaMigrator implementation.
 */
public class NullCustomSignInManagerDbSchemaMigrator : ICustomSignInManagerDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
