using HomePocket.Client.ViewModels;
using HomePocket.Shared.Context;
using System.Net.Http.Json;

namespace HomePocket.Client.Services
{
	public class AuthService
	{
		private readonly HttpClient _client;

		public AuthService(HttpClient client)
		{
			_client = client;
		}



		public async Task<bool> LogOut()
		{
			try
			{
				var msg = await _client.GetAsync($"Auth/LogOutUser");
				if (msg.IsSuccessStatusCode)
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return false;

		}

		public async Task<bool> LoginAsync(User user)
		{
			try
			{
				var msg = await _client.PostAsJsonAsync<User>($"Auth/LoginUser", user);
				if (msg.IsSuccessStatusCode)
				{
					return true;
				}
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return false;

		}

		
		public async Task<User> GetCurrentLoggedUser()
		{
			User user = null;
			try
			{
				user = await _client.GetFromJsonAsync<User>($"Auth/GetCurrentUser");				
			}
			catch (Exception ex)
			{
				await Console.Out.WriteLineAsync(ex.Message);
			}
			return user;
		}
	}
}
