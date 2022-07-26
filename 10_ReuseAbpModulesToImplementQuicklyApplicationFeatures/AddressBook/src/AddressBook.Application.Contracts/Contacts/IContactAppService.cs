using System;
using AddressBook.Contacts.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AddressBook.Contacts
{
    public interface IContactAppService :
        ICrudAppService< 
            ContactDto, 
            Guid, 
            PagedAndSortedResultRequestDto,
            CreateContactDto,
            UpdateContactDto>
    {

    }
}