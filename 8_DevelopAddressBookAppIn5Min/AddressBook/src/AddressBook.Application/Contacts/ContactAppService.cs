using System;
using AddressBook.Permissions;
using AddressBook.Contacts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AddressBook.Contacts;

public class ContactAppService : CrudAppService<Contact, ContactDto, Guid, PagedAndSortedResultRequestDto, CreateContactDto, UpdateContactDto>,
    IContactAppService
{
    protected override string GetPolicyName { get; set; } = AddressBookPermissions.Contact.Default;
    protected override string GetListPolicyName { get; set; } = AddressBookPermissions.Contact.Default;
    protected override string CreatePolicyName { get; set; } = AddressBookPermissions.Contact.Create;
    protected override string UpdatePolicyName { get; set; } = AddressBookPermissions.Contact.Update;
    protected override string DeletePolicyName { get; set; } = AddressBookPermissions.Contact.Delete;

    private readonly IContactRepository _repository;

    public ContactAppService(IContactRepository repository) : base(repository) => _repository = repository;


}
