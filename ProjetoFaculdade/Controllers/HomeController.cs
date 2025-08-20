using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoFaculdade.Interface;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Controllers;

[Authorize(Roles = "Usuario")]
public class HomeController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public HomeController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet]
    public async Task<IActionResult> ObterUsuarios()
    {
        var usuarios = await _usuarioRepository.ObterListaUsuarios();
        return View(usuarios);
    }

    public IActionResult Privacy()
    {
        return View();
    }

}