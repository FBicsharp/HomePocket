using HomePocket.Client.ViewModels;
using HomePocket.Shared.Context;
using System.Net.Http.Json;

namespace HomePocket.Client.Services
{
    public class UserService
    {
        private readonly HttpClient _client;

        public UserService(HttpClient client)
        {
            _client = client;
        }



        public async Task<bool> UpdateTheme(User user,long id)
        {
            
            try
            {
                var msg = await _client.PutAsJsonAsync($"User/UpdateTheme/{id}", user.DarkTheme);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);                
                return false;
            }
            return true;
            
        }


        public async Task<bool> UpdateNotifications(User user,long id)
        {
            
            try
            {
                var msg = await _client.PutAsJsonAsync($"User/UpdateNotifications/{id}", user.Notifications);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);                
                return false;
            }
            return true;
            
        }

        public async Task<bool> UpdateProfile(User user,long id)
        {
            
            try
            {
                var msg = await _client.PutAsJsonAsync($"User/UpdateProfile/{id}", user);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);                
                return false;
            }
            return true;
            
        }

		public async Task<User> GetProfile( long id)
		{
            var user = new User();
			try
			{
				user = await _client.GetFromJsonAsync<User>($"User/GetProfile/{id}");
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return user;

		}

        public async Task<List<User>> GetAllUser()
        {
             
            var userlist = new List<User>();
			try
			{
				userlist = await _client.GetFromJsonAsync<List<User>>($"User");
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return userlist;
        }
		public async Task<List<User>> GetVisibleUser(int startsIndex, int count)
		{

			var userlist = new List<User>();
			try
			{
				userlist = await _client.GetFromJsonAsync<List<User>>($"User/GetVisibleUser?startsIndex={startsIndex}&count={count}");
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return userlist;
		}
	}
}
