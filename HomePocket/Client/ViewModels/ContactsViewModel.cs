using HomePocket.Client.Services;
using HomePocket.Shared.Context;

namespace HomePocket.Client.ViewModels
{
    public class ContactsViewModel : IContactsViewModel
    {
        public List<Contact> Contacts { get; set; }
        public List<Contact> ContactsFiltered { get; set; }
        public string Filter { get; set; }
        
        private HttpClient _httpClient;

        //methods
        public ContactsViewModel()
        {
            
        }
        private readonly UserService _userService;


        public ContactsViewModel(UserService userService)
        {
            _userService = userService;
        }



        public async Task SearchContacts()
        {
           ContactsFiltered = this.Contacts.Where(c=>c.FirstName.Contains(Filter,StringComparison.CurrentCultureIgnoreCase) || c.LastName.Contains(Filter,StringComparison.CurrentCultureIgnoreCase)).ToList();
        }

        public async Task GetContacts()
        {
            List<User> users = await _userService.GetAllUser();
            LoadCurrentObject(users);
        }

        private void LoadCurrentObject(List<User> users)
        {
            this.Contacts = new List<Contact>();
            foreach (User user in users)
            {
                this.Contacts.Add(user);
            }
        }

    }
}
