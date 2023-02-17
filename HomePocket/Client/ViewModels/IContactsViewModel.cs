using HomePocket.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web.Virtualization;

namespace HomePocket.Client.ViewModels
{
    public interface IContactsViewModel
    {

        public List<Contact> Contacts { get; set; }
        public List<Contact> ContactsFiltered { get; set; }
        public string Filter { get; set; }
        public Task GetContacts();
        public Task SearchContacts();

		public ValueTask<ItemsProviderResult<Contact>> GetVisibleContacts(ItemsProviderRequest itemsProviderRequest);

	}
}