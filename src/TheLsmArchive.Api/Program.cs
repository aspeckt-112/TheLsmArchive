using MudBlazor.Services;
using TheLsmArchive.Api.Components;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddMudServices()
    .AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app
    .UseHttpsRedirection()
    .UseAntiforgery();

app
    .MapStaticAssets();

app
    .MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(TheLsmArchive.Client._Imports).Assembly);

await app.RunAsync();