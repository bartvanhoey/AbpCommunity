using System.Threading.Tasks;

namespace AddressBook.Web.Pages.Contacts.Contact
{
    public class IndexModel : AddressBookPageModel
    {
        public virtual async Task OnGetAsync()
        {
            await Task.CompletedTask;
        }
    }
}
