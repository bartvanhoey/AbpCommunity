using System;
using System.ComponentModel.DataAnnotations;

namespace AddressBook.Web.Pages.Contacts.Contact.ViewModels
{
    public class EditContactViewModel
    {
        [Display(Name = "ContactName")]
        public string Name { get; set; }

        [Display(Name = "ContactPhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "ContactAddress")]
        public string Address { get; set; }

        [Display(Name = "ContactAge")]
        public int? Age { get; set; }

        [Display(Name = "ContactBirthDay")]
        public DateTime BirthDay { get; set; }
    }
}
