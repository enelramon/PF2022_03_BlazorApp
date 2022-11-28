using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using PF2022_03_BlazorApp.DAL;
using PF2022_03_BlazorApp.BLL;
using Radzen;
using BlazorStrap;
using PF2022_03_BlazorApp.ViewModels;

var builder = WebApplication.CreateBuilder(args);

var ConStr = builder.Configuration.GetConnectionString("ConStr");

builder.Services.AddDbContext<Contexto>(Options =>
    Options.UseSqlite(ConStr)
);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorStrap();

builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<ClientesBLL>();
builder.Services.AddScoped<PrioridadesBLL>();
builder.Services.AddScoped<TicketsBLL>();
builder.Services.AddScoped<RecordatoriosBLL>();
builder.Services.AddScoped<SistemasBLL>();
builder.Services.AddScoped<TecnicosBLL>();

builder.Services.AddScoped<ICounterViewModel, CounterViewModel>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
