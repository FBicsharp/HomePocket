using HomePocket.Client.Services;
using HomePocket.Shared.Context;


namespace HomePocket.Client.ViewModels
{
	public class ProfileViewModel : IProfileViewModel
	{
        private readonly UserService _userService;

        // public ProfileViewModel(UserService userService)
		// {
        //     _userService = userService;
        // }
		

		public long UserId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailAddress { get; set; }
		public string Message { get; set; }

		public static implicit operator ProfileViewModel(User user)
		{
			return new ProfileViewModel
			{
				FirstName = user.FirstName,
				LastName = user.LastName,
				EmailAddress = user.EmailAddress,
				UserId = user.UserId
			};
		}

		public static implicit operator User(ProfileViewModel profileViewModel)
		{
			var user = new User();
			user.FirstName = profileViewModel.FirstName;
			user.LastName = profileViewModel.LastName;
			user.EmailAddress = profileViewModel.EmailAddress;
			user.UserId = profileViewModel.UserId;

			return user;
		}

		public async Task UpdateProfile()
		{
			// User user = this;
			// if (await _userService.UpdateProfile(user, 10))
			// {
			// }			
				Message = "Profile updated successfully";
		}

		public async Task GetProfile()
		{
			
			//this = await _userService.GetProfile(10);
			Message = "Profile loaded successfully";
		}


	}
}
