using HomePocket.Client.Services;
using HomePocket.Shared.Context;


namespace HomePocket.Client.ViewModels
{
	public class SettingsViewModel : ISettingsViewModel
	{
		public bool Notification { get; set; }
		public bool DarkTheme { get; set; }
		public long UserId { get; set; }

		private readonly UserService _userService;


		public SettingsViewModel(UserService userService)
		{
			_userService = userService;
		}
		public SettingsViewModel()
		{ }

		#region VIEWMODEL METHOD 	

		public async Task Save()
		{
			User user = this;
			await _userService.UpdateTheme(user, user.UserId);
			await _userService.UpdateNotifications(user, user.UserId);
		}
		public async Task Load()
		{
			var user = await _userService.GetProfile(10);
			LoadCurrentProfile(user);
		}
		public async Task GetProfile()
		{
			var user = await _userService.GetProfile(10);
			LoadCurrentProfile(user);

		}
		#endregion

		#region VIEWMODEL OBJECT CAST

		private void LoadCurrentProfile(SettingsViewModel settingsViewModel)
		{
			this.DarkTheme = settingsViewModel.DarkTheme;
			this.Notification = settingsViewModel.Notification;
			this.UserId = settingsViewModel.UserId;
		}



		public static implicit operator SettingsViewModel(User user)
		{
			return new SettingsViewModel
			{
				DarkTheme = user.DarkTheme == 0,
				Notification = user.Notifications == 0,
				UserId = user.UserId
			};
		}

		public static implicit operator User(SettingsViewModel settingsViewModel)
		{
			var user = new User();
			user.DarkTheme = settingsViewModel.DarkTheme ? 1 : 0;
			user.Notifications = settingsViewModel.Notification ? 1 : 0;
			user.UserId = settingsViewModel.UserId;
			return user;
		}
		#endregion

	}
}
