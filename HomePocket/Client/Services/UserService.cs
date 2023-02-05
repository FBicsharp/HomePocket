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


        public async Task<bool> UpdateProfile(User user,long id)
        {
            
            try
            {
                var msg = await _client.PutAsJsonAsync($"user/UpdateProfile/{id}", user);
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
				user = await _client.GetFromJsonAsync<User>($"user/GetProfile/{id}");
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return user;

		}

	}
}
