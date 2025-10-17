using BlazorNotesApp.Data;
using BlazorNotesApp.Repositories;
using BlazorNotesApp.Repositories.Interfaces;
using BlazorNotesApp.Services;
using BlazorNotesApp.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.Configure<RazorPagesOptions>(options => options.RootDirectory = "/Components/Pages");


// This tells the program to use the connection string from appsetting.json, in my case it is my localDb
builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add repositories & services to builder
builder.Services.AddScoped<INoteRepository, NoteRepository>();
builder.Services.AddScoped<INoteService, NoteService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
Console.WriteLine($"Base directory: {AppContext.BaseDirectory}");
Console.WriteLine($"Host file exists: {File.Exists(Path.Combine(AppContext.BaseDirectory, "Pages", "_Host.cshtml"))}");

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");


app.Run();