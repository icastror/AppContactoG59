using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AppContactosG59.Data; // 1 Instruccion
using AppContactosG59.Models; // 2 Instruccion
using Microsoft.EntityFrameworkCore; // 3 Instruccion

namespace AppContactosG59.Controllers;

public class HomeController : Controller
{
    private readonly AppDBContext _contexto; // 4 Instruccion

    public HomeController(AppDBContext contexto) // 5 Instruccion
    {
        _contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Index() // 6 Instruccion
    {
        return View(await _contexto.Contacto.ToListAsync());
    }   

    public IActionResult Crear() // 7 Instruccion
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Crear(Contacto contacto) // 7 Instruccion
    {
        if (ModelState.IsValid)
        {
            _contexto.Contacto.Add(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View();
    }


    ///  ----  ////

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
