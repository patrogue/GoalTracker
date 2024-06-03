using Microsoft.EntityFrameworkCore;
using GoalTracker.Application.Abstractions;
using GoalTracker.Infrastructure;
using GoalTracker.Infrastructure.Repositories;
using GoalTracker.Presentation.Components;
using MudBlazor.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.AddRazorComponents().AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddDbContext<PersonDbContext>(options => options.UseSqlite(connectionString));
builder.Services.AddScoped<IPersonRepositry, PersonRepository>();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
