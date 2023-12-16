using Microsoft.EntityFrameworkCore;
using MvcPlato.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configurar la base de datos (SQLite - ApplicationDbContext)
ConfigureSqlite<ApplicationDbContext>(builder, "ApplicationDbContext");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

// Método de configuración para cada contexto de base de datos con SQLite
void ConfigureSqlite<TContext>(WebApplicationBuilder builder, string contextName)
    where TContext : DbContext
{
    builder.Services.AddDbContext<TContext>(options =>
    {
        options.UseSqlite(builder.Configuration.GetConnectionString(contextName));
    });
}