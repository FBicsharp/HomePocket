namespace HomePocket.Client.ViewModels.Auth
{
	public interface ILoginViewModel
	{
        public string EmailAddress { get; set; }
        public string Password { get; set; }
		public string Message { get; set; }

		Task Login();
		Task Logout();

	}
}