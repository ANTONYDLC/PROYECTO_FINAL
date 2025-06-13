using HamburguesasTienda.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HamburguesasTienda.Data;

public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var anuncios = await _context.Anuncios.OrderByDescending(a => a.FechaCreacion).ToListAsync();
        return View(anuncios);
    }

    public async Task<IActionResult> Productos()
    {
        var productos = await _context.Productos.ToListAsync();
        return View(productos);
    }

    public async Task<IActionResult> EditarProducto(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var producto = await _context.Productos.FindAsync(id);

        if (producto == null)
        {
            return NotFound();
        }

        return View(producto);
    }

    [HttpPost]
    public async Task<IActionResult> EditarProducto(Producto producto)
    {
        if (!ModelState.IsValid) return View(producto);

        if (producto.Id == 0)
            _context.Add(producto);
        else
            _context.Update(producto);

        await _context.SaveChangesAsync();
        return RedirectToAction("Productos");
    }

    public async Task<IActionResult> Usuarios()
    {
        var usuarios = await _context.Usuarios.ToListAsync();
        return View(usuarios);
    }

    public IActionResult CrearAnuncio() => View();

    [HttpPost]
    public async Task<IActionResult> CrearAnuncio(Anuncio anuncio)
    {
        if (!ModelState.IsValid) return View(anuncio);
        _context.Anuncios.Add(anuncio);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }

    public IActionResult Estadisticas()
{
    var totalUsuarios = _context.Usuarios.Count();
    var totalProductos = _context.Productos.Count();
    var totalVentas = _context.Productos.Sum(p => p.Ventas);

    var productoTop = _context.Productos
        .OrderByDescending(p => p.Ventas)
        .FirstOrDefault();

    var model = new EstadisticasViewModel
    {
        TotalUsuarios = totalUsuarios,
        TotalProductos = totalProductos,
        TotalVentas = totalVentas,
        ProductoTop = productoTop
    };

    return View(model);
}


    // ✅ NUEVA ACCIÓN PARA /Admin/Panel
    public async Task<IActionResult> Panel()
    {
        var totalUsuarios = await _context.Usuarios.CountAsync();
        var totalProductos = await _context.Productos.CountAsync();
        var productoTop = await _context.Productos
            .OrderByDescending(p => p.Ventas)
            .FirstOrDefaultAsync();
        var ultimosAnuncios = await _context.Anuncios
            .OrderByDescending(a => a.FechaCreacion)
            .Take(5)
            .ToListAsync();

        ViewBag.TotalUsuarios = totalUsuarios;
        ViewBag.TotalProductos = totalProductos;
        ViewBag.ProductoTop = productoTop?.Nombre ?? "Sin ventas";
        ViewBag.UltimosAnuncios = ultimosAnuncios;

        return View();
    }
}