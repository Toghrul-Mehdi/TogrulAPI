using Microsoft.EntityFrameworkCore;
using TogrulAPI.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



var app = builder.Build();

builder.Services.AddDbContext<TogrulDB>(s => s.UseSqlServer(builder.Configuration.GetConnectionString("Mssql")));

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
