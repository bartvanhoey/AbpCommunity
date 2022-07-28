using AddressBook.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace AddressBook
{
    [DependsOn(
        typeof(AddressBookEntityFrameworkCoreTestModule)
    )]
    public class AddressBookDomainTestModule : AbpModule
    {

    }
}
