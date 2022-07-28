using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Contacts;
using AddressBook.Contacts.Dtos;
using AddressBook.Web.Pages.Contacts.Contact.ViewModels;

namespace AddressBook.Web.Pages.Contacts.Contact
{
    public class CreateModalModel : AddressBookPageModel
    {
        [BindProperty]
        public CreateContactViewModel ViewModel { get; set; }

        private readonly IContactAppService _service;

        public CreateModalModel(IContactAppService service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateContactViewModel, CreateContactDto>(ViewModel);
            await _service.CreateAsync(dto);
            return NoContent();
        }
    }
}