using System;
using Volo.Abp.Domain.Entities;

namespace AddressBook.Contacts
{
    public class Contact : AggregateRoot<Guid>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        public DateTime BirthDay { get; set; }

    protected Contact()
    {
    }

    public Contact(
        Guid id,
        string name,
        string phoneNumber,
        string address,
        int? age,
        DateTime birthDay
    ) : base(id)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Address = address;
        Age = age;
        BirthDay = birthDay;
    }
    }
}
