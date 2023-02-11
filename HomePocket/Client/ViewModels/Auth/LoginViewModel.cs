using HomePocket.Client.Services;
using HomePocket.Shared.Context;
using Microsoft.AspNetCore.Components;

namespace HomePocket.Client.ViewModels.Auth
{
	public class LoginViewModel : ILoginViewModel
	{
		public string EmailAddress { get; set; }
		public string Password { get; set; }
		public string Message { get; set; }

		public LoginViewModel()
		{

		}
		private readonly AuthService _authService;
		private readonly NavigationManager _navigationManager;


		public LoginViewModel(AuthService authService, NavigationManager navigationManager)
		{
			_authService = authService;
			_navigationManager = navigationManager;
		}

		public async Task Logout()
		{	
			await _authService.LogOut();
			_navigationManager.NavigateTo("/", true);
		}
		public async Task Login()
		{
			User user = this;			
			if (await _authService.LoginAsync(user))
			{
				_navigationManager.NavigateTo("/", true);
			}
			Message = "Login failed";
		}

		public static implicit operator LoginViewModel(User user)
		{
			return new LoginViewModel()
			{
				EmailAddress = user.EmailAddress,
				Password = user.Password
			};
		}
		public static implicit operator User(LoginViewModel loginViewModel)
		{
			var user = new User();
			user.FirstName = string.Empty;
			user.LastName = string.Empty;
			user.EmailAddress = loginViewModel.EmailAddress;
			user.Password = loginViewModel.Password;
			return user;
		}


	}
}
