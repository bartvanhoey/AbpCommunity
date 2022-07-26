using System;
using System.Threading.Tasks;
using AddressBook.Contacts;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace AddressBook.EntityFrameworkCore.Contacts
{
    public class ContactRepositoryTests : AddressBookEntityFrameworkCoreTestBase
    {
        private readonly IContactRepository _contactRepository;

        public ContactRepositoryTests()
        {
            _contactRepository = GetRequiredService<IContactRepository>();
        }

        /*
        [Fact]
        public async Task Test1()
        {
            await WithUnitOfWorkAsync(async () =>
            {
                // Arrange
    
                // Act
    
                //Assert
            });
        }
        */
    }
}
