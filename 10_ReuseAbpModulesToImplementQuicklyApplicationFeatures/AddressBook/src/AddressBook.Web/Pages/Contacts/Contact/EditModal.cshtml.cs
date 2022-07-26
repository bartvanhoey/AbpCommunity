using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AddressBook.Contacts;
using AddressBook.Contacts.Dtos;
using AddressBook.Web.Pages.Contacts.Contact.ViewModels;

namespace AddressBook.Web.Pages.Contacts.Contact;

public class EditModalModel : AddressBookPageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public EditContactViewModel ViewModel { get; set; }

    private readonly IContactAppService _service;

    public EditModalModel(IContactAppService service)
    {
        _service = service;
    }

    public virtual async Task OnGetAsync()
    {
        var dto = await _service.GetAsync(Id);
        ViewModel = ObjectMapper.Map<ContactDto, EditContactViewModel>(dto);
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        var dto = ObjectMapper.Map<EditContactViewModel, UpdateContactDto>(ViewModel);
        await _service.UpdateAsync(Id, dto);
        return NoContent();
    }
}