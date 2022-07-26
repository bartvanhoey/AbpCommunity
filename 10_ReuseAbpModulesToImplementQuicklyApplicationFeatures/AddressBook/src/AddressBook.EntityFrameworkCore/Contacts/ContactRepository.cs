using System;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AddressBook.Contacts
{
    public class ContactRepository : EfCoreRepository<AddressBookDbContext, Contact, Guid>, IContactRepository
    {
        public ContactRepository(IDbContextProvider<AddressBookDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public override async Task<IQueryable<Contact>> WithDetailsAsync()
        {
            return (await GetQueryableAsync()).IncludeDetails();
        }
    }
}