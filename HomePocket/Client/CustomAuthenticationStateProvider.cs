using HomePocket.Client.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace HomePocket.Client
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{

		private readonly AuthService _authService;


		public CustomAuthenticationStateProvider(AuthService authService)
		{
			_authService = authService;
		}


		public async override Task<AuthenticationState> GetAuthenticationStateAsync()
		{



			var loggedUser = await _authService.GetCurrentLoggedUser();
			if (loggedUser == null || string.IsNullOrEmpty(loggedUser.EmailAddress))
				return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));

			var claim = new Claim(ClaimTypes.Name, loggedUser.EmailAddress);
			var claimsIdentity = new ClaimsIdentity(new[] { claim }, "serverAuth");
			var claimsPrinciple = new ClaimsPrincipal(claimsIdentity);
			return new AuthenticationState(claimsPrinciple);

		}
	}
}
