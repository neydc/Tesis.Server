using BlazorCrud.Cliente;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using BlazorCrud.Cliente.Services;
using CurrieTechnologies.Razor.SweetAlert2;

//Login 
using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorCrud.Cliente.ExtensionesLogin;
using System.Security.Authentication;
//

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5045") });

builder.Services.AddSweetAlert2();

builder.Services.AddScoped<IMascotaService,MascotaService>();
builder.Services.AddScoped<IClienteService,ClienteService>();

//Login 
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddAuthorizationCore();
//

await builder.Build().RunAsync();
