using HomePocket.Client.ViewModels;

namespace HomePocket.Client.ViewModels
{
    public interface IContactsViewModel
    {
       
        public List<Contact> Contacts { get; set; }
        public Task GetContacts();

    }
}