using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using HamburguesasTienda.Services;

public class FakeStoreController : Controller
{
    private readonly FakeStoreService _fakeStoreService;

    public FakeStoreController(FakeStoreService fakeStoreService)
    {
        _fakeStoreService = fakeStoreService;
    }

    public async Task<IActionResult> Productos()
    {
        var productos = await _fakeStoreService.GetProductsAsync();
        return View(productos);
    }
}