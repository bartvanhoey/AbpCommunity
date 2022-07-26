using System;

namespace AddressBook.Contacts.Dtos;

[Serializable]
public class CreateContactDto
{
    public string Name { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public int? Age { get; set; }

    public DateTime BirthDay { get; set; }
}