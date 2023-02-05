namespace HomePocket.Client.ViewModels
{
    public interface ISettingsViewModel
    {
        public bool Notification { get; set; }
        public bool DarkTheme { get; set; }
        public Task Save();
        public Task Load();

    }
}