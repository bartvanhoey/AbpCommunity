using System;
using Volo.Abp.Domain.Repositories;

namespace AddressBook.Contacts;

public interface IContactRepository : IRepository<Contact, Guid>
{
}
