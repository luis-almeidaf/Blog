using Blazored.LocalStorage;
using Blog.Application;
using Blog.Infrastructure;
using Blog.WebUI.Authentication;
using Blog.WebUI.Components;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider>(provider =>
    provider.GetRequiredService<CustomAuthenticationStateProvider>());
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorization();


builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();