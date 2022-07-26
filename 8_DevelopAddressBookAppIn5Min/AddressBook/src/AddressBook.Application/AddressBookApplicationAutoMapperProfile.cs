using AddressBook.Contacts;
using AddressBook.Contacts.Dtos;
using AutoMapper;

namespace AddressBook;

public class AddressBookApplicationAutoMapperProfile : Profile
{
    public AddressBookApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Contact, ContactDto>();
        CreateMap<CreateContactDto, Contact>(MemberList.Source);
        CreateMap<UpdateContactDto, Contact>(MemberList.Source);
    }
}
