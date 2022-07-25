using System.Threading.Tasks;

namespace CustomSignInManager.Data;

public interface ICustomSignInManagerDbSchemaMigrator
{
    Task MigrateAsync();
}
