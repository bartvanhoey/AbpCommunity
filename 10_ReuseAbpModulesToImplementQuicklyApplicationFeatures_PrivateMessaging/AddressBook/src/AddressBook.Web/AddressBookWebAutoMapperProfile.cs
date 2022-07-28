using AddressBook.Contacts.Dtos;
using AddressBook.Web.Pages.Contacts.Contact.ViewModels;
using AutoMapper;

namespace AddressBook.Web
{
    public class AddressBookWebAutoMapperProfile : Profile
    {
        public AddressBookWebAutoMapperProfile()
        {
            //Define your AutoMapper configuration here for the Web project.
            CreateMap<ContactDto, EditContactViewModel>();
            CreateMap<CreateContactViewModel, CreateContactDto>();
            CreateMap<EditContactViewModel, UpdateContactDto>();
        }
    }
}
