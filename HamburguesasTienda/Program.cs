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

// ✅ Ejecutar Seeder del admin
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Verificar si ya hay un admin, y si no, crearlo
    if (!context.Usuarios.Any(u => u.Rol == "Admin"))
    {
        var admin = new Usuario
        {
            Nombre = "Administrador",
            Email = "admin@tienda.com",
            Contraseña = "admin123", // En desarrollo, sin encriptar
            Rol = "Admin"
        };

        context.Usuarios.Add(admin);
        context.SaveChanges();
    }
}

// ✅ Configuración de rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Inicio}/{id?}"
);

app.Run();
