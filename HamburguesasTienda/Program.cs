using HamburguesasTienda.Models;
using Microsoft.EntityFrameworkCore;
using HamburguesasTienda.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;

using HamburguesasTienda.Services;


var builder = WebApplication.CreateBuilder(args);

// ✅ Configuración de la conexión a PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<FakeStoreService>();
builder.Services.AddHttpClient<OpenWeatherService>();



builder.Services.AddSession();

// ✅ Configurar políticas de cookies para compatibilidad con autenticación externa
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => false;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// ✅ Configurar cookies de autenticación
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.None;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
});

// ✅ Agregar autenticación con Google
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
})
.AddCookie()
.AddGoogle(options =>
{
    options.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
});

var app = builder.Build();

// 🔐 Configuración del pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection(); // Asegura HTTPS
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy(); // 👈 Importante para autenticación externa
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

// ✅ Ejecutar Seeder del admin
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!context.Usuarios.Any(u => u.Rol == "Admin"))
    {
        var admin = new Usuario
        {
            Nombre = "Administrador",
            Email = "admin@tienda.com",
            Contraseña = "admin123",
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
