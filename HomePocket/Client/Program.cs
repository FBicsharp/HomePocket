using HomePocket.Client;
using HomePocket.Client.Services;
using HomePocket.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<UserService>();
builder.Services.AddSingleton<IProfileViewModel,ProfileViewModel>();
var host = builder.Build();
var profileViewModel = host.Services.GetRequiredService<IProfileViewModel>();
await profileViewModel.GetProfile();

await host.RunAsync();
