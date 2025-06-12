using HamburguesasTienda.Models;
using Microsoft.EntityFrameworkCore;
using HamburguesasTienda.Data;



var builder = WebApplication.CreateBuilder(args);

// ✅ Configuración de la conexión a PostgreSQL (lee desde appsettings.json)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddSession();

var app = builder.Build();

// 🔐 Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}


app.UseStaticFiles(); // CSS, JS, imágenes
app.UseRouting();
app.UseSession();
app.UseAuthorization();

// ✅ Configuración de rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
