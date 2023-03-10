using HomePocket.Client;
using HomePocket.Client.Services;
using HomePocket.Client.ViewModels;
using HomePocket.Client.ViewModels.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();


builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();

builder.Services.AddScoped<IProfileViewModel,ProfileViewModel>();
builder.Services.AddScoped<ISettingsViewModel,SettingsViewModel>();
builder.Services.AddScoped<IContactsViewModel,ContactsViewModel>();
builder.Services.AddScoped<ILoginViewModel, LoginViewModel>();


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


await builder.Build().RunAsync();
