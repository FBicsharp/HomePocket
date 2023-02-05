using HomePocket.Client.Services;
using HomePocket.Shared.Context;


namespace HomePocket.Client.ViewModels
{
    public class ProfileViewModel : IProfileViewModel
    {
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Message { get; set; }

        private readonly UserService _userService;


        public ProfileViewModel(UserService userService)
        {
            _userService = userService;
        }
        public ProfileViewModel()
        { }

	#region VIEWMODEL METHOD 	

        public async Task UpdateProfile()
        {
            User user = this;
            if (await _userService.UpdateProfile(user, user.UserId))
            {
                Message = "Profile updated successfully";
            }
        }

        public async Task GetProfile()
        {
            var user = await _userService.GetProfile(10);
            LoadCurrentProfile(user);
            Message = "Profile loaded successfully";
        }
	#endregion

	#region VIEWMODEL OBJECT CAST

        private void LoadCurrentProfile(ProfileViewModel profileViewModel)
        {
            this.FirstName = profileViewModel.FirstName;
            this.LastName = profileViewModel.LastName;
            this.EmailAddress = profileViewModel.EmailAddress;
            this.UserId = profileViewModel.UserId;
        }
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
	#endregion

    }
}
