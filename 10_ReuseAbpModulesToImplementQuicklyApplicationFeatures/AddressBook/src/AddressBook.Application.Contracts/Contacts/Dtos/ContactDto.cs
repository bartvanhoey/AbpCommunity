using System;
using Volo.Abp.Application.Dtos;

namespace AddressBook.Contacts.Dtos;

[Serializable]
public class ContactDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public int? Age { get; set; }

    public DateTime BirthDay { get; set; }
}