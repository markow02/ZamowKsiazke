using ZamowKsiazke.Models;
using Microsoft.EntityFrameworkCore;
using ZamowKsiazke.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ZamowKsiazkeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZamowKsiazkeContext")
                         ?? throw new InvalidOperationException("Connection string 'ZamowKsiazkeContext' not found.")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seedowanie danych
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding the database.");
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
