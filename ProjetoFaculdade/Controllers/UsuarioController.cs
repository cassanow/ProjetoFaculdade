using Microsoft.AspNetCore.Mvc;
using ProjetoFaculdade.DTO;
using ProjetoFaculdade.Interface;
using ProjetoFaculdade.Mapper;
using ProjetoFaculdade.Models;

namespace ProjetoFaculdade.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _usuarioRepository;

    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }
    
    [HttpGet]
    public IActionResult Registrar()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registrar(Usuario usuario)
    {
        return View(usuario);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var usuario = MapeamentoUsuario.ToUsuario(dto);
        
        
        return View(dto);
    }
}