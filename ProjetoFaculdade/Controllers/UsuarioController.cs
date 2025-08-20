using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        if (await _usuarioRepository.UsuarioExiste(usuario.Email))
        {
            return View(usuario);
        }

        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("ObterUsuarios", "Home");
        }
        
        await _usuarioRepository.Registrar(usuario);    
        return RedirectToAction("ObterUsuarios", "Home");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        if (User.Identity.IsAuthenticated)
        {
            return RedirectToAction("ObterUsuarios", "Home");
        }

        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        
        var usuario = await _usuarioRepository.ObterUsuario(dto.Email);

        if (usuario == null)
        {
            return View(dto);   
        }

        if (!await _usuarioRepository.UsuarioExiste(usuario.Email))
        {
            return View(dto);
        }

        if (dto.Email != usuario.Email || dto.Senha != usuario.Senha)
        {
            ModelState.AddModelError(string.Empty, "Email ou senha inválidos.");
            return View(dto);
        }

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Email, dto.Email),
            new Claim(ClaimTypes.Role, "Usuario")
        };
        
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);   
        
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        
        return RedirectToAction("ObterUsuarios", "Home");
      
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Usuario");
    }
}