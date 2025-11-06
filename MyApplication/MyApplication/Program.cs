using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using BusinessLayer.Services.StateServices;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using DataAccessLayer.Repositories;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.Configuration.Json;
using MudBlazor.Services;
using MyApplication.Components;
using System;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add MudBlazor services
builder.Services.AddMudServices();

//services
builder.Services.AddScoped<IVozilaService, VozilaService>();
builder.Services.AddScoped<IIzdajeService, IzdajeService>();
builder.Services.AddScoped<SaveUrlService>();
builder.Services.AddScoped<IVoznikiService, VoznikiService>();
builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<UserState>();
builder.Services.AddScoped<IUporabnikService, UporabnikService>();
builder.Services.AddScoped<IClientService, ClientService>();

//repositories
builder.Services.AddScoped<IVrstePlinaRepostiory, VrstePlinaRepository>();
builder.Services.AddScoped<IVozilaRepository, VozilaRepository>();
builder.Services.AddScoped<IVoznikiRepository, VoznikiRepository>();
builder.Services.AddScoped<IIzdajeRepository, IzdajeRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IUporabnikiRepository, UporabnikiRepository>();

builder.Services.AddHttpContextAccessor();


// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContextFactory<BohovaContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ConnectionString") ??
        throw new InvalidOperationException(
            "Connection string 'BlazorWebAppMoviesContext' not found.")));

//builder.Services.AddAntiforgery(options => { options.Cookie.Name = "X-CSRF-TOKEN"; options.Cookie.SameSite = SameSiteMode.None; options.Cookie.SecurePolicy = CookieSecurePolicy.Always; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
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

//EF cmd:
//Scaffold-DbContext "Data Source=localhost\SQLEXPRESS;Database=Bohova;Trusted_Connection=False;TrustServerCertificate=True;User Id=sa;Password=Welcome!1" Microsoft.EntityFrameworkCore.SqlServer -Project DataAccessLayer -StartupProject MyApplication -OutputDir Models -Context BohovaContext -Force