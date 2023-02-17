using HomePocket.Client.Services;
using HomePocket.Shared.Context;
using Microsoft.AspNetCore.Components.Web.Virtualization;

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

		public async ValueTask<ItemsProviderResult<Contact>> GetVisibleContacts(ItemsProviderRequest itemsProviderRequest)
		{
            Console.WriteLine("Start Index "+itemsProviderRequest.StartIndex);
            Console.WriteLine("Count "+ itemsProviderRequest.Count);
			Console.WriteLine("start request" + DateTime.Now.ToString("hh:mm:ss:fff"));
			List<User> users = await _userService.GetVisibleUser(itemsProviderRequest.StartIndex, itemsProviderRequest.Count);			
			Console.WriteLine("Converting obj " + DateTime.Now.ToString("hh:mm:ss:fff"));
			LoadCurrentObject(users);
			Console.WriteLine("end" + DateTime.Now.ToString("hh:mm:ss:fff"));
			return new ItemsProviderResult<Contact>(this.Contacts, 20000 );

		}
	}
}
